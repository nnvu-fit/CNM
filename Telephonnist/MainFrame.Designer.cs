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
            this.btLook = new System.Windows.Forms.Button();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rdbStandard = new System.Windows.Forms.RadioButton();
            this.rdbPremium = new System.Windows.Forms.RadioButton();
            this.btFind = new System.Windows.Forms.Button();
            this.btBook = new System.Windows.Forms.Button();
            this.tbDriveName = new System.Windows.Forms.TextBox();
            this.tbDriverID = new System.Windows.Forms.TextBox();
            this.lDriverName = new System.Windows.Forms.Label();
            this.lDriverID = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.lFrom = new System.Windows.Forms.Label();
            this.lCallerName = new System.Windows.Forms.Label();
            this.lPhone = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbTo = new System.Windows.Forms.TextBox();
            this.lTo = new System.Windows.Forms.Label();
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
            this.gbCaller.Controls.Add(this.tbTo);
            this.gbCaller.Controls.Add(this.lTo);
            this.gbCaller.Controls.Add(this.btLook);
            this.gbCaller.Controls.Add(this.gbType);
            this.gbCaller.Controls.Add(this.btFind);
            this.gbCaller.Controls.Add(this.btBook);
            this.gbCaller.Controls.Add(this.tbDriveName);
            this.gbCaller.Controls.Add(this.tbDriverID);
            this.gbCaller.Controls.Add(this.lDriverName);
            this.gbCaller.Controls.Add(this.lDriverID);
            this.gbCaller.Controls.Add(this.tbFullName);
            this.gbCaller.Controls.Add(this.tbFrom);
            this.gbCaller.Controls.Add(this.lFrom);
            this.gbCaller.Controls.Add(this.lCallerName);
            this.gbCaller.Controls.Add(this.lPhone);
            this.gbCaller.Controls.Add(this.tbPhone);
            this.gbCaller.Location = new System.Drawing.Point(12, 184);
            this.gbCaller.Name = "gbCaller";
            this.gbCaller.Size = new System.Drawing.Size(232, 465);
            this.gbCaller.TabIndex = 4;
            this.gbCaller.TabStop = false;
            this.gbCaller.Text = "Caller Detail";
            // 
            // btLook
            // 
            this.btLook.Location = new System.Drawing.Point(33, 345);
            this.btLook.Name = "btLook";
            this.btLook.Size = new System.Drawing.Size(75, 23);
            this.btLook.TabIndex = 11;
            this.btLook.Text = "Look";
            this.btLook.UseVisualStyleBackColor = true;
            this.btLook.Visible = false;
            this.btLook.Click += new System.EventHandler(this.BtLook_Click);
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
            this.rdbStandard.CheckedChanged += new System.EventHandler(this.RdbStandard_CheckedChanged);
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
            this.rdbPremium.CheckedChanged += new System.EventHandler(this.RdbPremium_CheckedChanged);
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(20, 345);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(75, 23);
            this.btFind.TabIndex = 1;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // btBook
            // 
            this.btBook.Location = new System.Drawing.Point(140, 345);
            this.btBook.Name = "btBook";
            this.btBook.Size = new System.Drawing.Size(75, 23);
            this.btBook.TabIndex = 10;
            this.btBook.Text = "Book";
            this.btBook.UseVisualStyleBackColor = true;
            this.btBook.Click += new System.EventHandler(this.BtBook_Click);
            // 
            // tbDriveName
            // 
            this.tbDriveName.Location = new System.Drawing.Point(88, 412);
            this.tbDriveName.Name = "tbDriveName";
            this.tbDriveName.Size = new System.Drawing.Size(138, 20);
            this.tbDriveName.TabIndex = 1;
            // 
            // tbDriverID
            // 
            this.tbDriverID.Location = new System.Drawing.Point(88, 385);
            this.tbDriverID.Name = "tbDriverID";
            this.tbDriverID.Size = new System.Drawing.Size(138, 20);
            this.tbDriverID.TabIndex = 1;
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
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(65, 45);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(161, 20);
            this.tbFullName.TabIndex = 8;
            this.tbFullName.TextChanged += new System.EventHandler(this.TbFullName_TextChanged);
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(6, 84);
            this.tbFrom.Multiline = true;
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(220, 80);
            this.tbFrom.TabIndex = 1;
            // 
            // lFrom
            // 
            this.lFrom.AutoSize = true;
            this.lFrom.Location = new System.Drawing.Point(6, 68);
            this.lFrom.Name = "lFrom";
            this.lFrom.Size = new System.Drawing.Size(30, 13);
            this.lFrom.TabIndex = 5;
            this.lFrom.Text = "From";
            // 
            // lCallerName
            // 
            this.lCallerName.AutoSize = true;
            this.lCallerName.Location = new System.Drawing.Point(6, 48);
            this.lCallerName.Name = "lCallerName";
            this.lCallerName.Size = new System.Drawing.Size(52, 13);
            this.lCallerName.TabIndex = 2;
            this.lCallerName.Text = "Full name";
            // 
            // lPhone
            // 
            this.lPhone.AutoSize = true;
            this.lPhone.Location = new System.Drawing.Point(6, 22);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(76, 13);
            this.lPhone.TabIndex = 1;
            this.lPhone.Text = "Phone number";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(88, 19);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(138, 20);
            this.tbPhone.TabIndex = 0;
            this.tbPhone.TextChanged += new System.EventHandler(this.TbPhone_TextChanged);
            // 
            // tbTo
            // 
            this.tbTo.Location = new System.Drawing.Point(6, 183);
            this.tbTo.Multiline = true;
            this.tbTo.Name = "tbTo";
            this.tbTo.Size = new System.Drawing.Size(220, 80);
            this.tbTo.TabIndex = 12;
            // 
            // lTo
            // 
            this.lTo.AutoSize = true;
            this.lTo.Location = new System.Drawing.Point(6, 167);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(20, 13);
            this.lTo.TabIndex = 13;
            this.lTo.Text = "To";
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
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lFrom;
        private System.Windows.Forms.Label lCallerName;
        private System.Windows.Forms.Button btLogout;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.Button btBook;
        private System.Windows.Forms.TextBox tbDriveName;
        private System.Windows.Forms.TextBox tbDriverID;
        private System.Windows.Forms.Label lDriverName;
        private System.Windows.Forms.Label lDriverID;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.RadioButton rdbStandard;
        private System.Windows.Forms.RadioButton rdbPremium;
        private System.Windows.Forms.Button btLook;
        private System.Windows.Forms.TextBox tbTo;
        private System.Windows.Forms.Label lTo;
    }
}

