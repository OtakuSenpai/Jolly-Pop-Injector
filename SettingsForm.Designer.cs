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
            this.AutoInjectCheckbox = new System.Windows.Forms.CheckBox();
            this.SoundsCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseAfterInjectionCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveDLLCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveProcessCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseBtn = new System.Windows.Forms.Button();
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
            // 
            // SoundsCheckbox
            // 
            this.SoundsCheckbox.AutoSize = true;
            this.SoundsCheckbox.Location = new System.Drawing.Point(12, 58);
            this.SoundsCheckbox.Name = "SoundsCheckbox";
            this.SoundsCheckbox.Size = new System.Drawing.Size(85, 17);
            this.SoundsCheckbox.TabIndex = 1;
            this.SoundsCheckbox.Text = "Play Sounds";
            this.SoundsCheckbox.UseVisualStyleBackColor = true;
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
            // 
            // SaveDLLCheckbox
            // 
            this.SaveDLLCheckbox.AutoSize = true;
            this.SaveDLLCheckbox.Location = new System.Drawing.Point(12, 81);
            this.SaveDLLCheckbox.Name = "SaveDLLCheckbox";
            this.SaveDLLCheckbox.Size = new System.Drawing.Size(118, 17);
            this.SaveDLLCheckbox.TabIndex = 3;
            this.SaveDLLCheckbox.Text = "Save DLL Location";
            this.SaveDLLCheckbox.UseVisualStyleBackColor = true;
            // 
            // SaveProcessCheckbox
            // 
            this.SaveProcessCheckbox.AutoSize = true;
            this.SaveProcessCheckbox.Location = new System.Drawing.Point(12, 104);
            this.SaveProcessCheckbox.Name = "SaveProcessCheckbox";
            this.SaveProcessCheckbox.Size = new System.Drawing.Size(123, 17);
            this.SaveProcessCheckbox.TabIndex = 4;
            this.SaveProcessCheckbox.Text = "Save Process Name";
            this.SaveProcessCheckbox.UseVisualStyleBackColor = true;
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(12, 127);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(169, 23);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 157);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.SaveProcessCheckbox);
            this.Controls.Add(this.SaveDLLCheckbox);
            this.Controls.Add(this.CloseAfterInjectionCheckbox);
            this.Controls.Add(this.SoundsCheckbox);
            this.Controls.Add(this.AutoInjectCheckbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Jolly-Pop Injector Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AutoInjectCheckbox;
        private System.Windows.Forms.CheckBox SoundsCheckbox;
        private System.Windows.Forms.CheckBox CloseAfterInjectionCheckbox;
        private System.Windows.Forms.CheckBox SaveDLLCheckbox;
        private System.Windows.Forms.CheckBox SaveProcessCheckbox;
        private System.Windows.Forms.Button CloseBtn;
    }
}