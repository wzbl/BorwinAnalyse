using BorwinAnalyse.BaseClass;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BorwinSplicMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            BorwinAnalyse.Forms.AnalyseMainForm analyseMainForm = new BorwinAnalyse.Forms.AnalyseMainForm();
            analyseMainForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //foreach (Component NextComponent in this.components.Components)
            //{
            //    KryptonContextMenu NextComponen = (KryptonContextMenu)NextComponent;
            //    //进行处理
            //}
        }

      
    }
}
