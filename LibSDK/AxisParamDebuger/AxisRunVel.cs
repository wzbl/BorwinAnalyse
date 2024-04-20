using BorwinAnalyse.BaseClass;
using LibSDK.Motion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibSDK.AxisParamDebuger
{
    /// <summary>
    /// 轴运行速度
    /// </summary>
    public class AxisRunVel
    {
        private static AxisRunVel instance;
        public static AxisRunVel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AxisRunVel();
                }
                return instance;
            }
        }

        #region 轴
        public  AxisRunParam 流道调宽 = new AxisRunParam();
        public  AxisRunParam 凸轮 = new AxisRunParam();
        public  AxisRunParam 左进入 = new AxisRunParam();
        public  AxisRunParam 右进入 = new AxisRunParam();
        public  AxisRunParam 吸头平移 = new AxisRunParam();
        public  AxisRunParam 吸头上下 = new AxisRunParam();
        public  AxisRunParam 热熔上下 = new AxisRunParam();
        public  AxisRunParam 拨刀 = new AxisRunParam();
        public  AxisRunParam 卷料 = new AxisRunParam();

        public  AxisRunParam 探针A = new AxisRunParam();
        public  AxisRunParam 测值整体上下 = new AxisRunParam();
        public  AxisRunParam 探针B = new AxisRunParam();
        public  AxisRunParam 下针 = new AxisRunParam();
        #endregion

        /// <summary>
        /// 加载参数
        /// </summary>
        public void Load()
        {
            string savePath = @"Ini/AxisRunVel.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            else
            {
                instance = JsonConvert.DeserializeObject<AxisRunVel>(File.ReadAllText(savePath));
            }
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        public void Save()
        {
            string savePath = @"Ini/AxisRunVel.json";
            if (!File.Exists(savePath))
            {
                FileStream fs1 = new FileStream(savePath, FileMode.Create, FileAccess.ReadWrite);
                fs1.Close();
            }
            File.WriteAllText(savePath, JsonConvert.SerializeObject(instance));
        }
    }

    [Serializable]
    public class AxisRunParam
    {
        /// <summary>
        /// 速度
        /// </summary>
        public double Sped;
        /// <summary>
        /// 加速度
        /// </summary>
        public double Acc;
    }

}
