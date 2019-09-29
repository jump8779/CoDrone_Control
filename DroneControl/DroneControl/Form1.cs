using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

using IronPython;
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython.Modules;
using System.Threading;

namespace DroneControl
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string temp = null;
        string pressure = null;
        string battery = null;
        Thread Drone;

        public void Drone_Start()
        {
            var engine = Python.CreateEngine();
            
            var scope = engine.CreateScope();
            var source = (dynamic)null; //var형 초기화
            try
            {
                source = engine.CreateScriptSourceFromFile("pyCoDrone.py");
                source.Execute(scope);

                var startD = scope.GetVariable<Func<object, object, object>>("connect");
                startD("COM6", "3004");

                var moveD = scope.GetVariable<Func<object>>("moving");
                moveD();

                var stopD = scope.GetVariable<Func<object>>("disconnect");
                stopD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
           
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void Bt_DroneStart_Click(object sender, EventArgs e)
        {
            Drone = new Thread(new ThreadStart(Drone_Start));
            Drone.Start();
        }

        private void Bt_EmergencyStop_Click(object sender, EventArgs e)
        {
            Drone.Join();
        }
    }
}