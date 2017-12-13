using System;
using System.Windows.Forms;

namespace Jolly_Pop_Injector
{
    public partial class SettingsForm : Form
    {
        public SettingsHandler Settings;
        public SettingsForm(SettingsHandler s)
        {
            InitializeComponent();
            Settings = s;

            if (Settings.AutoInject == 1)
            {
                AutoInjectCheckbox.Checked = true;
            }
            if (Settings.CloseAfterInjection == 1)
            {
                CloseAfterInjectionCheckbox.Checked = true;
            }
            if (Settings.SaveDll == 1)
            {
                SaveDLLCheckbox.Checked = true;
            }
            if (Settings.SaveProcessName == 1)
            {
                SaveProcessCheckbox.Checked = true;
            }
            if (Settings.SilentStart == 1)
            {
                SilentStartCheckbox.Checked = true;
            }
            if (Settings.AutoCloseWarning == 1)
            {
                ShowWarningCheckbox.Checked = true;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void AutoInjectCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.AutoInject = AutoInjectCheckbox.Checked ? 1 : 0;
        }

        private void CloseAfterInjectionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.CloseAfterInjection = CloseAfterInjectionCheckbox.Checked ? 1 : 0;
        }

        private void SaveDLLCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SaveDll = SaveDLLCheckbox.Checked ? 1 : 0;
        }

        private void SaveProcessCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SaveProcessName = SaveProcessCheckbox.Checked ? 1 : 0;
        }

        private void SilentStartCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.SilentStart = SilentStartCheckbox.Checked ? 1 : 0;
        }

        private void ShowWarningCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Settings.AutoCloseWarning = ShowWarningCheckbox.Checked ? 1 : 0;
        }
    }
}
