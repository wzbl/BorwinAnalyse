using BorwinAnalyse.BaseClass;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BorwinAnalyse.UCControls
{
    public partial class UCUser : UserControl
    {
        public UCUser()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            if (kryptonDataGridView1.Columns.Count > 0)
            {
                kryptonDataGridView1.Columns[0].ReadOnly = true;
            }
            this.Load += UCUser_Load;
        }

        private void UCUser_Load(object sender, EventArgs e)
        {
            Search();
        }

        public List<User> users = new List<User>();
        private void btnRegi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comLevel.Text) || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("信息不全".tr());
                return;
            }

            User user = new User();
            user.level = (Level)comLevel.SelectedIndex;
            user.EmpNo = UserManager.Instance.users.Count.ToString();
            user.name = txtUserName.Text;
            user.pass = txtPass.Text;
            if (user.level > UserManager.Instance.CurrentUser.level)
            {
                MessageBox.Show("设置等级需要小于当前等级".tr());
                return;
            }
            UserManager.Instance.users.Where(x => x.name == user.name).ToList();
            if (UserManager.Instance.users.Where(x => x.name == user.name).ToList().Count > 0)
            {
                MessageBox.Show("用户".tr() + user.name + "已经存在".tr());
                return;
            }
            MessageBox.Show("注册成功".tr());
            UserManager.Instance.users.Add(user);
            UserManager.Instance.Save();
            Search();
        }

        private void btnUpdataBom_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
            {
                string empNo = kryptonDataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                string name = kryptonDataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                string pass = kryptonDataGridView1.Rows[i].Cells[2].FormattedValue.ToString();
                string level = kryptonDataGridView1.Rows[i].Cells[3].FormattedValue.ToString();
                int.TryParse(level, out int lev);
                if (lev > (int)UserManager.Instance.CurrentUser.level)
                {
                    continue;
                }
                List<User> users = UserManager.Instance.users.Where((x) => x.EmpNo == empNo).ToList();
                if (users.Count > 0)
                {
                    users[0].name = name;
                    users[0].pass = pass;
                    if (users[0] != UserManager.Instance.CurrentUser)
                    {
                        users[0].level = (Level)lev;
                    }
                }
            }
            UserManager.Instance.Save();
            Search();
        }

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.SelectedRows.Count > 0)
            {
                int index = kryptonDataGridView1.SelectedRows[0].Index;
                string empNo = kryptonDataGridView1.Rows[index].Cells[0].FormattedValue.ToString();
                List<User> users = UserManager.Instance.users.Where((x) => x.EmpNo == empNo).ToList();
                if (users.Count > 0)
                {
                    if (users[0] == UserManager.Instance.CurrentUser)
                    {
                        MessageBox.Show("不可删除当前用户".tr());
                        return;
                    }
                    UserManager.Instance.users.Remove(users[0]);
                }
                UserManager.Instance.Save();
                Search();
            }
        }

        private void Search()
        {
            kryptonDataGridView1.Rows.Clear();
            kryptonDataGridView1.Rows.Add
                       (
                       UserManager.Instance.CurrentUser.EmpNo,
                       UserManager.Instance.CurrentUser.name,
                       UserManager.Instance.CurrentUser.pass,
                       (int)UserManager.Instance.CurrentUser.level
                       );
            for (int i = 0; i < UserManager.Instance.users.Count; i++)
            {
                if (UserManager.Instance.users[i].level < UserManager.Instance.CurrentUser.level)
                {
                    kryptonDataGridView1.Rows.Add
                        (
                        UserManager.Instance.users[i].EmpNo,
                        UserManager.Instance.users[i].name,
                        UserManager.Instance.users[i].pass,
                          (int)UserManager.Instance.users[i].level
                        );
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comLevel.Text) || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("信息不全".tr());
                return;
            }

            User user = new User();
            user.level = (Level)comLevel.SelectedIndex;
            user.name = txtUserName.Text;
            user.pass = txtPass.Text;
            if (UserManager.Instance.users.Where(x => x.name == user.name && x.pass == user.pass && user.level == x.level).ToList().Count > 0)
            {
                MessageBox.Show("登录成功".tr());
                UserManager.Instance.CurrentUser = UserManager.Instance.users.Where(x => x.name == user.name).First();
            }
            else
            {
                MessageBox.Show("登录失败".tr());
            }
            Search();
        }
    }
}
