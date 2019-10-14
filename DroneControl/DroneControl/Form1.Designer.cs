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
            this.pictureBox_DroneNevi = new System.Windows.Forms.PictureBox();
            this.rTB_position = new System.Windows.Forms.RichTextBox();
            this.Bt_Connect = new System.Windows.Forms.Button();
            this.Bt_Disconnect = new System.Windows.Forms.Button();
            this.GB_DroneState = new System.Windows.Forms.GroupBox();
            this.bt_zigzag = new System.Windows.Forms.Button();
            this.bt_sway = new System.Windows.Forms.Button();
            this.bt_hop = new System.Windows.Forms.Button();
            this.bt_triangle = new System.Windows.Forms.Button();
            this.bt_spiral = new System.Windows.Forms.Button();
            this.bt_circle = new System.Windows.Forms.Button();
            this.bt_square = new System.Windows.Forms.Button();
            this.lbltemp = new System.Windows.Forms.Label();
            this.lblpressure = new System.Windows.Forms.Label();
            this.lblbattery = new System.Windows.Forms.Label();
            this.lbl_temp = new System.Windows.Forms.Label();
            this.lbl_press = new System.Windows.Forms.Label();
            this.lbl_battery = new System.Windows.Forms.Label();
            this.stat_light = new System.Windows.Forms.Button();
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
            // Bt_Connect
            // 
            this.Bt_Connect.Location = new System.Drawing.Point(681, 568);
            this.Bt_Connect.Name = "Bt_Connect";
            this.Bt_Connect.Size = new System.Drawing.Size(125, 59);
            this.Bt_Connect.TabIndex = 5;
            this.Bt_Connect.Text = "CONNECT";
            this.Bt_Connect.UseVisualStyleBackColor = true;
            this.Bt_Connect.Click += new System.EventHandler(this.Bt_Connect_Click);
            // 
            // Bt_Disconnect
            // 
            this.Bt_Disconnect.Location = new System.Drawing.Point(681, 650);
            this.Bt_Disconnect.Name = "Bt_Disconnect";
            this.Bt_Disconnect.Size = new System.Drawing.Size(125, 59);
            this.Bt_Disconnect.TabIndex = 6;
            this.Bt_Disconnect.Text = "DISCONNECT";
            this.Bt_Disconnect.UseVisualStyleBackColor = true;
            this.Bt_Disconnect.Click += new System.EventHandler(this.Bt_DisConnect_Click);
            // 
            // GB_DroneState
            // 
            this.GB_DroneState.Controls.Add(this.bt_zigzag);
            this.GB_DroneState.Controls.Add(this.bt_sway);
            this.GB_DroneState.Controls.Add(this.bt_hop);
            this.GB_DroneState.Controls.Add(this.bt_triangle);
            this.GB_DroneState.Controls.Add(this.bt_spiral);
            this.GB_DroneState.Controls.Add(this.bt_circle);
            this.GB_DroneState.Controls.Add(this.bt_square);
            this.GB_DroneState.Location = new System.Drawing.Point(12, 568);
            this.GB_DroneState.Name = "GB_DroneState";
            this.GB_DroneState.Size = new System.Drawing.Size(653, 141);
            this.GB_DroneState.TabIndex = 7;
            this.GB_DroneState.TabStop = false;
            this.GB_DroneState.Text = "Drone_State";
            // 
            // bt_zigzag
            // 
            this.bt_zigzag.Location = new System.Drawing.Point(311, 40);
            this.bt_zigzag.Name = "bt_zigzag";
            this.bt_zigzag.Size = new System.Drawing.Size(91, 34);
            this.bt_zigzag.TabIndex = 0;
            this.bt_zigzag.Text = "ZIGZAG";
            this.bt_zigzag.UseVisualStyleBackColor = true;
            this.bt_zigzag.Click += new System.EventHandler(this.Bt_zigzag_Click);
            // 
            // bt_sway
            // 
            this.bt_sway.Location = new System.Drawing.Point(214, 88);
            this.bt_sway.Name = "bt_sway";
            this.bt_sway.Size = new System.Drawing.Size(91, 34);
            this.bt_sway.TabIndex = 0;
            this.bt_sway.Text = "SWAY";
            this.bt_sway.UseVisualStyleBackColor = true;
            this.bt_sway.Click += new System.EventHandler(this.Bt_sway_Click);
            // 
            // bt_hop
            // 
            this.bt_hop.Location = new System.Drawing.Point(214, 40);
            this.bt_hop.Name = "bt_hop";
            this.bt_hop.Size = new System.Drawing.Size(91, 34);
            this.bt_hop.TabIndex = 0;
            this.bt_hop.Text = "HOP";
            this.bt_hop.UseVisualStyleBackColor = true;
            this.bt_hop.Click += new System.EventHandler(this.Bt_hop_Click);
            // 
            // bt_triangle
            // 
            this.bt_triangle.Location = new System.Drawing.Point(117, 88);
            this.bt_triangle.Name = "bt_triangle";
            this.bt_triangle.Size = new System.Drawing.Size(91, 34);
            this.bt_triangle.TabIndex = 0;
            this.bt_triangle.Text = "TRIANGLE";
            this.bt_triangle.UseVisualStyleBackColor = true;
            this.bt_triangle.Click += new System.EventHandler(this.Bt_triangle_Click);
            // 
            // bt_spiral
            // 
            this.bt_spiral.Location = new System.Drawing.Point(117, 40);
            this.bt_spiral.Name = "bt_spiral";
            this.bt_spiral.Size = new System.Drawing.Size(91, 34);
            this.bt_spiral.TabIndex = 0;
            this.bt_spiral.Text = "SPIRAL";
            this.bt_spiral.UseVisualStyleBackColor = true;
            this.bt_spiral.Click += new System.EventHandler(this.Bt_spiral_Click);
            // 
            // bt_circle
            // 
            this.bt_circle.Location = new System.Drawing.Point(20, 88);
            this.bt_circle.Name = "bt_circle";
            this.bt_circle.Size = new System.Drawing.Size(91, 34);
            this.bt_circle.TabIndex = 0;
            this.bt_circle.Text = "CIRCLE";
            this.bt_circle.UseVisualStyleBackColor = true;
            this.bt_circle.Click += new System.EventHandler(this.Bt_circle_Click);
            // 
            // bt_square
            // 
            this.bt_square.Location = new System.Drawing.Point(20, 40);
            this.bt_square.Name = "bt_square";
            this.bt_square.Size = new System.Drawing.Size(91, 34);
            this.bt_square.TabIndex = 0;
            this.bt_square.Text = "SQUARE";
            this.bt_square.UseVisualStyleBackColor = true;
            this.bt_square.Click += new System.EventHandler(this.Bt_square_Click);
            // 
            // lbltemp
            // 
            this.lbltemp.AutoSize = true;
            this.lbltemp.Location = new System.Drawing.Point(1112, 590);
            this.lbltemp.Name = "lbltemp";
            this.lbltemp.Size = new System.Drawing.Size(37, 15);
            this.lbltemp.TabIndex = 8;
            this.lbltemp.Text = "온도";
            // 
            // lblpressure
            // 
            this.lblpressure.AutoSize = true;
            this.lblpressure.Location = new System.Drawing.Point(1112, 634);
            this.lblpressure.Name = "lblpressure";
            this.lblpressure.Size = new System.Drawing.Size(37, 15);
            this.lblpressure.TabIndex = 9;
            this.lblpressure.Text = "기압";
            // 
            // lblbattery
            // 
            this.lblbattery.AutoSize = true;
            this.lblbattery.Location = new System.Drawing.Point(1112, 675);
            this.lblbattery.Name = "lblbattery";
            this.lblbattery.Size = new System.Drawing.Size(52, 15);
            this.lblbattery.TabIndex = 10;
            this.lblbattery.Text = "베터리";
            // 
            // lbl_temp
            // 
            this.lbl_temp.BackColor = System.Drawing.Color.Gray;
            this.lbl_temp.Location = new System.Drawing.Point(1015, 586);
            this.lbl_temp.Name = "lbl_temp";
            this.lbl_temp.Size = new System.Drawing.Size(80, 23);
            this.lbl_temp.TabIndex = 11;
            this.lbl_temp.Text = "0 C";
            this.lbl_temp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_press
            // 
            this.lbl_press.BackColor = System.Drawing.Color.Gray;
            this.lbl_press.Location = new System.Drawing.Point(1015, 630);
            this.lbl_press.Name = "lbl_press";
            this.lbl_press.Size = new System.Drawing.Size(80, 23);
            this.lbl_press.TabIndex = 11;
            this.lbl_press.Text = "0";
            this.lbl_press.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_battery
            // 
            this.lbl_battery.BackColor = System.Drawing.Color.Gray;
            this.lbl_battery.Location = new System.Drawing.Point(1015, 671);
            this.lbl_battery.Name = "lbl_battery";
            this.lbl_battery.Size = new System.Drawing.Size(80, 23);
            this.lbl_battery.TabIndex = 11;
            this.lbl_battery.Text = "0 %";
            this.lbl_battery.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stat_light
            // 
            this.stat_light.BackColor = System.Drawing.Color.Goldenrod;
            this.stat_light.Location = new System.Drawing.Point(871, 608);
            this.stat_light.Name = "stat_light";
            this.stat_light.Size = new System.Drawing.Size(75, 60);
            this.stat_light.TabIndex = 12;
            this.stat_light.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 736);
            this.Controls.Add(this.stat_light);
            this.Controls.Add(this.lbl_battery);
            this.Controls.Add(this.lbl_press);
            this.Controls.Add(this.lbl_temp);
            this.Controls.Add(this.lblbattery);
            this.Controls.Add(this.lblpressure);
            this.Controls.Add(this.lbltemp);
            this.Controls.Add(this.GB_DroneState);
            this.Controls.Add(this.Bt_Disconnect);
            this.Controls.Add(this.Bt_Connect);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_DroneNevi;
        private System.Windows.Forms.RichTextBox rTB_position;
        private System.Windows.Forms.Button Bt_Connect;
        private System.Windows.Forms.Button Bt_Disconnect;
        private System.Windows.Forms.GroupBox GB_DroneState;
        private System.Windows.Forms.Label lbltemp;
        private System.Windows.Forms.Label lblpressure;
        private System.Windows.Forms.Label lblbattery;
        private System.Windows.Forms.Label lbl_temp;
        private System.Windows.Forms.Label lbl_press;
        private System.Windows.Forms.Label lbl_battery;
        private System.Windows.Forms.Button stat_light;
        private System.Windows.Forms.Button bt_zigzag;
        private System.Windows.Forms.Button bt_sway;
        private System.Windows.Forms.Button bt_hop;
        private System.Windows.Forms.Button bt_triangle;
        private System.Windows.Forms.Button bt_spiral;
        private System.Windows.Forms.Button bt_circle;
        private System.Windows.Forms.Button bt_square;
    }
}

