using LowLevelHooking;
using Octokit;
using Semver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private static Properties.Settings settings = Properties.Settings.Default;

        private GlobalKeyboardHook keyboardHook = new GlobalKeyboardHook();
        private List<DSItemCategory> categories = new List<DSItemCategory>();
        private DSProcess dsProcess = null;
        private bool loaded = false;
        private bool reading = false;

        public MainForm()
        {
            InitializeComponent();
            Disposed += MainForm_Disposed;
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            keyboardHook.Dispose();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Text = "DS Gadget " + System.Windows.Forms.Application.ProductVersion;
            enableTabs(false);
            if (settings.UpgradeRequired)
            {
                settings.Upgrade();
                settings.UpgradeRequired = false;
            }
            initPlayer();
            initStats();
            initItems();
            initGraphics();
            initCheats();
            initHotkeys();

            GitHubClient gitHubClient = new GitHubClient(new ProductHeaderValue("DS-Gadget"));
            try
            {
                Release release = await gitHubClient.Repository.Release.GetLatest("JKAnderson", "DS-Gadget");
                if (SemVersion.Parse(release.TagName) > System.Windows.Forms.Application.ProductVersion)
                {
                    labelCheckVersion.Visible = false;
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = release.HtmlUrl;
                    linkLabelNewVersion.Links.Add(link);
                    linkLabelNewVersion.Visible = true;
                }
                else
                {
                    labelCheckVersion.Text = "App up to date";
                }
            }
            catch (Exception ex) when (ex is ApiException || ex is ArgumentException)
            {
                labelCheckVersion.Text = "Current app version unknown";
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            savePlayer();
            saveStats();
            saveItems();
            saveGraphics();
            saveCheats();
            saveHotkeys();
            settings.Save();
            if (dsProcess != null)
                dsProcess.Close();
        }

        private void enableTabs(bool enable)
        {
            foreach (TabPage tab in tabControlMain.TabPages)
                tab.Enabled = enable;
        }

        private void timerCheckProcess_Tick(object sender, EventArgs e)
        {
            if (dsProcess == null)
            {
                Process[] candidates = Process.GetProcessesByName("DARKSOULS");
                foreach (Process candidate in candidates)
                {
                    DSProcess result = DSProcess.Attach(candidate, out string version, out bool valid);
                    labelProcess.Text = candidate.Id.ToString();
                    labelVersion.Text = version;
                    if (valid)
                        labelVersion.ForeColor = Color.DarkGreen;
                    else
                        labelVersion.ForeColor = Color.DarkRed;
                    if (result != null)
                        dsProcess = result;
                }
            }
        }

        private void timerUpdateProcess_Tick(object sender, EventArgs e)
        {
            if (dsProcess != null)
            {
                if (dsProcess.Alive())
                {
                    if (dsProcess.Loaded())
                    {
                        if (!loaded)
                        {
                            labelLoaded.Text = "Yes";
                            enableTabs(true);
                            dsProcess.LoadPointers();
                            reading = true;
                            reloadPlayer();
                            reloadStats();
                            reloadItems();
                            reloadGraphics();
                            reloadCheats();
                            reloadHotkeys();
                            reading = false;
                            loaded = true;
                        }
                        else
                        {
                            reading = true;
                            updatePlayer();
                            updateStats();
                            updateItems();
                            updateGraphics();
                            updateCheats();
                            updateHotkeys();
                            reading = false;
                        }
                    }
                    else if (loaded && !dsProcess.Loaded())
                    {
                        labelLoaded.Text = "No";
                        enableTabs(false);
                        loaded = false;
                    }
                }
                else
                {
                    dsProcess.Close();
                    dsProcess = null;
                    labelProcess.Text = "None";
                    labelVersion.Text = "None";
                    labelVersion.ForeColor = Color.Black;
                    labelLoaded.Text = "No";
                    enableTabs(false);
                    loaded = false;
                }
            }
        }

        private void linkLabelNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }

        #region Player Tab
        private int skipBonfire = 0;

        private void initPlayer()
        {
            foreach (DSBonfire bonfire in DSBonfire.All)
                comboBoxBonfire.Items.Add(bonfire);
            comboBoxBonfire.SelectedIndex = 0;
            numericUpDownSpeed.Value = settings.Speed;
        }

        private void savePlayer()
        {
            settings.Speed = numericUpDownSpeed.Value;

            if (dsProcess != null)
            {
                dsProcess.SetPosLock(false);
            }
        }

        private void reloadPlayer()
        {
            checkBoxPosLock.Checked = false;
            dsProcess.SetGravity(checkBoxGravity.Checked);
            checkBoxCollision.Checked = true;
            if (checkBoxSpeed.Checked)
                dsProcess.SetSpeed((float)numericUpDownSpeed.Value);
        }

        private void updatePlayer()
        {
            numericUpDownHP.Value = (decimal)dsProcess.GetHP();
            numericUpDownHPMax.Value = (decimal)dsProcess.GetHPMax();
            numericUpDownHPModMax.Value = (decimal)dsProcess.GetHPModMax();
            numericUpDownStam.Value = (decimal)dsProcess.GetStam();
            numericUpDownStamMax.Value = (decimal)dsProcess.GetStamMax();
            numericUpDownStamModMax.Value = (decimal)dsProcess.GetStamModMax();
            numericUpDownPhantom.Value = dsProcess.GetPhantomType();
            numericUpDownTeam.Value = dsProcess.GetTeamType();

            textBoxWorld.Text = dsProcess.GetWorld().ToString();
            textBoxArea.Text = dsProcess.GetArea().ToString();
            numericUpDownPosX.Value = (decimal)dsProcess.GetPosX();
            numericUpDownPosY.Value = (decimal)dsProcess.GetPosY();
            numericUpDownPosZ.Value = (decimal)dsProcess.GetPosZ();
            numericUpDownPosAngle.Value = (decimal)((dsProcess.GetPosAngle() + Math.PI) / (Math.PI * 2) * 360);
            numericUpDownPosStableX.Value = (decimal)dsProcess.GetPosStableX();
            numericUpDownPosStableY.Value = (decimal)dsProcess.GetPosStableY();
            numericUpDownPosStableZ.Value = (decimal)dsProcess.GetPosStableZ();
            numericUpDownPosStableAngle.Value = (decimal)((dsProcess.GetPosStableAngle() + Math.PI) / (Math.PI * 2) * 360);

            checkBoxDeathCam.Checked = dsProcess.GetDeathCam();

            int bonfireID = dsProcess.GetBonfire();
            if (bonfireID != skipBonfire && !comboBoxBonfire.DroppedDown && bonfireID != (comboBoxBonfire.SelectedItem as DSBonfire).ID)
            {
                object result = null;
                foreach (object bonfire in comboBoxBonfire.Items)
                {
                    if (bonfireID == (bonfire as DSBonfire).ID)
                        result = bonfire;
                }
                if (result != null)
                    comboBoxBonfire.SelectedItem = result;
                else
                {
                    skipBonfire = bonfireID;
                    MessageBox.Show("Unknown bonfire ID, please report me: " + bonfireID, "Unknown Bonfire");
                }
            }
        }

        private void numericUpDownPhantom_ValueChanged(object sender, EventArgs e)
        {
            dsProcess.SetPhantomType((int)numericUpDownPhantom.Value);
        }

        private void numericUpDownTeam_ValueChanged(object sender, EventArgs e)
        {
            dsProcess.SetTeamType((int)numericUpDownTeam.Value);
        }

        private void checkBoxPosLock_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPosLock(checkBoxPosLock.Checked);
            numericUpDownPosX.Enabled = checkBoxPosLock.Checked;
            numericUpDownPosY.Enabled = checkBoxPosLock.Checked;
            numericUpDownPosZ.Enabled = checkBoxPosLock.Checked;
        }

        private void numericUpDownPosX_ValueChanged(object sender, EventArgs e)
        {
            setPos();
        }

        private void numericUpDownPosY_ValueChanged(object sender, EventArgs e)
        {
            setPos();
        }

        private void numericUpDownPosZ_ValueChanged(object sender, EventArgs e)
        {
            setPos();
        }

        private void setPos()
        {
            if (checkBoxPosLock.Checked)
            {
                float x = (float)numericUpDownPosX.Value;
                float y = (float)numericUpDownPosY.Value;
                float z = (float)numericUpDownPosZ.Value;
                dsProcess?.SetPos(x, y, z);
            }
        }

        private void buttonPosStore_Click(object sender, EventArgs e)
        {
            posStore();
        }

        private void posStore()
        {
            numericUpDownPosStoredX.Value = numericUpDownPosX.Value;
            numericUpDownPosStoredY.Value = numericUpDownPosY.Value;
            numericUpDownPosStoredZ.Value = numericUpDownPosZ.Value;
            numericUpDownPosStoredAngle.Value = numericUpDownPosAngle.Value;
        }

        private void buttonPosRestore_Click(object sender, EventArgs e)
        {
            posRestore();
        }

        private void posRestore()
        {
            float x = (float)numericUpDownPosStoredX.Value;
            float y = (float)numericUpDownPosStoredY.Value;
            float z = (float)numericUpDownPosStoredZ.Value;
            float angle = (float)((double)numericUpDownPosStoredAngle.Value / 360 * (Math.PI * 2) - Math.PI);
            dsProcess?.PosWarp(x, y, z, angle);
        }

        private void checkBoxGravity_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetGravity(checkBoxGravity.Checked);
        }

        private void checkBoxCollision_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetCollision(checkBoxCollision.Checked);
        }

        private void checkBoxDeathCam_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetDeathCam(checkBoxDeathCam.Checked);
        }

        private void comboBoxBonfire_SelectedIndexChanged(object sender, EventArgs e)
        {
            DSBonfire bonfire = comboBoxBonfire.SelectedItem as DSBonfire;
            dsProcess?.SetBonfire(bonfire.ID);
        }

        private void checkBoxSpeed_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownSpeed.Enabled = checkBoxSpeed.Checked;
            dsProcess?.SetSpeed(checkBoxSpeed.Checked ? (float)numericUpDownSpeed.Value : 1);
        }

        private void numericUpDownSpeed_ValueChanged(object sender, EventArgs e)
        {
            dsProcess?.SetSpeed((float)numericUpDownSpeed.Value);
        }
        #endregion

        #region Stats Tab
        private void initStats()
        {
            foreach (DSClass charClass in DSClass.All)
                comboBoxClass.Items.Add(charClass);
            numericUpDownHumanity.Maximum = Int32.MaxValue;
            numericUpDownHumanity.Minimum = Int32.MinValue;
        }

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
            dsProcess.SetClass(charClass.ID);
            numericUpDownVit.Minimum = charClass.Vitality;
            numericUpDownAtt.Minimum = charClass.Attunement;
            numericUpDownEnd.Minimum = charClass.Endurance;
            numericUpDownStr.Minimum = charClass.Strength;
            numericUpDownDex.Minimum = charClass.Dexterity;
            numericUpDownRes.Minimum = charClass.Resistance;
            numericUpDownInt.Minimum = charClass.Intelligence;
            numericUpDownFth.Minimum = charClass.Faith;
            if (!reading)
                recalculateStats();
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
        #endregion

        #region Graphics Tab
        private void initGraphics()
        {
            checkBoxFilter.Checked = settings.FilterEnable;
            checkBoxBrightnessSync.Checked = settings.FilterBrightnessSync;
            numericUpDownBrightnessR.Value = settings.FilterBrightnessR;
            numericUpDownBrightnessG.Value = settings.FilterBrightnessG;
            numericUpDownBrightnessB.Value = settings.FilterBrightnessB;
            checkBoxContrastSync.Checked = settings.FilterContrastSync;
            numericUpDownContrastR.Value = settings.FilterContrastR;
            numericUpDownContrastG.Value = settings.FilterContrastG;
            numericUpDownContrastB.Value = settings.FilterContrastB;
            numericUpDownSaturation.Value = settings.FilterSaturation;
            numericUpDownHue.Value = settings.FilterHue;
        }

        private void saveGraphics()
        {
            settings.FilterEnable = checkBoxFilter.Checked;
            settings.FilterBrightnessSync = checkBoxBrightnessSync.Checked;
            settings.FilterBrightnessR = numericUpDownBrightnessR.Value;
            settings.FilterBrightnessG = numericUpDownBrightnessG.Value;
            settings.FilterBrightnessB = numericUpDownBrightnessB.Value;
            settings.FilterContrastSync = checkBoxContrastSync.Checked;
            settings.FilterContrastR = numericUpDownContrastR.Value;
            settings.FilterContrastG = numericUpDownContrastG.Value;
            settings.FilterContrastB = numericUpDownContrastB.Value;
            settings.FilterSaturation = numericUpDownSaturation.Value;
            settings.FilterHue = numericUpDownHue.Value;

            if (dsProcess != null)
            {
                dsProcess.DrawMap(true);
                dsProcess.DrawCreatures(true);
                dsProcess.DrawObjects(true);
                dsProcess.DrawSFX(true);

                dsProcess.DrawSpriteMasks(true);
                dsProcess.DrawSprites(true);
                dsProcess.DrawTrans(true);
                dsProcess.DrawShadows(true);
                dsProcess.DrawSpriteShadows(true);
                dsProcess.DrawTextures(true);

                dsProcess.DrawBounding(false);
                dsProcess.DrawCompassLarge(false);
                dsProcess.DrawCompassSmall(false);
                dsProcess.DrawAltimeter(false);
                dsProcess.DrawNodes(false);

                dsProcess.OverrideFilter(true);
            }
        }

        private void reloadGraphics()
        {
            dsProcess.DrawMap(checkBoxMap.Checked);
            dsProcess.DrawCreatures(checkBoxCreatures.Checked);
            dsProcess.DrawObjects(checkBoxObjects.Checked);
            dsProcess.DrawSFX(checkBoxSFX.Checked);

            dsProcess.DrawSpriteMasks(checkBoxSpriteMasks.Checked);
            dsProcess.DrawSprites(checkBoxSprites.Checked);
            dsProcess.DrawTrans(checkBoxDrawTrans.Checked);
            dsProcess.DrawShadows(checkBoxShadows.Checked);
            dsProcess.DrawSpriteShadows(checkBoxSpriteShadows.Checked);
            dsProcess.DrawTextures(checkBoxTextures.Checked);

            dsProcess.DrawBounding(checkBoxBounding.Checked);
            dsProcess.DrawCompassLarge(checkBoxCompassLarge.Checked);
            dsProcess.DrawCompassSmall(checkBoxCompassSmall.Checked);
            dsProcess.DrawAltimeter(checkBoxAltimeter.Checked);
            dsProcess.DrawNodes(checkBoxNodes.Checked);

            dsProcess.OverrideFilter(checkBoxFilter.Checked);
            updateBrightness();
            updateContrast();
            dsProcess.SetSaturation((float)numericUpDownSaturation.Value);
            dsProcess.SetHue((float)numericUpDownHue.Value);
        }

        private void updateGraphics() { }

        private void checkBoxBounding_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawBounding(checkBoxBounding.Checked);
        }

        private void checkBoxSpriteMasks_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSpriteMasks(checkBoxSpriteMasks.Checked);
        }

        private void checkBoxSprites_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSprites(checkBoxSprites.Checked);
        }

        private void checkBoxDrawTrans_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawTrans(checkBoxDrawTrans.Checked);
        }

        private void checkBoxShadows_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawShadows(checkBoxShadows.Checked);
        }

        private void checkBoxSpriteShadows_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSpriteShadows(checkBoxSpriteShadows.Checked);
        }

        private void checkBoxTextures_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawTextures(checkBoxTextures.Checked);
        }

        private void checkBoxMap_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawMap(checkBoxMap.Checked);
        }

        private void checkBoxCreatures_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawCreatures(checkBoxCreatures.Checked);
        }

        private void checkBoxObjects_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawObjects(checkBoxObjects.Checked);
        }

        private void checkBoxSFX_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawSFX(checkBoxSFX.Checked);
        }

        private void checkBoxCompassLarge_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawCompassLarge(checkBoxCompassLarge.Checked);
        }

        private void checkBoxCompassSmall_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawCompassSmall(checkBoxCompassSmall.Checked);
        }

        private void checkBoxAltimeter_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawAltimeter(checkBoxAltimeter.Checked);
        }

        private void checkBoxNodes_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.DrawNodes(checkBoxNodes.Checked);
        }

        private void checkBoxFilter_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.OverrideFilter(checkBoxFilter.Checked);
        }

        private void updateBrightness()
        {
            float brightnessR = (float)numericUpDownBrightnessR.Value;
            float brightnessG = (float)numericUpDownBrightnessG.Value;
            float brightnessB = (float)numericUpDownBrightnessB.Value;
            dsProcess?.SetBrightness(brightnessR, brightnessG, brightnessB);
        }

        private void checkBoxBrightnessSync_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownBrightnessG.Enabled = !checkBoxBrightnessSync.Checked;
            numericUpDownBrightnessB.Enabled = !checkBoxBrightnessSync.Checked;
        }

        private void numericUpDownBrightnessR_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxBrightnessSync.Checked)
            {
                numericUpDownBrightnessG.Value = numericUpDownBrightnessR.Value;
                numericUpDownBrightnessB.Value = numericUpDownBrightnessR.Value;
            }
            updateBrightness();
        }

        private void numericUpDownBrightnessG_ValueChanged(object sender, EventArgs e)
        {
            updateBrightness();
        }

        private void numericUpDownBrightnessB_ValueChanged(object sender, EventArgs e)
        {
            updateBrightness();
        }


        private void updateContrast()
        {
            float contrastR = (float)numericUpDownContrastR.Value;
            float contrastG = (float)numericUpDownContrastG.Value;
            float contrastB = (float)numericUpDownContrastB.Value;
            dsProcess?.SetContrast(contrastR, contrastG, contrastB);
        }

        private void checkBoxContrastSync_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDownContrastG.Enabled = !checkBoxContrastSync.Checked;
            numericUpDownContrastB.Enabled = !checkBoxContrastSync.Checked;
        }

        private void numericUpDownContrastR_ValueChanged(object sender, EventArgs e)
        {
            if (checkBoxContrastSync.Checked)
            {
                numericUpDownContrastG.Value = numericUpDownContrastR.Value;
                numericUpDownContrastB.Value = numericUpDownContrastR.Value;
            }
            updateContrast();
        }

        private void numericUpDownContrastG_ValueChanged(object sender, EventArgs e)
        {
            updateContrast();
        }

        private void numericUpDownContrastB_ValueChanged(object sender, EventArgs e)
        {
            updateContrast();
        }

        private void numericUpDownSaturation_ValueChanged(object sender, EventArgs e)
        {
            dsProcess?.SetSaturation((float)numericUpDownSaturation.Value);
        }

        private void numericUpDownHue_ValueChanged(object sender, EventArgs e)
        {
            dsProcess?.SetHue((float)numericUpDownHue.Value);
        }
        #endregion

        #region Items Tab
        private void initItems()
        {
            foreach (DSInfusion infusion in DSInfusion.All)
                comboBoxInfusion.Items.Add(infusion);
            comboBoxInfusion.SelectedIndex = 0;
            foreach (DSItemCategory category in DSItemCategory.All)
                comboBoxCategory.Items.Add(category);
            comboBoxCategory.SelectedIndex = 0;
        }

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
        #endregion

        #region Cheats Tab
        private void initCheats() { }
        private void saveCheats()
        {
            dsProcess.SetAllNoMagic(false);
            dsProcess.SetNoDead(false);
            dsProcess.SetExterminate(false);
            dsProcess.SetAllStamina(false);
            dsProcess.SetAllAmmo(false);
            dsProcess.SetHide(false);
            dsProcess.SetSilence(false);
            dsProcess.SetAllNoDead(false);
            dsProcess.SetAllNoDamage(false);
            dsProcess.SetAllNoHit(false);
            dsProcess.SetAllNoAttack(false);
            dsProcess.SetAllNoMove(false);
            dsProcess.SetAllNoUpdateAI(false);
        }

        private void reloadCheats()
        {
            dsProcess.SetPlayerDeadMode(checkBoxPlayerDeadMode.Checked);
            dsProcess.SetPlayerNoDamage(checkBoxPlayerNoDamage.Checked);
            dsProcess.SetPlayerNoHit(checkBoxPlayerNoHit.Checked);
            dsProcess.SetPlayerNoStamina(checkBoxPlayerNoStamina.Checked);
            dsProcess.SetPlayerSuperArmor(checkBoxPlayerSuperArmor.Checked);
            dsProcess.SetPlayerNoGoods(checkBoxPlayerNoGoods.Checked);
            dsProcess.SetAllNoMagic(checkBoxAllNoMagic.Checked);
            dsProcess.SetNoDead(checkBoxPlayerNoDead.Checked);
            dsProcess.SetExterminate(checkBoxPlayerExterminate.Checked);
            dsProcess.SetAllStamina(checkBoxAllNoStamina.Checked);
            dsProcess.SetAllAmmo(checkBoxAllNoArrow.Checked);
            dsProcess.SetHide(checkBoxPlayerHide.Checked);
            dsProcess.SetSilence(checkBoxPlayerSilence.Checked);
            dsProcess.SetAllNoDead(checkBoxAllNoDead.Checked);
            dsProcess.SetAllNoDamage(checkBoxAllNoDamage.Checked);
            dsProcess.SetAllNoHit(checkBoxAllNoHit.Checked);
            dsProcess.SetAllNoAttack(checkBoxAllNoAttack.Checked);
            dsProcess.SetAllNoMove(checkBoxAllNoMove.Checked);
            dsProcess.SetAllNoUpdateAI(checkBoxAllNoUpdateAI.Checked);
        }

        private void updateCheats() { }

        private void checkBoxPlayerDeadMode_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerDeadMode(checkBoxPlayerDeadMode.Checked);
        }

        private void checkBoxPlayerNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoDamage(checkBoxPlayerNoDamage.Checked);
        }

        private void checkBoxPlayerNoHit_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoHit(checkBoxPlayerNoHit.Checked);
        }

        private void checkBoxPlayerNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoStamina(checkBoxPlayerNoStamina.Checked);
        }

        private void checkBoxPlayerSuperArmor_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerSuperArmor(checkBoxPlayerSuperArmor.Checked);
        }

        private void checkBoxPlayerNoGoods_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess?.SetPlayerNoGoods(checkBoxPlayerNoGoods.Checked);
        }

        private void checkBoxAllNoMagic_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoMagic(checkBoxAllNoMagic.Checked);
        }

        private void checkBoxPlayerNoDead_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetNoDead(checkBoxPlayerNoDead.Checked);
        }

        private void checkBoxPlayerExterminate_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetExterminate(checkBoxPlayerExterminate.Checked);
        }

        private void checkBoxAllNoStamina_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllStamina(checkBoxAllNoStamina.Checked);
        }

        private void checkBoxAllNoArrow_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllAmmo(checkBoxAllNoArrow.Checked);
        }

        private void checkBoxPlayerHide_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetHide(checkBoxPlayerHide.Checked);
        }

        private void checkBoxPlayerSilence_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetSilence(checkBoxPlayerSilence.Checked);
        }

        private void checkBoxAllNoDead_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoDead(checkBoxAllNoDead.Checked);
        }

        private void checkBoxAllNoDamage_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoDamage(checkBoxAllNoDamage.Checked);
        }

        private void checkBoxAllNoHit_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoHit(checkBoxAllNoHit.Checked);
        }

        private void checkBoxAllNoAttack_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoAttack(checkBoxAllNoAttack.Checked);
        }

        private void checkBoxAllNoMove_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoMove(checkBoxAllNoMove.Checked);
        }

        private void checkBoxAllNoUpdateAI_CheckedChanged(object sender, EventArgs e)
        {
            dsProcess.SetAllNoUpdateAI(checkBoxAllNoUpdateAI.Checked);
        }
        #endregion

        #region Hotkeys Tab
        private KeysConverter keyConverter = new KeysConverter();
        private List<GadgetHotkey> hotkeys = new List<GadgetHotkey>();

        private void initHotkeys()
        {
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

            keyboardHook.KeyDownOrUp += GlobalKeyboardHook_KeyDownOrUp;
        }

        private void saveHotkeys()
        {
            foreach (GadgetHotkey hotkey in hotkeys)
                hotkey.Save();
        }

        private void reloadHotkeys() { }
        private void updateHotkeys() { }

        private void GlobalKeyboardHook_KeyDownOrUp(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (loaded && dsProcess.Focused() && !e.IsUp)
            {
                foreach (GadgetHotkey hotkey in hotkeys)
                {
                    hotkey.Trigger(e.KeyCode);
                }
            }
        }
        #endregion
    }
}
