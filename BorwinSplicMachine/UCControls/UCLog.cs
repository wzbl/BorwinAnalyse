using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
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
    public partial class UCLog : UserControl
    {
        public UCLog()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.components = new System.ComponentModel.Container();
            this.Load += UCLog_Load;
        }

        private void UCLog_Load(object sender, EventArgs e)
        {
            comType.SelectedIndex = 0;
            startTime.Value= DateTime.Today;
            endTime.Value= DateTime.Now;
            UpdataLanguage();
        }

        public void UpdataLanguage()
        {
            LanguageManager.Instance.UpdateLanguage(this, this.components.Components);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (startTime.Value.Ticks > endTime.Value.Ticks)
            {
                MessageBox.Show("开始时间大于结束时间".tr());
            }

            if (comType.Text.Trim()!= "ALL")
            {
                Search(startTime.Value, endTime.Value, comType.Text.Trim());
            }
            else
            {
                Search(startTime.Value, endTime.Value);
            }
        }

        public async void Search(DateTime startTime, DateTime endTime)
        {
            List<LogModel> logs = LogManager.Instance.SearchByTime(startTime, endTime);
           
            await Task.Run(() => {
                UpdataGrid(logs);
            });
        }

        public async void Search(DateTime startTime, DateTime endTime,string type)
        {
            List<LogModel> logs = LogManager.Instance.SearchByType(startTime, endTime, type);

            await Task.Run(() => {
                UpdataGrid(logs);
            });
        }


        public void UpdataGrid(List<LogModel> logs)
        {
            this.Invoke(new Action(() => {
            kryptonDataGridView1.Rows.Clear();
            for (int i = 0; i < logs.Count; i++)
            {
                    kryptonDataGridView1.Rows.Add(
                        kryptonDataGridView1.Rows.Count,
                        logs[i].Time,
                        logs[i].Type,
                        logs[i].Content,
                        logs[i].Operator
                        );
            }
            }));
        }
    }

}
