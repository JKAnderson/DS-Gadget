using Octokit;
using Semver;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;

namespace DS_Gadget
{
    public partial class MainForm : Form
    {
        private static Properties.Settings settings = Properties.Settings.Default;

        private DSHook Hook;
        private bool loaded = false;
        private bool reading = false;

        public MainForm()
        {
            InitializeComponent();
            Hook = new DSHook(5000, 5000);
            Hook.OnHooked += Hook_OnHooked;
            Hook.OnUnhooked += Hook_OnUnhooked;
            Hook.Start();
        }

        private void Hook_OnHooked(object sender, PropertyHook.PHEventArgs e)
        {
            Invoke(new Action(() =>
            {
                labelProcess.Text = Hook.ID.ToString();
                labelVersion.Text = Hook.Version;
                labelVersion.ForeColor = Hook.Valid ? Color.DarkGreen : Color.DarkOrange;
            }));
        }

        private void Hook_OnUnhooked(object sender, PropertyHook.PHEventArgs e)
        {
            Invoke(new Action(() =>
            {
                labelProcess.Text = "None";
                labelVersion.Text = "None";
                labelVersion.ForeColor = Color.Black;
                labelLoaded.Text = "No";
                enableTabs(false);
                loaded = false;
            }));
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Location = settings.WindowLocation;
            Text = "DS Gadget " + System.Windows.Forms.Application.ProductVersion;
            enableTabs(false);
            InitAllTabs();

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
            catch (Exception ex) when (ex is HttpRequestException || ex is ApiException || ex is ArgumentException)
            {
                labelCheckVersion.Text = "Current app version unknown";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                settings.WindowLocation = Location;
            else
                settings.WindowLocation = RestoreBounds.Location;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveAllTabs();
            ResetAllTabs();
        }

        private void enableTabs(bool enable)
        {
            foreach (TabPage tab in tabControlMain.TabPages)
                tab.Enabled = enable;
        }

        private void timerUpdateProcess_Tick(object sender, EventArgs e)
        {
            if (Hook.Hooked)
            {
                if (Hook.Loaded)
                {
                    if (!loaded)
                    {
                        labelLoaded.Text = "Yes";
                        loaded = true;
                        reading = true;
                        ReloadAllTabs();
                        reading = false;
                        enableTabs(true);
                    }
                    else
                    {
                        reading = true;
                        UpdateAllTabs();
                        reading = false;
                    }
                }
                else if (loaded)
                {
                    labelLoaded.Text = "No";
                    enableTabs(false);
                    loaded = false;
                }
            }
        }

        private void InitAllTabs()
        {
            initPlayer();
            initStats();
            initItems();
            initGraphics();
            initCheats();
            initInternals();
            initMisc();
            initHotkeys();
        }

        private void ReloadAllTabs()
        {
            reloadPlayer();
            reloadStats();
            reloadItems();
            reloadGraphics();
            reloadCheats();
            reloadInternals();
            reloadMisc();
            reloadHotkeys();
        }

        private void UpdateAllTabs()
        {
            updatePlayer();
            updateStats();
            updateItems();
            updateGraphics();
            updateCheats();
            updateInternals();
            updateMisc();
            updateHotkeys();
        }

        private void SaveAllTabs()
        {
            savePlayer();
            saveStats();
            saveItems();
            saveGraphics();
            saveCheats();
            saveInternals();
            saveMisc();
            saveHotkeys();
        }

        private void ResetAllTabs()
        {
            resetPlayer();
            resetStats();
            resetItems();
            resetGraphics();
            resetCheats();
            resetInternals();
            resetMisc();
            resetHotkeys();
        }

        private void linkLabelNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData.ToString());
        }
    }
}
