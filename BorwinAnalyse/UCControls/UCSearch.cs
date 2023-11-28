using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Comm;
using BorwinAnalyse.DataBase.Model;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NPOI.HSSF.Util.HSSFColor;

namespace BorwinAnalyse.UCControls
{
    public partial class UCSearch : UserControl
    {
        public UCSearch()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            this.Dock = DockStyle.Fill;
            this.Load += UCSearch_Load;
        }

        private void UCSearch_Load(object sender, EventArgs e)
        {
            kryptonNavigator1.SelectedIndex = 1;
        }
    }
}
