using BorwinAnalyse.BaseClass;
using MvCamCtrl.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionModel
{
    public class SplicCamera:MyCamera
    {
        public SplicCamera(ParamType paramType)
        {
               ParamData paramData5 = new ParamData(ParamType.CCD, "CCD", "2", "视觉");
        }
    }
}
