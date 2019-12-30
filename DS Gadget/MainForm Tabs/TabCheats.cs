using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initCheats() { }

        private void resetCheats()
        {
            if (Hook.Valid)
            {
                if (checkBoxAllNoMagic.Checked)
                    Hook.SetAllNoMagic(false);
                if (checkBoxPlayerNoDead.Checked)
                    Hook.SetNoDead(false);
                if (checkBoxPlayerExterminate.Checked)
                    Hook.SetExterminate(false);
                if (checkBoxAllNoStamina.Checked)
                    Hook.SetAllStamina(false);
                if (checkBoxAllNoArrow.Checked)
                    Hook.SetAllAmmo(false);
                if (checkBoxPlayerHide.Checked)
                    Hook.SetHide(false);
                if (checkBoxPlayerSilence.Checked)
                    Hook.SetSilence(false);
                if (checkBoxAllNoDead.Checked)
                    Hook.SetAllNoDead(false);
                if (checkBoxAllNoDamage.Checked)
                    Hook.SetAllNoDamage(false);
                if (checkBoxAllNoHit.Checked)
                    Hook.SetAllNoHit(false);
                if (checkBoxAllNoAttack.Checked)
                    Hook.SetAllNoAttack(false);
                if (checkBoxAllNoMove.Checked)
                    Hook.SetAllNoMove(false);
                if (checkBoxAllNoUpdateAI.Checked)
                    Hook.SetAllNoUpdateAI(false);

                if (loaded)
                {
                    if (checkBoxPlayerDeadMode.Checked)
                        Hook.PlayerDeadMode = false;
                    if (checkBoxPlayerNoDamage.Checked)
                        Hook.SetPlayerNoDamage(false);
                    if (checkBoxPlayerNoHit.Checked)
                        Hook.SetPlayerNoHit(false);
                    if (checkBoxPlayerNoStamina.Checked)
                        Hook.SetPlayerNoStamina(false);
                    if (checkBoxPlayerSuperArmor.Checked)
                        Hook.SetPlayerSuperArmor(false);
                    if (checkBoxPlayerNoGoods.Checked)
                        Hook.SetPlayerNoGoods(false);
                }
            }
        }

        private void saveCheats() { }

        private void reloadCheats()
        {
            if (checkBoxPlayerDeadMode.Checked)
                Hook.PlayerDeadMode = true;
            if (checkBoxPlayerNoDamage.Checked)
                Hook.SetPlayerNoDamage(true);
            if (checkBoxPlayerNoHit.Checked)
                Hook.SetPlayerNoHit(true);
            if (checkBoxPlayerNoStamina.Checked)
                Hook.SetPlayerNoStamina(true);
            if (checkBoxPlayerSuperArmor.Checked)
                Hook.SetPlayerSuperArmor(true);
            if (checkBoxPlayerNoGoods.Checked)
                Hook.SetPlayerNoGoods(true);
            if (checkBoxAllNoMagic.Checked)
                Hook.SetAllNoMagic(true);
            if (checkBoxPlayerNoDead.Checked)
                Hook.SetNoDead(true);
            if (checkBoxPlayerExterminate.Checked)
                Hook.SetExterminate(true);
            if (checkBoxAllNoStamina.Checked)
                Hook.SetAllStamina(true);
            if (checkBoxAllNoArrow.Checked)
                Hook.SetAllAmmo(true);
            if (checkBoxPlayerHide.Checked)
                Hook.SetHide(true);
            if (checkBoxPlayerSilence.Checked)
                Hook.SetSilence(true);
            if (checkBoxAllNoDead.Checked)
                Hook.SetAllNoDead(true);
            if (checkBoxAllNoDamage.Checked)
                Hook.SetAllNoDamage(true);
            if (checkBoxAllNoHit.Checked)
                Hook.SetAllNoHit(true);
            if (checkBoxAllNoAttack.Checked)
                Hook.SetAllNoAttack(true);
            if (checkBoxAllNoMove.Checked)
                Hook.SetAllNoMove(true);
            if (checkBoxAllNoUpdateAI.Checked)
                Hook.SetAllNoUpdateAI(true);
        }

        private void updateCheats()
        {
            // The game sometimes sets and unsets this, for instance when dropping into Manus' or BoC's arena
            // However for reasons I don't understand, constantly setting it causes issues with bow aiming for some users
            // So only re-set it when it has actually been unset
            if (checkBoxPlayerDeadMode.Checked && !Hook.PlayerDeadMode)
                Hook.PlayerDeadMode = true;
        }


        private void checkBoxPlayerDeadMode_CheckedChanged(object sender, EventArgs e)
        {
            Hook.PlayerDeadMode = checkBoxPlayerDeadMode.Checked;
        }

        private void checkBoxPlayerNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoDamage(checkBoxPlayerNoDamage.Checked);
        }

        private void checkBoxPlayerNoHit_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoHit(checkBoxPlayerNoHit.Checked);
        }

        private void checkBoxPlayerNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoStamina(checkBoxPlayerNoStamina.Checked);
        }

        private void checkBoxPlayerSuperArmor_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerSuperArmor(checkBoxPlayerSuperArmor.Checked);
        }

        private void checkBoxPlayerNoGoods_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoGoods(checkBoxPlayerNoGoods.Checked);
        }

        private void checkBoxAllNoMagic_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoMagic(checkBoxAllNoMagic.Checked);
        }

        private void checkBoxPlayerNoDead_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetNoDead(checkBoxPlayerNoDead.Checked);
        }

        private void checkBoxPlayerExterminate_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetExterminate(checkBoxPlayerExterminate.Checked);
        }

        private void checkBoxAllNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllStamina(checkBoxAllNoStamina.Checked);
        }

        private void checkBoxAllNoArrow_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllAmmo(checkBoxAllNoArrow.Checked);
        }

        private void checkBoxPlayerHide_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetHide(checkBoxPlayerHide.Checked);
        }

        private void checkBoxPlayerSilence_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetSilence(checkBoxPlayerSilence.Checked);
        }

        private void checkBoxAllNoDead_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoDead(checkBoxAllNoDead.Checked);
        }

        private void checkBoxAllNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoDamage(checkBoxAllNoDamage.Checked);
        }

        private void checkBoxAllNoHit_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoHit(checkBoxAllNoHit.Checked);
        }

        private void checkBoxAllNoAttack_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoAttack(checkBoxAllNoAttack.Checked);
        }

        private void checkBoxAllNoMove_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoMove(checkBoxAllNoMove.Checked);
        }

        private void checkBoxAllNoUpdateAI_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoUpdateAI(checkBoxAllNoUpdateAI.Checked);
        }
    }
}
