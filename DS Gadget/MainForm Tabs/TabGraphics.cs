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
            if (Hook.Hooked)
            {
                if (!checkBoxMap.Checked)
                    Hook.DrawMap(true);
                if (!checkBoxCreatures.Checked)
                    Hook.DrawCreatures(true);
                if (!checkBoxObjects.Checked)
                    Hook.DrawObjects(true);
                if (!checkBoxSFX.Checked)
                    Hook.DrawSFX(true);

                if (!checkBoxSpriteMasks.Checked)
                    Hook.DrawSpriteMasks(true);
                if (!checkBoxSprites.Checked)
                    Hook.DrawSprites(true);
                if (!checkBoxDrawTrans.Checked)
                    Hook.DrawTrans(true);
                if (!checkBoxShadows.Checked)
                    Hook.DrawShadows(true);
                if (!checkBoxSpriteShadows.Checked)
                    Hook.DrawSpriteShadows(true);
                if (!checkBoxTextures.Checked)
                    Hook.DrawTextures(true);

                if (checkBoxBounding.Checked)
                    Hook.DrawBounding(false);
                if (checkBoxCompassLarge.Checked)
                    Hook.DrawCompassLarge(false);
                if (checkBoxCompassSmall.Checked)
                    Hook.DrawCompassSmall(false);
                if (checkBoxAltimeter.Checked)
                    Hook.DrawAltimeter(false);
                if (checkBoxNodes.Checked)
                    Hook.DrawNodes(false);

                if (loaded)
                {
                    if (checkBoxFilter.Checked)
                        Hook.OverrideFilter(false);
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
                Hook.DrawMap(false);
            if (!checkBoxCreatures.Checked)
                Hook.DrawCreatures(false);
            if (!checkBoxObjects.Checked)
                Hook.DrawObjects(false);
            if (!checkBoxSFX.Checked)
                Hook.DrawSFX(false);

            if (!checkBoxSpriteMasks.Checked)
                Hook.DrawSpriteMasks(false);
            if (!checkBoxSprites.Checked)
                Hook.DrawSprites(false);
            if (!checkBoxDrawTrans.Checked)
                Hook.DrawTrans(false);
            if (!checkBoxShadows.Checked)
                Hook.DrawShadows(false);
            if (!checkBoxSpriteShadows.Checked)
                Hook.DrawSpriteShadows(false);
            if (!checkBoxTextures.Checked)
                Hook.DrawTextures(false);

            if (checkBoxBounding.Checked)
                Hook.DrawBounding(true);
            if (checkBoxCompassLarge.Checked)
                Hook.DrawCompassLarge(true);
            if (checkBoxCompassSmall.Checked)
                Hook.DrawCompassSmall(true);
            if (checkBoxAltimeter.Checked)
                Hook.DrawAltimeter(true);
            if (checkBoxNodes.Checked)
                Hook.DrawNodes(true);

            if (checkBoxFilter.Checked)
            {
                Hook.OverrideFilter(checkBoxFilter.Checked);
                updateBrightness();
                updateContrast();
                Hook.SetSaturation((float)numericUpDownSaturation.Value);
                Hook.SetHue((float)numericUpDownHue.Value);
            }
        }

        private void updateGraphics() { }

        private void checkBoxBounding_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawBounding(checkBoxBounding.Checked);
        }

        private void checkBoxSpriteMasks_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSpriteMasks(checkBoxSpriteMasks.Checked);
        }

        private void checkBoxSprites_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSprites(checkBoxSprites.Checked);
        }

        private void checkBoxDrawTrans_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawTrans(checkBoxDrawTrans.Checked);
        }

        private void checkBoxShadows_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawShadows(checkBoxShadows.Checked);
        }

        private void checkBoxSpriteShadows_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSpriteShadows(checkBoxSpriteShadows.Checked);
        }

        private void checkBoxTextures_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawTextures(checkBoxTextures.Checked);
        }

        private void checkBoxMap_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawMap(checkBoxMap.Checked);
        }

        private void checkBoxCreatures_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawCreatures(checkBoxCreatures.Checked);
        }

        private void checkBoxObjects_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawObjects(checkBoxObjects.Checked);
        }

        private void checkBoxSFX_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawSFX(checkBoxSFX.Checked);
        }

        private void checkBoxCompassLarge_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawCompassLarge(checkBoxCompassLarge.Checked);
        }

        private void checkBoxCompassSmall_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawCompassSmall(checkBoxCompassSmall.Checked);
        }

        private void checkBoxAltimeter_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawAltimeter(checkBoxAltimeter.Checked);
        }

        private void checkBoxNodes_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DrawNodes(checkBoxNodes.Checked);
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            Hook.OverrideFilter(checkBoxFilter.Checked);
            if (checkBoxFilter.Checked)
            {
                updateBrightness();
                updateContrast();
                Hook.SetSaturation((float)numericUpDownSaturation.Value);
                Hook.SetHue((float)numericUpDownHue.Value);
            }
        }

        private void updateBrightness()
        {
            float brightnessR = (float)numericUpDownBrightnessR.Value;
            float brightnessG = (float)numericUpDownBrightnessG.Value;
            float brightnessB = (float)numericUpDownBrightnessB.Value;
            Hook.SetBrightness(brightnessR, brightnessG, brightnessB);
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
            Hook.SetContrast(contrastR, contrastG, contrastB);
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
            Hook.SetSaturation((float)numericUpDownSaturation.Value);
        }

        private void numericUpDownHue_ValueChanged(object sender, EventArgs e)
        {
            Hook.SetHue((float)numericUpDownHue.Value);
        }
    }
}
