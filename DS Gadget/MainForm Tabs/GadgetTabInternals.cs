using System;

namespace DS_Gadget
{
    internal partial class GadgetTabInternals : GadgetTab
    {
        public GadgetTabInternals()
        {
            InitializeComponent();
        }

        public override void UpdateTab()
        {
            txtEquipRight1Idx.Text = Hook.EquipRight1Idx.ToString();
            txtEquipRight1ID.Text = Hook.EquipRight1ID.ToString();

            txtEquipRight2Idx.Text = Hook.EquipRight2Idx.ToString();
            txtEquipRight2ID.Text = Hook.EquipRight2ID.ToString();

            txtEquipLeft1Idx.Text = Hook.EquipLeft1Idx.ToString();
            txtEquipLeft1ID.Text = Hook.EquipLeft1ID.ToString();

            txtEquipLeft2Idx.Text = Hook.EquipLeft2Idx.ToString();
            txtEquipLeft2ID.Text = Hook.EquipLeft2ID.ToString();

            txtEquipArrow1Idx.Text = Hook.EquipArrow1Idx.ToString();
            txtEquipArrow1ID.Text = Hook.EquipArrow1ID.ToString();

            txtEquipArrow2Idx.Text = Hook.EquipArrow2Idx.ToString();
            txtEquipArrow2ID.Text = Hook.EquipArrow2ID.ToString();

            txtEquipBolt1Idx.Text = Hook.EquipBolt1Idx.ToString();
            txtEquipBolt1ID.Text = Hook.EquipBolt1ID.ToString();

            txtEquipBolt2Idx.Text = Hook.EquipBolt2Idx.ToString();
            txtEquipBolt2ID.Text = Hook.EquipBolt2ID.ToString();

            txtEquipHelmetIdx.Text = Hook.EquipHelmetIdx.ToString();
            txtEquipHelmetID.Text = Hook.EquipHelmetID.ToString();

            txtEquipChestIdx.Text = Hook.EquipChestIdx.ToString();
            txtEquipChestID.Text = Hook.EquipChestID.ToString();

            txtEquipGloveIdx.Text = Hook.EquipGloveIdx.ToString();
            txtEquipGloveID.Text = Hook.EquipGloveID.ToString();

            txtEquipPantsIdx.Text = Hook.EquipPantsIdx.ToString();
            txtEquipPantsID.Text = Hook.EquipPantsID.ToString();

            txtEquipHairIdx.Text = Hook.EquipHairIdx.ToString();
            txtEquipHairID.Text = Hook.EquipHairID.ToString();

            txtEquipRing1Idx.Text = Hook.EquipRing1Idx.ToString();
            txtEquipRing1ID.Text = Hook.EquipRing1ID.ToString();

            txtEquipRing2Idx.Text = Hook.EquipRing2Idx.ToString();
            txtEquipRing2ID.Text = Hook.EquipRing2ID.ToString();

            txtEquipItem1Idx.Text = Hook.EquipItem1Idx.ToString();
            txtEquipItem1ID.Text = Hook.EquipItem1ID.ToString();

            txtEquipItem2Idx.Text = Hook.EquipItem2Idx.ToString();
            txtEquipItem2ID.Text = Hook.EquipItem2ID.ToString();

            txtEquipItem3Idx.Text = Hook.EquipItem3Idx.ToString();
            txtEquipItem3ID.Text = Hook.EquipItem3ID.ToString();

            txtEquipItem4Idx.Text = Hook.EquipItem4Idx.ToString();
            txtEquipItem4ID.Text = Hook.EquipItem4ID.ToString();

            txtEquipItem5Idx.Text = Hook.EquipItem5Idx.ToString();
            txtEquipItem5ID.Text = Hook.EquipItem5ID.ToString();

            txtStoredMagic.Text = Hook.StoredMagic.ToString();
            txtStoredItem.Text = Hook.StoredItem.ToString();
            txtStoredQuantity.Text = Hook.StoredQuantity.ToString();
        }

        private void btnHaircut_Click(object sender, EventArgs e)
        {
            Hook.EquipHairIdx = -1;
            // Female
            if (Hook.Gender == 0)
                Hook.EquipHairID = 3000;
            // Not female
            else
                Hook.EquipHairID = 1000;
        }
    }
}
