using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initCheats() { }

        private void resetCheats()
        {
            if (dsProcess != null)
            {
                if (checkBoxAllNoMagic.Checked)
                    dsProcess.SetAllNoMagic(false);
                if (checkBoxPlayerNoDead.Checked)
                    dsProcess.SetNoDead(false);
                if (checkBoxPlayerExterminate.Checked)
                    dsProcess.SetExterminate(false);
                if (checkBoxAllNoStamina.Checked)
                    dsProcess.SetAllStamina(false);
                if (checkBoxAllNoArrow.Checked)
                    dsProcess.SetAllAmmo(false);
                if (checkBoxPlayerHide.Checked)
                    dsProcess.SetHide(false);
                if (checkBoxPlayerSilence.Checked)
                    dsProcess.SetSilence(false);
                if (checkBoxAllNoDead.Checked)
                    dsProcess.SetAllNoDead(false);
                if (checkBoxAllNoDamage.Checked)
                    dsProcess.SetAllNoDamage(false);
                if (checkBoxAllNoHit.Checked)
                    dsProcess.SetAllNoHit(false);
                if (checkBoxAllNoAttack.Checked)
                    dsProcess.SetAllNoAttack(false);
                if (checkBoxAllNoMove.Checked)
                    dsProcess.SetAllNoMove(false);
                if (checkBoxAllNoUpdateAI.Checked)
                    dsProcess.SetAllNoUpdateAI(false);

                if (loaded)
                {
                    if (checkBoxPlayerDeadMode.Checked)
                        dsProcess.SetPlayerDeadMode(false);
                    if (checkBoxPlayerNoDamage.Checked)
                        dsProcess.SetPlayerNoDamage(false);
                    if (checkBoxPlayerNoHit.Checked)
                        dsProcess.SetPlayerNoHit(false);
                    if (checkBoxPlayerNoStamina.Checked)
                        dsProcess.SetPlayerNoStamina(false);
                    if (checkBoxPlayerSuperArmor.Checked)
                        dsProcess.SetPlayerSuperArmor(false);
                    if (checkBoxPlayerNoGoods.Checked)
                        dsProcess.SetPlayerNoGoods(false);
                }
            }
        }

        private void saveCheats() { }

        private void reloadCheats()
        {
            if (checkBoxPlayerDeadMode.Checked)
                dsProcess.SetPlayerDeadMode(true);
            if (checkBoxPlayerNoDamage.Checked)
                dsProcess.SetPlayerNoDamage(true);
            if (checkBoxPlayerNoHit.Checked)
                dsProcess.SetPlayerNoHit(true);
            if (checkBoxPlayerNoStamina.Checked)
                dsProcess.SetPlayerNoStamina(true);
            if (checkBoxPlayerSuperArmor.Checked)
                dsProcess.SetPlayerSuperArmor(true);
            if (checkBoxPlayerNoGoods.Checked)
                dsProcess.SetPlayerNoGoods(true);
            if (checkBoxAllNoMagic.Checked)
                dsProcess.SetAllNoMagic(true);
            if (checkBoxPlayerNoDead.Checked)
                dsProcess.SetNoDead(true);
            if (checkBoxPlayerExterminate.Checked)
                dsProcess.SetExterminate(true);
            if (checkBoxAllNoStamina.Checked)
                dsProcess.SetAllStamina(true);
            if (checkBoxAllNoArrow.Checked)
                dsProcess.SetAllAmmo(true);
            if (checkBoxPlayerHide.Checked)
                dsProcess.SetHide(true);
            if (checkBoxPlayerSilence.Checked)
                dsProcess.SetSilence(true);
            if (checkBoxAllNoDead.Checked)
                dsProcess.SetAllNoDead(true);
            if (checkBoxAllNoDamage.Checked)
                dsProcess.SetAllNoDamage(true);
            if (checkBoxAllNoHit.Checked)
                dsProcess.SetAllNoHit(true);
            if (checkBoxAllNoAttack.Checked)
                dsProcess.SetAllNoAttack(true);
            if (checkBoxAllNoMove.Checked)
                dsProcess.SetAllNoMove(true);
            if (checkBoxAllNoUpdateAI.Checked)
                dsProcess.SetAllNoUpdateAI(true);
        }

        private void updateCheats()
        {
            // The game sometimes sets and unsets this, for instance when dropping into Manus' or BoC's arena
            // However for reasons I don't understand, constantly setting it causes issues with bow aiming for some users
            // So only re-set it when it has actually been unset
            if (checkBoxPlayerDeadMode.Checked && !dsProcess.GetPlayerDeadMode())
                dsProcess.SetPlayerDeadMode(true);
        }


        private void checkBoxPlayerDeadMode_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerDeadMode(checkBoxPlayerDeadMode.Checked);
        }

        private void checkBoxPlayerNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoDamage(checkBoxPlayerNoDamage.Checked);
        }

        private void checkBoxPlayerNoHit_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoHit(checkBoxPlayerNoHit.Checked);
        }

        private void checkBoxPlayerNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoStamina(checkBoxPlayerNoStamina.Checked);
        }

        private void checkBoxPlayerSuperArmor_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerSuperArmor(checkBoxPlayerSuperArmor.Checked);
        }

        private void checkBoxPlayerNoGoods_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoGoods(checkBoxPlayerNoGoods.Checked);
        }

        private void checkBoxAllNoMagic_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoMagic(checkBoxAllNoMagic.Checked);
        }

        private void checkBoxPlayerNoDead_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetNoDead(checkBoxPlayerNoDead.Checked);
        }

        private void checkBoxPlayerExterminate_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetExterminate(checkBoxPlayerExterminate.Checked);
        }

        private void checkBoxAllNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllStamina(checkBoxAllNoStamina.Checked);
        }

        private void checkBoxAllNoArrow_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllAmmo(checkBoxAllNoArrow.Checked);
        }

        private void checkBoxPlayerHide_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetHide(checkBoxPlayerHide.Checked);
        }

        private void checkBoxPlayerSilence_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetSilence(checkBoxPlayerSilence.Checked);
        }

        private void checkBoxAllNoDead_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoDead(checkBoxAllNoDead.Checked);
        }

        private void checkBoxAllNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoDamage(checkBoxAllNoDamage.Checked);
        }

        private void checkBoxAllNoHit_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoHit(checkBoxAllNoHit.Checked);
        }

        private void checkBoxAllNoAttack_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoAttack(checkBoxAllNoAttack.Checked);
        }

        private void checkBoxAllNoMove_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoMove(checkBoxAllNoMove.Checked);
        }

        private void checkBoxAllNoUpdateAI_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoUpdateAI(checkBoxAllNoUpdateAI.Checked);
        }
    }
}
