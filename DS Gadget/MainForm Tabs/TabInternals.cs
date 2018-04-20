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
            textBoxEquipRight1Idx.Text = dsProcess.GetEquipRight1Idx().ToString();
            textBoxEquipRight1ID.Text = dsProcess.GetEquipRight1ID().ToString();

            textBoxEquipRight2Idx.Text = dsProcess.GetEquipRight2Idx().ToString();
            textBoxEquipRight2ID.Text = dsProcess.GetEquipRight2ID().ToString();

            textBoxEquipLeft1Idx.Text = dsProcess.GetEquipLeft1Idx().ToString();
            textBoxEquipLeft1ID.Text = dsProcess.GetEquipLeft1ID().ToString();

            textBoxEquipLeft2Idx.Text = dsProcess.GetEquipLeft2Idx().ToString();
            textBoxEquipLeft2ID.Text = dsProcess.GetEquipLeft2ID().ToString();

            textBoxEquipArrow1Idx.Text = dsProcess.GetEquipArrow1Idx().ToString();
            textBoxEquipArrow1ID.Text = dsProcess.GetEquipArrow1ID().ToString();

            textBoxEquipArrow2Idx.Text = dsProcess.GetEquipArrow2Idx().ToString();
            textBoxEquipArrow2ID.Text = dsProcess.GetEquipArrow2ID().ToString();

            textBoxEquipBolt1Idx.Text = dsProcess.GetEquipBolt1Idx().ToString();
            textBoxEquipBolt1ID.Text = dsProcess.GetEquipBolt1ID().ToString();

            textBoxEquipBolt2Idx.Text = dsProcess.GetEquipBolt2Idx().ToString();
            textBoxEquipBolt2ID.Text = dsProcess.GetEquipBolt2ID().ToString();

            textBoxEquipHelmetIdx.Text = dsProcess.GetEquipHelmetIdx().ToString();
            textBoxEquipHelmetID.Text = dsProcess.GetEquipHelmetID().ToString();

            textBoxEquipChestIdx.Text = dsProcess.GetEquipChestIdx().ToString();
            textBoxEquipChestID.Text = dsProcess.GetEquipChestID().ToString();

            textBoxEquipGloveIdx.Text = dsProcess.GetEquipGloveIdx().ToString();
            textBoxEquipGloveID.Text = dsProcess.GetEquipGloveID().ToString();

            textBoxEquipPantsIdx.Text = dsProcess.GetEquipPantsIdx().ToString();
            textBoxEquipPantsID.Text = dsProcess.GetEquipPantsID().ToString();

            textBoxEquipHairIdx.Text = dsProcess.GetEquipHairIdx().ToString();
            textBoxEquipHairID.Text = dsProcess.GetEquipHairID().ToString();

            textBoxEquipRing1Idx.Text = dsProcess.GetEquipRing1Idx().ToString();
            textBoxEquipRing1ID.Text = dsProcess.GetEquipRing1ID().ToString();

            textBoxEquipRing2Idx.Text = dsProcess.GetEquipRing2Idx().ToString();
            textBoxEquipRing2ID.Text = dsProcess.GetEquipRing2ID().ToString();

            textBoxEquipItem1Idx.Text = dsProcess.GetEquipItem1Idx().ToString();
            textBoxEquipItem1ID.Text = dsProcess.GetEquipItem1ID().ToString();

            textBoxEquipItem2Idx.Text = dsProcess.GetEquipItem2Idx().ToString();
            textBoxEquipItem2ID.Text = dsProcess.GetEquipItem2ID().ToString();

            textBoxEquipItem3Idx.Text = dsProcess.GetEquipItem3Idx().ToString();
            textBoxEquipItem3ID.Text = dsProcess.GetEquipItem3ID().ToString();

            textBoxEquipItem4Idx.Text = dsProcess.GetEquipItem4Idx().ToString();
            textBoxEquipItem4ID.Text = dsProcess.GetEquipItem4ID().ToString();

            textBoxEquipItem5Idx.Text = dsProcess.GetEquipItem5Idx().ToString();
            textBoxEquipItem5ID.Text = dsProcess.GetEquipItem5ID().ToString();

            textBoxStoredMagic.Text = dsProcess.GetStoredMagic().ToString();
            textBoxStoredItem.Text = dsProcess.GetStoredItem().ToString();
        }
    }
}
