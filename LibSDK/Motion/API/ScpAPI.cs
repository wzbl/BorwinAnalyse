using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.Motion
{
    public class ScpAPI
    {
        private readonly BoardSwitchCs Scp = new BoardSwitchCs();

        public bool ScptIni(int instIdx, short cardNum)
        {
           return  Scp.API.ScptIni(instIdx, cardNum);
        }
        public bool ScpDownLoad(int idx, string filepath, short Autorun)
        {
           return Scp.API.ScpDownLoad(idx, filepath, 1);
        }
        public  bool ScpRun(int idx, int flag)
        {
            return Scp.API.ScpRun(idx, flag);
        }

        public bool ScpSetGlobalVarValue(int idx, string pVarName, double value)
        {
            return Scp.API.ScpSetGlobalVarValue((int)idx, pVarName, value);
        }
        public double ScpGetGlobalVarValue(int idx, string pVarName)
        {
            return Scp.API.ScpGetGlobalVarValue((int)idx, pVarName);
        }
    }
}
