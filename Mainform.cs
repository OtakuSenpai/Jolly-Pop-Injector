using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
