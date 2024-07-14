#include <Wire.h> // thu vien giao tiep i2c
#include "Kalman.h"//https://github.com/TKJElectronics/KalmanFilter 

#define ToRad PI/180 // change degree to rad
#define ToDeg 180/PI // change rad to degree

Kalman kalman;  //Kalman filter define: kalman.getAngle(pitch, gyrorate, dt); 

#define factortheta PI/20  // The theta setpoint value change ever 7ms if control 
#define factorphi PI/180   // The Phi setpoint value change ever 7ms if control 

uint32_t timerloop, timerold; // set sampling time 

//Motor control Pin// 
int leftpwm = 10;   //Control pwm left motor //9
int leftdir = 32;  //Control direction left motor 
int leftdir2 = 31; //Control direction left motor 
int righpwm = 9;  //Control pwm right motor //10
int righdir = 30;  //Control direction right motor; 
int righdir2 = 29; //Control direction right motor 

float leftencoder;  //read left encoder value 
float righencoder;  //read right encoder value 

int leftencoder_a = 2;  // Read state encoder channel LOW or HIGH 
int leftencoder_b = 12; 
int righencoder_a = 3; 
int righencoder_b = 13; 

//MPU6050 Data// 
double mpudata; //Save psi angle ( Y axis) 
double accX, accZ; 
float GyroY; 
float error=-0.85; //error between mpudata and the angle you want (0 degree)

uint32_t timer; //Timer for kalman filter psi angle; 
uint8_t i2cData[14]; 

//LQR data// 
long PWML, PWMR; // PWM output for H-Brigde 

float k1, k2, k3, k4, k5, k6; // The factor of K maxtrix 

bool falldown;// Run = true; Stop  = false; 

float theta, psi, phi; 
float thetadot, psidot, phidot; 
float thetaold = 0, psiold = 0, phiold = 0; 

float leftvolt; //output volt left motor in LQR 
float righvolt; //output volt right motor in lQR 

float addtheta;//Save setpoint value 
float addphi;  //Save setpoint value 

int ForwardBack;// 1 -> Forward;   -1 -> Back;      0 -> Stop And Balancing 
int LeftRight;  // 1 -> Turnleft;  -1 -> TurnRight  0 -> Stop And Balancing 

///////////////////////////////////////////////// 
///////////    SERIAL BEGIN   /////////////////// 
///////////////////////////////////////////////// 
void setup() { 
  Serial.begin(115200); 
  Serial3.begin(115200); //Serial connect to blutooth send data to pc and plot graph 

  k1 = 0.7;  //k1*theta 
  k2 = 7;  //2*thetadot 
  k3 = 355; //k3*psi 
  k4 = 28.04;  //k4*psidot 
  k5 = 6;   //k5*phi
  k6 = 0.3;   //k6*phidot 
  
  //Set state control motor begin 
  ForwardBack = 0; 
  LeftRight = 0; 
  
  //Set zero setpoint value 
  addphi = 0; 
  addtheta = 0; 
  
  //SET PWM FREQUENCY 31 kHz  
  TCCR2B = TCCR2B & B11111000 | B00000001; // for PWM frequency of 31kHz; //Pin 9 & Pin 10 (https://arduino info.wikispaces.com/Arduino-PWM-Frequency) 
  
  //Output pin control motor left and right// 
  pinMode(leftpwm, OUTPUT); 
  pinMode(righpwm, OUTPUT); 
  pinMode(leftdir, OUTPUT); 
  pinMode(righdir, OUTPUT); 
  pinMode(leftdir2, OUTPUT); 
  pinMode(righdir2, OUTPUT); 
  
  //Input pin read encoder// 
  pinMode(leftencoder_a, INPUT_PULLUP); 
  pinMode(leftencoder_b, INPUT_PULLUP); 
  pinMode(righencoder_a, INPUT_PULLUP); 
  pinMode(righencoder_b, INPUT_PULLUP); 
  
  //interrupt encoder// 
  attachInterrupt(0, left_isr, RISING); 
  attachInterrupt(1, righ_isr, RISING); 
  
  //Data MPU6050// 
  Wire.begin(); 
  TWBR = ((F_CPU/400000L) - 16)/2; 
  i2cData[0] = 7; 
  i2cData[1] = 0x00; 
  i2cData[2] = 0x00; 
  i2cData[3] = 0x00; 
  while (i2cWrite(0x19, i2cData, 4, false)); 
  while (i2cWrite(0x6B, 0x01, true)); 
  while (i2cRead(0x75, i2cData, 1)); 
  if (i2cData[0] != 0x68) { 
    Serial.print(F("Error reading sensor")); 
    while (1);  
  } 
  delay(10); 
  
  while (i2cRead(0x3B, i2cData, 6)); 
  accX = (i2cData[0] << 8) | i2cData[1]; 
  accZ = (i2cData[4] << 8) | i2cData[5]; 
  double pitch = atan2(-accX, accZ)*RAD_TO_DEG; 
  kalman.setAngle(pitch); 
  kalman.setQangle(0.0000085); 
  kalman.setQbias(0.000005); 
  kalman.setRmeasure(0.0009); 
  timer = micros();
} 
////////////////////////////////// 
//       MAIN PROGRAMMING   
////////////////////////////////// 
void loop() { 
  readmpu(); 
  //Serial.println(mpudata); 
  if((micros() - timerloop) > 6000) {//Set time loop update and control motor 
    theta = (0.545454*(leftencoder+righencoder))*ToRad; //Read theta value and convert to Rad 
    psi = (mpudata+error)*ToRad;                     
   //Read psi value and convert to Rad 
    phi =  (0.22159*(leftencoder-righencoder))*ToRad;     //Read phi value and convert to Rad 
  
    //Update time compare with timeloop 
    double dt = (float)(micros() - timerloop)/1000000.0; 
    timerloop = micros(); 
  
    //Update input angle value 
     thetadot = (theta - thetaold)/dt; 
     psidot = (psi)/dt; 
     phidot = (phi - phiold)/dt; 
  
     //Upadte old angle value 
     thetaold = theta; 
     psiold = psi; 
     phiold = phi; 
  
    // 
    addtheta = addtheta + ForwardBack*factortheta; 
    addphi = addphi + LeftRight*factorphi; 
    
    getlqr(theta + addtheta, thetadot, psi, psidot, phi + addphi, phidot); 
    motorcontrol(PWML, PWMR,(mpudata+error), falldown); 
    
    //Serial.println(mpudata+error); 
    //Serial.println(leftencoder);
    //Serial.println(righencoder);
    //send data to serial3
    //string s will send data form arduino to pc can catch data excatly by one
    //after that the
    String S = "";
    S = (String)(psi*ToDeg)+','+(String)(theta*ToDeg)+','+(String)(phi*ToDeg)+','+(String)(-addtheta*ToDeg)+','+(String)(-addphi*ToDeg);   
    Serial.println(S);
    Serial3.println(S);
  }
} 

