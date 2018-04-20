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
            int vitality = (int)numericUpDownVit.Value;
            int attunement = (int)numericUpDownAtt.Value;
            int endurance = (int)numericUpDownEnd.Value;
            int strength = (int)numericUpDownStr.Value;
            int dexterity = (int)numericUpDownDex.Value;
            int resistance = (int)numericUpDownRes.Value;
            int intelligence = (int)numericUpDownInt.Value;
            int faith = (int)numericUpDownFth.Value;

            DSClass charClass = comboBoxClass.SelectedItem as DSClass;
            int sl = charClass.SoulLevel;
            sl += vitality - charClass.Vitality;
            sl += attunement - charClass.Attunement;
            sl += endurance - charClass.Endurance;
            sl += strength - charClass.Strength;
            sl += dexterity - charClass.Dexterity;
            sl += resistance - charClass.Resistance;
            sl += intelligence - charClass.Intelligence;
            sl += faith - charClass.Faith;

            dsProcess.LevelUp(vitality, attunement, endurance, strength, dexterity, resistance, intelligence, faith, sl);
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
