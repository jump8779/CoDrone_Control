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

namespace DroneControl
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void Bt_DroneStart_Click(object sender, EventArgs e)
        {
            var engine = IronPython.Hosting.Python.CreateEngine();

            var scope = engine.CreateScope();

            try
            {
                var source = engine.CreateScriptSourceFromFile("pyCoDrone.py");
                source.Execute(scope);

                var Fnhelloworld = scope.GetVariable<Func<object>>("HelloWorld");
                rTB_position.Text += Fnhelloworld() +"\r\n";

                var Fnhelloworld2 = scope.GetVariable<Func<object, object>>("HelloWorld2");
                rTB_position.Text += Fnhelloworld2("HelloWorld2") + "\r\n";

                var FnListTest = scope.GetVariable<Func<object>>("ListTest");

                List r = (List)FnListTest();
                foreach (string data in r)
                {
                    rTB_position.Text += "result:" + data + "\r\n";
                }

                var myClass = scope.GetVariable<Func<object, object>>("MyClass");
                var myInstance = myClass("world");

                rTB_position.Text += engine.Operations.GetMember(myInstance, "value");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_EmergencyStop_Click(object sender, EventArgs e)
        {

        }
    }
}
