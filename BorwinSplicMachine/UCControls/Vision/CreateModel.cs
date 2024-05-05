using ComponentFactory.Krypton.Toolkit;
using FeederSpliceVisionSys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BorwinSplicMachine.UCControls.Vision
{
    public partial class CreateModel : KryptonForm
    {
       
        public CreateModel()
        {
            InitializeComponent();
        }

        ModelType mCurModel = ModelType.ProductModel;
        Station curStation = Station.None;

        public void DrawRegion(KryptonButton btn, RegionType regionType)
        {
            if (btn.Enabled)
            {
                btn.Enabled = false;
                VisionDetection.SaveModelRegion(curStation, mCurModel, regionType);
            }
            else
            {
                VisionDetection.DrawModelRegion(curStation, mCurModel, regionType);
                btn.BackColor = Color.Lime;
            }
        }

        public void GetModelData()
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

        private void SetModelData()
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            mCurModel = ModelType.ProductModel;
            SetModelData();
        }
    }
}
