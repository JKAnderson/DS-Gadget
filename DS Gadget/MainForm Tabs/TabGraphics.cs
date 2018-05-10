using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initGraphics()
        {
            checkBoxFilter.Checked = settings.FilterEnable;
            checkBoxBrightnessSync.Checked = settings.FilterBrightnessSync;
            numericUpDownBrightnessR.Value = settings.FilterBrightnessR;
            numericUpDownBrightnessG.Value = settings.FilterBrightnessG;
            numericUpDownBrightnessB.Value = settings.FilterBrightnessB;
            checkBoxContrastSync.Checked = settings.FilterContrastSync;
            numericUpDownContrastR.Value = settings.FilterContrastR;
            numericUpDownContrastG.Value = settings.FilterContrastG;
            numericUpDownContrastB.Value = settings.FilterContrastB;
            numericUpDownSaturation.Value = settings.FilterSaturation;
            numericUpDownHue.Value = settings.FilterHue;
        }

        private void resetGraphics()
        {
            if (dsProcess != null)
            {
                if (!checkBoxMap.Checked)
                    dsProcess.DrawMap(true);
                if (!checkBoxCreatures.Checked)
                    dsProcess.DrawCreatures(true);
                if (!checkBoxObjects.Checked)
                    dsProcess.DrawObjects(true);
                if (!checkBoxSFX.Checked)
                    dsProcess.DrawSFX(true);

                if (!checkBoxSpriteMasks.Checked)
                    dsProcess.DrawSpriteMasks(true);
                if (!checkBoxSprites.Checked)
                    dsProcess.DrawSprites(true);
                if (!checkBoxDrawTrans.Checked)
                    dsProcess.DrawTrans(true);
                if (!checkBoxShadows.Checked)
                    dsProcess.DrawShadows(true);
                if (!checkBoxSpriteShadows.Checked)
                    dsProcess.DrawSpriteShadows(true);
                if (!checkBoxTextures.Checked)
                    dsProcess.DrawTextures(true);

                if (checkBoxBounding.Checked)
                    dsProcess.DrawBounding(false);
                if (checkBoxCompassLarge.Checked)
                    dsProcess.DrawCompassLarge(false);
                if (checkBoxCompassSmall.Checked)
                    dsProcess.DrawCompassSmall(false);
                if (checkBoxAltimeter.Checked)
                    dsProcess.DrawAltimeter(false);
                if (checkBoxNodes.Checked)
                    dsProcess.DrawNodes(false);

                if (loaded)
                {
                    if (checkBoxFilter.Checked)
                        dsProcess.OverrideFilter(false);
                }
            }
        }

        private void saveGraphics()
        {
            settings.FilterEnable = checkBoxFilter.Checked;
            settings.FilterBrightnessSync = checkBoxBrightnessSync.Checked;
            settings.FilterBrightnessR = numericUpDownBrightnessR.Value;
            settings.FilterBrightnessG = numericUpDownBrightnessG.Value;
            settings.FilterBrightnessB = numericUpDownBrightnessB.Value;
            settings.FilterContrastSync = checkBoxContrastSync.Checked;
            settings.FilterContrastR = numericUpDownContrastR.Value;
            settings.FilterContrastG = numericUpDownContrastG.Value;
            settings.FilterContrastB = numericUpDownContrastB.Value;
            settings.FilterSaturation = numericUpDownSaturation.Value;
            settings.FilterHue = numericUpDownHue.Value;
        }

        private void reloadGraphics()
        {
            if (!checkBoxMap.Checked)
                dsProcess.DrawMap(false);
            if (!checkBoxCreatures.Checked)
                dsProcess.DrawCreatures(false);
            if (!checkBoxObjects.Checked)
                dsProcess.DrawObjects(false);
            if (!checkBoxSFX.Checked)
                dsProcess.DrawSFX(false);

            if (!checkBoxSpriteMasks.Checked)
                dsProcess.DrawSpriteMasks(false);
            if (!checkBoxSprites.Checked)
                dsProcess.DrawSprites(false);
            if (!checkBoxDrawTrans.Checked)
                dsProcess.DrawTrans(false);
            if (!checkBoxShadows.Checked)
                dsProcess.DrawShadows(false);
            if (!checkBoxSpriteShadows.Checked)
                dsProcess.DrawSpriteShadows(false);
            if (!checkBoxTextures.Checked)
                dsProcess.DrawTextures(false);

            if (checkBoxBounding.Checked)
                dsProcess.DrawBounding(true);
            if (checkBoxCompassLarge.Checked)
                dsProcess.DrawCompassLarge(true);
            if (checkBoxCompassSmall.Checked)
                dsProcess.DrawCompassSmall(true);
            if (checkBoxAltimeter.Checked)
                dsProcess.DrawAltimeter(true);
            if (checkBoxNodes.Checked)
                dsProcess.DrawNodes(true);

            if (checkBoxFilter.Checked)
            {
                dsProcess.OverrideFilter(checkBoxFilter.Checked);
                updateBrightness();
                updateContrast();
                dsProcess.SetSaturation((float)numericUpDownSaturation.Value);
                dsProcess.SetHue((float)numericUpDownHue.Value);
            }
        }

        private void updateGraphics() { }

        private void checkBoxBounding_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawBounding(checkBoxBounding.Checked);
        }

        private void checkBoxSpriteMasks_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSpriteMasks(checkBoxSpriteMasks.Checked);
        }

        private void checkBoxSprites_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSprites(checkBoxSprites.Checked);
        }

        private void checkBoxDrawTrans_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawTrans(checkBoxDrawTrans.Checked);
        }

        private void checkBoxShadows_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawShadows(checkBoxShadows.Checked);
        }

        private void checkBoxSpriteShadows_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSpriteShadows(checkBoxSpriteShadows.Checked);
        }

        private void checkBoxTextures_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawTextures(checkBoxTextures.Checked);
        }

        private void checkBoxMap_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawMap(checkBoxMap.Checked);
        }

        private void checkBoxCreatures_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawCreatures(checkBoxCreatures.Checked);
        }

        private void checkBoxObjects_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawObjects(checkBoxObjects.Checked);
        }

        private void checkBoxSFX_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSFX(checkBoxSFX.Checked);
        }

        private void checkBoxCompassLarge_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawCompassLarge(checkBoxCompassLarge.Checked);
        }

        private void checkBoxCompassSmall_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawCompassSmall(checkBoxCompassSmall.Checked);
        }

        private void checkBoxAltimeter_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawAltimeter(checkBoxAltimeter.Checked);
        }

        private void checkBoxNodes_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawNodes(checkBoxNodes.Checked);
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.OverrideFilter(checkBoxFilter.Checked);
        }

        private void updateBrightness()
        {
            float brightnessR = (float)numericUpDownBrightnessR.Value;
            float brightnessG = (float)numericUpDownBrightnessG.Value;
            float brightnessB = (float)numericUpDownBrightnessB.Value;
            dsProcess?.SetBrightness(brightnessR, brightnessG, brightnessB);
        }

        private void checkBoxBrightnessSync_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownBrightnessG.Enabled = !checkBoxBrightnessSync.Checked;
            numericUpDownBrightnessB.Enabled = !checkBoxBrightnessSync.Checked;
        }

        private void numericUpDownBrightnessR_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxBrightnessSync.Checked)
            {
                numericUpDownBrightnessG.Value = numericUpDownBrightnessR.Value;
                numericUpDownBrightnessB.Value = numericUpDownBrightnessR.Value;
            }
            updateBrightness();
        }

        private void numericUpDownBrightnessG_ValueChanged(object sender, EventArgs e)
        {
            updateBrightness();
        }

        private void numericUpDownBrightnessB_ValueChanged(object sender, EventArgs e)
        {
            updateBrightness();
        }


        private void updateContrast()
        {
            float contrastR = (float)numericUpDownContrastR.Value;
            float contrastG = (float)numericUpDownContrastG.Value;
            float contrastB = (float)numericUpDownContrastB.Value;
            dsProcess?.SetContrast(contrastR, contrastG, contrastB);
        }

        private void checkBoxContrastSync_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownContrastG.Enabled = !checkBoxContrastSync.Checked;
            numericUpDownContrastB.Enabled = !checkBoxContrastSync.Checked;
        }

        private void numericUpDownContrastR_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxContrastSync.Checked)
            {
                numericUpDownContrastG.Value = numericUpDownContrastR.Value;
                numericUpDownContrastB.Value = numericUpDownContrastR.Value;
            }
            updateContrast();
        }

        private void numericUpDownContrastG_ValueChanged(object sender, EventArgs e)
        {
            updateContrast();
        }

        private void numericUpDownContrastB_ValueChanged(object sender, EventArgs e)
        {
            updateContrast();
        }

        private void numericUpDownSaturation_ValueChanged(object sender, EventArgs e)
        {
            dsProcess?.SetSaturation((float)numericUpDownSaturation.Value);
        }

        private void numericUpDownHue_ValueChanged(object sender, EventArgs e)
        {
            dsProcess?.SetHue((float)numericUpDownHue.Value);
        }
    }
}
