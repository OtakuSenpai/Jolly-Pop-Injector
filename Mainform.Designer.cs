namespace Jolly_Pop_Injector {
    partial class Mainform {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.label1 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DLLPathTextBox = new System.Windows.Forms.TextBox();
            this.ProcessTextbox = new System.Windows.Forms.TextBox();
            this.DLLBrowseBtn = new System.Windows.Forms.Button();
            this.BrowseProcessBtn = new System.Windows.Forms.Button();
            this.InjectBtn = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.GithubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.AutoInjectTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(55, 58);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(16, 13);
            this.StatusLabel.TabIndex = 1;
            this.StatusLabel.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DLL:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Process:";
            // 
            // DLLPathTextBox
            // 
            this.DLLPathTextBox.Location = new System.Drawing.Point(58, 6);
            this.DLLPathTextBox.Name = "DLLPathTextBox";
            this.DLLPathTextBox.Size = new System.Drawing.Size(151, 20);
            this.DLLPathTextBox.TabIndex = 4;
            // 
            // ProcessTextbox
            // 
            this.ProcessTextbox.Location = new System.Drawing.Point(58, 31);
            this.ProcessTextbox.Name = "ProcessTextbox";
            this.ProcessTextbox.Size = new System.Drawing.Size(151, 20);
            this.ProcessTextbox.TabIndex = 5;
            // 
            // DLLBrowseBtn
            // 
            this.DLLBrowseBtn.Location = new System.Drawing.Point(211, 4);
            this.DLLBrowseBtn.Name = "DLLBrowseBtn";
            this.DLLBrowseBtn.Size = new System.Drawing.Size(33, 23);
            this.DLLBrowseBtn.TabIndex = 6;
            this.DLLBrowseBtn.Text = "...";
            this.DLLBrowseBtn.UseVisualStyleBackColor = true;
            // 
            // BrowseProcessBtn
            // 
            this.BrowseProcessBtn.Location = new System.Drawing.Point(211, 29);
            this.BrowseProcessBtn.Name = "BrowseProcessBtn";
            this.BrowseProcessBtn.Size = new System.Drawing.Size(33, 23);
            this.BrowseProcessBtn.TabIndex = 7;
            this.BrowseProcessBtn.Text = "...";
            this.BrowseProcessBtn.UseVisualStyleBackColor = true;
            // 
            // InjectBtn
            // 
            this.InjectBtn.Location = new System.Drawing.Point(169, 79);
            this.InjectBtn.Name = "InjectBtn";
            this.InjectBtn.Size = new System.Drawing.Size(75, 23);
            this.InjectBtn.TabIndex = 8;
            this.InjectBtn.Text = "Inject";
            this.InjectBtn.UseVisualStyleBackColor = true;
            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Location = new System.Drawing.Point(88, 79);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(75, 23);
            this.SettingsBtn.TabIndex = 9;
            this.SettingsBtn.Text = "Settings";
            this.SettingsBtn.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(7, 79);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 10;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            // 
            // GithubLinkLabel
            // 
            this.GithubLinkLabel.AutoSize = true;
            this.GithubLinkLabel.Location = new System.Drawing.Point(4, 105);
            this.GithubLinkLabel.Name = "GithubLinkLabel";
            this.GithubLinkLabel.Size = new System.Drawing.Size(242, 13);
            this.GithubLinkLabel.TabIndex = 11;
            this.GithubLinkLabel.TabStop = true;
            this.GithubLinkLabel.Text = "https://github.com/AWilliams17/Jolly-Pop-Injector";
            // 
            // StatusTimer
            // 
            this.StatusTimer.Enabled = true;
            // 
            // AutoInjectTimer
            // 
            this.AutoInjectTimer.Enabled = true;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 126);
            this.Controls.Add(this.GithubLinkLabel);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.InjectBtn);
            this.Controls.Add(this.BrowseProcessBtn);
            this.Controls.Add(this.DLLBrowseBtn);
            this.Controls.Add(this.ProcessTextbox);
            this.Controls.Add(this.DLLPathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mainform";
            this.Text = "-";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DLLPathTextBox;
        private System.Windows.Forms.TextBox ProcessTextbox;
        private System.Windows.Forms.Button DLLBrowseBtn;
        private System.Windows.Forms.Button BrowseProcessBtn;
        private System.Windows.Forms.Button InjectBtn;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.LinkLabel GithubLinkLabel;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.Timer AutoInjectTimer;
    }
}

