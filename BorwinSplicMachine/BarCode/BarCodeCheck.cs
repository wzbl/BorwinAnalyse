using BorwinAnalyse.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinSplicMachine.BarCode
{
    

    /// <summary>
    /// 条码校验
    /// </summary>
    public class BarCodeCheck
    {
        public CodeModel Code1=new CodeModel();
        public CodeModel Code2= new CodeModel();

        public virtual void CheckCode(ref string code)
        {
            if (ParamManager.Instance.条码校验_是否二维码分割.B)
            {
                string[] strings = code.Split(ParamManager.Instance.条码校验_分割符.S.ToCharArray()).ToArray();
                if (strings.Length > ParamManager.Instance.条码校验_索引位置.I + 1)
                {
                    code = strings[ParamManager.Instance.条码校验_索引位置.I];
                }
            }

            if (ParamManager.Instance.条码校验_是否删除前缀.B && code.Length >= ParamManager.Instance.条码校验_删除前缀长度.I)
            {
                code.Remove(0, ParamManager.Instance.条码校验_删除前缀长度.I);
            }

            if (ParamManager.Instance.条码校验_是否删除后缀.B && code.Length >= ParamManager.Instance.条码校验_删除后缀长度.I)
            {
                int startpos = code.Length - ParamManager.Instance.条码校验_删除后缀长度.I;
                code.Remove(startpos, ParamManager.Instance.条码校验_删除后缀长度.I);
            }

            if (ParamManager.Instance.条码校验_是否字符替换.B)
            {
                code.Replace(ParamManager.Instance.条码校验_原始字符.S, ParamManager.Instance.条码校验_替换为.S);
            }

            if (ParamManager.Instance.条码校验_是否字符大写.B)
            {
                code = code.ToUpper();
            }
        }
    }


    public class CodeModel
    {
        public bool IsSuccess;
        public string Code;
    }
}
