using LowLevelHooking;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DS_Gadget
{
    class GadgetHotkey
    {
        private string settingsName;
        private TextBox hotkeyTextBox;
        private TabPage hotkeyTabPage;
        private Action hotkeyAction;

        public VirtualKey Key;

        public GadgetHotkey(string setSettingsName, TextBox setTextBox, TabPage setTabPage, Action setAction)
        {
            settingsName = setSettingsName;
            hotkeyTextBox = setTextBox;
            hotkeyTabPage = setTabPage;
            hotkeyAction = setAction;

            Key = (VirtualKey)(int)Properties.Settings.Default[settingsName];
            hotkeyTextBox.Text = Key.ToString();
            hotkeyTextBox.Enter += new EventHandler(enter);
            hotkeyTextBox.Leave += new EventHandler(leave);
            hotkeyTextBox.KeyUp += new KeyEventHandler(keyUp);
        }

        private void enter(object sender, EventArgs e)
        {
            hotkeyTextBox.BackColor = Color.LightGreen;
        }

        private void leave(object sender, EventArgs e)
        {
            hotkeyTextBox.BackColor = Color.White;
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            Key = (VirtualKey)e.KeyValue;
            hotkeyTextBox.Text = Key.ToString();
            e.Handled = true;
            hotkeyTabPage.Focus();
        }

        public bool Trigger(VirtualKey pressed)
        {
            if (pressed == Key)
                hotkeyAction();
            return pressed == Key;
        }

        public void Save()
        {
            Properties.Settings.Default[settingsName] = (int)Key;
        }
    }
}
