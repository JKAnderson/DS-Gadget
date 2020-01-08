using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    internal partial class GadgetTabItems : GadgetTab
    {
        public GadgetTabItems()
        {
            InitializeComponent();
        }

        public override void InitTab(MainForm parent)
        {
            base.InitTab(parent);
            foreach (DSItemCategory category in DSItemCategory.All)
                cmbCategory.Items.Add(category);
            cmbCategory.SelectedIndex = 0;
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxItems.Items.Clear();
            DSItemCategory category = cmbCategory.SelectedItem as DSItemCategory;
            foreach (DSItem item in category.Items)
                lbxItems.Items.Add(item);
            lbxItems.SelectedIndex = 0;
        }

        private void cbxQuantityRestrict_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbxQuantityRestrict.Checked)
            {
                nudQuantity.Enabled = true;
                nudQuantity.Maximum = int.MaxValue;
            }
            else if (lbxItems.SelectedIndex != -1)
            {
                DSItem item = lbxItems.SelectedItem as DSItem;
                nudQuantity.Maximum = item.StackLimit;
                if (item.StackLimit == 1)
                    nudQuantity.Enabled = false;
            }
        }

        private void cmbInfusion_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSInfusion infusion = cmbInfusion.SelectedItem as DSInfusion;
            nudUpgrade.Maximum = infusion.MaxUpgrade;
        }

        private void lbxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSItem item = lbxItems.SelectedItem as DSItem;
            if (cbxQuantityRestrict.Checked)
            {
                if (item.StackLimit == 1)
                    nudQuantity.Enabled = false;
                else
                    nudQuantity.Enabled = true;
                nudQuantity.Maximum = item.StackLimit;
            }
            switch (item.UpgradeType)
            {
                case DSItem.Upgrade.None:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Enabled = false;
                    nudUpgrade.Maximum = 0;
                    break;
                case DSItem.Upgrade.Unique:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 5;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.Armor:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 10;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.Infusable:
                    cmbInfusion.Items.Clear();
                    foreach (DSInfusion infusion in DSInfusion.All)
                        cmbInfusion.Items.Add(infusion);
                    cmbInfusion.SelectedIndex = 0;
                    cmbInfusion.Enabled = true;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.InfusableRestricted:
                    cmbInfusion.Items.Clear();
                    foreach (DSInfusion infusion in DSInfusion.All)
                        if (!infusion.Restricted)
                            cmbInfusion.Items.Add(infusion);
                    cmbInfusion.SelectedIndex = 0;
                    cmbInfusion.Enabled = true;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.PyroFlame:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 15;
                    nudUpgrade.Enabled = true;
                    break;
                case DSItem.Upgrade.PyroFlameAscended:
                    cmbInfusion.Enabled = false;
                    cmbInfusion.Items.Clear();
                    nudUpgrade.Maximum = 5;
                    nudUpgrade.Enabled = true;
                    break;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateItem();
        }

        private void lbxItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CreateItem();
        }

        public void CreateItem()
        {
            DSItemCategory category = cmbCategory.SelectedItem as DSItemCategory;
            DSItem item = lbxItems.SelectedItem as DSItem;
            int id = item.ID;
            if (item.UpgradeType == DSItem.Upgrade.PyroFlame || item.UpgradeType == DSItem.Upgrade.PyroFlameAscended)
                id += (int)nudUpgrade.Value * 100;
            else
                id += (int)nudUpgrade.Value;
            if (item.UpgradeType == DSItem.Upgrade.Infusable || item.UpgradeType == DSItem.Upgrade.InfusableRestricted)
            {
                DSInfusion infusion = cmbInfusion.SelectedItem as DSInfusion;
                id += infusion.Value;
            }
            Hook.GetItem(category.ID, id, (int)nudQuantity.Value);
        }
    }
}
