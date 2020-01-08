using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DS_Gadget
{
    internal partial class GadgetTabGraphics : GadgetTab
    {
        public GadgetTabGraphics()
        {
            InitializeComponent();
        }

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            cbxFilter.Checked = Settings.FilterEnable;
            cbxBrightnessSync.Checked = Settings.FilterBrightnessSync;
            nudBrightnessR.Value = Settings.FilterBrightnessR;
            nudBrightnessG.Value = Settings.FilterBrightnessG;
            nudBrightnessB.Value = Settings.FilterBrightnessB;
            cbxContrastSync.Checked = Settings.FilterContrastSync;
            nudContrastR.Value = Settings.FilterContrastR;
            nudContrastG.Value = Settings.FilterContrastG;
            nudContrastB.Value = Settings.FilterContrastB;
            nudSaturation.Value = Settings.FilterSaturation;
            nudHue.Value = Settings.FilterHue;
        }

        public override void ResetTab()
        {
            if (Hook.Hooked)
            {
                if (!cbxMap.Checked)
                    Hook.DrawMap(true);
                if (!cbxCreatures.Checked)
                    Hook.DrawCreatures(true);
                if (!cbxObjects.Checked)
                    Hook.DrawObjects(true);
                if (!cbxSFX.Checked)
                    Hook.DrawSFX(true);

                if (!cbxSpriteMasks.Checked)
                    Hook.DrawSpriteMasks(true);
                if (!cbxSprites.Checked)
                    Hook.DrawSprites(true);
                if (!cbxDrawTrans.Checked)
                    Hook.DrawTrans(true);
                if (!cbxShadows.Checked)
                    Hook.DrawShadows(true);
                if (!cbxSpriteShadows.Checked)
                    Hook.DrawSpriteShadows(true);
                if (!cbxTextures.Checked)
                    Hook.DrawTextures(true);

                if (cbxBounding.Checked)
                    Hook.DrawBounding(false);
                if (cbxCompassLarge.Checked)
                    Hook.DrawCompassLarge(false);
                if (cbxCompassSmall.Checked)
                    Hook.DrawCompassSmall(false);
                if (cbxAltimeter.Checked)
                    Hook.DrawAltimeter(false);
                if (cbxNodes.Checked)
                    Hook.DrawNodes(false);

                if (Loaded)
                {
                    if (cbxFilter.Checked)
                        Hook.OverrideFilter(false);
                }
            }
        }

        public override void SaveTab()
        {
            Settings.FilterEnable = cbxFilter.Checked;
            Settings.FilterBrightnessSync = cbxBrightnessSync.Checked;
            Settings.FilterBrightnessR = nudBrightnessR.Value;
            Settings.FilterBrightnessG = nudBrightnessG.Value;
            Settings.FilterBrightnessB = nudBrightnessB.Value;
            Settings.FilterContrastSync = cbxContrastSync.Checked;
            Settings.FilterContrastR = nudContrastR.Value;
            Settings.FilterContrastG = nudContrastG.Value;
            Settings.FilterContrastB = nudContrastB.Value;
            Settings.FilterSaturation = nudSaturation.Value;
            Settings.FilterHue = nudHue.Value;
        }

        public override void ReloadTab()
        {
            if (!cbxMap.Checked)
                Hook.DrawMap(false);
            if (!cbxCreatures.Checked)
                Hook.DrawCreatures(false);
            if (!cbxObjects.Checked)
                Hook.DrawObjects(false);
            if (!cbxSFX.Checked)
                Hook.DrawSFX(false);

            if (!cbxSpriteMasks.Checked)
                Hook.DrawSpriteMasks(false);
            if (!cbxSprites.Checked)
                Hook.DrawSprites(false);
            if (!cbxDrawTrans.Checked)
                Hook.DrawTrans(false);
            if (!cbxShadows.Checked)
                Hook.DrawShadows(false);
            if (!cbxSpriteShadows.Checked)
                Hook.DrawSpriteShadows(false);
            if (!cbxTextures.Checked)
                Hook.DrawTextures(false);

            if (cbxBounding.Checked)
                Hook.DrawBounding(true);
            if (cbxCompassLarge.Checked)
                Hook.DrawCompassLarge(true);
            if (cbxCompassSmall.Checked)
                Hook.DrawCompassSmall(true);
            if (cbxAltimeter.Checked)
                Hook.DrawAltimeter(true);
            if (cbxNodes.Checked)
                Hook.DrawNodes(true);

            if (cbxFilter.Checked)
            {
                Hook.OverrideFilter(cbxFilter.Checked);
                UpdateBrightness();
                UpdateContrast();
                Hook.SetSaturation((float)nudSaturation.Value);
                Hook.SetHue((float)nudHue.Value);
            }
        }

        public void FlipFilter()
        {
            cbxFilter.Checked = !cbxFilter.Checked;
        }

        private void UpdateBrightness()
        {
            float brightnessR = (float)nudBrightnessR.Value;
            float brightnessG = (float)nudBrightnessG.Value;
            float brightnessB = (float)nudBrightnessB.Value;
            Hook.SetBrightness(brightnessR, brightnessG, brightnessB);
        }

        private void UpdateContrast()
        {
            float contrastR = (float)nudContrastR.Value;
            float contrastG = (float)nudContrastG.Value;
            float contrastB = (float)nudContrastB.Value;
            Hook.SetContrast(contrastR, contrastG, contrastB);
        }

        private void cbxMap_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawMap(cbxMap.Checked);
        }

        private void cbxCreatures_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawCreatures(cbxCreatures.Checked);
        }

        private void cbxObjects_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawObjects(cbxObjects.Checked);
        }

        private void cbxSFX_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSFX(cbxSFX.Checked);
        }

        private void cbxShadows_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawShadows(cbxShadows.Checked);
        }

        private void cbxSpriteShadows_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSpriteShadows(cbxSpriteShadows.Checked);
        }

        private void cbxTextures_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawTextures(cbxTextures.Checked);
        }

        private void cbxSprites_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSprites(cbxSprites.Checked);
        }

        private void cbxSpriteMasks_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSpriteMasks(cbxSpriteMasks.Checked);
        }

        private void cbxDrawTrans_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawTrans(cbxDrawTrans.Checked);
        }

        private void cbxCompassLarge_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawCompassLarge(cbxCompassLarge.Checked);
        }

        private void cbxCompassSmall_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawCompassSmall(cbxCompassSmall.Checked);
        }

        private void cbxAltimeter_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawAltimeter(cbxAltimeter.Checked);
        }

        private void cbxNodes_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawNodes(cbxNodes.Checked);
        }

        private void cbxBounding_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawBounding(cbxBounding.Checked);
        }

        private void cbxFilter_CheckedChanged(object sender, EventArgs e)
        {
            Hook.OverrideFilter(cbxFilter.Checked);
            if (cbxFilter.Checked)
            {
                UpdateBrightness();
                UpdateContrast();
                Hook.SetSaturation((float)nudSaturation.Value);
                Hook.SetHue((float)nudHue.Value);
            }
        }

        private void cbxBrightnessSync_CheckedChanged(object sender, EventArgs e)
        {
            nudBrightnessG.Enabled = !cbxBrightnessSync.Checked;
            nudBrightnessB.Enabled = !cbxBrightnessSync.Checked;
        }

        private void nudBrightnessR_ValueChanged(object sender, EventArgs e)
        {
            if (cbxBrightnessSync.Checked)
            {
                nudBrightnessG.Value = nudBrightnessR.Value;
                nudBrightnessB.Value = nudBrightnessR.Value;
            }
            UpdateBrightness();
        }

        private void nudBrightnessG_ValueChanged(object sender, EventArgs e)
        {
            UpdateBrightness();
        }

        private void nudBrightnessB_ValueChanged(object sender, EventArgs e)
        {
            UpdateBrightness();
        }

        private void cbxContrastSync_CheckedChanged(object sender, EventArgs e)
        {
            nudContrastG.Enabled = !cbxContrastSync.Checked;
            nudContrastB.Enabled = !cbxContrastSync.Checked;
        }

        private void nudContrastR_ValueChanged(object sender, EventArgs e)
        {
            if (cbxContrastSync.Checked)
            {
                nudContrastG.Value = nudContrastR.Value;
                nudContrastB.Value = nudContrastR.Value;
            }
            UpdateContrast();
        }

        private void nudContrastG_ValueChanged(object sender, EventArgs e)
        {
            UpdateContrast();
        }

        private void nudContrastB_ValueChanged(object sender, EventArgs e)
        {
            UpdateContrast();
        }

        private void nudSaturation_ValueChanged(object sender, EventArgs e)
        {
            Hook.SetSaturation((float)nudSaturation.Value);
        }

        private void nudHue_ValueChanged(object sender, EventArgs e)
        {
            Hook.SetHue((float)nudHue.Value);
        }
    }
}