//left motor encoder interrupt// 
void left_isr() { 
  if(digitalRead(leftencoder_b)) { 
    leftencoder++;  } 
  else { 
    leftencoder--;  } 
  } 
//right motor encoder interrupt// 
void righ_isr() { 
  if(digitalRead(righencoder_b)) { 
    righencoder++;  } 
  else { 
    righencoder--;  } 
  } 

//Read psi// 
void readmpu() {
  while (i2cRead(0x3B, i2cData, 14));
  accX = (int16_t)((i2cData[0] << 8) | i2cData[1]);
  accZ = (int16_t)((i2cData[4] << 8) | i2cData[5]);
  GyroY = (int16_t)((i2cData[10] << 8) | i2cData[11]);  //gia toc goc cua truc y

  double dt = (double)(micros() - timer)/1000000;  //tính toán tgian đọc cho tới khi nhận đc kết quả
  timer = micros();
  
  double pitch = (atan2(-accX, accZ))*RAD_TO_DEG;  //gia tri goc nghieng y tren cam bien
  double GyroYrate = GyroY/131.0;
 
  mpudata = kalman.getAngle(pitch, GyroYrate, dt);  //loc gia tri goc do goc do dc từ cảm biến thường bị nhiễu

  if (abs(mpudata+error) > 20) {
    falldown = true;
  } 
  else {
    falldown = false;
  }
  //Serial.println(mpudata);
}
//LQR function// 
void getlqr(float theta_, float thetadot_, float psi_, float psidot_, float phi_, float phidot_) { 
  
  leftvolt = k1*theta_ + k2*thetadot_ + k3*psi_ + k4*psidot_ - k5*phi_ - k6*phidot_; 
  righvolt = k1*theta_ + k2*thetadot_ + k3*psi_ + k4*psidot_ + k5*phi_ + k6*phidot_; 
  
  PWML = map(leftvolt, -(k3*PI)/15, (k3*PI)/15, -255, 255);//Limit 20 deg. 
  PWMR = map(righvolt, -(k3*PI)/15, (k3*PI)/15, -255, 255); 
  
  PWML = constrain(PWML, -250, 250);//limit pwm value in (-250, 250)  
  PWMR = constrain(PWMR, -250, 250);
} 

//Motor control function// 
void motorcontrol(long lpwm, long rpwm, float angle, bool stopstate) {
  if (abs(angle) > 20) {
    stopandreset();
  } 
  else {
    if (leftvolt > 0) {
      leftmotor(abs(lpwm), 1);  //Forward
    } 
    else if (leftvolt < 0) {
      leftmotor(abs(lpwm), 0);  //Back
    } 
    else {
      stopandreset();
    }
    //
    if (righvolt > 0) {
      righmotor(abs(rpwm), 1);
    } 
    else if (righvolt < 0) {
      righmotor(abs(rpwm), 0);
    } 
    else {
      stopandreset();
    }
  }
}

//Stop motor and reset data 
void stopandreset() //The data angle and encoder will be reset back to zero. 
{ 
  analogWrite(leftpwm, 0); 
  digitalWrite(leftdir, LOW); 
  digitalWrite(leftdir2, LOW); 
  analogWrite(righpwm, 0); 
  digitalWrite(righdir, LOW); 
  digitalWrite(righdir2, LOW); 

  //Reset default place// 
  leftencoder = 0; 
  righencoder = 0; 
  
  //Reset zero setpoint 
  addtheta = 0; 
  addphi = 0;
} 

//Control left motor 
void leftmotor(uint8_t lpwm, int direct) { 
  analogWrite(leftpwm, lpwm); 
  if (direct == 1) { //angle > 0 
    digitalWrite(leftdir, LOW); 
    digitalWrite(leftdir2, HIGH);  
  } 
  else { 
    digitalWrite(leftdir, HIGH); 
    digitalWrite(leftdir2, LOW);  
  } 
} 

//Control right motor 
void righmotor(uint8_t rpwm, int direct) { 
  analogWrite(righpwm, rpwm); 
  if (direct == 1) { //angle > 0 
    digitalWrite(righdir, LOW); 
    digitalWrite(righdir2, HIGH);  
    } 
  else { 
    digitalWrite(righdir, HIGH); 
    digitalWrite(righdir2, LOW);  
    } 
} 
