using LowLevelHooking;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private GlobalKeyboardHook keyboardHook = new GlobalKeyboardHook();
        private List<GadgetHotkey> hotkeys = new List<GadgetHotkey>();

        private void initHotkeys()
        {
            checkBoxEnableHotkeys.Checked = settings.EnableHotkeys;
            checkBoxHandleHotkeys.Checked = settings.HandleHotkeys;

            hotkeys.Add(new GadgetHotkey("HotkeyFilter", textBoxHotkeyFilter, tabPageHotkeys, () =>
            {
                gadgetTabGraphics.FlipFilter();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyMoveswap", textBoxHotkeyMoveswap, tabPageHotkeys, () =>
            {
                Hook.MoveSwap();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyAnim", textBoxHotkeyAnim, tabPageHotkeys, () =>
            {
                Hook.ResetAnim();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyStore", textBoxHotkeyStore, tabPageHotkeys, () =>
            {
                gadgetTabPlayer.StorePosition();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyRestore", textBoxHotkeyRestore, tabPageHotkeys, () =>
            {
                gadgetTabPlayer.RestorePosition();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyGravity", textBoxHotkeyGravity, tabPageHotkeys, () =>
            {
                gadgetTabPlayer.FlipGravity();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyCollision", textBoxHotkeyCollision, tabPageHotkeys, () =>
            {
                gadgetTabPlayer.FlipCollision();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeySpeed", textBoxHotkeySpeed, tabPageHotkeys, () =>
            {
                gadgetTabPlayer.FlipSpeed();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyMenu", textBoxHotkeyMenu, tabPageHotkeys, () =>
            {
                Hook.MenuKick();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyUp", textBoxHotkeyUp, tabPageHotkeys, () =>
            {
                float x = Hook.PosX;
                float y = Hook.PosY;
                float z = Hook.PosZ;
                float angle = Hook.PosAngle;
                Hook.PosWarp(x, y + 5, z, angle);
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyDown", textBoxHotkeyDown, tabPageHotkeys, () =>
            {
                float x = Hook.PosX;
                float y = Hook.PosY;
                float z = Hook.PosZ;
                float angle = Hook.PosAngle;
                Hook.PosWarp(x, y - 5, z, angle);
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyDeath", textBoxHotkeyDeath, tabPageHotkeys, () =>
            {
                gadgetTabCheats.FlipPlayerDeadMode();
            }));

            hotkeys.Add(new GadgetHotkey("HotkeyItem", txtHotkeyItem, tabPageHotkeys, () =>
            {
                gadgetTabItems.CreateItem();
            }));

            /* Template :^
            hotkeys.Add(new GadgetHotkey("Hotkey", textBoxHotkey, tabPageHotkeys, () =>
            {

            }));
            */

#if DEBUG
            hotkeys.Add(new GadgetHotkey("HotkeyTest1", textBoxHotkeyTest1, tabPageHotkeys, () =>
            {
                Hook.HotkeyTest1();
            }));
            hotkeys.Add(new GadgetHotkey("HotkeyTest2", textBoxHotkeyTest2, tabPageHotkeys, () =>
            {
                Hook.HotkeyTest2();
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
            if (!e.IsUp && Loaded && checkBoxEnableHotkeys.Checked && Hook.Focused)
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
