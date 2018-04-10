using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initStats()
        {
            foreach (DSClass charClass in DSClass.All)
                comboBoxClass.Items.Add(charClass);
            numericUpDownHumanity.Maximum = Int32.MaxValue;
            numericUpDownHumanity.Minimum = Int32.MinValue;
        }

        private void resetStats() { }
        private void saveStats() { }

        private void reloadStats()
        {
            comboBoxClass.SelectedIndex = dsProcess.GetClass();
        }

        private void updateStats()
        {
            textBoxSoulLevel.Text = dsProcess.GetSoulLevel().ToString();
            numericUpDownHumanity.Value = dsProcess.GetHumanity();
            numericUpDownSouls.Value = dsProcess.GetSouls();
            try
            {
                numericUpDownVit.Value = dsProcess.GetVitality();
                numericUpDownAtt.Value = dsProcess.GetAttunement();
                numericUpDownEnd.Value = dsProcess.GetEndurance();
                numericUpDownStr.Value = dsProcess.GetStrength();
                numericUpDownDex.Value = dsProcess.GetDexterity();
                numericUpDownRes.Value = dsProcess.GetResistance();
                numericUpDownInt.Value = dsProcess.GetIntelligence();
                numericUpDownFth.Value = dsProcess.GetFaith();
            }
            // Race condition when checking if the game is still loaded; doesn't really matter
            catch (ArgumentOutOfRangeException) { return; }
        }

        private void recalculateStats()
        {
            DSClass charClass = comboBoxClass.SelectedItem as DSClass;
            int sl = charClass.SoulLevel;
            sl += (int)numericUpDownVit.Value - charClass.Vitality;
            dsProcess.SetVitality((int)numericUpDownVit.Value);
            sl += (int)numericUpDownAtt.Value - charClass.Attunement;
            dsProcess.SetAttunement((int)numericUpDownAtt.Value);
            sl += (int)numericUpDownEnd.Value - charClass.Endurance;
            dsProcess.SetEndurance((int)numericUpDownEnd.Value);
            sl += (int)numericUpDownStr.Value - charClass.Strength;
            dsProcess.SetStrength((int)numericUpDownStr.Value);
            sl += (int)numericUpDownDex.Value - charClass.Dexterity;
            dsProcess.SetDexterity((int)numericUpDownDex.Value);
            sl += (int)numericUpDownRes.Value - charClass.Resistance;
            dsProcess.SetResistance((int)numericUpDownRes.Value);
            sl += (int)numericUpDownInt.Value - charClass.Intelligence;
            dsProcess.SetIntelligence((int)numericUpDownInt.Value);
            sl += (int)numericUpDownFth.Value - charClass.Faith;
            dsProcess.SetFaith((int)numericUpDownFth.Value);
            dsProcess.SetSoulLevel(sl);
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSClass charClass = comboBoxClass.SelectedItem as DSClass;
            numericUpDownVit.Minimum = charClass.Vitality;
            numericUpDownAtt.Minimum = charClass.Attunement;
            numericUpDownEnd.Minimum = charClass.Endurance;
            numericUpDownStr.Minimum = charClass.Strength;
            numericUpDownDex.Minimum = charClass.Dexterity;
            numericUpDownRes.Minimum = charClass.Resistance;
            numericUpDownInt.Minimum = charClass.Intelligence;
            numericUpDownFth.Minimum = charClass.Faith;
            if (!reading)
            {
                dsProcess.SetClass(charClass.ID);
                recalculateStats();
            }
        }

        private void numericUpDownStats_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                recalculateStats();
        }

        private void numericUpDownHumanity_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                dsProcess?.SetHumanity((int)numericUpDownHumanity.Value);
        }

        private void numericUpDownSouls_ValueChanged(object sender, EventArgs e)
        {
            if (!reading)
                dsProcess?.SetSouls((int)numericUpDownSouls.Value);
        }
    }
}
