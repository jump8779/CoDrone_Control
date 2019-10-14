using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices; //구조체 설정

namespace DroneControl
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            pictureBoxBmp = new Bitmap(pictureBox_DroneNevi.Width, pictureBox_DroneNevi.Height);
        }

        private TcpClient cSocket;
        private Boolean IsConnected = false;
        private NetworkStream cNts;
        private Thread ReadTh;
        int YAW;
        float X, Y;

        Bitmap pictureBoxBmp;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct statData
        {
            public short battery_p;
            public short temp;
            public short pressure;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct attiData
        {
            public short attROLL;
            public short attPITCH;
            public short attYAW;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct moveData
        {
            public short getR;
            public short getP;
            public short getY;
            public short getT;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct recvData
        {
            public statData statD;
            public attiData attiD;
            public moveData moveD;
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct sequData
        {
            public int sequence;
        }
        //byte를 struct로
        public static object ByteToStructure(byte[] data, Type type)
        {
            //배열의 크기만큼 Unmanaged Memory에 메모리 할당
            IntPtr ptr = Marshal.AllocHGlobal(data.Length);
            //배열 내의 데이터를 할당된 메모리에 복사
            //(Managed Memory -> Unmanaged Memory)
            Marshal.Copy(data, 0, ptr, data.Length);
            //데이터를 구조체 객체로 변환
            object obj = Marshal.PtrToStructure(ptr, type);
            //Unmanaged Memory영역의 메모리 할당 해제
            Marshal.FreeHGlobal(ptr);

            if (Marshal.SizeOf(obj) != data.Length)
            {
                return null; //데이터 크기 확인
            }
            return obj; //구조체 리턴
        }
        //struct를 byte로
        public static byte[] StructureToByte(object obj)
        {
            //구조체 객체 크기
            int size = Marshal.SizeOf(obj);
            byte[] buff = new byte[size];
            //객체 크기만큼 Unmanaged Memory에 메모리 할당
            IntPtr ptr = Marshal.AllocHGlobal(size);
            //데이터를 할당된 메모리 블럭으로 마샬링
            //true : ptr 매개 변수에 대해 값 초기화 (DestroyStructure(IntPtr, Type)호출)
            //false : 메모리 블럭에 이미 데이터가 포함되어 있을 시 메모리 누수 발생 가능
            Marshal.StructureToPtr(obj, ptr, true);
            //(Unmanaged Memory -> Managed Memory)
            Marshal.Copy(ptr, buff, 0, size);
            Marshal.FreeHGlobal(ptr);
            return buff;
        }
        private void AttiLog(int ROLL, int PITCH, int YAW)
        {
            string atti = "ROLL : " + ROLL + " PITCH : "
                        + PITCH + " YAW : " + YAW + "\r\n";

            rTB_position.AppendText(atti);
            rTB_position.AppendText("\r\n");
            //입력된 텍스트에 맞게 스크롤을 내려준다
            this.Activate();
            rTB_position.Focus();
            //캐럿(커서)를 텍스트박스의 끝으로 내려준다
            rTB_position.SelectionStart = rTB_position.Text.Length;
            rTB_position.ScrollToCaret(); //스크롤을 캐럿위치에 맞춰준다
        }
        private void DrawingD(int ROLL, int PITCH)
        {
            Pen p = new Pen(Color.Red);
            p.Width = 8;

            Graphics g = Graphics.FromImage(pictureBoxBmp);
            if(Math.Abs(YAW) > 90)
            {
                double dX, dY;
                dX = PITCH * Math.Sin(YAW);
                dY = PITCH * Math.Cos(YAW);
                g.DrawLine(p, X, Y, X + (float)dX, Y - (float)dY);
                X += (float)dX;
                Y -= (float)dY;
            }
            else if(YAW != 0)
            {
                double dX, dY;
                dX = PITCH * Math.Sin(YAW);
                dY = PITCH * Math.Cos(YAW);
                g.DrawLine(p, X, Y, X + (float)dX, Y + (float)dY);
                X += (float)dX;
                Y += (float)dY;
            }
            else
            {
                g.DrawLine(p, X, Y, X + ROLL, Y + PITCH);
                X += ROLL;
                Y += PITCH;
            }
            pictureBox_DroneNevi.Image = pictureBoxBmp;

            p.Dispose();
            g.Dispose();
        }
        private void SendSequ(object s)
        {
            pictureBox_DroneNevi.Refresh();
            X = pictureBoxBmp.Width / 2;
            Y = pictureBoxBmp.Height / 4;
            sequData SendD = new sequData();
            switch (s)
            {
                case "SQUARE":
                    SendD.sequence = 1;
                    break;
                case "CIRCLE":
                    SendD.sequence = 2;
                    break;
                case "SPIRAL":
                    SendD.sequence = 3;
                    break;
                case "TRIANGLE":
                    SendD.sequence = 4;
                    break;
                case "HOP":
                    SendD.sequence = 5;
                    break;
                case "SWAY":
                    SendD.sequence = 6;
                    break;
                case "ZIGZAG":
                    SendD.sequence = 7;
                    break;
            }
            try
            {
                byte[] data = StructureToByte(SendD);
                cNts.Write(data, 0, data.Length);
                cNts.Flush();
            }
            catch
            {
                MessageBox.Show("데이터 전송 실패");
            }
        }

        private void Receive()
        {
            recvData RecvD;
            int size = Marshal.SizeOf(typeof(recvData));
            byte[] data = new byte[size];
            short oldgetR = 0, oldgetP = 0, oldgetY = 0, oldgetT = 0;
            try
            {
                while (IsConnected)
                {
                    cNts.Read(data, 0, size);
                    RecvD = (recvData)ByteToStructure(data, typeof(recvData));
                    
                    lbl_battery.Text = RecvD.statD.battery_p + " %";
                    lbl_temp.Text = RecvD.statD.temp + " C";
                    lbl_press.Text = RecvD.statD.pressure + " hPa";


                    AttiLog(RecvD.attiD.attROLL, RecvD.attiD.attPITCH, RecvD.attiD.attYAW);
                    if (oldgetR != RecvD.moveD.getR && oldgetP != RecvD.moveD.getP)
                    {
                        DrawingD(RecvD.moveD.getR, RecvD.moveD.getP);
                        oldgetR = RecvD.moveD.getR;
                        oldgetP = RecvD.moveD.getP;
                    }
                    if (RecvD.statD.battery_p < 30)
                    {
                        stat_light.BackColor = Color.Red;
                    }

                    YAW = RecvD.moveD.getY;

                    Array.Clear(data, 0, size);
                }
            }
            catch
            {
                MessageBox.Show("데이터 수신 오류");
            }
        }
        private void Disconnect()
        {
            if (IsConnected == false) return;
            IsConnected = false;
            ReadTh.Join();
            cNts.Close();
            cSocket.Close();
        }
        private void Main_Load(object sender, EventArgs e)
        {
           
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
        private void Bt_Connect_Click(object sender, EventArgs e)
        {
            if(IsConnected == false)
            {
                try
                {
                    cSocket = new TcpClient();
                    cSocket.Connect("localhost", 8080);
                    rTB_position.AppendText("Connecting Success...");
                    IsConnected = true;
                }
                catch
                {
                    MessageBox.Show("서버 연결에 실패했습니다.");
                    return;
                }
                cNts = cSocket.GetStream();
                ReadTh = new Thread(new ThreadStart(Receive));
                ReadTh.Start();
            }
        }
        private void Bt_DisConnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Bt_square_Click(object sender, EventArgs e)
        {
            SendSequ(sender);
        }

        private void Bt_spiral_Click(object sender, EventArgs e)
        {
            SendSequ(sender);
        }

        private void Bt_hop_Click(object sender, EventArgs e)
        {
            SendSequ(sender);
        }

        private void Bt_zigzag_Click(object sender, EventArgs e)
        {
            SendSequ(sender);
        }

        private void Bt_circle_Click(object sender, EventArgs e)
        {
            SendSequ(sender);
        }

        private void Bt_triangle_Click(object sender, EventArgs e)
        {
            SendSequ(sender);
        }

        private void Bt_sway_Click(object sender, EventArgs e)
        {
            SendSequ(sender);
        }
    }
}