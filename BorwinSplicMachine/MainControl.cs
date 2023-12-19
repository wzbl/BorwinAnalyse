using BorwinAnalyse.UCControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinSplicMachine
{
    public class MainControl
    {
        public UCMain UCMain { get; set; }
        public UCBOM UCBOM { get; set; }
        public UCParam UCParam { get; set; }

        public UCSearchBom UCSearchBom { get; set; }

        public UCSearchLanguage UCSearchLanguage { get; set; }

        public UCAnalyseSet UCAnalyseSet { get; set; }
        public UCControls.UCBaseSet UCBaseSet { get; set; }

        public MainControl()
        {
            UCBOM = new UCBOM();
            UCParam = new UCParam();
            UCSearchLanguage = new UCSearchLanguage();
            UCSearchBom = new UCSearchBom();
            UCAnalyseSet = new UCAnalyseSet();
            UCMain=new UCMain();
            UCBaseSet=new UCControls.UCBaseSet();
        }
    }
}
