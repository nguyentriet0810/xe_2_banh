using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;
using System.IO.Ports;

namespace App_Test
{
    public partial class Form1 : Form
    {
        //input data receive from serialport
        string sttheta;
        string stpsi;
        string stphi;
        string staddtheta;
        string staddphi;
        //data bit button control sen statement to bluetooth
        int w, a, s, d;
        //
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectBT_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPorts.Text != "")
                {
                    if (cbBaud.Text != "")
                    {
                        serialPort1.PortName = cbPorts.Text;
                        serialPort1.BaudRate = Convert.ToInt32(cbBaud.Text);
                        serialPort1.Parity = Parity.None;
                        serialPort1.StopBits = StopBits.One;
                        serialPort1.DataBits = 8;
                        serialPort1.Handshake = Handshake.None;
                        serialPort1.RtsEnable = true;

                        if (serialPort1.IsOpen) return;
                        serialPort1.Open();
                        ConnectBT.Enabled = false;
                        DisconnectBT.Enabled = true;
                        //
                        ForwardBT.Enabled = true;
                        BackwardBT.Enabled = true;
                        LeftBT.Enabled = true;
                        RightBT.Enabled = true;
                        StopBT.Enabled = true;

                        cbBaud.Enabled = false;
                        cbPorts.Enabled = false;

                        ExitBT.Enabled = false;
                    }
                    else
                        return;
                }
                else
                    return;
            }
            catch
            {
                return;
            } 
            
        }

        //Connect Button//
        private void DisconnectBT_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen == false) return;
                serialPort1.Close();
                ConnectBT.Enabled = true;
                DisconnectBT.Enabled = false;
                //
                ForwardBT.Enabled = false;
                BackwardBT.Enabled = false;
                LeftBT.Enabled = false;
                RightBT.Enabled = false;
                StopBT.Enabled = false;

                cbBaud.Enabled = true;
                cbPorts.Enabled = true;

                ExitBT.Enabled = true;
            }
            catch
            {
                return;
            }
        }

        //Serial data receive//
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //split data receive from serialport
                string[] arrList = serialPort1.ReadLine().Split(',');
                stpsi = arrList[0];// Psi value.
                sttheta = arrList[1];// Theta value.
                stphi = arrList[2];// Phi value.
                staddtheta = arrList[3];// Theta setpoint value.
                staddphi = arrList[4];// Phi setpoint value.
            }
            catch
            {
                return;
            }
        }

        int intlen = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ConnectBT.Enabled == false)
            {
                Draw(stpsi, sttheta, stphi, staddtheta, staddphi);
                //display value on graph
                // text color and value
                lblpsi.ForeColor = Color.Blue;
                lblpsi.Text = stpsi;

                lbltheta.ForeColor = Color.Blue;
                lbltheta.Text = sttheta;

                lblphi.ForeColor = Color.Blue;
                lblphi.Text = stphi;

                lblstheta.ForeColor = Color.Red;
                lblstheta.Text = staddtheta;

                lblsphi.ForeColor = Color.Red;
                lblsphi.Text = staddphi;
            }
            //auto detect COM port//
            string[] ports = SerialPort.GetPortNames();
            if (intlen != ports.Length)
            {
                intlen = ports.Length;
                cbPorts.Items.Clear();
                for (int j = 0; j < intlen; j++)
                {
                    cbPorts.Items.Add(ports[j]);
                }
            }
        }
        //
        int TickStart1;
        int TickStart2;
        int TickStart3;
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            cbBaud.Enabled = true;
            cbPorts.Enabled = true;
            //Disable button control
            ForwardBT.Enabled = false;
            BackwardBT.Enabled = false;
            LeftBT.Enabled = false;
            RightBT.Enabled = false;
            StopBT.Enabled = false;

            //Load value//
            cbBaud.Items.Add(9600);
            cbBaud.Items.Add(19200);
            cbBaud.Items.Add(38400);
            cbBaud.Items.Add(57600);
            cbBaud.Items.Add(74880);
            cbBaud.Items.Add(115200);
            cbBaud.Items.Add(230400);
            cbBaud.Items.Add(250000);
            //
            DisconnectBT.Enabled = false;

            //Show contents of graph
            //Name graph
            //Value x,y axis..
            GraphPane myPane1 = zedGraph1.GraphPane;
            myPane1.Title.Text = "Psi Graph";
            myPane1.XAxis.Title.Text = "Time, Seconds";
            myPane1.YAxis.Title.Text = "Angle, Deg";

            RollingPointPairList list1 = new RollingPointPairList(60000);
            LineItem Curve1 = myPane1.AddCurve("Psi Value", list1, Color.Blue, SymbolType.None);

            myPane1.XAxis.Scale.Min = 0;
            myPane1.XAxis.Scale.Max = 10;
            myPane1.YAxis.Scale.Min = -10;
            myPane1.YAxis.Scale.Max = 10;

            zedGraph1.AxisChange();
            TickStart1 = Environment.TickCount;

            /*Display the graph 2 of contents*/
            //Psidot graph//
            GraphPane myPane2 = zedGraph2.GraphPane;
            myPane2.Title.Text = "Theta Graph";
            myPane2.XAxis.Title.Text = "Time, Seconds";
            myPane2.YAxis.Title.Text = "Angle, Deg";

            RollingPointPairList list2 = new RollingPointPairList(60000);
            LineItem Curve2 = myPane2.AddCurve("Theta Value", list2, Color.Blue, SymbolType.None);
            //
            RollingPointPairList list2_ = new RollingPointPairList(60000);
            LineItem Curve2_ = myPane2.AddCurve("Setpoint", list2_, Color.Red, SymbolType.None);

            myPane2.XAxis.Scale.Min = 0;
            myPane2.XAxis.Scale.Max = 10;
            myPane2.YAxis.Scale.Min = -540;
            myPane2.YAxis.Scale.Max = 540;

            zedGraph2.AxisChange();
            TickStart2 = Environment.TickCount;

            /*Display the graph 3 of contents*/
            //Theta graph//
            GraphPane myPane3 = zedGraph3.GraphPane;
            myPane3.Title.Text = "Phi Graph";//Ten do thi
            myPane3.XAxis.Title.Text = "Time, Seconds";//Noi dung truc X
            myPane3.YAxis.Title.Text = "Angle, Deg";//Noi dung truc Y

            RollingPointPairList list3 = new RollingPointPairList(60000);//So diem hien thi tren do thi
            LineItem Curve3 = myPane3.AddCurve("Phi Vallue", list3, Color.Blue, SymbolType.None);//Chon mau cho net ve

            RollingPointPairList list3_ = new RollingPointPairList(60000);//So diem hien thi tren do thi
            LineItem Curve3_ = myPane3.AddCurve("Setpoint", list3_, Color.Red, SymbolType.None);//Chon mau cho net ve

            myPane3.XAxis.Scale.Min = 0;//Gia tri nho nhat cua truc X
            myPane3.XAxis.Scale.Max = 10;//Gia tri lon nhat cua truc X
            myPane3.YAxis.Scale.Min = -120;//Gia tri nho nhat cua truc Y
            myPane3.YAxis.Scale.Max = 120;//Gia tri lon nhat cua truc Y

            zedGraph3.AxisChange();//Tu do Scroll do thi
            TickStart3 = Environment.TickCount;
        }
        //Draw line in the zedgraph using string data    //
        //receive from serialport convert to double value//

        private void Draw(string inpsi, string intheta, string inphi, string inaddtheta, string inaddphi)
        {
            double _psi;
            double _theta;
            double _phi;
            double _addtheta;
            double _addphi;

            double.TryParse(inpsi, out _psi);//Conver tring to double//
            double.TryParse(intheta, out _theta);//Conver tring to double//
            double.TryParse(inphi, out _phi);//Conver tring to double//
            double.TryParse(inaddtheta, out _addtheta);
            double.TryParse(inaddphi, out _addphi);

            //Error color text
            lblphierror.ForeColor = Color.Blue;
            lblthetaerror.ForeColor = Color.Blue;
            //Error value update...
            lblthetaerror.Text = Math.Round((Math.Abs(_theta) - Math.Abs(_addtheta)), 2).ToString();
            lblphierror.Text = Math.Round((Math.Abs(_phi) - Math.Abs(_addphi)), 2).ToString();

            if (zedGraph1.GraphPane.CurveList.Count <= 0)
                return;
            if (zedGraph2.GraphPane.CurveList.Count <= 0)
                return;
            if (zedGraph3.GraphPane.CurveList.Count <= 0)
                return;

            LineItem curve1 = zedGraph1.GraphPane.CurveList[0] as LineItem;
            LineItem curve2 = zedGraph2.GraphPane.CurveList[0] as LineItem;
            LineItem curve3 = zedGraph3.GraphPane.CurveList[0] as LineItem;

            LineItem curve2_ = zedGraph2.GraphPane.CurveList[1] as LineItem;// SetPoint Curve Theta
            LineItem curve3_ = zedGraph3.GraphPane.CurveList[1] as LineItem;// SetPoint Curve Phi

            if (curve1 == null)
                return;
            if (curve2 == null)
                return;
            if (curve3 == null)
                return;
            if (curve2_ == null)
                return;
            if (curve3_ == null)
                return;

            //
            IPointListEdit list1 = curve1.Points as IPointListEdit;
            IPointListEdit list2 = curve2.Points as IPointListEdit;
            IPointListEdit list3 = curve3.Points as IPointListEdit;
            //
            IPointListEdit list2_ = curve2_.Points as IPointListEdit;
            IPointListEdit list3_ = curve3_.Points as IPointListEdit;

            //
            if (list1 == null)
                return;
            if (list2 == null)
                return;
            if (list3 == null)
                return;
            //
            if (list2_ == null)
                return;
            if (list3_ == null)
                return;

            //
            double time1 = (Environment.TickCount - TickStart1) / 1000.0;
            double time2 = (Environment.TickCount - TickStart2) / 1000.0;
            double time3 = (Environment.TickCount - TickStart3) / 1000.0;

            //
            list1.Add(time1, _psi);
            list2.Add(time2, _theta);
            list3.Add(time3, _phi);
            //
            list2_.Add(time2, (_addtheta));
            list3_.Add(time3, (_addphi));

            //
            Scale xScale1 = zedGraph1.GraphPane.XAxis.Scale;
            Scale xScale2 = zedGraph2.GraphPane.XAxis.Scale;
            Scale xScale3 = zedGraph3.GraphPane.XAxis.Scale;

            //
            Scale yScale1 = zedGraph1.GraphPane.YAxis.Scale;
            Scale yScale2 = zedGraph2.GraphPane.YAxis.Scale;
            Scale yScale3 = zedGraph3.GraphPane.YAxis.Scale;

            //
            if (time1 > xScale1.Max - xScale1.MajorStep)
            {
                xScale1.Max = time1 + xScale1.MajorStep;
                xScale1.Min = xScale1.Max - 10;//Auto scale x axis in limit time
            }
            if (time2 > xScale2.Max - xScale2.MajorStep)
            {
                xScale2.Max = time2 + xScale2.MajorStep;
                xScale2.Min = xScale2.Max - 30;
            }
            if (time3 > xScale3.Max - xScale3.MajorStep)
            {
                xScale3.Max = time3 + xScale3.MajorStep;
                xScale3.Min = xScale3.Max - 30;
            }
            //
            zedGraph1.AxisChange();
            zedGraph2.AxisChange();
            zedGraph3.AxisChange();
            //
            zedGraph1.Invalidate();
            zedGraph2.Invalidate();
            zedGraph3.Invalidate();
        }
        private void ExitBT_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            Close();
        }
        //////////////////////////////////////////////////
        //////////////SEND DATA CONTROL TO DEVICE/////////
        /////////////////////////////////////////////////
        private void ForwardBT_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("F");//Forward control
        }
        private void BackwardBT_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("B");//Back control
        }
        private void LeftBT_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("L");//Turnleft control
        }
        private void RightBT_MouseDown(object sender, MouseEventArgs e)
        {
            serialPort1.Write("R");//Turnright control
        }

        //Mouse Up
        private void ForwardBT_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("T");//Stop forward
        }
        private void RightBT_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("O");//Stop back
        }
        private void LeftBT_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("U");//Stop turnleft
        }
        private void BackBT_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("V");//Stop turnright
        }

        /// <summary>
        /// Key Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Control Motor Forward
            if (e.KeyValue == 87)//W
            {
                w = 0;
                serialPort1.Write("T");
                ForwardBT.Enabled = true;
            }
            //Control Motor Back
            if (e.KeyValue == 83)//S
            {
                s = 0;
                serialPort1.Write("V");
                BackwardBT.Enabled = true;
            }
            //Control Motor Left
            if (e.KeyValue == 65)//A
            {
                a = 0;
                serialPort1.Write("U");
                LeftBT.Enabled = true;
            }
            //Control Motor Right
            if (e.KeyValue == 68)//D
            {
                //lbl.Text = "key up";
                d = 0;
                serialPort1.Write("O");
                RightBT.Enabled = true;
            }
        }
        /// <summary>
        /// Key control motor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Control Motor Forward
            if (e.KeyValue == 87)//W
            {
                if (w != 1)
                {
                    serialPort1.Write("F");
                    ForwardBT.Enabled = false;
                    w = 1;
                }
            }
            //Control Motor Back
            if (e.KeyValue == 83)//S
            {
                if (s != 1)
                {
                    serialPort1.Write("B");
                    BackwardBT.Enabled = false;
                    s = 1;
                }
            }
            //Control Motor Left
            if (e.KeyValue == 65)//A
            {
                if (a != 1)
                {
                    serialPort1.Write("R");
                    LeftBT.Enabled = false;
                    a = 1;
                }
            }
            //Control Motor Right
            if (e.KeyValue == 68)//D
            {
                //lbl.Text = "key down";
                if (d != 1)
                {
                    serialPort1.Write("L");
                    RightBT.Enabled = false;
                    d = 1;
                }
            }
            //
        }
    }
}