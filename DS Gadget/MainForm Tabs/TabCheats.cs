using System;
using System.Media;
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
                dsProcess.SetAllNoMagic(false);
                dsProcess.SetNoDead(false);
                dsProcess.SetExterminate(false);
                dsProcess.SetAllStamina(false);
                dsProcess.SetAllAmmo(false);
                dsProcess.SetHide(false);
                dsProcess.SetSilence(false);
                dsProcess.SetAllNoDead(false);
                dsProcess.SetAllNoDamage(false);
                dsProcess.SetAllNoHit(false);
                dsProcess.SetAllNoAttack(false);
                dsProcess.SetAllNoMove(false);
                dsProcess.SetAllNoUpdateAI(false);

                if (loaded)
                {
                    dsProcess.SetPlayerDeadMode(false);
                    dsProcess.SetPlayerNoDamage(false);
                    dsProcess.SetPlayerNoHit(false);
                    dsProcess.SetPlayerNoStamina(false);
                    dsProcess.SetPlayerSuperArmor(false);
                    dsProcess.SetPlayerNoGoods(false);
                }
            }
        }

        private void saveCheats() { }

        private void reloadCheats()
        {
            dsProcess.SetPlayerDeadMode(checkBoxPlayerDeadMode.Checked);
            dsProcess.SetPlayerNoDamage(checkBoxPlayerNoDamage.Checked);
            dsProcess.SetPlayerNoHit(checkBoxPlayerNoHit.Checked);
            dsProcess.SetPlayerNoStamina(checkBoxPlayerNoStamina.Checked);
            dsProcess.SetPlayerSuperArmor(checkBoxPlayerSuperArmor.Checked);
            dsProcess.SetPlayerNoGoods(checkBoxPlayerNoGoods.Checked);
            dsProcess.SetAllNoMagic(checkBoxAllNoMagic.Checked);
            dsProcess.SetNoDead(checkBoxPlayerNoDead.Checked);
            dsProcess.SetExterminate(checkBoxPlayerExterminate.Checked);
            dsProcess.SetAllStamina(checkBoxAllNoStamina.Checked);
            dsProcess.SetAllAmmo(checkBoxAllNoArrow.Checked);
            dsProcess.SetHide(checkBoxPlayerHide.Checked);
            dsProcess.SetSilence(checkBoxPlayerSilence.Checked);
            dsProcess.SetAllNoDead(checkBoxAllNoDead.Checked);
            dsProcess.SetAllNoDamage(checkBoxAllNoDamage.Checked);
            dsProcess.SetAllNoHit(checkBoxAllNoHit.Checked);
            dsProcess.SetAllNoAttack(checkBoxAllNoAttack.Checked);
            dsProcess.SetAllNoMove(checkBoxAllNoMove.Checked);
            dsProcess.SetAllNoUpdateAI(checkBoxAllNoUpdateAI.Checked);
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
