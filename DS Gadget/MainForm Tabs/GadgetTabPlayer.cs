using System;
using System.Data;
using System.Linq;

namespace DS_Gadget
{
    internal partial class GadgetTabPlayer : GadgetTab
    {
        private struct PlayerState
        {
            public bool Set;
            public int HP, Stamina;
            public bool DeathCam;
            public byte[] FollowCam;
        }
        private PlayerState playerState;

        public GadgetTabPlayer()
        {
            InitializeComponent();
        }

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            playerState.Set = false;
            cbxStoreState.Checked = Settings.StoreHP;
            foreach (DSBonfire bonfire in DSBonfire.All)
                cbxBonfire.Items.Add(bonfire);
            nudSpeed.Value = Settings.Speed;
        }

        public override void ResetTab()
        {
            if (Hook.Hooked)
            {
                if (cbxPosLock.Checked)
                    Hook.SetPosLock(false);
                if (Loaded)
                {
                    if (!cbxGravity.Checked)
                        Hook.SetGravity(true);
                    if (!cbxCollision.Checked)
                        Hook.SetCollision(true);
                    if (cbxSpeed.Checked)
                        Hook.SetSpeed(1);
                }
            }
        }

        public override void SaveTab()
        {
            Settings.StoreHP = cbxStoreState.Checked;
            Settings.Speed = nudSpeed.Value;
        }

        public override void ReloadTab()
        {
            if (cbxPosLock.Checked)
                Hook.SetPosLock(true);
            if (!cbxGravity.Checked)
                Hook.SetGravity(false);
            if (!cbxCollision.Checked)
                Hook.SetCollision(false);
            if (cbxSpeed.Checked)
                Hook.SetSpeed((float)nudSpeed.Value);
        }

        public override void UpdateTab()
        {
            nudHealth.Value = Hook.Health;
            nudHealthMax.Value = Hook.HealthMax;
            nudHealthModMax.Value = Hook.HealthModMax;
            nudStamina.Value = Hook.Stamina;
            nudStaminaMax.Value = Hook.StaminaMax;
            nudStaminaModMax.Value = Hook.StaminaModMax;
            nudChrType.Value = Hook.ChrType;
            nudTeamType.Value = Hook.TeamType;

            if (cbxForcePlayRegion.Checked)
                Hook.PlayRegion = (int)nudPlayRegion.Value;
            else
                nudPlayRegion.Value = Hook.PlayRegion;

            txtWorld.Text = Hook.World.ToString();
            txtArea.Text = Hook.Area.ToString();
            nudPosX.Value = (decimal)Hook.PosX;
            nudPosY.Value = (decimal)Hook.PosY;
            nudPosZ.Value = (decimal)Hook.PosZ;
            nudPosAngle.Value = (decimal)((Hook.PosAngle + Math.PI) / (Math.PI * 2) * 360);
            nudPosStableX.Value = (decimal)Hook.PosStableX;
            nudPosStableY.Value = (decimal)Hook.PosStableY;
            nudPosStableZ.Value = (decimal)Hook.PosStableZ;
            nudPosStableAngle.Value = (decimal)((Hook.PosStableAngle + Math.PI) / (Math.PI * 2) * 360);

            cbxDeathCam.Checked = Hook.DeathCam;

            int bonfireID = Hook.LastBonfire;
            if (!cbxBonfire.DroppedDown && bonfireID != (cbxBonfire.SelectedItem as DSBonfire)?.ID)
            {
                DSBonfire result = cbxBonfire.Items.Cast<DSBonfire>().FirstOrDefault(b => b.ID == bonfireID);
                if (result == null)
                {
                    result = new DSBonfire(bonfireID, $"Unknown: {bonfireID}");
                    cbxBonfire.Items.Add(result);
                }
                cbxBonfire.SelectedItem = result;
            }

            // Backstabbing resets speed, so reapply it 24/7
            if (cbxSpeed.Checked)
                Hook.SetSpeed((float)nudSpeed.Value);
        }

