using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Jolly_Pop_Injector {
    public partial class Mainform : Form {

        public SettingsHandler settings = new SettingsHandler();
        public XMLHandler xmlhandler = new XMLHandler();
        public SettingsForm settingsform;

        public Mainform() {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void Mainform_Load(object sender, EventArgs e) {
            utils.HandleXML(settings);
            string window_title = "Jolly-Pop Injector: It's a DLL Injector";
            if (!utils.IsAdministrator()) { //Gripe at the user if they're not an admin.
                window_title += " -NOT ADMIN-";
                MessageBox.Show("Warning - You must run this tool as an administrator in order for it to work properly.");
            }
            this.Text = window_title;
        }

        public void OnProcessExit(object sender, EventArgs e) {
            XMLHandler.WriteSettingsToXML(settings);
        }

        private void SettingsBtn_Click(object sender, EventArgs e) {
            if (FormHandler.formopen(settingsform)) {
                settingsform.Dispose();
            }
            settingsform = new SettingsForm(settings);
            settingsform.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e) {
            XMLHandler.WriteSettingsToXML(settings);
            Application.Exit();
        }

        private void InjectBtn_Click(object sender, EventArgs e) {

        }

        private void GithubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/AWilliams17/Jolly-Pop-Injector");
        }

        private void DLLBrowseBtn_Click(object sender, EventArgs e) {

        }

        private void BrowseProcessBtn_Click(object sender, EventArgs e) {

        }

        private void StatusTimer_Tick(object sender, EventArgs e) {

        }

        private void AutoInjectTimer_Tick(object sender, EventArgs e) {

        }
    }
}
