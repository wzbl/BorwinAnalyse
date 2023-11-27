using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinAnalyse.UCControls
{
    public partial class UCAnalyseSet : UserControl
    {
        public UCAnalyseSet()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            Dock = DockStyle.Fill;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void Save()
        {


        }


        bool isEnterDataGridView1 = false;
        private void kryptonDataGridView1_MouseEnter(object sender, EventArgs e)
        {
            isEnterDataGridView1 = true;
        }

        private void kryptonDataGridView1_MouseLeave(object sender, EventArgs e)
        {
            isEnterDataGridView1 = false;
        }

        private void kryptonDataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Right)
            {
                ShowMenu(kryptonDataGridView1,kryptonContextMenu1);
            }
        }

        private void ShowMenu(Control c, KryptonContextMenu kcm)
        {
            kcm.Show(c.RectangleToScreen(c.ClientRectangle),
                     (KryptonContextMenuPositionH)Enum.Parse(typeof(KryptonContextMenuPositionH), "Left"),
                     (KryptonContextMenuPositionV)Enum.Parse(typeof(KryptonContextMenuPositionV), "Left"));
        }
    }
}
