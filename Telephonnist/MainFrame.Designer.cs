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
            this.gbGmap = new System.Windows.Forms.GroupBox();
            this.wbMap = new System.Windows.Forms.WebBrowser();
            this.gbZoom = new System.Windows.Forms.GroupBox();
            this.View = new System.Windows.Forms.Button();
            this.gbGmap.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGmap
            // 
            this.gbGmap.Controls.Add(this.wbMap);
            this.gbGmap.Location = new System.Drawing.Point(258, 12);
            this.gbGmap.Name = "gbGmap";
            this.gbGmap.Size = new System.Drawing.Size(637, 637);
            this.gbGmap.TabIndex = 0;
            this.gbGmap.TabStop = false;
            this.gbGmap.Text = "Maps";
            // 
            // wbMap
            // 
            this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMap.Location = new System.Drawing.Point(3, 16);
            this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMap.Name = "wbMap";
            this.wbMap.Size = new System.Drawing.Size(631, 618);
            this.wbMap.TabIndex = 0;
            // 
            // gbZoom
            // 
            this.gbZoom.Location = new System.Drawing.Point(200, 12);
            this.gbZoom.Name = "gbZoom";
            this.gbZoom.Size = new System.Drawing.Size(52, 637);
            this.gbZoom.TabIndex = 1;
            this.gbZoom.TabStop = false;
            this.gbZoom.Text = "Zoom";
            // 
            // View
            // 
            this.View.Location = new System.Drawing.Point(54, 102);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(75, 23);
            this.View.TabIndex = 2;
            this.View.Text = "View";
            this.View.UseVisualStyleBackColor = true;
            this.View.Click += new System.EventHandler(this.View_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 661);
            this.Controls.Add(this.View);
            this.Controls.Add(this.gbZoom);
            this.Controls.Add(this.gbGmap);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(923, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(923, 700);
            this.Name = "MainFrame";
            this.Text = "MainFrame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrame_Close);
            this.gbGmap.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGmap;
        private System.Windows.Forms.GroupBox gbZoom;
        private System.Windows.Forms.WebBrowser wbMap;
        private System.Windows.Forms.Button View;
    }
}

