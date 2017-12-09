namespace Jolly_Pop_Injector {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.AutoInjectCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseAfterInjectionCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveDLLCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveProcessCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SilentStartCheckbox = new System.Windows.Forms.CheckBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AutoInjectCheckbox
            // 
            this.AutoInjectCheckbox.AutoSize = true;
            this.AutoInjectCheckbox.Location = new System.Drawing.Point(15, 29);
            this.AutoInjectCheckbox.Name = "AutoInjectCheckbox";
            this.AutoInjectCheckbox.Size = new System.Drawing.Size(117, 17);
            this.AutoInjectCheckbox.TabIndex = 0;
            this.AutoInjectCheckbox.Text = "Automatically Inject";
            this.ToolTip.SetToolTip(this.AutoInjectCheckbox, "When checked, the tool will automatically inject the\r\nspecified process when/if i" +
        "t is detected.");
            this.AutoInjectCheckbox.UseVisualStyleBackColor = true;
            this.AutoInjectCheckbox.CheckedChanged += new System.EventHandler(this.AutoInjectCheckbox_CheckedChanged);
            // 
            // CloseAfterInjectionCheckbox
            // 
            this.CloseAfterInjectionCheckbox.AutoSize = true;
            this.CloseAfterInjectionCheckbox.Location = new System.Drawing.Point(15, 52);
            this.CloseAfterInjectionCheckbox.Name = "CloseAfterInjectionCheckbox";
            this.CloseAfterInjectionCheckbox.Size = new System.Drawing.Size(120, 17);
            this.CloseAfterInjectionCheckbox.TabIndex = 2;
            this.CloseAfterInjectionCheckbox.Text = "Close After Injection";
            this.ToolTip.SetToolTip(this.CloseAfterInjectionCheckbox, resources.GetString("CloseAfterInjectionCheckbox.ToolTip"));
            this.CloseAfterInjectionCheckbox.UseVisualStyleBackColor = true;
            this.CloseAfterInjectionCheckbox.CheckedChanged += new System.EventHandler(this.CloseAfterInjectionCheckbox_CheckedChanged);
            // 
            // SaveDLLCheckbox
            // 
            this.SaveDLLCheckbox.AutoSize = true;
            this.SaveDLLCheckbox.Location = new System.Drawing.Point(15, 75);
            this.SaveDLLCheckbox.Name = "SaveDLLCheckbox";
            this.SaveDLLCheckbox.Size = new System.Drawing.Size(118, 17);
            this.SaveDLLCheckbox.TabIndex = 3;
            this.SaveDLLCheckbox.Text = "Save DLL Location";
            this.ToolTip.SetToolTip(this.SaveDLLCheckbox, "When checked, the tool will automatically save the\r\nlocation of the last loaded D" +
        "LL to the settings file,\r\nand load it on start.");
            this.SaveDLLCheckbox.UseVisualStyleBackColor = true;
            this.SaveDLLCheckbox.CheckedChanged += new System.EventHandler(this.SaveDLLCheckbox_CheckedChanged);
            // 
            // SaveProcessCheckbox
            // 
            this.SaveProcessCheckbox.AutoSize = true;
            this.SaveProcessCheckbox.Location = new System.Drawing.Point(15, 98);
            this.SaveProcessCheckbox.Name = "SaveProcessCheckbox";
            this.SaveProcessCheckbox.Size = new System.Drawing.Size(123, 17);
            this.SaveProcessCheckbox.TabIndex = 4;
            this.SaveProcessCheckbox.Text = "Save Process Name";
            this.ToolTip.SetToolTip(this.SaveProcessCheckbox, "When checked, the tool will save the last specified\r\nprocess name to the settings" +
        " file and load it on\r\nlaunch.");
            this.SaveProcessCheckbox.UseVisualStyleBackColor = true;
            this.SaveProcessCheckbox.CheckedChanged += new System.EventHandler(this.SaveProcessCheckbox_CheckedChanged);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(12, 144);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(169, 23);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // SilentStartCheckbox
            // 
            this.SilentStartCheckbox.AutoSize = true;
            this.SilentStartCheckbox.Location = new System.Drawing.Point(15, 121);
            this.SilentStartCheckbox.Name = "SilentStartCheckbox";
            this.SilentStartCheckbox.Size = new System.Drawing.Size(77, 17);
            this.SilentStartCheckbox.TabIndex = 6;
            this.SilentStartCheckbox.Text = "Silent Start";
            this.ToolTip.SetToolTip(this.SilentStartCheckbox, "When checked, the settings configuration file &\r\nadministrator warnings will not " +
        "be shown. Of course,\r\nif an error occurs whilst attempting to load the XML,\r\ntha" +
        "t will still be shown.");
            this.SilentStartCheckbox.UseVisualStyleBackColor = true;
            this.SilentStartCheckbox.CheckedChanged += new System.EventHandler(this.SilentStartCheckbox_CheckedChanged);
            // 
            // ToolTip
            // 
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mouse over the options for help.";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 176);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SilentStartCheckbox);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SaveProcessCheckbox);
            this.Controls.Add(this.SaveDLLCheckbox);
            this.Controls.Add(this.CloseAfterInjectionCheckbox);
            this.Controls.Add(this.AutoInjectCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(210, 215);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(210, 215);
            this.Name = "SettingsForm";
            this.Text = "Jolly-Pop Injector Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AutoInjectCheckbox;
        private System.Windows.Forms.CheckBox CloseAfterInjectionCheckbox;
        private System.Windows.Forms.CheckBox SaveDLLCheckbox;
        private System.Windows.Forms.CheckBox SaveProcessCheckbox;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.CheckBox SilentStartCheckbox;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label label1;
    }
}