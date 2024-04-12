using BorwinSplicMachine;
using ComponentFactory.Krypton.Toolkit;
using FeederSpliceVisionSys;
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
            Init();
        }

        private void Init()
        {
            try
            {
                //VisionDetection.set_ImageShowUIPanel(Station.LiftStation, pL);
                //VisionDetection.set_ImageShowUIPanel(Station.RightStation, pR);
                //VisionDetection.set_ImageShowUIPanel(Station.MeasureStation, pM);

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

        /// <summary>
        /// 完成事件
        /// </summary>
        /// <param name="_Station"></param>
        /// <param name="Result"></param>
        public void DetectionCompleted(Station _Station, MyResult Result)
        {
            switch (Result.DetectionType)
            {
                case  MyDetectionType.Detection_CutPos:
                    {
                        switch (_Station)
                        {
                            case  Station.LiftStation:
                                {
                                    //Listinfo("1#相机裁切位置检测完成");
                                    if (Result.Result == MyDetectionResult.NoProduct)
                                    {
                                        Form1.MainControl.motControl.FlowLeft = MainFlow.找空料NG;
                                        //Listinfo("1#未检测到产品，需移动料带");
                                        return;
                                    }
                                    else if (Result.Result == MyDetectionResult.Error_)
                                    {
                                        Form1.MainControl.motControl.FlowLeft = MainFlow.找空料NG;
                                        //Listinfo("1#检测异常");
                                        return;
                                    }
                                    else if (Result.Result == MyDetectionResult.CreateModel)
                                    {
                                        Form1.MainControl.motControl.FlowLeft = MainFlow.找空料NG;
                                        //Listinfo("1#弹出创建模板界面");
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
                                    string str = "产品尺寸：" + productsize + " 裁切位置:" + CutPosValue;
                                    ListInfo(str);
                                    if (Result.OCVEnabled)
                                    {
                                        if (Result.OCVResult == false)
                                        {
                                            //Listinfo("弹出OCV图片显示及人工确认界面");
                                        }

                                    }

                                    break;
                                }

                            case  Station.RightStation:
                                {
                                    break;
                                }
                        }

                        break;
                    }

                case  MyDetectionType.Detection_DockPos:
                    {
                        switch (_Station)
                        {
                            case  Station.LiftStation:
                                {
                                    //Listinfo("1#相机位置补偿检测完成");
                                    if (Result.Result == MyDetectionResult.Error_)
                                    {
                                        //Listinfo("1#检测异常");
                                        return;
                                    }
                                    double DockPosValue = Result.DockPosValue;
                                    MotControl.leftDockPos= DockPosValue;
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

                case  MyDetectionType.Detection_CheckMaterial:
                    {
                        switch (_Station)
                        {
                            case  Station.LiftStation:
                                {
                                    if (Result.CheckMaterialResult)
                                        ListInfo("1#检测到有料带");
                                    else
                                        ListInfo("1#检测到无料带");
                                    VisionDetection.Detection_CheckMaterial_Stop(curStation );
                                    break;
                                }

                            case  Station.RightStation:
                                {
                                    break;
                                }
                        }

                        break;
                    }

                case  MyDetectionType.Detection_PositionOffset:
                    {
                        if (Result.Result == MyDetectionResult.Accept)
                        {
                            //Listinfo("3#检测完成");
                            double PositionOffsetValue = Result.PositionOffsetValue;
                            return;
                        }

                        break;
                    }
            }
        }


        private void UCVisor_Load(object sender, EventArgs e)
        {
         
        }

        private void btnLSoftTrigger_Click(object sender, EventArgs e)
        {
            if (btnLSoftTrigger.BackColor == Color.Lime)
            {
                btnLSoftTrigger.BackColor = Color.White;
                MyCameraTriggerModel myCameraTriggerModel = VisionDetection.get_CameraTriggerModel(Station.LiftStation); myCameraTriggerModel = MyCameraTriggerModel.SoftTrigger;
            }
            else
            {
                btnLSoftTrigger.BackColor = Color.Lime;
                MyCameraTriggerModel myCameraTriggerModel = VisionDetection.get_CameraTriggerModel(Station.LiftStation); myCameraTriggerModel = MyCameraTriggerModel.ContinueTrigger;
            }

        }

        private void btnRSoftTrigger_Click(object sender, EventArgs e)
        {
            if (btnRSoftTrigger.BackColor == Color.Lime)
            {
                btnRSoftTrigger.BackColor = Color.White;
                MyCameraTriggerModel myCameraTriggerModel = VisionDetection.get_CameraTriggerModel(Station.RightStation); myCameraTriggerModel = MyCameraTriggerModel.SoftTrigger;
            }
            else
            {
                btnRSoftTrigger.BackColor = Color.Lime;
                MyCameraTriggerModel myCameraTriggerModel = VisionDetection.get_CameraTriggerModel(Station.RightStation); myCameraTriggerModel = MyCameraTriggerModel.ContinueTrigger;
            }
        }

        private void btnMSoftTrigger_Click(object sender, EventArgs e)
        {
            if (btnMSoftTrigger.BackColor == Color.Lime)
            {
                btnMSoftTrigger.BackColor = Color.White;
                MyCameraTriggerModel myCameraTriggerModel = VisionDetection.get_CameraTriggerModel(Station.MeasureStation); myCameraTriggerModel = MyCameraTriggerModel.SoftTrigger;
            }
            else
            {
                btnMSoftTrigger.BackColor = Color.Lime;
                MyCameraTriggerModel myCameraTriggerModel = VisionDetection.get_CameraTriggerModel(Station.MeasureStation); myCameraTriggerModel = MyCameraTriggerModel.ContinueTrigger;
            }
        }

        private void btnLTriggle_Click(object sender, EventArgs e)
        {
            VisionDetection.CameraSnapAnImage(Station.LiftStation);
        }

        private void btnRTriggle_Click(object sender, EventArgs e)
        {
            VisionDetection.CameraSnapAnImage(Station.RightStation);
        }

        private void btnMTriggle_Click(object sender, EventArgs e)
        {
            VisionDetection.CameraSnapAnImage(Station.MeasureStation);
        }

        private void btnCutPos1_Click(object sender, EventArgs e)
        {
            VisionDetection.Detection_CutPos(Station.LiftStation);
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
            VisionDetection.Detection_DockPos(Station.LiftStation);
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
                VisionDetection.Detection_CheckMaterial_Stop(Station.LiftStation);
            }
            else
            {
                btnCheckMaterial1.BackColor = Color.Lime;
                VisionDetection.Detection_CheckMaterial_Start(Station.LiftStation);
            }

        }

        private void btnCheckMaterial2_Click(object sender, EventArgs e)
        {
            if (btnCheckMaterial2.BackColor == Color.Lime)
            {
                btnCheckMaterial1.BackColor = Color.White;
                VisionDetection.Detection_CheckMaterial_Stop(Station.RightStation);
            }
            else
            {
                btnCheckMaterial2.BackColor = Color.Lime;
                VisionDetection.Detection_CheckMaterial_Start(Station.RightStation);
            }
        }

        private void btnSetMaterialNumber_Click(object sender, EventArgs e)
        {
            //  If SetMaterialNumber("123459789", ComboBox9.SelectedIndex) = MyCheckMaterialNumberResult.ChangedLight Then
            //Dim llight As MyLightLevel = LightParameter(Station.LiftStation)
            //  Dim rlight As MyLightLevel = LightParameter(Station.RightStation)

            MyCheckMaterialNumberResult res = VisionDetection.SetMaterialNumber("445555", MyTapeWidthType.M8);
            ListInfo("调整光源");
        }

        public void ListInfo(string s)
        {

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

        private void SetStationData()
        {
            VisionDetection.set_ShowDrawRegionUIPanel(curStation, currentP);
            double cirradius=0, pixelsize=0;
            VisionDetection. GetPixelCalibrationParameter(curStation,ref cirradius,ref pixelsize);
            txtRadus.Text = cirradius.ToString();
            txtPix.Text = pixelsize.ToString();

            MyCameraParameter MyCameraParameter_ = VisionDetection.get_CameraParameter(curStation);
            txtFirstExposureTime.Text = MyCameraParameter_.FirstExposureTime.ToString();
            txtSecondExposureTime.Text = MyCameraParameter_.SecondExposureTime.ToString();
            txtDefaultLight.Text = VisionDetection.get_DefaultBacklightLevel(curStation).ToString();
            MyLightLevel MyLightLevel_ = VisionDetection.get_LightParameter(curStation);
            if (MyLightLevel_!=null)
            {
                comLight.SelectedIndex = (int)MyLightLevel_.SelectLightSource;
                txtBacklight.Text = MyLightLevel_.BacklightLevel.ToString();
                txtFrontlight.Text = MyLightLevel_.FrontlightLevel.ToString();
            }
            MyMaterialDetection MyMaterialDetection_ = VisionDetection.get_CheckMaterialParameter (curStation);
            if (MyMaterialDetection_!=null)
            {
                txtGrayMax.Text = MyMaterialDetection_.GrayMax.ToString();
                txtArea.Text = MyMaterialDetection_.Area.ToString();
            }
            
            SetModelData();


        }


        private void btnSetCurrentCameraNum_Click(object sender, EventArgs e)
        {
            VisionDetection.set_CameraSerialNum((Station)comSelectCamera.SelectedIndex + 1, comCameraNum.Text);
        }

        private void btnFirstExproseTime_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtFirstExposureTime.Text, out int exposureTime))
            {
                VisionDetection.SetCameraExposureTime(curStation, exposureTime);
            }

        }

        private void btnSecendExproseTime_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSecondExposureTime.Text, out int exposureTime))
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

        private void btnTriggle_Click(object sender, EventArgs e)
        {
            if (btnTriggle.BackColor == Color.Lime)
            {
                MyCameraTriggerModel myCameraTrigger = VisionDetection.get_DrawRegionCameraTriggerModel(curStation);
                myCameraTrigger = MyCameraTriggerModel.SoftTrigger;
                btnTriggle.BackColor = Color.White;
            }
            else
            {
                btnTriggle.BackColor = Color.Lime;
                MyCameraTriggerModel myCameraTrigger = VisionDetection.get_DrawRegionCameraTriggerModel(curStation);
                myCameraTrigger = MyCameraTriggerModel.ContinueTrigger;
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
            MyCameraParameter_.FirstExposureTime = int.Parse(txtFirstExposureTime.Text);
            MyCameraParameter_.SecondExposureTime = int.Parse(txtSecondExposureTime.Text);
            VisionDetection.set_DefaultBacklightLevel(curStation, int.Parse(txtDefaultLight.Text));
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
    }
}
