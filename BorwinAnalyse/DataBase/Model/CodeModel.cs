using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwinAnalyse.DataBase.Model
{
    /// <summary>
    /// 条码
    /// </summary>
    public class CodeModel
    {
        /// <summary>
        /// 结果
        /// </summary>
        public bool Result {  get; set; }

        /// <summary>
        /// 条码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// MesCode,当mes上条码与Code不同时
        /// </summary>
        public string MESCode {  get; set; }

        /// <summary>
        /// 校验条码
        /// </summary>
        /// <returns></returns>
        public bool CheckCode()
        {
            return true;
        }
    }
}
