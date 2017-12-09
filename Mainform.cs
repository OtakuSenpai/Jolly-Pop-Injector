﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Jolly_Pop_Injector
{
    public partial class Mainform : Form
    {

        public SettingsHandler settings = new SettingsHandler();
        public XMLHandler xmlhandler = new XMLHandler(Application.StartupPath + "/JPI.xml");
        public SettingsForm settingsform;

        public Mainform()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            utils.LoadSettings(settings, 2);
            string window_title = "Jolly-Pop Injector: It's a DLL Injector";
            if (!utils.IsAdministrator())
            { //Gripe at the user if they're not an admin.
                window_title += " -NOT ADMIN-";
                MessageBox.Show("Warning - You must run this tool as an administrator in order for it to work properly.");
            }
            this.Text = window_title;
            if (settings.SaveProcessName == 1 && settings.Process != "Not set")
            {
                ProcessTextbox.Text = settings.Process;
            }
            if (settings.SaveDLLlocation == 1 && settings.DLL != "Not set")
            {
                DLLPathTextBox.Text = settings.DLL;
            }
        }

        public void OnProcessExit(object sender, EventArgs e)
        {
            utils.SaveSettings(settings, 1);
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            if (FormHandler.formopen(settingsform))
            {
                settingsform.Dispose();
            }
            settingsform = new SettingsForm(settings);
            settingsform.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            utils.SaveSettings(settings, 1);
            Application.Exit();
        }

        private void InjectBtn_Click(object sender, EventArgs e)
        {
            utils.Inject(settings);
        }

        private void GithubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/AWilliams17/Jolly-Pop-Injector");
        }

        private void DLLBrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog browse_dll = new OpenFileDialog();
            browse_dll.Filter = "DLL Files|*.dll";
            browse_dll.Title = "Select the DLL to inject.";
            if (browse_dll.ShowDialog() == DialogResult.OK)
            {
                DLLPathTextBox.Text = browse_dll.FileName;
                settings.DLL = browse_dll.FileName;
            }
        }

        private void BrowseProcessBtn_Click(object sender, EventArgs e)
        {
            string process_name = ProcessTextbox.Text;
            if (ProcessHandler.ProcessIsRunning(process_name))
            {
                if (process_name.Contains(".exe"))
                {
                    process_name = process_name.Substring(0, process_name.Length - 4); //Strip it out
                }
                settings.Process = process_name;
                MessageBox.Show("Process found.");
            }
            else
            {
                MessageBox.Show("I did not find that process.");
            }
        }

        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            if (settings.DLL == "Not set" || settings.Process == "Not set")
            {
                StatusLabel.Text = "Waiting for a DLL/Process.";
                StatusLabel.ForeColor = Color.Red;
                InjectBtn.Enabled = false;
            }
            else if (!ProcessHandler.ProcessIsRunning(settings.Process))
            {
                StatusLabel.Text = "I can't find the process.";
                StatusLabel.ForeColor = Color.Red;
                InjectBtn.Enabled = false;
            }
            else if (!File.Exists(settings.DLL))
            {
                StatusLabel.Text = "I can't find the DLL.";
                StatusLabel.ForeColor = Color.Red;
                InjectBtn.Enabled = false;
            }
            else
            {
                StatusLabel.Text = "Ready to inject the process: " + settings.Process.ToUpper();
                StatusLabel.ForeColor = Color.Green;
                InjectBtn.Enabled = true;
            }
        }

        private string last_auto_injected_process = null;
        private void AutoInjectTimer_Tick(object sender, EventArgs e)
        {
            if (InjectBtn.Enabled && settings.AutoInject == 1) //If the inject button is enabled then obviously all the above checks passed.
            { //So go ahead and do whatever.
                if (last_auto_injected_process != settings.Process)
                {
                    utils.Inject(settings);
                    last_auto_injected_process = settings.Process;
                }
                //If the currently selected process has already been auto-injected, then don't inject it a million other times
                //with each tick. :p
            }
        }
    }
}
