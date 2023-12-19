using BorwinAnalyse.BaseClass;
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

namespace BorwinSplicMachine.UCControls
{
    public partial class UCBaseSet : UserControl
    {
        public UCBaseSet()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCBaseSet_Load;
            this.components = new System.ComponentModel.Container();
        }

        private void UCBaseSet_Load(object sender, EventArgs e)
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void kryptonOffice2007Black_Click(object sender, EventArgs e)
        {
            int model = int.Parse(((KryptonRadioButton)sender).Tag.ToString());
            kryptonManager1.GlobalPaletteMode = (PaletteModeManager)model;
        }

        private void kryptonButton1_Click_1(object sender, EventArgs e)
        {
            int index = int.Parse(((KryptonButton)sender).Tag.ToString());
            LanguageManager.Instance.UpdateCurrentLanguage(index);
        }
    }
}
