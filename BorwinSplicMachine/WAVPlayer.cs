using BorwinAnalyse.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine
{
    public static class WAVPlayer
    {
        public enum playName
        {
            BOM解析成功,//The BOM is parsed successfully
            BOM解析失败,//BOM parsing failed
            OCR比对成功,//OCR comparison successful
            OCR比对失败, //OCR comparison is failed
            测值比对成功,//The measured value was successfully matched
            测值比对失败,//Measurement comparison failed
            测值完成,//The measurement is complete
            接料完成等待下一扫码,//After the receiving is completed, please take the material belt
            请扫条码,//Please scan the barcode
            条码1获取成功请扫条码2,//Barcode 1 is successful, please scan barcode 2
            条码比对成功,//Barcode comparison is successful; Please put in the strip
            条码比对失败,//Barcode comparison is failed
            Pass,
            Fail,
            合盘复扫,
            合盘完成,
            扫码成功1
        }

        static System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

        public static void Playerer(playName Name)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    sp.SoundLocation = Application.StartupPath + "\\wav\\" + Name.ToString().tr() + ".wav";
                    sp.Play();
                }
                );

            }
            catch
            {
              
            }
        }
    }
}
