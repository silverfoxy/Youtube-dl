namespace Youtube_dl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_link = new System.Windows.Forms.TextBox();
            this.button_download = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button_cancel = new System.Windows.Forms.Button();
            this.linkLabel_downloadlink = new System.Windows.Forms.LinkLabel();
            this.comboBox_quality = new System.Windows.Forms.ComboBox();
            this.button_update = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.button_settings = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Youtube Link";
            // 
            // textBox_link
            // 
            this.textBox_link.Location = new System.Drawing.Point(98, 16);
            this.textBox_link.Name = "textBox_link";
            this.textBox_link.Size = new System.Drawing.Size(405, 20);
            this.textBox_link.TabIndex = 1;
            this.textBox_link.TextChanged += new System.EventHandler(this.textBox_link_TextChanged);
            // 
            // button_download
            // 
            this.button_download.Location = new System.Drawing.Point(391, 77);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(135, 23);
            this.button_download.TabIndex = 2;
            this.button_download.Text = "Download To Server";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 116);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(583, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(91, 17);
            this.toolStripStatusLabel1.Text = "Not Connected.";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(310, 77);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 4;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // linkLabel_downloadlink
            // 
            this.linkLabel_downloadlink.AutoSize = true;
            this.linkLabel_downloadlink.Location = new System.Drawing.Point(12, 48);
            this.linkLabel_downloadlink.Name = "linkLabel_downloadlink";
            this.linkLabel_downloadlink.Size = new System.Drawing.Size(91, 13);
            this.linkLabel_downloadlink.TabIndex = 5;
            this.linkLabel_downloadlink.TabStop = true;
            this.linkLabel_downloadlink.Text = "Click to download";
            this.linkLabel_downloadlink.Visible = false;
            this.linkLabel_downloadlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // comboBox_quality
            // 
            this.comboBox_quality.FormattingEnabled = true;
            this.comboBox_quality.Location = new System.Drawing.Point(74, 77);
            this.comboBox_quality.Name = "comboBox_quality";
            this.comboBox_quality.Size = new System.Drawing.Size(121, 21);
            this.comboBox_quality.TabIndex = 6;
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(201, 77);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(102, 23);
            this.button_update.TabIndex = 7;
            this.button_update.Text = "Update Quality";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            // 
            // button_settings
            // 
            this.button_settings.BackgroundImage = global::Youtube_dl.Properties.Resources.gnome_preferences_system;
            this.button_settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_settings.Location = new System.Drawing.Point(518, 9);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(32, 32);
            this.button_settings.TabIndex = 8;
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 138);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.comboBox_quality);
            this.Controls.Add(this.linkLabel_downloadlink);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_download);
            this.Controls.Add(this.textBox_link);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Downloader";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_link;
        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.LinkLabel linkLabel_downloadlink;
        private System.Windows.Forms.ComboBox comboBox_quality;
        private System.Windows.Forms.Button button_update;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button button_settings;
    }
}

