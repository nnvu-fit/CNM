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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDriver = new System.Windows.Forms.TabPage();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.gbTelephonistDetail = new System.Windows.Forms.GroupBox();
            this.btLogout = new System.Windows.Forms.Button();
            this.lName = new System.Windows.Forms.Label();
            this.lUsername = new System.Windows.Forms.Label();
            this.gbCaller = new System.Windows.Forms.GroupBox();
            this.btFind = new System.Windows.Forms.Button();
            this.btBook = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lDriverName = new System.Windows.Forms.Label();
            this.lDriverID = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lLocation = new System.Windows.Forms.Label();
            this.lLng = new System.Windows.Forms.Label();
            this.lLat = new System.Windows.Forms.Label();
            this.lCallerName = new System.Windows.Forms.Label();
            this.lPhone = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rdbStandard = new System.Windows.Forms.RadioButton();
            this.rdbPremium = new System.Windows.Forms.RadioButton();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.gbTelephonistDetail.SuspendLayout();
            this.gbCaller.SuspendLayout();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMaps
            // 
            this.gbMaps.Location = new System.Drawing.Point(250, 12);
            this.gbMaps.Name = "gbMaps";
            this.gbMaps.Size = new System.Drawing.Size(637, 637);
            this.gbMaps.TabIndex = 1;
            this.gbMaps.TabStop = false;
            this.gbMaps.Text = "Maps";
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
            this.tabHistory.Size = new System.Drawing.Size(224, 610);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // gbTelephonistDetail
            // 
            this.gbTelephonistDetail.Controls.Add(this.btLogout);
            this.gbTelephonistDetail.Controls.Add(this.lName);
            this.gbTelephonistDetail.Controls.Add(this.lUsername);
            this.gbTelephonistDetail.Location = new System.Drawing.Point(12, 12);
            this.gbTelephonistDetail.Name = "gbTelephonistDetail";
            this.gbTelephonistDetail.Size = new System.Drawing.Size(232, 166);
            this.gbTelephonistDetail.TabIndex = 3;
            this.gbTelephonistDetail.TabStop = false;
            this.gbTelephonistDetail.Text = "Telephonist Detail";
            // 
            // btLogout
            // 
            this.btLogout.Location = new System.Drawing.Point(78, 116);
            this.btLogout.Name = "btLogout";
            this.btLogout.Size = new System.Drawing.Size(75, 23);
            this.btLogout.TabIndex = 2;
            this.btLogout.Text = "Logout";
            this.btLogout.UseVisualStyleBackColor = true;
            this.btLogout.Click += new System.EventHandler(this.BtLogout_Click);
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(6, 68);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(52, 13);
            this.lName.TabIndex = 1;
            this.lName.Text = "Full name";
            // 
            // lUsername
            // 
            this.lUsername.AutoSize = true;
            this.lUsername.Location = new System.Drawing.Point(6, 22);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(55, 13);
            this.lUsername.TabIndex = 0;
            this.lUsername.Text = "Username";
            // 
            // gbCaller
            // 
            this.gbCaller.Controls.Add(this.gbType);
            this.gbCaller.Controls.Add(this.btFind);
            this.gbCaller.Controls.Add(this.btBook);
            this.gbCaller.Controls.Add(this.textBox7);
            this.gbCaller.Controls.Add(this.textBox6);
            this.gbCaller.Controls.Add(this.lDriverName);
            this.gbCaller.Controls.Add(this.lDriverID);
            this.gbCaller.Controls.Add(this.textBox5);
            this.gbCaller.Controls.Add(this.textBox4);
            this.gbCaller.Controls.Add(this.textBox3);
            this.gbCaller.Controls.Add(this.textBox2);
            this.gbCaller.Controls.Add(this.lLocation);
            this.gbCaller.Controls.Add(this.lLng);
            this.gbCaller.Controls.Add(this.lLat);
            this.gbCaller.Controls.Add(this.lCallerName);
            this.gbCaller.Controls.Add(this.lPhone);
            this.gbCaller.Controls.Add(this.textBox1);
            this.gbCaller.Location = new System.Drawing.Point(12, 184);
            this.gbCaller.Name = "gbCaller";
            this.gbCaller.Size = new System.Drawing.Size(232, 465);
            this.gbCaller.TabIndex = 4;
            this.gbCaller.TabStop = false;
            this.gbCaller.Text = "Caller Detail";
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(20, 345);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(75, 23);
            this.btFind.TabIndex = 1;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            // 
            // btBook
            // 
            this.btBook.Location = new System.Drawing.Point(140, 345);
            this.btBook.Name = "btBook";
            this.btBook.Size = new System.Drawing.Size(75, 23);
            this.btBook.TabIndex = 10;
            this.btBook.Text = "Book";
            this.btBook.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(88, 412);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(138, 20);
            this.textBox7.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(88, 385);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(138, 20);
            this.textBox6.TabIndex = 1;
            // 
            // lDriverName
            // 
            this.lDriverName.AutoSize = true;
            this.lDriverName.Location = new System.Drawing.Point(6, 415);
            this.lDriverName.Name = "lDriverName";
            this.lDriverName.Size = new System.Drawing.Size(61, 13);
            this.lDriverName.TabIndex = 1;
            this.lDriverName.Text = "Drive name";
            // 
            // lDriverID
            // 
            this.lDriverID.AutoSize = true;
            this.lDriverID.Location = new System.Drawing.Point(6, 388);
            this.lDriverID.Name = "lDriverID";
            this.lDriverID.Size = new System.Drawing.Size(49, 13);
            this.lDriverID.TabIndex = 9;
            this.lDriverID.Text = "Driver ID";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(65, 84);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(161, 20);
            this.textBox5.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 196);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(220, 80);
            this.textBox4.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(33, 154);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(193, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(33, 128);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(193, 20);
            this.textBox2.TabIndex = 6;
            // 
            // lLocation
            // 
            this.lLocation.AutoSize = true;
            this.lLocation.Location = new System.Drawing.Point(6, 180);
            this.lLocation.Name = "lLocation";
            this.lLocation.Size = new System.Drawing.Size(48, 13);
            this.lLocation.TabIndex = 5;
            this.lLocation.Text = "Location";
            // 
            // lLng
            // 
            this.lLng.AutoSize = true;
            this.lLng.Location = new System.Drawing.Point(6, 157);
            this.lLng.Name = "lLng";
            this.lLng.Size = new System.Drawing.Size(21, 13);
            this.lLng.TabIndex = 4;
            this.lLng.Text = "lng";
            // 
            // lLat
            // 
            this.lLat.AutoSize = true;
            this.lLat.Location = new System.Drawing.Point(6, 131);
            this.lLat.Name = "lLat";
            this.lLat.Size = new System.Drawing.Size(18, 13);
            this.lLat.TabIndex = 3;
            this.lLat.Text = "lat";
            // 
            // lCallerName
            // 
            this.lCallerName.AutoSize = true;
            this.lCallerName.Location = new System.Drawing.Point(6, 87);
            this.lCallerName.Name = "lCallerName";
            this.lCallerName.Size = new System.Drawing.Size(52, 13);
            this.lCallerName.TabIndex = 2;
            this.lCallerName.Text = "Full name";
            // 
            // lPhone
            // 
            this.lPhone.AutoSize = true;
            this.lPhone.Location = new System.Drawing.Point(6, 45);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(76, 13);
            this.lPhone.TabIndex = 1;
            this.lPhone.Text = "Phone number";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 0;
            // 
            // rdbStandard
            // 
            this.rdbStandard.AutoSize = true;
            this.rdbStandard.Location = new System.Drawing.Point(14, 19);
            this.rdbStandard.Name = "rdbStandard";
            this.rdbStandard.Size = new System.Drawing.Size(68, 17);
            this.rdbStandard.TabIndex = 1;
            this.rdbStandard.TabStop = true;
            this.rdbStandard.Text = "Standard";
            this.rdbStandard.UseVisualStyleBackColor = true;
            this.rdbStandard.CheckedChanged += new System.EventHandler(this.rdbStandard_CheckedChanged);
            // 
            // rdbPremium
            // 
            this.rdbPremium.AutoSize = true;
            this.rdbPremium.Location = new System.Drawing.Point(134, 19);
            this.rdbPremium.Name = "rdbPremium";
            this.rdbPremium.Size = new System.Drawing.Size(65, 17);
            this.rdbPremium.TabIndex = 11;
            this.rdbPremium.TabStop = true;
            this.rdbPremium.Text = "Premium";
            this.rdbPremium.UseVisualStyleBackColor = true;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.rdbStandard);
            this.gbType.Controls.Add(this.rdbPremium);
            this.gbType.Location = new System.Drawing.Point(6, 282);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(220, 50);
            this.gbType.TabIndex = 1;
            this.gbType.TabStop = false;
            this.gbType.Text = "Type";
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
            this.tabControl.ResumeLayout(false);
            this.gbTelephonistDetail.ResumeLayout(false);
            this.gbTelephonistDetail.PerformLayout();
            this.gbCaller.ResumeLayout(false);
            this.gbCaller.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbMaps;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDriver;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.GroupBox gbTelephonistDetail;
        private System.Windows.Forms.GroupBox gbCaller;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lUsername;
        private System.Windows.Forms.Label lPhone;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lLocation;
        private System.Windows.Forms.Label lLng;
        private System.Windows.Forms.Label lLat;
        private System.Windows.Forms.Label lCallerName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.Button btBook;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label lDriverName;
        private System.Windows.Forms.Label lDriverID;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rdbStandard;
        private System.Windows.Forms.RadioButton rdbPremium;
    }
}

