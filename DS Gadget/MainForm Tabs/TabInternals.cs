using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initInternals() { }
        private void resetInternals() { }
        private void saveInternals() { }
        private void reloadInternals() { }

        private void updateInternals()
        {
            textBoxEquipRight1Idx.Text = Hook.EquipRight1Idx.ToString();
            textBoxEquipRight1ID.Text = Hook.EquipRight1ID.ToString();

            textBoxEquipRight2Idx.Text = Hook.EquipRight2Idx.ToString();
            textBoxEquipRight2ID.Text = Hook.EquipRight2ID.ToString();

            textBoxEquipLeft1Idx.Text = Hook.EquipLeft1Idx.ToString();
            textBoxEquipLeft1ID.Text = Hook.EquipLeft1ID.ToString();

            textBoxEquipLeft2Idx.Text = Hook.EquipLeft2Idx.ToString();
            textBoxEquipLeft2ID.Text = Hook.EquipLeft2ID.ToString();

            textBoxEquipArrow1Idx.Text = Hook.EquipArrow1Idx.ToString();
            textBoxEquipArrow1ID.Text = Hook.EquipArrow1ID.ToString();

            textBoxEquipArrow2Idx.Text = Hook.EquipArrow2Idx.ToString();
            textBoxEquipArrow2ID.Text = Hook.EquipArrow2ID.ToString();

            textBoxEquipBolt1Idx.Text = Hook.EquipBolt1Idx.ToString();
            textBoxEquipBolt1ID.Text = Hook.EquipBolt1ID.ToString();

            textBoxEquipBolt2Idx.Text = Hook.EquipBolt2Idx.ToString();
            textBoxEquipBolt2ID.Text = Hook.EquipBolt2ID.ToString();

            textBoxEquipHelmetIdx.Text = Hook.EquipHelmetIdx.ToString();
            textBoxEquipHelmetID.Text = Hook.EquipHelmetID.ToString();

            textBoxEquipChestIdx.Text = Hook.EquipChestIdx.ToString();
            textBoxEquipChestID.Text = Hook.EquipChestID.ToString();

            textBoxEquipGloveIdx.Text = Hook.EquipGloveIdx.ToString();
            textBoxEquipGloveID.Text = Hook.EquipGloveID.ToString();

            textBoxEquipPantsIdx.Text = Hook.EquipPantsIdx.ToString();
            textBoxEquipPantsID.Text = Hook.EquipPantsID.ToString();

            textBoxEquipHairIdx.Text = Hook.EquipHairIdx.ToString();
            textBoxEquipHairID.Text = Hook.EquipHairID.ToString();

            textBoxEquipRing1Idx.Text = Hook.EquipRing1Idx.ToString();
            textBoxEquipRing1ID.Text = Hook.EquipRing1ID.ToString();

            textBoxEquipRing2Idx.Text = Hook.EquipRing2Idx.ToString();
            textBoxEquipRing2ID.Text = Hook.EquipRing2ID.ToString();

            textBoxEquipItem1Idx.Text = Hook.EquipItem1Idx.ToString();
            textBoxEquipItem1ID.Text = Hook.EquipItem1ID.ToString();

            textBoxEquipItem2Idx.Text = Hook.EquipItem2Idx.ToString();
            textBoxEquipItem2ID.Text = Hook.EquipItem2ID.ToString();

            textBoxEquipItem3Idx.Text = Hook.EquipItem3Idx.ToString();
            textBoxEquipItem3ID.Text = Hook.EquipItem3ID.ToString();

            textBoxEquipItem4Idx.Text = Hook.EquipItem4Idx.ToString();
            textBoxEquipItem4ID.Text = Hook.EquipItem4ID.ToString();

            textBoxEquipItem5Idx.Text = Hook.EquipItem5Idx.ToString();
            textBoxEquipItem5ID.Text = Hook.EquipItem5ID.ToString();

            textBoxStoredMagic.Text = Hook.StoredMagic.ToString();
            textBoxStoredItem.Text = Hook.StoredItem.ToString();
            textBoxStoredQuantity.Text = Hook.StoredQuantity.ToString();
        }

        private void buttonHaircut_Click(object sender, EventArgs e)
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
