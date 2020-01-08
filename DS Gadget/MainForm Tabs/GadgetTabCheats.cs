using System;

namespace DS_Gadget
{
    internal partial class GadgetTabCheats : GadgetTab
    {
        public GadgetTabCheats()
        {
            InitializeComponent();
        }

        public override void ResetTab()
        {
            if (Hook.Hooked)
            {
                if (cbxAllNoMagic.Checked)
                    Hook.SetAllNoMagic(false);
                if (cbxPlayerNoDead.Checked)
                    Hook.SetNoDead(false);
                if (cbxPlayerExterminate.Checked)
                    Hook.SetExterminate(false);
                if (cbxAllNoStamina.Checked)
                    Hook.SetAllStamina(false);
                if (cbxAllNoArrow.Checked)
                    Hook.SetAllAmmo(false);
                if (cbxPlayerHide.Checked)
                    Hook.SetHide(false);
                if (cbxPlayerSilence.Checked)
                    Hook.SetSilence(false);
                if (cbxAllNoDead.Checked)
                    Hook.SetAllNoDead(false);
                if (cbxAllNoDamage.Checked)
                    Hook.SetAllNoDamage(false);
                if (cbxAllNoHit.Checked)
                    Hook.SetAllNoHit(false);
                if (cbxAllNoAttack.Checked)
                    Hook.SetAllNoAttack(false);
                if (cbxAllNoMove.Checked)
                    Hook.SetAllNoMove(false);
                if (cbxAllNoUpdateAI.Checked)
                    Hook.SetAllNoUpdateAI(false);

                if (Loaded)
                {
                    if (cbxPlayerDeadMode.Checked)
                        Hook.PlayerDeadMode = false;
                    if (cbxPlayerNoDamage.Checked)
                        Hook.SetPlayerNoDamage(false);
                    if (cbxPlayerNoHit.Checked)
                        Hook.SetPlayerNoHit(false);
                    if (cbxPlayerNoStamina.Checked)
                        Hook.SetPlayerNoStamina(false);
                    if (cbxPlayerSuperArmor.Checked)
                        Hook.SetPlayerSuperArmor(false);
                    if (cbxPlayerNoGoods.Checked)
                        Hook.SetPlayerNoGoods(false);
                }
            }
        }

        public override void ReloadTab()
        {
            if (cbxPlayerDeadMode.Checked)
                Hook.PlayerDeadMode = true;
            if (cbxPlayerNoDamage.Checked)
                Hook.SetPlayerNoDamage(true);
            if (cbxPlayerNoHit.Checked)
                Hook.SetPlayerNoHit(true);
            if (cbxPlayerNoStamina.Checked)
                Hook.SetPlayerNoStamina(true);
            if (cbxPlayerSuperArmor.Checked)
                Hook.SetPlayerSuperArmor(true);
            if (cbxPlayerNoGoods.Checked)
                Hook.SetPlayerNoGoods(true);
            if (cbxAllNoMagic.Checked)
                Hook.SetAllNoMagic(true);
            if (cbxPlayerNoDead.Checked)
                Hook.SetNoDead(true);
            if (cbxPlayerExterminate.Checked)
                Hook.SetExterminate(true);
            if (cbxAllNoStamina.Checked)
                Hook.SetAllStamina(true);
            if (cbxAllNoArrow.Checked)
                Hook.SetAllAmmo(true);
            if (cbxPlayerHide.Checked)
                Hook.SetHide(true);
            if (cbxPlayerSilence.Checked)
                Hook.SetSilence(true);
            if (cbxAllNoDead.Checked)
                Hook.SetAllNoDead(true);
            if (cbxAllNoDamage.Checked)
                Hook.SetAllNoDamage(true);
            if (cbxAllNoHit.Checked)
                Hook.SetAllNoHit(true);
            if (cbxAllNoAttack.Checked)
                Hook.SetAllNoAttack(true);
            if (cbxAllNoMove.Checked)
                Hook.SetAllNoMove(true);
            if (cbxAllNoUpdateAI.Checked)
                Hook.SetAllNoUpdateAI(true);
        }

        public override void UpdateTab()
        {
            // The game sometimes sets and unsets this, for instance when dropping into Manus' or BoC's arena
            // However for reasons I don't understand, constantly setting it causes issues with bow aiming for some users
            // So only re-set it when it has actually been unset
            if (cbxPlayerDeadMode.Checked && !Hook.PlayerDeadMode)
                Hook.PlayerDeadMode = true;
        }

        public void FlipPlayerDeadMode()
        {
            cbxPlayerDeadMode.Checked = !cbxPlayerDeadMode.Checked;
        }

        private void cbxPlayerDeadMode_CheckedChanged(object sender, EventArgs e)
        {
            Hook.PlayerDeadMode = cbxPlayerDeadMode.Checked;
        }

        private void cbxPlayerNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoDamage(cbxPlayerNoDamage.Checked);
        }

        private void cbxPlayerNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoStamina(cbxPlayerNoStamina.Checked);
        }

        private void cbxPlayerHide_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetHide(cbxPlayerHide.Checked);
        }

        private void cbxPlayerExterminate_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetExterminate(cbxPlayerExterminate.Checked);
        }

        private void cbxAllNoArrow_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllAmmo(cbxAllNoArrow.Checked);
        }

        private void cbxPlayerNoDead_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetNoDead(cbxPlayerNoDead.Checked);
        }

        private void cbxPlayerNoHit_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoHit(cbxPlayerNoHit.Checked);
        }

        private void cbxPlayerSuperArmor_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerSuperArmor(cbxPlayerSuperArmor.Checked);
        }

        private void cbxPlayerSilence_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetSilence(cbxPlayerSilence.Checked);
        }

        private void cbxPlayerNoGoods_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPlayerNoGoods(cbxPlayerNoGoods.Checked);
        }

        private void cbxAllNoMagic_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoMagic(cbxAllNoMagic.Checked);
        }

        private void cbxAllNoDead_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoDead(cbxAllNoDead.Checked);
        }

        private void cbxAllNoHit_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoHit(cbxAllNoHit.Checked);
        }

        private void cbxAllNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoDamage(cbxAllNoDamage.Checked);
        }

        private void cbxAllNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllStamina(cbxAllNoStamina.Checked);
        }

        private void cbxAllNoAttack_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoAttack(cbxAllNoAttack.Checked);
        }

        private void cbxAllNoUpdateAI_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoUpdateAI(cbxAllNoUpdateAI.Checked);
        }

        private void cbxAllNoMove_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetAllNoMove(cbxAllNoMove.Checked);
        }
    }
}