        public void StorePosition()
        {
            nudPosStoredX.Value = nudPosX.Value;
            nudPosStoredY.Value = nudPosY.Value;
            nudPosStoredZ.Value = nudPosZ.Value;
            nudPosStoredAngle.Value = nudPosAngle.Value;
            playerState.HP = (int)nudHealth.Value;
            playerState.Stamina = (int)nudStamina.Value;
            playerState.FollowCam = Hook.DumpFollowCam();
            playerState.DeathCam = Hook.DeathCam;
            playerState.Set = true;
        }

        public void RestorePosition()
        {
            float x = (float)nudPosStoredX.Value;
            float y = (float)nudPosStoredY.Value;
            float z = (float)nudPosStoredZ.Value;
            float angle = (float)((double)nudPosStoredAngle.Value / 360 * (Math.PI * 2) - Math.PI);

            Hook.PosWarp(x, y, z, angle);
            if (playerState.Set)
            {
                // Two frames for safety, wait until after warp
                System.Threading.Thread.Sleep(1000 / 15);
                Hook.UndumpFollowCam(playerState.FollowCam);

                if (cbxStoreState.Checked)
                {
                    nudHealth.Value = playerState.HP;
                    nudStamina.Value = playerState.Stamina;
                    cbxDeathCam.Checked = playerState.DeathCam;
                }
            }
        }

        public void FlipGravity()
        {
            cbxGravity.Checked = !cbxGravity.Checked;
        }

        public void FlipCollision()
        {
            cbxCollision.Checked = !cbxCollision.Checked;
        }

        public void FlipSpeed()
        {
            cbxSpeed.Checked = !cbxSpeed.Checked;
        }

        private void nudHealth_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Health = (int)nudHealth.Value;
        }

        private void nudStamina_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.Stamina = (int)nudStamina.Value;
        }

        private void nudChrType_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.ChrType = (int)nudChrType.Value;
        }

        private void nudTeamType_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.TeamType = (int)nudTeamType.Value;
        }

        private void nudPlayRegion_ValueChanged(object sender, EventArgs e)
        {
            if (!Reading)
                Hook.PlayRegion = (int)nudPlayRegion.Value;
        }

        private void cbxPosLock_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetPosLock(cbxPosLock.Checked);
            nudPosX.Enabled = cbxPosLock.Checked;
            nudPosY.Enabled = cbxPosLock.Checked;
            nudPosZ.Enabled = cbxPosLock.Checked;
        }

        private void nudPos_ValueChanged(object sender, EventArgs e)
        {
            if (cbxPosLock.Checked)
            {
                float x = (float)nudPosX.Value;
                float y = (float)nudPosY.Value;
                float z = (float)nudPosZ.Value;
                Hook.SetPos(x, y, z);
            }
        }

        private void btnPosStore_Click(object sender, EventArgs e)
        {
            StorePosition();
        }

        private void btnPosRestore_Click(object sender, EventArgs e)
        {
            RestorePosition();
        }

        private void cbxGravity_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetGravity(cbxGravity.Checked);
        }

        private void cbxCollision_CheckedChanged(object sender, EventArgs e)
        {
            Hook.SetCollision(cbxCollision.Checked);
        }

        private void cbxDeathCam_CheckedChanged(object sender, EventArgs e)
        {
            Hook.DeathCam = cbxDeathCam.Checked;
        }

        private void cbxBonfire_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSBonfire bonfire = cbxBonfire.SelectedItem as DSBonfire;
            Hook.LastBonfire = bonfire.ID;
        }

        private void btnBonfireWarp_Click(object sender, EventArgs e)
        {
            Hook.BonfireWarp();
        }

        private void cbxSpeed_CheckedChanged(object sender, EventArgs e)
        {
            nudSpeed.Enabled = cbxSpeed.Checked;
            Hook.SetSpeed(cbxSpeed.Checked ? (float)nudSpeed.Value : 1);
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            Hook.SetSpeed((float)nudSpeed.Value);
        }
    }
}
