using LibSDK.Motion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK
{
    public partial class UCMotion : UserControl
    {
        public UCMotion()
        {
            InitializeComponent();
            this.Load += UCMotion_Load;
            this.Dock = DockStyle.Fill;
        }
        MotAPI xzhou;
        private void UCMotion_Load(object sender, EventArgs e)
        {
            xzhou =  MotionControl.AddAxis("1", Enums.MotorType.Step);
            CAxisParm[] obj = new CAxisParm[AxisParm.AParms.Count];
            for (int i = 0; i < AxisParm.AParms.Count;i++)
            {
               
                obj[i]= AxisParm.AParms[i];
          
            }
            
            PPTAxisParam.PPTParam.SelectedObject = obj;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            xzhou.JOP(1,100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xzhou.AxisStop();
        }
    }
}
