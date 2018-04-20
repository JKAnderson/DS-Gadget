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

        private DSProcess dsProcess = null;
        private bool loaded = false;
        private bool reading = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Location = settings.WindowLocation;
            Text = "DS Gadget " + System.Windows.Forms.Application.ProductVersion;
            enableTabs(false);
            initPlayer();
            initStats();
            initItems();
            initGraphics();
            initCheats();
            initInternals();
            initMisc();
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
            savePlayer();
            saveStats();
            saveItems();
            saveGraphics();
            saveCheats();
            saveInternals();
            saveMisc();
            saveHotkeys();

            resetPlayer();
            resetStats();
            resetItems();
            resetGraphics();
            resetCheats();
            resetInternals();
            resetMisc();
            resetHotkeys();

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
                DSProcess result = DSProcess.GetProcess();
                if (result != null)
                {
                    labelProcess.Text = result.ID.ToString();
                    labelVersion.Text = result.Version;
                    labelVersion.ForeColor = result.Valid ? Color.DarkGreen : Color.DarkRed;
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
                            reloadInternals();
                            reloadMisc();
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
                            updateInternals();
                            updateMisc();
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
    }
}
