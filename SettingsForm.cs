using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jolly_Pop_Injector
{
    public partial class SettingsForm : Form
    {
        public SettingsHandler settings;
        public SettingsForm(SettingsHandler s)
        {
            InitializeComponent();
            settings = s;

            if (settings.AutoInject == 1)
            {
                AutoInjectCheckbox.Checked = true;
            }
            if (settings.CloseAfterInjection == 1)
            {
                CloseAfterInjectionCheckbox.Checked = true;
            }
            if (settings.SaveDll == 1)
            {
                SaveDLLCheckbox.Checked = true;
            }
            if (settings.SaveProcessName == 1)
            {
                SaveProcessCheckbox.Checked = true;
            }
            if (settings.SilentStart == 1)
            {
                SilentStartCheckbox.Checked = true;
            }
            if (settings.AutoCloseWarning == 1)
            {
                ShowWarningCheckbox.Checked = true;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AutoInjectCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoInjectCheckbox.Checked)
            {
                settings.AutoInject = 1;
            }
            else
            {
                settings.AutoInject = 0;
            }
        }

        private void CloseAfterInjectionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CloseAfterInjectionCheckbox.Checked)
            {
                settings.CloseAfterInjection = 1;
            }
            else
            {
                settings.CloseAfterInjection = 0;
            }
        }

        private void SaveDLLCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveDLLCheckbox.Checked)
            {
                settings.SaveDll = 1;
            }
            else
            {
                settings.SaveDll = 0;
            }
        }

        private void SaveProcessCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveProcessCheckbox.Checked)
            {
                settings.SaveProcessName = 1;
            }
            else
            {
                settings.SaveProcessName = 0;
            }
        }

        private void SilentStartCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SilentStartCheckbox.Checked)
            {
                settings.SilentStart = 1;
            }
            else
            {
                settings.SilentStart = 0;
            }
        }

        private void ShowWarningCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowWarningCheckbox.Checked)
            {
                settings.AutoCloseWarning = 1;
            }
            else
            {
                settings.AutoCloseWarning = 0;
            }
        }
    }
}
