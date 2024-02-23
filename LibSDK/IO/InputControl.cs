using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibSDK.IO
{
    public partial class InputControl : UserControl
    {
        private string inputText;
        private int inputIndex;
        DSignalLamp dSignalLamp;
        public Input Input { get; set; }

        public InputControl()
        {
            InitializeComponent();
            dSignalLamp = new DSignalLamp();
            this.Controls.Add(dSignalLamp);
            MotionControl.IsEnable += IsEnable;
        }

        private void IsEnable(bool obj)
        {
            txtInputIndex.ReadOnly = !obj;
            txtInputText.ReadOnly = !obj;
        }

        public int Value
        {
            get => dSignalLamp.Value;
            set
            {
                dSignalLamp.Value = value;
            }
        }

        public void RefreshUI()
        {
            txtInputText.Text = Input.IOParm.IoName;
            txtInputIndex.Text = Input.IOParm.CardNo + "-" + Input.IOParm.IONum;
        }

        private void txtInputIndex_TextChanged(object sender, EventArgs e)
        {
            if (!txtInputIndex.Text.Contains("-"))
            {
                return;
            }

            string[] s = txtInputIndex.Text.Split('-');
            if (s.Length != 2)
            {
                return;
            }

            if (short.TryParse(s[0],out short cardNo)&& short.TryParse(s[1], out short IoNo))
            {
                Input.IOParm.CardNo = cardNo;
                Input.IOParm.IONum= IoNo;
            }
        }

        private void txtInputText_TextChanged(object sender, EventArgs e)
        {
            Input.IOParm.IoName = txtInputText.Text;
        }
    }
}
