using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initItems()
        {
            foreach (DSInfusion infusion in DSInfusion.All)
                comboBoxInfusion.Items.Add(infusion);
            comboBoxInfusion.SelectedIndex = 0;
            foreach (DSItemCategory category in DSItemCategory.All)
                comboBoxCategory.Items.Add(category);
            comboBoxCategory.SelectedIndex = 0;
        }

        private void resetItems() { }
        private void saveItems() { }
        private void reloadItems() { }
        private void updateItems() { }

        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxItems.Items.Clear();
            DSItemCategory category = comboBoxCategory.SelectedItem as DSItemCategory;
            foreach (DSItem item in category.Items)
                listBoxItems.Items.Add(item);
            listBoxItems.SelectedIndex = 0;
        }

        private void comboBoxInfusion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSInfusion infusion = comboBoxInfusion.SelectedItem as DSInfusion;
            numericUpDownUpgrade.Maximum = infusion.MaxUpgrade;
        }

        private void checkBoxRestrictQuantity_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxRestrictQuantity.Checked)
            {
                numericUpDownQuantity.Enabled = true;
                numericUpDownQuantity.Maximum = Int32.MaxValue;
            }
            else if (listBoxItems.SelectedIndex != -1)
            {
                DSItem item = listBoxItems.SelectedItem as DSItem;
                numericUpDownQuantity.Maximum = item.StackLimit;
                if (item.StackLimit == 1)
                    numericUpDownQuantity.Enabled = false;
            }
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSItem item = listBoxItems.SelectedItem as DSItem;
            if (checkBoxRestrictQuantity.Checked)
            {
                if (item.StackLimit == 1)
                    numericUpDownQuantity.Enabled = false;
                else
                    numericUpDownQuantity.Enabled = true;
                numericUpDownQuantity.Maximum = item.StackLimit;
            }
            if (item.Infusable)
            {
                comboBoxInfusion.Enabled = true;
                DSInfusion infusion = comboBoxInfusion.SelectedItem as DSInfusion;
                numericUpDownUpgrade.Enabled = true;
                numericUpDownUpgrade.Maximum = infusion.MaxUpgrade;
            }
            else
            {
                comboBoxInfusion.Enabled = false;
                numericUpDownUpgrade.Maximum = item.MaxUpgrade;
                if (item.MaxUpgrade > 0)
                    numericUpDownUpgrade.Enabled = true;
                else
                    numericUpDownUpgrade.Enabled = false;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            createItem();
        }

        private void listBoxItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            createItem();
        }

        private void createItem()
        {
            DSItemCategory category = comboBoxCategory.SelectedItem as DSItemCategory;
            DSItem item = listBoxItems.SelectedItem as DSItem;
            int id = item.ID + (int)numericUpDownUpgrade.Value;
            if (item.Infusable)
            {
                DSInfusion infusion = comboBoxInfusion.SelectedItem as DSInfusion;
                id += infusion.Value;
            }
            dsProcess.DropItem(category.ID, id, (int)numericUpDownQuantity.Value);
        }
    }
}
