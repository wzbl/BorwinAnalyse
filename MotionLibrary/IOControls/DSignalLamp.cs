using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionLibrary.IOControls
{
    public partial class DSignalLamp : UCSignalLamp
    {
        private bool canClick;
        private int value;

        public DSignalLamp()
        {
            InitializeComponent();
        }

        public bool CanClick
        {
            get => canClick;
            set
            {
                canClick = value;
                Cursor = canClick ? Cursors.Hand : Cursors.Default;
            }

        }

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                if (this.value == 0)
                {
                    LampColor[0] = Color.Red;
                }
                else if (this.value == 1)
                {
                    LampColor[0] = Color.Green;
                }
                else
                {
                    LampColor[0] = Color.Gray;
                }
                Refresh();
            }
        }
    }
}
