using BorwinAnalyse.BaseClass;
using Mes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.Load += FormLogin_Load;
            this.FormClosed += FormLogin_FormClosed;
            comLevel.SelectedIndex = 0;
            if (UserManager.Instance.CurrentUser == null || UserManager.Instance.CurrentUser.level == Level.Oprator)
            {
                btnRegi.Visible = false;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #region 窗体移动

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//标签是否为左键



        private void Frm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void Frm_MouseMove(object sender, MouseEventArgs e)
        {

            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void Frm_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }


        #endregion

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UserManager.Instance.Load();
            if (UserManager.Instance.users.Count == 0)
            {
                User user = new User();
                user.EmpNo = UserManager.Instance.users.Count.ToString();
                user.name = "Admin";
                user.pass = "Admin";
                user.level = Level.Admin;
                UserManager.Instance.users.Add(user);
                UserManager.Instance.Save();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;
            if (progressBar1.Value >= 100)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (progressBar1.Value > 10 && !Form1.MainControl.IsInitFinish)
            {
                Form1.MainControl.Init();
                timer1.Stop();
            }
            else if (progressBar1.Value > 70 && !Form1.MainControl.IsStartFinish)
            {
                Form1.MainControl.Start();
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
            user.EmpNo = UserManager.Instance.users.Count.ToString();
            user.name = txtUserName.Text;
            user.pass = txtPass.Text;
            if (UserManager.Instance.users.Where(x => x.name == user.name && x.pass == user.pass && user.level == x.level).ToList().Count > 0)
            {
                if (UserManager.Instance.CurrentUser == null)
                {
                    timer1.Start();
                    progressBar1.Visible = true;
                }
                else
                {
                    if (user.level < Level.Admin)
                    {
                        btnRegi.Visible = false;
                    }
                    else
                    {
                        btnRegi.Visible = true;
                    }
                    MessageBox.Show("登录成功".tr());
                }
                UserManager.Instance.CurrentUser = UserManager.Instance.users.Where(x => x.name == user.name).First();
            }
            else
            {
                MessageBox.Show("登录失败".tr());
            }

        }

        private void btnRegi_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }



        private void txtUserName_MouseDown(object sender, MouseEventArgs e)
        {
            Process kbpr = System.Diagnostics.Process.Start("osk.exe"); // 打开系统键盘
            if (!kbpr.HasExited)
            {
                kbpr.Kill();
            }

        }


        private void btnOSK_Click(object sender, EventArgs e)
        {
            Form1.OSKPro();
        }
    }


}
