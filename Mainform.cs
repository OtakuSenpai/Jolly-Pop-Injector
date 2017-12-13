using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Jolly_Pop_Injector
{
    public partial class Mainform : Form
    {

        public SettingsHandler Settings = new SettingsHandler();
        public XmlHandler XmlHandler = new XmlHandler(Application.StartupPath + "/JPI.xml");
        public SettingsForm SettingsForm;

        public Mainform()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            Utils.LoadSettings(Settings, 2);
            string windowTitle = "Jolly-Pop Injector: It's a DLL Injector";
            const string adminWarning = "Warning - You must run this tool as an administrator in order for it to work properly.";
            if (!Utils.IsAdministrator())
            { //Gripe at the user if they're not an admin.
                windowTitle += " -NOT ADMIN-";
                if (Settings.SilentStart == 0)
                {
                    MessageBox.Show(adminWarning);
                }
            }
            Text = windowTitle;
            if (Settings.SaveProcessName == 1 && Settings.Process != "Not set")
            {
                ProcessTextbox.Text = Settings.Process;
            }
            if (Settings.SaveDll == 1 && Settings.Dll != "Not set")
            {
                DLLPathTextBox.Text = Settings.Dll;
            }
        }

        public void OnProcessExit(object sender, EventArgs e)
        {
            if (Settings.SaveDll == 0)
            {
                Settings.Dll = "Not set";
            }
            if (Settings.SaveProcessName == 0)
            {
                Settings.Process = "Not set";
            }
            Utils.SaveSettings(Settings, 1);
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            if (FormHandler.Formopen(SettingsForm))
            {
                SettingsForm.Dispose();
            }
            SettingsForm = new SettingsForm(Settings);
            SettingsForm.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Utils.Exit(1, Settings);
        }

        private void InjectBtn_Click(object sender, EventArgs e)
        {
            Utils.Inject(Settings, AutoShutdown, shutdown_countdown, 0);
        }

        private void GithubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/AWilliams17/Jolly-Pop-Injector");
        }

        private void DLLBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseDll = new OpenFileDialog();
            browseDll.Filter = "DLL Files|*.dll";
            browseDll.Title = "Select the DLL to inject.";
            if (browseDll.ShowDialog() == DialogResult.OK)
            {
                DLLPathTextBox.Text = browseDll.FileName;
                Settings.Dll = browseDll.FileName;
            }
        }

        private void BrowseProcessBtn_Click(object sender, EventArgs e)
        {
            string processName = ProcessTextbox.Text;
            string dialogResult;
            if (ProcessHandler.ProcessIsRunning(processName))
            {
                if (processName.Contains(".exe"))
                {
                    processName = processName.Substring(0, processName.Length - 4); //Strip it out
                }
                Settings.Process = processName;
                dialogResult = "Process found.";
            }
            else
            {
                dialogResult = "I did not find that process.";
            }
            MessageBox.Show(dialogResult);
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if (!AutoShutdown.Enabled)
            {
                StatusLabel.BackColor = SystemColors.Control;
                string status;
                bool disabled = true;

                if (Settings.Dll == "Not set" || Settings.Process == "Not set")
                {
                    status = "Waiting for a DLL/Process.";
                }
                else if (!ProcessHandler.ProcessIsRunning(Settings.Process))
                {
                    status = "I can't find the process.";
                }
                else if (!File.Exists(Settings.Dll))
                {
                    status = "I can't find the DLL.";
                }
                else
                {
                    status = "Ready to inject the process: " + Settings.Process.ToUpper();
                    disabled = false;
                }

                if (disabled)
                {
                    StatusLabel.ForeColor = Color.Red;
                    InjectBtn.Enabled = false;
                }
                else
                {
                    StatusLabel.ForeColor = Color.Green;
                    InjectBtn.Enabled = true;
                }
                StatusLabel.Text = status;
            }
        }

        private string _lastAutoInjectedProcess;
        private void AutoInjectTimer_Tick(object sender, EventArgs e)
        {
            if (InjectBtn.Enabled && Settings.AutoInject == 1) //If the inject button is enabled then obviously all the above checks passed.
            { //So go ahead and do whatever.
                if (_lastAutoInjectedProcess != Settings.Process)
                {
                    _lastAutoInjectedProcess = Settings.Process;
                    Utils.Inject(Settings, AutoShutdown, shutdown_countdown, 1);
                }
                //If the currently selected process has already been auto-injected, then don't inject it a million other times
                //with each tick. :p
            }
        }

        int shutdown_countdown = 6;
        private void AutoShutdown_Tick(object sender, EventArgs e)
        {
            shutdown_countdown--;
            StatusLabel.Text = "Shutting down in... " + shutdown_countdown.ToString();
            StatusLabel.ForeColor = Color.Yellow;
            StatusLabel.BackColor = Color.DarkRed;
            if (shutdown_countdown == 0)
            {
                Utils.Exit(1, Settings);
            }
        }
    }
}
