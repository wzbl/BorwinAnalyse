using BorwinAnalyse.UCControls;
using BorwinSplicMachine.LCR;
using BorwinSplicMachine.UCControls;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BorwinSplicMachine
{
    public class MainControl
    {
        public UCMain UCMain
        {
            get;
            set;
        }
        public UCBOM UCBOM { get; set; }
        public UCParam UCParam { get; set; }

        public UCSearchBom UCSearchBom { get; set; }

        public UCSearchLanguage UCSearchLanguage { get; set; }

        public UCAnalyseSet UCAnalyseSet { get; set; }
        public UCControls.UCBaseSet UCBaseSet { get; set; }
        public UCLog UCLog { get; set; }

        public UCLCR UCLCR { get; set; }
        Form1 MainForm;
        public MainControl(Form1 MainForm)
        {
            UCBOM = new UCBOM();
            UCParam = new UCParam();
            UCSearchLanguage = new UCSearchLanguage();
            UCSearchBom = new UCSearchBom();
            UCAnalyseSet = new UCAnalyseSet();
            UCMain = new UCMain();
            UCBaseSet = new UCControls.UCBaseSet();
            UCLog = new UCLog();
            UCLCR = new UCLCR();
            this.MainForm = MainForm;
        }


        public async void UpdataLanguage()
        {
            await asyncUpdataLanguage();
        }

        public async Task asyncUpdataLanguage()
        {
            await Task.Run(() =>
            {
                UCBOM.UpdataLanguage();
                UCParam.UpdataLanguage();
                UCSearchLanguage.UpdataLanguage();
                UCSearchBom.UpdataLanguage();
                UCAnalyseSet.UpdataLanguage();
                UCMain.UpdataLanguage();
                UCBaseSet.UpdataLanguage();
                MainForm.UpdataLanguage();
                UCLog.UpdataLanguage();
                UCLCR.UpdateLanguage();
            });
        }

    }
}
