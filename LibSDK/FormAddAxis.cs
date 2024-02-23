using ComponentFactory.Krypton.Toolkit;
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
    public partial class FormAddAxis : KryptonForm
    {
        public FormAddAxis()
        {
            InitializeComponent();
        }

        public short CardNo;

        private void FormAddAxis_Load(object sender, EventArgs e)
        {
            comCardNo.Items.Clear();
            for (int i = 0; i < BaseConfig.Instance.cardConfigs.Count; i++)
            {
                comCardNo.Items.Add(BaseConfig.Instance.cardConfigs[i].CardNo);
            }
            if (comCardNo.Items.Count > 0)
                comCardNo.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comCardNo.Items.Count > 0)
            {
                CardNo = short.Parse(comCardNo.Text);
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
