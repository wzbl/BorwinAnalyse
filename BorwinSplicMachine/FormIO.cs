using ComponentFactory.Krypton.Toolkit;
using LibSDK.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine
{
    public partial class FormIO : KryptonForm
    {
        public FormIO()
        {
            InitializeComponent();
            this.Controls.Add(new UCIOList());
            //this.Controls.Add(new UCIOControl());
        }
    }
}
