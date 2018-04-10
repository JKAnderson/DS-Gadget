using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private void initMisc()
        {
            checkBoxStoreHP.Checked = settings.StoreHP;
        }

        private void resetMisc() { }

        private void saveMisc()
        {
            settings.StoreHP = checkBoxStoreHP.Checked;
        }

        private void reloadMisc() { }
        private void updateMisc() { }
    }
}
