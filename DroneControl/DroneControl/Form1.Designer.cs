namespace DroneControl
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox_DroneNevi = new System.Windows.Forms.PictureBox();
            this.rTB_position = new System.Windows.Forms.RichTextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.PBar_temp = new CircularProgressBar.CircularProgressBar();
            this.PBar_pressure = new CircularProgressBar.CircularProgressBar();
            this.PBar_battery = new CircularProgressBar.CircularProgressBar();
            this.Bt_DroneStart = new System.Windows.Forms.Button();
            this.Bt_EmergencyStop = new System.Windows.Forms.Button();
            this.GB_DroneState = new System.Windows.Forms.GroupBox();
            this.lbl_Drone = new System.Windows.Forms.Label();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.lbldrone = new System.Windows.Forms.Label();
            this.lblport = new System.Windows.Forms.Label();
            this.lbltemp = new System.Windows.Forms.Label();
            this.lblpressure = new System.Windows.Forms.Label();
            this.lblbattery = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DroneNevi)).BeginInit();
            this.GB_DroneState.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox_DroneNevi
            // 
            this.pictureBox_DroneNevi.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_DroneNevi.Name = "pictureBox_DroneNevi";
            this.pictureBox_DroneNevi.Size = new System.Drawing.Size(745, 535);
            this.pictureBox_DroneNevi.TabIndex = 0;
            this.pictureBox_DroneNevi.TabStop = false;
            // 
            // rTB_position
            // 
            this.rTB_position.Location = new System.Drawing.Point(764, 13);
            this.rTB_position.Name = "rTB_position";
            this.rTB_position.Size = new System.Drawing.Size(445, 534);
            this.rTB_position.TabIndex = 1;
            this.rTB_position.Text = "";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            // 
            // PBar_temp
            // 
            this.PBar_temp.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.PBar_temp.AnimationSpeed = 500;
            this.PBar_temp.BackColor = System.Drawing.Color.Transparent;
            this.PBar_temp.Font = new System.Drawing.Font("굴림", 72F, System.Drawing.FontStyle.Bold);
            this.PBar_temp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PBar_temp.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PBar_temp.InnerMargin = 2;
            this.PBar_temp.InnerWidth = -1;
            this.PBar_temp.Location = new System.Drawing.Point(851, 568);
            this.PBar_temp.MarqueeAnimationSpeed = 2000;
            this.PBar_temp.Name = "PBar_temp";
            this.PBar_temp.OuterColor = System.Drawing.Color.Gray;
            this.PBar_temp.OuterMargin = -25;
            this.PBar_temp.OuterWidth = 25;
            this.PBar_temp.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PBar_temp.ProgressWidth = 25;
            this.PBar_temp.SecondaryFont = new System.Drawing.Font("굴림", 36F);
            this.PBar_temp.Size = new System.Drawing.Size(100, 100);
            this.PBar_temp.StartAngle = 270;
            this.PBar_temp.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PBar_temp.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.PBar_temp.SubscriptText = ".23";
            this.PBar_temp.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PBar_temp.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.PBar_temp.SuperscriptText = "°C";
            this.PBar_temp.TabIndex = 2;
            this.PBar_temp.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.PBar_temp.Value = 68;
            // 
            // PBar_pressure
            // 
            this.PBar_pressure.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.PBar_pressure.AnimationSpeed = 500;
            this.PBar_pressure.BackColor = System.Drawing.Color.Transparent;
            this.PBar_pressure.Font = new System.Drawing.Font("굴림", 72F, System.Drawing.FontStyle.Bold);
            this.PBar_pressure.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PBar_pressure.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PBar_pressure.InnerMargin = 2;
            this.PBar_pressure.InnerWidth = -1;
            this.PBar_pressure.Location = new System.Drawing.Point(951, 568);
            this.PBar_pressure.MarqueeAnimationSpeed = 2000;
            this.PBar_pressure.Name = "PBar_pressure";
            this.PBar_pressure.OuterColor = System.Drawing.Color.Gray;
            this.PBar_pressure.OuterMargin = -25;
            this.PBar_pressure.OuterWidth = 25;
            this.PBar_pressure.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PBar_pressure.ProgressWidth = 25;
            this.PBar_pressure.SecondaryFont = new System.Drawing.Font("굴림", 36F);
            this.PBar_pressure.Size = new System.Drawing.Size(100, 100);
            this.PBar_pressure.StartAngle = 270;
            this.PBar_pressure.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PBar_pressure.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.PBar_pressure.SubscriptText = ".23";
            this.PBar_pressure.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PBar_pressure.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.PBar_pressure.SuperscriptText = "°C";
            this.PBar_pressure.TabIndex = 3;
            this.PBar_pressure.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.PBar_pressure.Value = 68;
            // 
            // PBar_battery
            // 
            this.PBar_battery.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.PBar_battery.AnimationSpeed = 500;
            this.PBar_battery.BackColor = System.Drawing.Color.Transparent;
            this.PBar_battery.Font = new System.Drawing.Font("굴림", 72F, System.Drawing.FontStyle.Bold);
            this.PBar_battery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PBar_battery.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PBar_battery.InnerMargin = 2;
            this.PBar_battery.InnerWidth = -1;
            this.PBar_battery.Location = new System.Drawing.Point(1051, 568);
            this.PBar_battery.MarqueeAnimationSpeed = 2000;
            this.PBar_battery.Name = "PBar_battery";
            this.PBar_battery.OuterColor = System.Drawing.Color.Gray;
            this.PBar_battery.OuterMargin = -25;
            this.PBar_battery.OuterWidth = 25;
            this.PBar_battery.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PBar_battery.ProgressWidth = 25;
            this.PBar_battery.SecondaryFont = new System.Drawing.Font("굴림", 36F);
            this.PBar_battery.Size = new System.Drawing.Size(100, 100);
            this.PBar_battery.StartAngle = 270;
            this.PBar_battery.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PBar_battery.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.PBar_battery.SubscriptText = ".23";
            this.PBar_battery.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.PBar_battery.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.PBar_battery.SuperscriptText = "°C";
            this.PBar_battery.TabIndex = 4;
            this.PBar_battery.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.PBar_battery.Value = 68;
            // 
            // Bt_DroneStart
            // 
            this.Bt_DroneStart.Location = new System.Drawing.Point(681, 568);
            this.Bt_DroneStart.Name = "Bt_DroneStart";
            this.Bt_DroneStart.Size = new System.Drawing.Size(125, 59);
            this.Bt_DroneStart.TabIndex = 5;
            this.Bt_DroneStart.Text = "START";
            this.Bt_DroneStart.UseVisualStyleBackColor = true;
            this.Bt_DroneStart.Click += new System.EventHandler(this.Bt_DroneStart_Click);
            // 
            // Bt_EmergencyStop
            // 
            this.Bt_EmergencyStop.Location = new System.Drawing.Point(681, 650);
            this.Bt_EmergencyStop.Name = "Bt_EmergencyStop";
            this.Bt_EmergencyStop.Size = new System.Drawing.Size(125, 59);
            this.Bt_EmergencyStop.TabIndex = 6;
            this.Bt_EmergencyStop.Text = "STOP";
            this.Bt_EmergencyStop.UseVisualStyleBackColor = true;
            this.Bt_EmergencyStop.Click += new System.EventHandler(this.Bt_EmergencyStop_Click);
            // 
            // GB_DroneState
            // 
            this.GB_DroneState.Controls.Add(this.lbl_Drone);
            this.GB_DroneState.Controls.Add(this.lbl_Port);
            this.GB_DroneState.Controls.Add(this.lbldrone);
            this.GB_DroneState.Controls.Add(this.lblport);
            this.GB_DroneState.Location = new System.Drawing.Point(12, 568);
            this.GB_DroneState.Name = "GB_DroneState";
            this.GB_DroneState.Size = new System.Drawing.Size(653, 141);
            this.GB_DroneState.TabIndex = 7;
            this.GB_DroneState.TabStop = false;
            this.GB_DroneState.Text = "Drone_State";
            // 
            // lbl_Drone
            // 
            this.lbl_Drone.AutoSize = true;
            this.lbl_Drone.Location = new System.Drawing.Point(107, 85);
            this.lbl_Drone.Name = "lbl_Drone";
            this.lbl_Drone.Size = new System.Drawing.Size(0, 15);
            this.lbl_Drone.TabIndex = 3;
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Location = new System.Drawing.Point(78, 44);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(0, 15);
            this.lbl_Port.TabIndex = 2;
            // 
            // lbldrone
            // 
            this.lbldrone.AutoSize = true;
            this.lbldrone.Location = new System.Drawing.Point(25, 85);
            this.lbldrone.Name = "lbldrone";
            this.lbldrone.Size = new System.Drawing.Size(82, 15);
            this.lbldrone.TabIndex = 1;
            this.lbldrone.Text = "드론 번호 :";
            // 
            // lblport
            // 
            this.lblport.AutoSize = true;
            this.lblport.Location = new System.Drawing.Point(25, 44);
            this.lblport.Name = "lblport";
            this.lblport.Size = new System.Drawing.Size(47, 15);
            this.lblport.TabIndex = 0;
            this.lblport.Text = "포트 :";
            // 
            // lbltemp
            // 
            this.lbltemp.AutoSize = true;
            this.lbltemp.Location = new System.Drawing.Point(887, 683);
            this.lbltemp.Name = "lbltemp";
            this.lbltemp.Size = new System.Drawing.Size(37, 15);
            this.lbltemp.TabIndex = 8;
            this.lbltemp.Text = "온도";
            // 
            // lblpressure
            // 
            this.lblpressure.AutoSize = true;
            this.lblpressure.Location = new System.Drawing.Point(986, 683);
            this.lblpressure.Name = "lblpressure";
            this.lblpressure.Size = new System.Drawing.Size(37, 15);
            this.lblpressure.TabIndex = 9;
            this.lblpressure.Text = "기압";
            // 
            // lblbattery
            // 
            this.lblbattery.AutoSize = true;
            this.lblbattery.Location = new System.Drawing.Point(1078, 683);
            this.lblbattery.Name = "lblbattery";
            this.lblbattery.Size = new System.Drawing.Size(52, 15);
            this.lblbattery.TabIndex = 10;
            this.lblbattery.Text = "베터리";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 736);
            this.Controls.Add(this.lblbattery);
            this.Controls.Add(this.lblpressure);
            this.Controls.Add(this.lbltemp);
            this.Controls.Add(this.GB_DroneState);
            this.Controls.Add(this.Bt_EmergencyStop);
            this.Controls.Add(this.Bt_DroneStart);
            this.Controls.Add(this.PBar_battery);
            this.Controls.Add(this.PBar_pressure);
            this.Controls.Add(this.PBar_temp);
            this.Controls.Add(this.rTB_position);
            this.Controls.Add(this.pictureBox_DroneNevi);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1239, 783);
            this.MinimumSize = new System.Drawing.Size(1239, 783);
            this.Name = "Main";
            this.Text = "드론 제어";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DroneNevi)).EndInit();
            this.GB_DroneState.ResumeLayout(false);
            this.GB_DroneState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_DroneNevi;
        private System.Windows.Forms.RichTextBox rTB_position;
        private System.IO.Ports.SerialPort serialPort1;
        private CircularProgressBar.CircularProgressBar PBar_temp;
        private CircularProgressBar.CircularProgressBar PBar_pressure;
        private CircularProgressBar.CircularProgressBar PBar_battery;
        private System.Windows.Forms.Button Bt_DroneStart;
        private System.Windows.Forms.Button Bt_EmergencyStop;
        private System.Windows.Forms.GroupBox GB_DroneState;
        private System.Windows.Forms.Label lbldrone;
        private System.Windows.Forms.Label lblport;
        private System.Windows.Forms.Label lbltemp;
        private System.Windows.Forms.Label lblpressure;
        private System.Windows.Forms.Label lblbattery;
        private System.Windows.Forms.Label lbl_Drone;
        private System.Windows.Forms.Label lbl_Port;
    }
}

