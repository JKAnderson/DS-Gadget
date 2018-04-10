using LowLevelHooking;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {

        private GlobalKeyboardHook keyboardHook = new GlobalKeyboardHook();
        private KeysConverter keyConverter = new KeysConverter();
        private List<GadgetHotkey> hotkeys = new List<GadgetHotkey>();

        private void initHotkeys()
        {
            checkBoxEnableHotkeys.Checked = settings.EnableHotkeys;
            checkBoxHandleHotkeys.Checked = settings.HandleHotkeys;

            hotkeys.Add(new GadgetHotkey("HotkeyFilter", textBoxHotkeyFilter, tabPageHotkeys, () =>
            {
                checkBoxFilter.Checked = !checkBoxFilter.Checked;
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyMoveswap", textBoxHotkeyMoveswap, tabPageHotkeys, () =>
            {
                dsProcess.MoveSwap();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyAnim", textBoxHotkeyAnim, tabPageHotkeys, () =>
            {
                dsProcess.ResetAnim();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyStore", textBoxHotkeyStore, tabPageHotkeys, () =>
            {
                posStore();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyRestore", textBoxHotkeyRestore, tabPageHotkeys, () =>
            {
                posRestore();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyGravity", textBoxHotkeyGravity, tabPageHotkeys, () =>
            {
                checkBoxGravity.Checked = !checkBoxGravity.Checked;
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyCollision", textBoxHotkeyCollision, tabPageHotkeys, () =>
            {
                checkBoxCollision.Checked = !checkBoxCollision.Checked;
            }));

            hotkeys.Add(new GadgetHotkey("HotkeySpeed", textBoxHotkeySpeed, tabPageHotkeys, () =>
            {
                checkBoxSpeed.Checked = !checkBoxSpeed.Checked;
            }));

#if DEBUG
            hotkeys.Add(new GadgetHotkey("HotkeyTest1", textBoxHotkeyTest1, tabPageHotkeys, () =>
            {
                posStore();
                dsProcess.HotkeyTest1();
            }));
            hotkeys.Add(new GadgetHotkey("HotkeyTest2", textBoxHotkeyTest2, tabPageHotkeys, () =>
            {
                posRestore();
                //System.Threading.Thread.Sleep(1000 / 15);
                dsProcess.HotkeyTest2();
            }));
#else
            textBoxHotkeyTest1.Visible = false;
            labelHotkeyTest1.Visible = false;
            textBoxHotkeyTest2.Visible = false;
            labelHotkeyTest2.Visible = false;
#endif

            keyboardHook.KeyDownOrUp += GlobalKeyboardHook_KeyDownOrUp;
        }

        private void resetHotkeys() { }

        private void saveHotkeys()
        {
            settings.EnableHotkeys = checkBoxEnableHotkeys.Checked;
            settings.HandleHotkeys = checkBoxHandleHotkeys.Checked;
            foreach (GadgetHotkey hotkey in hotkeys)
                hotkey.Save();
            keyboardHook.Dispose();
        }

        private void reloadHotkeys() { }
        private void updateHotkeys() { }

        private void GlobalKeyboardHook_KeyDownOrUp(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (checkBoxEnableHotkeys.Checked && loaded && dsProcess.Focused() && !e.IsUp)
            {
                foreach (GadgetHotkey hotkey in hotkeys)
                {
                    if (hotkey.Trigger(e.KeyCode) && checkBoxHandleHotkeys.Checked)
                        e.Handled = true;
                }
            }
        }
    }
}
