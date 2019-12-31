using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private struct PlayerState
        {
            public bool Set;
            public int HP, Stamina;
            public bool DeathCam;
            public byte[] FollowCam;
        }

        private int skipBonfire = 0;
        private PlayerState playerState;

        private void initPlayer()
        {
            playerState.Set = false;
            checkBoxStoreState.Checked = settings.StoreHP;
            foreach (DSBonfire bonfire in DSBonfire.All)
                comboBoxBonfire.Items.Add(bonfire);
            comboBoxBonfire.SelectedIndex = 0;
            numericUpDownSpeed.Value = settings.Speed;
        }

        private void resetPlayer()
        {
            if (Hook.Hooked)
            {
                if (checkBoxPosLock.Checked)
                    Hook.SetPosLock(false);
                if (loaded)
                {
                    if (!checkBoxGravity.Checked)
                        Hook.SetGravity(true);
                    if (!checkBoxCollision.Checked)
                        Hook.SetCollision(true);
                    if (checkBoxSpeed.Checked)
                        Hook.SetSpeed(1);
                }
            }
        }

        private void savePlayer()
        {
            settings.StoreHP = checkBoxStoreState.Checked;
            settings.Speed = numericUpDownSpeed.Value;
        }

        private void reloadPlayer()
        {
            if (checkBoxPosLock.Checked)
                Hook.SetPosLock(true);
            if (!checkBoxGravity.Checked)
                Hook.SetGravity(false);
            if (!checkBoxCollision.Checked)
                Hook.SetCollision(false);
            if (checkBoxSpeed.Checked)
                Hook.SetSpeed((float)numericUpDownSpeed.Value);
        }

        private void updatePlayer()
        {
            numericUpDownHP.Value = Hook.Health;
            numericUpDownHPMax.Value = Hook.HealthMax;
            numericUpDownHPModMax.Value = Hook.HealthModMax;
            numericUpDownStam.Value = Hook.Stamina;
            numericUpDownStamMax.Value = Hook.StaminaMax;
            numericUpDownStamModMax.Value = Hook.StaminaModMax;
            numericUpDownPhantom.Value = Hook.PhantomType;
            numericUpDownTeam.Value = Hook.TeamType;

            textBoxWorld.Text = Hook.World.ToString();
            textBoxArea.Text = Hook.Area.ToString();
            numericUpDownPosX.Value = (decimal)Hook.PosX;
            numericUpDownPosY.Value = (decimal)Hook.PosY;
            numericUpDownPosZ.Value = (decimal)Hook.PosZ;
            numericUpDownPosAngle.Value = (decimal)((Hook.PosAngle + Math.PI) / (Math.PI * 2) * 360);
            numericUpDownPosStableX.Value = (decimal)Hook.PosStableX;
            numericUpDownPosStableY.Value = (decimal)Hook.PosStableY;
            numericUpDownPosStableZ.Value = (decimal)Hook.PosStableZ;
            numericUpDownPosStableAngle.Value = (decimal)((Hook.PosStableAngle + Math.PI) / (Math.PI * 2) * 360);

            checkBoxDeathCam.Checked = Hook.DeathCam;

            int bonfireID = Hook.LastBonfire;
            if (bonfireID != skipBonfire && !comboBoxBonfire.DroppedDown && bonfireID != (comboBoxBonfire.SelectedItem as DSBonfire).ID)
            {
                object result = null;
                foreach (object bonfire in comboBoxBonfire.Items)
                {
                    if (bonfireID == (bonfire as DSBonfire).ID)
                        result = bonfire;
                }
                if (result != null)
                    comboBoxBonfire.SelectedItem = result;
                else
                {
                    skipBonfire = bonfireID;
                    MessageBox.Show("Unknown bonfire ID, please report me: " + bonfireID, "Unknown Bonfire");
                }
            }

            // Backstabbing resets speed, so reapply it 24/7
            if (checkBoxSpeed.Checked)
                Hook.SetSpeed((float)numericUpDownSpeed.Value);
        }

        private void numericUpDownHP_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                Hook.Health = (int)numericUpDownHP.Value;
        }

        private void numericUpDownStam_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                Hook.Stamina = (int)numericUpDownStam.Value;
        }

        private void numericUpDownPhantom_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                Hook.PhantomType = (int)numericUpDownPhantom.Value;
        }

        private void numericUpDownTeam_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                Hook.TeamType = (int)numericUpDownTeam.Value;
        }

        private void checkBoxPosLock_CheckedChanged(object sender, EventArgs e)
        {
            Hook?.SetPosLock(checkBoxPosLock.Checked);
            numericUpDownPosX.Enabled = checkBoxPosLock.Checked;
            numericUpDownPosY.Enabled = checkBoxPosLock.Checked;
            numericUpDownPosZ.Enabled = checkBoxPosLock.Checked;
        }

        private void numericUpDownPosX_ValueChanged(object sender, EventArgs e)
        {
            setPos();
        }

        private void numericUpDownPosY_ValueChanged(object sender, EventArgs e)
        {
            setPos();
        }

        private void numericUpDownPosZ_ValueChanged(object sender, EventArgs e)
        {
            setPos();
        }

        private void setPos()
        {
            if (checkBoxPosLock.Checked)
            {
                float x = (float)numericUpDownPosX.Value;
                float y = (float)numericUpDownPosY.Value;
                float z = (float)numericUpDownPosZ.Value;
                Hook?.SetPos(x, y, z);
            }
        }

        private void buttonPosStore_Click(object sender, EventArgs e)
        {
            posStore();
        }

        private void posStore()
        {
            numericUpDownPosStoredX.Value = numericUpDownPosX.Value;
            numericUpDownPosStoredY.Value = numericUpDownPosY.Value;
            numericUpDownPosStoredZ.Value = numericUpDownPosZ.Value;
            numericUpDownPosStoredAngle.Value = numericUpDownPosAngle.Value;
            playerState.HP = (int)numericUpDownHP.Value;
            playerState.Stamina = (int)numericUpDownStam.Value;
            playerState.FollowCam = Hook.DumpFollowCam();
            playerState.DeathCam = Hook.DeathCam;
            playerState.Set = true;
        }

        private void buttonPosRestore_Click(object sender, EventArgs e)
        {
            posRestore();
        }

        private void posRestore()
        {
            float x = (float)numericUpDownPosStoredX.Value;
            float y = (float)numericUpDownPosStoredY.Value;
            float z = (float)numericUpDownPosStoredZ.Value;
            float angle = (float)((double)numericUpDownPosStoredAngle.Value / 360 * (Math.PI * 2) - Math.PI);
            Hook?.PosWarp(x, y, z, angle);
            if (playerState.Set)
            {
                // Two frames for safety, wait until after warp
                System.Threading.Thread.Sleep(1000 / 15);
                Hook.UndumpFollowCam(playerState.FollowCam);

                if (checkBoxStoreState.Checked)
                {
                    numericUpDownHP.Value = playerState.HP;
                    numericUpDownStam.Value = playerState.Stamina;
                    checkBoxDeathCam.Checked = playerState.DeathCam;
                }
            }
        }

        private void checkBoxGravity_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetGravity(checkBoxGravity.Checked);
        }

        private void checkBoxCollision_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetCollision(checkBoxCollision.Checked);
        }

        private void checkBoxDeathCam_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DeathCam = checkBoxDeathCam.Checked;
        }

        private void comboBoxBonfire_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSBonfire bonfire = comboBoxBonfire.SelectedItem as DSBonfire;
            Hook.LastBonfire = bonfire.ID;
        }

        private void buttonWarp_Click(object sender, EventArgs e)
        {
            Hook.BonfireWarp();
        }

        private void checkBoxSpeed_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownSpeed.Enabled = checkBoxSpeed.Checked;
            Hook.SetSpeed(checkBoxSpeed.Checked ? (float)numericUpDownSpeed.Value : 1);
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            Hook.SetSpeed((float)numericUpDownSpeed.Value);
        }
    }
}
