using System;

namespace DS_Gadget
{
    internal partial class GadgetTabMisc : GadgetTab
    {
        public GadgetTabMisc()
        {
            InitializeComponent();
        }

        private void btnEventFlagRead_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEventFlagID.Text, out int id))
                cbxEventFlagValue.Checked = Hook.ReadEventFlag(id);
        }

        private void btnEventFlagWrite_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtEventFlagID.Text, out int id))
                Hook.WriteEventFlag(id, cbxEventFlagValue.Checked);
        }

        private void btnUnlockGestures_Click(object sender, EventArgs e)
        {
            Hook.UnlockAllGestures();
        }
    }
}
