using BorwinAnalyse.BaseClass;
using BorwinAnalyse.DataBase.Model;
using BorwinSplicMachine;
using ComponentFactory.Krypton.Toolkit;
using FeederSpliceVisionSys;
using LibSDK;
using PdfSharp.Charting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace VisionModel.UCControls
{
    public partial class UCVisor : UserControl
    {
        public UCVisor()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += UCVisor_Load;
            VisionDetection.EventDetectionCompleted += DetectionCompleted;
        }

        private void Init()
        {
            try
            {
                string[] strings = VisionDetection.GetCameraSerialNums;
                for (int i = 0; i < strings.Length; i++)
                {
                    comCameraNum.Items.Add(strings[i]);
                }
            }
            catch (Exception)
            {

            }
        }
        public void Log(string message)
        {
            LogManager.Instance.WriteLog(new LogModel(LogType.相机日志, message));
        }

        int cont = 0;
        /// <summary>
        /// 完成事件
        /// </summary>
        /// <param name="_Station"></param>
        /// <param name="Result"></param>
        public void DetectionCompleted(Station _Station, MyResult Result)
        {
            switch (Result.DetectionType)
            {
                case MyDetectionType.Detection_CutPos:
                    {
                        switch (_Station)
                        {
                            case Station.LiftStation:
                                {
                                    Log("1#相机裁切位置检测完成" + Result.TapeType.ToString());
                                    if (Result.Result == MyDetectionResult.NoProduct)
                                    {
                                        Form1.MainControl.motControl.FlowLeft = MainFlow.找空料NG;
                                        Log("1#未检测到产品，需移动料带");
                                        return;
                                    }
                                    else if (Result.Result == MyDetectionResult.Error_)
                                    {
                                        Form1.MainControl.motControl.FlowLeft = MainFlow.找空料NG;
                                        Log("1#检测异常");
                                        return;
                                    }
                                    else if (Result.Result == MyDetectionResult.CreateModel)
                                    {
                                        if (cont>=2)
                                        {
                                            return;
                                        }
                                        VisiTest visiTest = new VisiTest();
                                        visiTest.ShowDialog();
                                        cont++;
                                        VisionDetection.Detection_CutPos(Station.LiftStation);
                                        Log("1#弹出创建模板界面");
                                        return;
                                    }
                                
                                    Form1.MainControl.motControl.FlowLeft = MainFlow.找空料OK;
                                    MotControl.leftCutPos = Result.CutPosValue;
                                    // 产品尺寸
                                    SizeF productsize = Result.Size;
                                    // 裁切位置
                                    double CutPosValue = Result.CutPosValue;
                                    // 料带类型
                                    MyTapeType TapeType = Result.TapeType;
                                    // 料带宽度
                                    MyTapeWidthType TapeWidthType = Result.TapeWidthType;
                                    // 物料间距
                                    MyProductSpacingType ProductSpacingType = Result.ProductSpacingType;
                                    Log("物料间距" + ProductSpacingType.ToString());
                                    Log("找空料OK");
                                    cont = 0;
                                    if (Result.OCVEnabled)
                                    {
                                        if (Result.OCVResult == false)
                                        {
                                            Log("弹出OCV图片显示及人工确认界面");
                                        }

                                    }

                                    break;
                                }

                            case Station.RightStation:
                                {
                                    break;
                                }
                        }

                        break;
                    }

                case MyDetectionType.Detection_DockPos:
                    {
                        switch (_Station)
                        {
                            case Station.LiftStation:
                                {
                                    Log("1#相机位置补偿检测完成");
                                    if (Result.Result == MyDetectionResult.Error_)
                                    {
                                        Log("1#检测异常");
                                        return;
                                    }
                                    double DockPosValue = Result.DockPosValue;
                                    MotControl.leftDockPos = DockPosValue;
                                    Form1.MainControl.motControl.FlowLeft = MainFlow.空料补偿完成;

                                    break;
                                }

                            case Station.RightStation:
                                {
                                    break;
                                }
                        }

                        break;
                    }

                case MyDetectionType.Detection_CheckMaterial:
                    {
                        switch (_Station)
                        {
                            case Station.LiftStation:
                                {
                                    if (Result.CheckMaterialResult)
                                        Log("1#检测到有料带");
                                    else
                                        Log("1#检测到无料带");
                                    VisionDetection.Detection_CheckMaterial_Stop(curStation);
                                    break;
                                }

                            case Station.RightStation:
                                {
                                    break;
                                }
                        }

                        break;
                    }

                case MyDetectionType.Detection_PositionOffset:
                    {
                        if (Result.Result == MyDetectionResult.Accept)
                        {
                            Log("3#检测完成");
                            double PositionOffsetValue = Result.PositionOffsetValue;
                            return;
                        }

                        break;
                    }
            }
        }


        private void UCVisor_Load(object sender, EventArgs e)
        {
            Init();
        }

     

        private void btnCutPos1_Click(object sender, EventArgs e)
        {
            VisionDetection.Detection_CutPos(curStation);
        }

        private void btnCutPos2_Click(object sender, EventArgs e)
        {
            VisionDetection.Detection_CutPos(Station.RightStation);
        }

        private void btnPositionOffset_Click(object sender, EventArgs e)
        {
            VisionDetection.Detecting_PositionOffset();
        }

        private void btnDockPos1_Click(object sender, EventArgs e)
        {
            VisionDetection.Detection_DockPos(curStation);
        }

        private void btnDockPos2_Click(object sender, EventArgs e)
        {
            VisionDetection.Detection_DockPos(Station.RightStation);
        }

        private void btnCheckMaterial1_Click(object sender, EventArgs e)
        {
            if (btnCheckMaterial1.BackColor == Color.Lime)
            {
                btnCheckMaterial1.BackColor = Color.White;
                VisionDetection.Detection_CheckMaterial_Stop(curStation);
            }
            else
            {
                btnCheckMaterial1.BackColor = Color.Lime;
                VisionDetection.Detection_CheckMaterial_Start(curStation);
            }

        }


        private void btnSetMaterialNumber_Click(object sender, EventArgs e)
        {
            MyCheckMaterialNumberResult res = VisionDetection.SetMaterialNumber("445555", MyTapeWidthType.M8);
        }

        Station curStation = Station.None;
        ModelType mCurModel = ModelType.None;
        private void comSelectCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comSelectCamera.SelectedIndex)
            {
                case 0:
                    comCameraNum.Text = VisionDetection.get_CameraSerialNum(Station.LiftStation);
                    VisionDetection.ShowImage(Station.LiftStation, MyShowImage.CurrentImage, ModelType.None);
                    VisionDetection.set_ShowDrawRegionUIPanel(Station.LiftStation, currentP);
                    curStation = Station.LiftStation;
                    break;
                case 1:
                    comCameraNum.Text = VisionDetection.get_CameraSerialNum(Station.RightStation);
                    VisionDetection.ShowImage(Station.RightStation, MyShowImage.CurrentImage, ModelType.None);
                    VisionDetection.set_ShowDrawRegionUIPanel(Station.RightStation, currentP);
                    curStation = Station.RightStation;
                    break;
                case 2:
                    comCameraNum.Text = VisionDetection.get_CameraSerialNum(Station.MeasureStation);
                    VisionDetection.ShowImage(Station.MeasureStation, MyShowImage.CurrentImage, ModelType.None);
                    VisionDetection.set_ShowDrawRegionUIPanel(Station.MeasureStation, currentP);
                    curStation = Station.MeasureStation;
                    break;
                default:
                    comCameraNum.Text = VisionDetection.get_CameraSerialNum(Station.None);
                    curStation = Station.None;
                    break;
            }

            SetStationData();
        }
        /// <summary>
        /// 切换相机，获取值
        /// </summary>
        private void SetStationData()
        {
            VisionDetection.set_ShowDrawRegionUIPanel(curStation, currentP);
            double cirradius = 0, pixelsize = 0;
            VisionDetection.GetPixelCalibrationParameter(curStation, ref cirradius, ref pixelsize);
            txtRadus.Text = cirradius.ToString();
            txtPix.Text = pixelsize.ToString();

            MyCameraParameter MyCameraParameter_ = VisionDetection.get_CameraParameter(curStation);
            txt透明曝光值.Text = MyCameraParameter_.ExposureTimeTransTape.ToString();
            txt纸料带曝光.Text = MyCameraParameter_.ExposureTimePaperTape.ToString();
            txt黑料带曝光.Text = MyCameraParameter_.ExposureTimeBlackTape.ToString();
            MyLightLevel MyLightLevel_ = VisionDetection.get_LightParameter(curStation);
            if (MyLightLevel_ != null)
            {
                comLight.SelectedIndex = (int)MyLightLevel_.SelectLightSource;
                txtBacklight.Text = MyLightLevel_.BacklightLevel.ToString();
                txtFrontlight.Text = MyLightLevel_.FrontlightLevel.ToString();
            }
            MyMaterialDetection MyMaterialDetection_ = VisionDetection.get_CheckMaterialParameter(curStation);
            if (MyMaterialDetection_ != null)
            {
                txtGrayMax.Text = MyMaterialDetection_.GrayMax.ToString();
                txtArea.Text = MyMaterialDetection_.Area.ToString();
            }

            SetModelData();
            double CircleLift = 0;
            double CircleMid = 0;
            double Circle2Mid = 0;
            VisionDetection.GetStandardDistance(curStation, ref CircleLift, ref CircleMid, ref Circle2Mid);
            txt孔边.Text = CircleLift.ToString();
            txt孔中心.Text = CircleMid.ToString();
            txt两孔之间.Text = Circle2Mid.ToString();

             MyGray myGray =  VisionDetection.get_TapeGrayParameter(curStation);
            txt透明Low.Text = myGray.TransTapeGrayMin.ToString();
            txt透明High.Text = myGray.TransTapeGrayMax.ToString();
            txt纸Low.Text = myGray.PaperTapeGrayMin.ToString();
            txt纸High.Text = myGray.PaperTapeGrayMax.ToString();
            txt黑Low.Text = myGray.BlackTapeGrayMin.ToString();
            txt黑High.Text = myGray.BlackTapeGrayMax.ToString();
        }


        private void btnSetCurrentCameraNum_Click(object sender, EventArgs e)
        {
            VisionDetection.set_CameraSerialNum((Station)comSelectCamera.SelectedIndex + 1, comCameraNum.Text);
        }

        private void btnFirstExproseTime_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt透明曝光值.Text, out int exposureTime))
            {
                VisionDetection.SetCameraExposureTime(curStation, exposureTime);
            }

        }

        private void btnSecendExproseTime_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt纸料带曝光.Text, out int exposureTime))
            {
                VisionDetection.SetCameraExposureTime(curStation, exposureTime);
            }
        }

        public void DrawRegion(KryptonButton btn, RegionType regionType)
        {
            if (btn.BackColor == Color.Lime)
            {
                btn.BackColor = Color.White;
                VisionDetection.SaveModelRegion(curStation, mCurModel, regionType);
            }
            else
            {
                VisionDetection.DrawModelRegion(curStation, mCurModel, regionType);
                btn.BackColor = Color.Lime;
            }
            btn.Enabled = true;
        }

        private void btnDrawRegion_Click(object sender, EventArgs e)
        {
            DrawRegion(btnDrawRegion, RegionType.PixelCalibrationCircle);
        }

        private void btnCalculatePixel_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtRadus.Text, out double r))
            {
                double pix = VisionDetection.CalculatePixelCalibrationParameters(curStation, r);
                txtPix.Text = pix.ToString();
            }

        }


        private void btnSaveSysPara_Click(object sender, EventArgs e)
        {
            VisionDetection.SaveImageModel = chkSaveImg.Checked;
            GetStationData();
            VisionDetection.SaveSystemData();
        }

        private void GetStationData()
        {
            VisionDetection.SetPixelCalibrationParameter(curStation, double.Parse(txtRadus.Text), double.Parse(txtPix.Text));

            MyCameraParameter MyCameraParameter_ = new MyCameraParameter();
            MyCameraParameter_.ExposureTimeTransTape = int.Parse(txt透明曝光值.Text);
            MyCameraParameter_.ExposureTimePaperTape = int.Parse(txt纸料带曝光.Text);
            MyCameraParameter_.ExposureTimeBlackTape = int.Parse(txt黑料带曝光.Text);
            MyLightLevel MyLightLevel_ = new MyLightLevel();
            MyLightLevel_.SelectLightSource = (LightSource)comLight.SelectedIndex;
            MyLightLevel_.BacklightLevel = int.Parse(txtBacklight.Text);
            MyLightLevel_.FrontlightLevel = int.Parse(txtFrontlight.Text);
            VisionDetection.set_CameraParameter(curStation, MyCameraParameter_);
            VisionDetection.set_LightParameter(curStation, MyLightLevel_);


            MyMaterialDetection MyMaterialDetection_ = new MyMaterialDetection();
            MyMaterialDetection_.GrayMax = double.Parse(txtGrayMax.Text);
            MyMaterialDetection_.Area = double.Parse(txtArea.Text);
            VisionDetection.set_CheckMaterialParameter(curStation, MyMaterialDetection_);
            VisionDetection.SetStandardDistance(curStation, double.Parse(txt孔边.Text), double.Parse(txt孔中心.Text), double.Parse(txt两孔之间.Text));
            MyGray myGray =new MyGray();
            myGray.TransTapeGrayMin = int.Parse(txt透明Low.Text);
            myGray.TransTapeGrayMax = int.Parse(txt透明High.Text);
            myGray.PaperTapeGrayMin = int.Parse(txt纸Low.Text);
            myGray.PaperTapeGrayMax = int.Parse(txt纸High.Text);
            myGray.BlackTapeGrayMin = int.Parse(txt黑Low.Text);
            myGray.BlackTapeGrayMax = int.Parse(txt黑High.Text);
            VisionDetection.set_TapeGrayParameter(curStation,myGray);
        }

        private void btnSaveProPara_Click(object sender, EventArgs e)
        {
            GetProductData();
            GetStationData();
            VisionDetection.SaveModelData();
        }

        private void GetProductData()
        {
            MyProductData _ProductData = new MyProductData();
            _ProductData.TapeWidth = (MyTapeWidthType)comTapeWidth.SelectedIndex;
            _ProductData.TapeType = (MyTapeType)comTapeType.SelectedIndex;
            _ProductData.ProductSpacingType = (MyProductSpacingType)comProductSpacingType.SelectedIndex;
            VisionDetection.ProductData = _ProductData;
        }

        private void btnRegionSearch_Click(object sender, EventArgs e)
        {
            DrawRegion(btnRegionSearch, RegionType.FindCircleRegion);
        }

        private void btnBaseLine_Click(object sender, EventArgs e)
        {
            DrawRegion(btnBaseLine, RegionType.BasicLine);
        }

        private void btnMaterialDetectionRegion_Click(object sender, EventArgs e)
        {
            DrawRegion(btnMaterialDetectionRegion, RegionType.MaterialDetectionRegion);
        }

        private void btnCurrentImg_Click(object sender, EventArgs e)
        {
            VisionDetection.ShowImage(curStation, MyShowImage.CurrentImage, ModelType.None);
        }

        private void btnModelTest_Click(object sender, EventArgs e)
        {
            mCurModel = ModelType.ProductModel;
            SetModelData();
        }

        private void SetModelData()
        {
            if (mCurModel == ModelType.Ocv)
            {
                MyOCVModelParameter OcvModelParameter_ = VisionDetection.get_OCVModelParameter(curStation, mCurModel);
                if (OcvModelParameter_ == null)
                {
                    return;
                }
                NUDStartAngle.Text = OcvModelParameter_.StartAngle.ToString();
                NUDEndAngle.Text = OcvModelParameter_.EndAngle.ToString();
                NUDContrast.Text = OcvModelParameter_.Contrast.ToString();
                NUDMatchThreshold.Text = OcvModelParameter_.MatchScore.ToString();
                NUDCountToFind.Text = OcvModelParameter_.CountToMatch.ToString();
                OCVScore.Text = OcvModelParameter_.OCVScore.ToString();
                chkEnable.Checked = OcvModelParameter_.Enabled;
                if (OcvModelParameter_.MatchMode == ModelMatchMode.QuickMode)
                    comSelectModel.SelectedIndex = 0;
                else
                    comSelectModel.SelectedIndex = 1;
            }
            else
            {
                MyModelParameter ModelParameter_ = VisionDetection.get_ModelParameter(curStation, mCurModel);
                if (ModelParameter_ == null)
                    return;

                comModelType.SelectedIndex = (int)ModelParameter_.ModelType;
                NUDStartAngle.Text = ModelParameter_.StartAngle.ToString();
                NUDEndAngle.Text = ModelParameter_.EndAngle.ToString(); ;
                NUDContrast.Text = ModelParameter_.Contrast.ToString(); ;
                NUDMatchThreshold.Text = ModelParameter_.MatchScore.ToString(); ;
                NUDCountToFind.Text = ModelParameter_.CountToMatch.ToString();
                if (ModelParameter_.MatchMode == ModelMatchMode.QuickMode)
                    comSelectModel.SelectedIndex = 0;
                else
                    comSelectModel.SelectedIndex = 1;

            }
        }

        private void btnOCVModel_Click(object sender, EventArgs e)
        {
            mCurModel = ModelType.Ocv;
            SetModelData();
        }

        private void btnTrainRegion_Click(object sender, EventArgs e)
        {
            DrawRegion(btnTrainRegion, RegionType.TrainRegion);
        }

        private void btnModelImg_Click(object sender, EventArgs e)
        {
            VisionDetection.ShowImage(curStation, MyShowImage.ModelImage, mCurModel);
        }

        private void btnMaskRegion_Click(object sender, EventArgs e)
        {
            DrawRegion(btnMaskRegion, RegionType.MaskRegion);
        }

        private void btnFindRegion_Click(object sender, EventArgs e)
        {
            DrawRegion(btnFindRegion, RegionType.FindRegion);
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            GetModelData();
            VisionDetection.RunTest(curStation, mCurModel);
        }



        public void GetModelData()
        {
            if (mCurModel == ModelType.Ocv)
            {
                MyOCVModelParameter ocvModelParameter_ = new MyOCVModelParameter();
                ocvModelParameter_.StartAngle = double.Parse(NUDStartAngle.Text);
                ocvModelParameter_.EndAngle = double.Parse(NUDEndAngle.Text);
                ocvModelParameter_.Contrast = double.Parse(NUDContrast.Text);
                ocvModelParameter_.MatchScore = int.Parse(NUDMatchThreshold.Text);
                ocvModelParameter_.CountToMatch = int.Parse(NUDCountToFind.Text);
                ocvModelParameter_.OCVScore = int.Parse(OCVScore.Text);
                ocvModelParameter_.Enabled = chkEnable.Checked;
                if (comSelectModel.SelectedIndex == 0)
                    ocvModelParameter_.MatchMode = ModelMatchMode.QuickMode;
                else
                    ocvModelParameter_.MatchMode = ModelMatchMode.MaxMode;
                VisionDetection.set_OCVModelParameter(curStation, mCurModel, ocvModelParameter_);
            }
            else
            {
                MyModelParameter ModelParameter_ = new MyModelParameter();
                ModelParameter_.StartAngle = double.Parse(NUDStartAngle.Text);
                ModelParameter_.EndAngle = double.Parse(NUDEndAngle.Text);
                ModelParameter_.Contrast = double.Parse(NUDContrast.Text);
                ModelParameter_.MatchScore = int.Parse(NUDMatchThreshold.Text);
                ModelParameter_.CountToMatch = int.Parse(NUDCountToFind.Text);
                ModelParameter_.ModelType = (MyModelType)comModelType.SelectedIndex;
                if (comSelectModel.SelectedIndex == 0)
                    ModelParameter_.MatchMode = ModelMatchMode.QuickMode;
                else
                    ModelParameter_.MatchMode = ModelMatchMode.MaxMode;

                VisionDetection.set_ModelParameter(curStation, mCurModel, ModelParameter_);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            GetModelData();
            if (!VisionDetection.Train(curStation, mCurModel))
                MessageBox.Show("训练失败");

        }

        private void btnOCVRegion_Click(object sender, EventArgs e)
        {
            DrawRegion(btnOCVRegion, RegionType.OCVRegion);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetModelData();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt黑料带曝光.Text, out int exposureTime))
            {
                VisionDetection.SetCameraExposureTime(curStation, exposureTime);
            }
        }
    }
}
