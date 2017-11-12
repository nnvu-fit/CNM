namespace Telephonnist
{
    partial class MainFrame
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
            this.gbMaps = new System.Windows.Forms.GroupBox();
            this.wbMaps = new System.Windows.Forms.WebBrowser();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDriver = new System.Windows.Forms.TabPage();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.gbTelephonistDetail = new System.Windows.Forms.GroupBox();
            this.gbCaller = new System.Windows.Forms.GroupBox();
            this.gbMaps.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMaps
            // 
            this.gbMaps.Controls.Add(this.wbMaps);
            this.gbMaps.Location = new System.Drawing.Point(250, 12);
            this.gbMaps.Name = "gbMaps";
            this.gbMaps.Size = new System.Drawing.Size(637, 637);
            this.gbMaps.TabIndex = 1;
            this.gbMaps.TabStop = false;
            this.gbMaps.Text = "Maps";
            // 
            // wbMaps
            // 
            this.wbMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMaps.Location = new System.Drawing.Point(3, 16);
            this.wbMaps.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMaps.Name = "wbMaps";
            this.wbMaps.Size = new System.Drawing.Size(631, 618);
            this.wbMaps.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDriver);
            this.tabControl.Controls.Add(this.tabHistory);
            this.tabControl.Location = new System.Drawing.Point(893, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(232, 636);
            this.tabControl.TabIndex = 2;
            // 
            // tabDriver
            // 
            this.tabDriver.Location = new System.Drawing.Point(4, 22);
            this.tabDriver.Name = "tabDriver";
            this.tabDriver.Padding = new System.Windows.Forms.Padding(3);
            this.tabDriver.Size = new System.Drawing.Size(224, 610);
            this.tabDriver.TabIndex = 0;
            this.tabDriver.Text = "Driver";
            this.tabDriver.UseVisualStyleBackColor = true;
            this.tabDriver.Click += new System.EventHandler(this.TabPage1_Click);
            // 
            // tabHistory
            // 
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(208, 610);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // gbTelephonistDetail
            // 
            this.gbTelephonistDetail.Location = new System.Drawing.Point(12, 12);
            this.gbTelephonistDetail.Name = "gbTelephonistDetail";
            this.gbTelephonistDetail.Size = new System.Drawing.Size(232, 132);
            this.gbTelephonistDetail.TabIndex = 3;
            this.gbTelephonistDetail.TabStop = false;
            this.gbTelephonistDetail.Text = "Telephonist Detail";
            // 
            // gbCaller
            // 
            this.gbCaller.Location = new System.Drawing.Point(12, 150);
            this.gbCaller.Name = "gbCaller";
            this.gbCaller.Size = new System.Drawing.Size(232, 499);
            this.gbCaller.TabIndex = 4;
            this.gbCaller.TabStop = false;
            this.gbCaller.Text = "Caller Detail";
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 661);
            this.Controls.Add(this.gbCaller);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.gbTelephonistDetail);
            this.Controls.Add(this.gbMaps);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1137, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1137, 700);
            this.Name = "MainFrame";
            this.Text = "MainFrame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrame_Close);
            this.gbMaps.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbMaps;
        private System.Windows.Forms.WebBrowser wbMaps;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDriver;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.GroupBox gbTelephonistDetail;
        private System.Windows.Forms.GroupBox gbCaller;
    }
}

