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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.AutoInjectCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseAfterInjectionCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveDLLCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveProcessCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.SilentStartCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AutoInjectCheckbox
            // 
            this.AutoInjectCheckbox.AutoSize = true;
            this.AutoInjectCheckbox.Location = new System.Drawing.Point(12, 12);
            this.AutoInjectCheckbox.Name = "AutoInjectCheckbox";
            this.AutoInjectCheckbox.Size = new System.Drawing.Size(117, 17);
            this.AutoInjectCheckbox.TabIndex = 0;
            this.AutoInjectCheckbox.Text = "Automatically Inject";
            this.AutoInjectCheckbox.UseVisualStyleBackColor = true;
            this.AutoInjectCheckbox.CheckedChanged += new System.EventHandler(this.AutoInjectCheckbox_CheckedChanged);
            // 
            // CloseAfterInjectionCheckbox
            // 
            this.CloseAfterInjectionCheckbox.AutoSize = true;
            this.CloseAfterInjectionCheckbox.Location = new System.Drawing.Point(12, 35);
            this.CloseAfterInjectionCheckbox.Name = "CloseAfterInjectionCheckbox";
            this.CloseAfterInjectionCheckbox.Size = new System.Drawing.Size(120, 17);
            this.CloseAfterInjectionCheckbox.TabIndex = 2;
            this.CloseAfterInjectionCheckbox.Text = "Close After Injection";
            this.CloseAfterInjectionCheckbox.UseVisualStyleBackColor = true;
            this.CloseAfterInjectionCheckbox.CheckedChanged += new System.EventHandler(this.CloseAfterInjectionCheckbox_CheckedChanged);
            // 
            // SaveDLLCheckbox
            // 
            this.SaveDLLCheckbox.AutoSize = true;
            this.SaveDLLCheckbox.Location = new System.Drawing.Point(12, 58);
            this.SaveDLLCheckbox.Name = "SaveDLLCheckbox";
            this.SaveDLLCheckbox.Size = new System.Drawing.Size(118, 17);
            this.SaveDLLCheckbox.TabIndex = 3;
            this.SaveDLLCheckbox.Text = "Save DLL Location";
            this.SaveDLLCheckbox.UseVisualStyleBackColor = true;
            this.SaveDLLCheckbox.CheckedChanged += new System.EventHandler(this.SaveDLLCheckbox_CheckedChanged);
            // 
            // SaveProcessCheckbox
            // 
            this.SaveProcessCheckbox.AutoSize = true;
            this.SaveProcessCheckbox.Location = new System.Drawing.Point(12, 81);
            this.SaveProcessCheckbox.Name = "SaveProcessCheckbox";
            this.SaveProcessCheckbox.Size = new System.Drawing.Size(123, 17);
            this.SaveProcessCheckbox.TabIndex = 4;
            this.SaveProcessCheckbox.Text = "Save Process Name";
            this.SaveProcessCheckbox.UseVisualStyleBackColor = true;
            this.SaveProcessCheckbox.CheckedChanged += new System.EventHandler(this.SaveProcessCheckbox_CheckedChanged);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(12, 127);
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
            this.SilentStartCheckbox.Location = new System.Drawing.Point(12, 104);
            this.SilentStartCheckbox.Name = "SilentStartCheckbox";
            this.SilentStartCheckbox.Size = new System.Drawing.Size(77, 17);
            this.SilentStartCheckbox.TabIndex = 6;
            this.SilentStartCheckbox.Text = "Silent Start";
            this.SilentStartCheckbox.UseVisualStyleBackColor = true;
            this.SilentStartCheckbox.CheckedChanged += new System.EventHandler(this.SilentStartCheckbox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 160);
            this.Controls.Add(this.SilentStartCheckbox);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SaveProcessCheckbox);
            this.Controls.Add(this.SaveDLLCheckbox);
            this.Controls.Add(this.CloseAfterInjectionCheckbox);
            this.Controls.Add(this.AutoInjectCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
    }
}