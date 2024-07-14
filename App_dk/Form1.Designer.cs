namespace App_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigBox = new System.Windows.Forms.GroupBox();
            this.ExitBT = new System.Windows.Forms.Button();
            this.DisconnectBT = new System.Windows.Forms.Button();
            this.ConnectBT = new System.Windows.Forms.Button();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ControlBox = new System.Windows.Forms.GroupBox();
            this.RightBT = new System.Windows.Forms.Button();
            this.LeftBT = new System.Windows.Forms.Button();
            this.BackwardBT = new System.Windows.Forms.Button();
            this.StopBT = new System.Windows.Forms.Button();
            this.ForwardBT = new System.Windows.Forms.Button();
            this.zedGraph1 = new ZedGraph.ZedGraphControl();
            this.zedGraph2 = new ZedGraph.ZedGraphControl();
            this.zedGraph3 = new ZedGraph.ZedGraphControl();
            this.InfoBox = new System.Windows.Forms.GroupBox();
            this.lblpsi = new System.Windows.Forms.Label();
            this.lbltheta = new System.Windows.Forms.Label();
            this.lblstheta = new System.Windows.Forms.Label();
            this.lblphi = new System.Windows.Forms.Label();
            this.lblsphi = new System.Windows.Forms.Label();
            this.thetaerror = new System.Windows.Forms.Label();
            this.lblthetaerror = new System.Windows.Forms.Label();
            this.phierror = new System.Windows.Forms.Label();
            this.lblphierror = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ConfigBox.SuspendLayout();
            this.ControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ConfigBox
            // 
            this.ConfigBox.Controls.Add(this.ExitBT);
            this.ConfigBox.Controls.Add(this.DisconnectBT);
            this.ConfigBox.Controls.Add(this.ConnectBT);
            this.ConfigBox.Controls.Add(this.cbBaud);
            this.ConfigBox.Controls.Add(this.label3);
            this.ConfigBox.Controls.Add(this.cbPorts);
            this.ConfigBox.Controls.Add(this.label2);
            this.ConfigBox.Location = new System.Drawing.Point(3, 18);
            this.ConfigBox.Name = "ConfigBox";
            this.ConfigBox.Size = new System.Drawing.Size(396, 173);
            this.ConfigBox.TabIndex = 1;
            this.ConfigBox.TabStop = false;
            this.ConfigBox.Text = "Config";
            // 
            // ExitBT
            // 
            this.ExitBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBT.Location = new System.Drawing.Point(129, 104);
            this.ExitBT.Name = "ExitBT";
            this.ExitBT.Size = new System.Drawing.Size(150, 42);
            this.ExitBT.TabIndex = 6;
            this.ExitBT.Text = "Exit";
            this.ExitBT.UseVisualStyleBackColor = true;
            // 
            // DisconnectBT
            // 
            this.DisconnectBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectBT.Location = new System.Drawing.Point(219, 62);
            this.DisconnectBT.Name = "DisconnectBT";
            this.DisconnectBT.Size = new System.Drawing.Size(127, 36);
            this.DisconnectBT.TabIndex = 5;
            this.DisconnectBT.Text = "Disconnect";
            this.DisconnectBT.UseVisualStyleBackColor = true;
            // 
            // ConnectBT
            // 
            this.ConnectBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBT.Location = new System.Drawing.Point(219, 17);
            this.ConnectBT.Name = "ConnectBT";
            this.ConnectBT.Size = new System.Drawing.Size(127, 36);
            this.ConnectBT.TabIndex = 4;
            this.ConnectBT.Text = "Connect";
            this.ConnectBT.UseVisualStyleBackColor = true;
            this.ConnectBT.Click += new System.EventHandler(this.ConnectBT_Click);
            // 
            // cbBaud
            // 
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Location = new System.Drawing.Point(72, 69);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(121, 24);
            this.cbBaud.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Baud";
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(72, 24);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(121, 24);
            this.cbPorts.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ports";
            // 
            // ControlBox
            // 
            this.ControlBox.Controls.Add(this.RightBT);
            this.ControlBox.Controls.Add(this.LeftBT);
            this.ControlBox.Controls.Add(this.BackwardBT);
            this.ControlBox.Controls.Add(this.StopBT);
            this.ControlBox.Controls.Add(this.ForwardBT);
            this.ControlBox.Location = new System.Drawing.Point(405, 18);
            this.ControlBox.Name = "ControlBox";
            this.ControlBox.Size = new System.Drawing.Size(269, 357);
            this.ControlBox.TabIndex = 2;
            this.ControlBox.TabStop = false;
            this.ControlBox.Text = "Control";
            // 
            // RightBT
            // 
            this.RightBT.BackgroundImage = global::App_Test.Properties.Resources.play_button_162755;
            this.RightBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RightBT.Location = new System.Drawing.Point(182, 97);
            this.RightBT.Name = "RightBT";
            this.RightBT.Size = new System.Drawing.Size(81, 71);
            this.RightBT.TabIndex = 4;
            this.RightBT.UseVisualStyleBackColor = true;
            // 
            // LeftBT
            // 
            this.LeftBT.BackgroundImage = global::App_Test.Properties.Resources.lest;
            this.LeftBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LeftBT.Location = new System.Drawing.Point(6, 97);
            this.LeftBT.Name = "LeftBT";
            this.LeftBT.Size = new System.Drawing.Size(83, 74);
            this.LeftBT.TabIndex = 3;
            this.LeftBT.UseVisualStyleBackColor = true;
            // 
            // BackwardBT
            // 
            this.BackwardBT.BackgroundImage = global::App_Test.Properties.Resources.play_button_1627551;
            this.BackwardBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BackwardBT.Location = new System.Drawing.Point(95, 175);
            this.BackwardBT.Name = "BackwardBT";
            this.BackwardBT.Size = new System.Drawing.Size(81, 74);
            this.BackwardBT.TabIndex = 2;
            this.BackwardBT.UseVisualStyleBackColor = true;
            // 
            // StopBT
            // 
            this.StopBT.BackgroundImage = global::App_Test.Properties.Resources.gallery_5908081;
            this.StopBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StopBT.Location = new System.Drawing.Point(95, 95);
            this.StopBT.Name = "StopBT";
            this.StopBT.Size = new System.Drawing.Size(81, 74);
            this.StopBT.TabIndex = 1;
            this.StopBT.UseVisualStyleBackColor = true;
            // 
            // ForwardBT
            // 
            this.ForwardBT.BackgroundImage = global::App_Test.Properties.Resources.for1;
            this.ForwardBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ForwardBT.Location = new System.Drawing.Point(94, 13);
            this.ForwardBT.Name = "ForwardBT";
            this.ForwardBT.Size = new System.Drawing.Size(82, 76);
            this.ForwardBT.TabIndex = 0;
            this.ForwardBT.UseVisualStyleBackColor = true;
            // 
            // zedGraph1
            // 
            this.zedGraph1.Location = new System.Drawing.Point(695, 18);
            this.zedGraph1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph1.Name = "zedGraph1";
            this.zedGraph1.ScrollGrace = 0D;
            this.zedGraph1.ScrollMaxX = 0D;
            this.zedGraph1.ScrollMaxY = 0D;
            this.zedGraph1.ScrollMaxY2 = 0D;
            this.zedGraph1.ScrollMinX = 0D;
            this.zedGraph1.ScrollMinY = 0D;
            this.zedGraph1.ScrollMinY2 = 0D;
            this.zedGraph1.Size = new System.Drawing.Size(671, 358);
            this.zedGraph1.TabIndex = 3;
            // 
            // zedGraph2
            // 
            this.zedGraph2.Location = new System.Drawing.Point(3, 382);
            this.zedGraph2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph2.Name = "zedGraph2";
            this.zedGraph2.ScrollGrace = 0D;
            this.zedGraph2.ScrollMaxX = 0D;
            this.zedGraph2.ScrollMaxY = 0D;
            this.zedGraph2.ScrollMaxY2 = 0D;
            this.zedGraph2.ScrollMinX = 0D;
            this.zedGraph2.ScrollMinY = 0D;
            this.zedGraph2.ScrollMinY2 = 0D;
            this.zedGraph2.Size = new System.Drawing.Size(671, 385);
            this.zedGraph2.TabIndex = 4;
            // 
            // zedGraph3
            // 
            this.zedGraph3.Location = new System.Drawing.Point(695, 382);
            this.zedGraph3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraph3.Name = "zedGraph3";
            this.zedGraph3.ScrollGrace = 0D;
            this.zedGraph3.ScrollMaxX = 0D;
            this.zedGraph3.ScrollMaxY = 0D;
            this.zedGraph3.ScrollMaxY2 = 0D;
            this.zedGraph3.ScrollMinX = 0D;
            this.zedGraph3.ScrollMinY = 0D;
            this.zedGraph3.ScrollMinY2 = 0D;
            this.zedGraph3.Size = new System.Drawing.Size(671, 385);
            this.zedGraph3.TabIndex = 5;
            // 
            // InfoBox
            // 
            this.InfoBox.Location = new System.Drawing.Point(3, 197);
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.Size = new System.Drawing.Size(396, 178);
            this.InfoBox.TabIndex = 6;
            this.InfoBox.TabStop = false;
            this.InfoBox.Text = "Infomation";
            // 
            // lblpsi
            // 
            this.lblpsi.AutoSize = true;
            this.lblpsi.Location = new System.Drawing.Point(828, 90);
            this.lblpsi.Name = "lblpsi";
            this.lblpsi.Size = new System.Drawing.Size(25, 16);
            this.lblpsi.TabIndex = 7;
            this.lblpsi.Text = "psi";
            // 
            // lbltheta
            // 
            this.lbltheta.AutoSize = true;
            this.lbltheta.Location = new System.Drawing.Point(115, 453);
            this.lbltheta.Name = "lbltheta";
            this.lbltheta.Size = new System.Drawing.Size(36, 16);
            this.lbltheta.TabIndex = 8;
            this.lbltheta.Text = "theta";
            // 
            // lblstheta
            // 
            this.lblstheta.AutoSize = true;
            this.lblstheta.Location = new System.Drawing.Point(239, 453);
            this.lblstheta.Name = "lblstheta";
            this.lblstheta.Size = new System.Drawing.Size(43, 16);
            this.lblstheta.TabIndex = 9;
            this.lblstheta.Text = "stheta";
            // 
            // lblphi
            // 
            this.lblphi.AutoSize = true;
            this.lblphi.Location = new System.Drawing.Point(828, 453);
            this.lblphi.Name = "lblphi";
            this.lblphi.Size = new System.Drawing.Size(25, 16);
            this.lblphi.TabIndex = 10;
            this.lblphi.Text = "phi";
            // 
            // lblsphi
            // 
            this.lblsphi.AutoSize = true;
            this.lblsphi.Location = new System.Drawing.Point(956, 453);
            this.lblsphi.Name = "lblsphi";
            this.lblsphi.Size = new System.Drawing.Size(32, 16);
            this.lblsphi.TabIndex = 11;
            this.lblsphi.Text = "sphi";
            // 
            // thetaerror
            // 
            this.thetaerror.AutoSize = true;
            this.thetaerror.Location = new System.Drawing.Point(433, 418);
            this.thetaerror.Name = "thetaerror";
            this.thetaerror.Size = new System.Drawing.Size(73, 16);
            this.thetaerror.TabIndex = 12;
            this.thetaerror.Text = "Theta error";
            // 
            // lblthetaerror
            // 
            this.lblthetaerror.AutoSize = true;
            this.lblthetaerror.Location = new System.Drawing.Point(546, 418);
            this.lblthetaerror.Name = "lblthetaerror";
            this.lblthetaerror.Size = new System.Drawing.Size(35, 16);
            this.lblthetaerror.TabIndex = 13;
            this.lblthetaerror.Text = "error";
            // 
            // phierror
            // 
            this.phierror.AutoSize = true;
            this.phierror.Location = new System.Drawing.Point(1143, 418);
            this.phierror.Name = "phierror";
            this.phierror.Size = new System.Drawing.Size(57, 16);
            this.phierror.TabIndex = 14;
            this.phierror.Text = "Phi error";
            // 
            // lblphierror
            // 
            this.lblphierror.AutoSize = true;
            this.lblphierror.Location = new System.Drawing.Point(1236, 418);
            this.lblphierror.Name = "lblphierror";
            this.lblphierror.Size = new System.Drawing.Size(35, 16);
            this.lblphierror.TabIndex = 15;
            this.lblphierror.Text = "error";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 798);
            this.Controls.Add(this.lblphierror);
            this.Controls.Add(this.phierror);
            this.Controls.Add(this.lblthetaerror);
            this.Controls.Add(this.thetaerror);
            this.Controls.Add(this.lblsphi);
            this.Controls.Add(this.lblphi);
            this.Controls.Add(this.lblstheta);
            this.Controls.Add(this.lbltheta);
            this.Controls.Add(this.lblpsi);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.zedGraph3);
            this.Controls.Add(this.zedGraph2);
            this.Controls.Add(this.zedGraph1);
            this.Controls.Add(this.ControlBox);
            this.Controls.Add(this.ConfigBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ConfigBox.ResumeLayout(false);
            this.ConfigBox.PerformLayout();
            this.ControlBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox ConfigBox;
        private System.Windows.Forms.Button ExitBT;
        private System.Windows.Forms.Button DisconnectBT;
        private System.Windows.Forms.Button ConnectBT;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox ControlBox;
        private System.Windows.Forms.Button RightBT;
        private System.Windows.Forms.Button LeftBT;
        private System.Windows.Forms.Button BackwardBT;
        private System.Windows.Forms.Button StopBT;
        private System.Windows.Forms.Button ForwardBT;
        private ZedGraph.ZedGraphControl zedGraph1;
        private ZedGraph.ZedGraphControl zedGraph2;
        private ZedGraph.ZedGraphControl zedGraph3;
        private System.Windows.Forms.GroupBox InfoBox;
        private System.Windows.Forms.Label lblpsi;
        private System.Windows.Forms.Label lbltheta;
        private System.Windows.Forms.Label lblstheta;
        private System.Windows.Forms.Label lblphi;
        private System.Windows.Forms.Label lblsphi;
        private System.Windows.Forms.Label thetaerror;
        private System.Windows.Forms.Label lblthetaerror;
        private System.Windows.Forms.Label phierror;
        private System.Windows.Forms.Label lblphierror;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
    }
}

