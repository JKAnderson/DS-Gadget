using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private int skipBonfire = 0;
        private int storedHP = -1;
        private byte[] camDump = null;

        private void initPlayer()
        {
            foreach (DSBonfire bonfire in DSBonfire.All)
                comboBoxBonfire.Items.Add(bonfire);
            comboBoxBonfire.SelectedIndex = 0;
            numericUpDownSpeed.Value = settings.Speed;
        }

        private void resetPlayer()
        {
            if (dsProcess != null)
            {
                dsProcess.SetPosLock(false);
                if (loaded)
                {
                    dsProcess.SetGravity(true);
                    dsProcess.SetCollision(true);
                    dsProcess.SetSpeed(1);
                }
            }
        }

        private void savePlayer()
        {
            settings.Speed = numericUpDownSpeed.Value;
            resetPlayer();
        }

        private void reloadPlayer()
        {
            checkBoxPosLock.Checked = false;
            dsProcess.SetGravity(checkBoxGravity.Checked);
            checkBoxCollision.Checked = true;
            if (checkBoxSpeed.Checked)
                dsProcess.SetSpeed((float)numericUpDownSpeed.Value);
        }

        private void updatePlayer()
        {
            numericUpDownHP.Value = (decimal)dsProcess.GetHP();
            numericUpDownHPMax.Value = (decimal)dsProcess.GetHPMax();
            numericUpDownHPModMax.Value = (decimal)dsProcess.GetHPModMax();
            numericUpDownStam.Value = (decimal)dsProcess.GetStam();
            numericUpDownStamMax.Value = (decimal)dsProcess.GetStamMax();
            numericUpDownStamModMax.Value = (decimal)dsProcess.GetStamModMax();
            numericUpDownPhantom.Value = dsProcess.GetPhantomType();
            numericUpDownTeam.Value = dsProcess.GetTeamType();

            textBoxWorld.Text = dsProcess.GetWorld().ToString();
            textBoxArea.Text = dsProcess.GetArea().ToString();
            numericUpDownPosX.Value = (decimal)dsProcess.GetPosX();
            numericUpDownPosY.Value = (decimal)dsProcess.GetPosY();
            numericUpDownPosZ.Value = (decimal)dsProcess.GetPosZ();
            numericUpDownPosAngle.Value = (decimal)((dsProcess.GetPosAngle() + Math.PI) / (Math.PI * 2) * 360);
            numericUpDownPosStableX.Value = (decimal)dsProcess.GetPosStableX();
            numericUpDownPosStableY.Value = (decimal)dsProcess.GetPosStableY();
            numericUpDownPosStableZ.Value = (decimal)dsProcess.GetPosStableZ();
            numericUpDownPosStableAngle.Value = (decimal)((dsProcess.GetPosStableAngle() + Math.PI) / (Math.PI * 2) * 360);

            checkBoxDeathCam.Checked = dsProcess.GetDeathCam();

            int bonfireID = dsProcess.GetBonfire();
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
        }

        private void numericUpDownHP_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                dsProcess.SetHP((int)numericUpDownHP.Value);
        }

        private void numericUpDownPhantom_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                dsProcess.SetPhantomType((int)numericUpDownPhantom.Value);
        }

        private void numericUpDownTeam_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                dsProcess.SetTeamType((int)numericUpDownTeam.Value);
        }

        private void checkBoxPosLock_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPosLock(checkBoxPosLock.Checked);
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
                dsProcess?.SetPos(x, y, z);
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
            storedHP = (int)numericUpDownHP.Value;
            camDump = dsProcess.DumpFollowCam();
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
            dsProcess?.PosWarp(x, y, z, angle);
            if (checkBoxStoreHP.Checked && storedHP > 0)
                numericUpDownHP.Value = storedHP;
            // Two frames for safety, restore camera after warp takes effect
            System.Threading.Thread.Sleep(1000 / 15);
            if (camDump != null)
                dsProcess.UndumpFollowCam(camDump);
        }

        private void checkBoxGravity_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetGravity(checkBoxGravity.Checked);
        }

        private void checkBoxCollision_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetCollision(checkBoxCollision.Checked);
        }

        private void checkBoxDeathCam_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetDeathCam(checkBoxDeathCam.Checked);
        }

        private void comboBoxBonfire_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSBonfire bonfire = comboBoxBonfire.SelectedItem as DSBonfire;
            dsProcess?.SetBonfire(bonfire.ID);
        }

        private void checkBoxSpeed_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownSpeed.Enabled = checkBoxSpeed.Checked;
            dsProcess?.SetSpeed(checkBoxSpeed.Checked ? (float)numericUpDownSpeed.Value : 1);
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            dsProcess?.SetSpeed((float)numericUpDownSpeed.Value);
        }
    }
}
