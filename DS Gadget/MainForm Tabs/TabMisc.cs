using System;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initMisc() { }
        private void resetMisc() { }
        private void saveMisc() { }
        private void reloadMisc() { }

        private void updateMisc()
        {
            
        }

        private void buttonEventFlagRead_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxEventFlagID.Text, out int id))
                checkBoxEventFlagValue.Checked = dsProcess.ReadEventFlag(id);
        }

        private void buttonEventFlagWrite_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBoxEventFlagID.Text, out int id))
                dsProcess.WriteEventFlag(id, checkBoxEventFlagValue.Checked);
        }
    }
}
