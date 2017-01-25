namespace SimplePhotoShow
{
    partial class frmRename
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
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnFolderBrowser = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtStartNum = new System.Windows.Forms.TextBox();
            this.chkFill = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSufix = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.chkPrefix = new System.Windows.Forms.CheckBox();
            this.chkSuffix = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.pgbCopy = new System.Windows.Forms.ProgressBar();
            this.fbdTarget = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(6, 19);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(275, 20);
            this.txtFolder.TabIndex = 2;
            // 
            // btnFolderBrowser
            // 
            this.btnFolderBrowser.Location = new System.Drawing.Point(287, 19);
            this.btnFolderBrowser.Name = "btnFolderBrowser";
            this.btnFolderBrowser.Size = new System.Drawing.Size(27, 20);
            this.btnFolderBrowser.TabIndex = 3;
            this.btnFolderBrowser.Text = "...";
            this.btnFolderBrowser.UseVisualStyleBackColor = true;
            this.btnFolderBrowser.Click += new System.EventHandler(this.btnFolderBrowser_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFolder);
            this.groupBox1.Controls.Add(this.btnFolderBrowser);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target folder";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtStartNum);
            this.groupBox2.Controls.Add(this.chkFill);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSufix);
            this.groupBox2.Controls.Add(this.txtPrefix);
            this.groupBox2.Controls.Add(this.chkPrefix);
            this.groupBox2.Controls.Add(this.chkSuffix);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 105);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output filename";
            // 
            // txtStartNum
            // 
            this.txtStartNum.Location = new System.Drawing.Point(79, 71);
            this.txtStartNum.Name = "txtStartNum";
            this.txtStartNum.Size = new System.Drawing.Size(85, 20);
            this.txtStartNum.TabIndex = 9;
            this.txtStartNum.Text = "0";
            this.txtStartNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStartNum_KeyDown);
            // 
            // chkFill
            // 
            this.chkFill.AutoSize = true;
            this.chkFill.Checked = true;
            this.chkFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFill.Location = new System.Drawing.Point(170, 73);
            this.chkFill.Name = "chkFill";
            this.chkFill.Size = new System.Drawing.Size(88, 17);
            this.chkFill.TabIndex = 6;
            this.chkFill.Text = "Fill with zeros";
            this.chkFill.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start number";
            // 
            // txtSufix
            // 
            this.txtSufix.Location = new System.Drawing.Point(64, 45);
            this.txtSufix.Name = "txtSufix";
            this.txtSufix.Size = new System.Drawing.Size(100, 20);
            this.txtSufix.TabIndex = 7;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(64, 19);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(100, 20);
            this.txtPrefix.TabIndex = 6;
            this.txtPrefix.Text = "img";
            // 
            // chkPrefix
            // 
            this.chkPrefix.AutoSize = true;
            this.chkPrefix.Checked = true;
            this.chkPrefix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrefix.Location = new System.Drawing.Point(6, 21);
            this.chkPrefix.Name = "chkPrefix";
            this.chkPrefix.Size = new System.Drawing.Size(52, 17);
            this.chkPrefix.TabIndex = 6;
            this.chkPrefix.Text = "Prefix";
            this.chkPrefix.UseVisualStyleBackColor = true;
            this.chkPrefix.CheckedChanged += new System.EventHandler(this.chkPrefix_CheckedChanged);
            // 
            // chkSuffix
            // 
            this.chkSuffix.AutoSize = true;
            this.chkSuffix.Location = new System.Drawing.Point(6, 47);
            this.chkSuffix.Name = "chkSuffix";
            this.chkSuffix.Size = new System.Drawing.Size(52, 17);
            this.chkSuffix.TabIndex = 6;
            this.chkSuffix.Text = "Suffix";
            this.chkSuffix.UseVisualStyleBackColor = true;
            this.chkSuffix.CheckedChanged += new System.EventHandler(this.chkSuffix_CheckedChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(262, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Can&cel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCopy.Location = new System.Drawing.Point(181, 184);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Cop&y";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // pgbCopy
            // 
            this.pgbCopy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbCopy.Location = new System.Drawing.Point(0, 218);
            this.pgbCopy.Name = "pgbCopy";
            this.pgbCopy.Size = new System.Drawing.Size(349, 23);
            this.pgbCopy.TabIndex = 8;
            // 
            // fbdTarget
            // 
            this.fbdTarget.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // frmRename
            // 
            this.AcceptButton = this.btnCopy;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(349, 241);
            this.Controls.Add(this.pgbCopy);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRename";
            this.ShowInTaskbar = false;
            this.Text = "Rename files";
            this.Load += new System.EventHandler(this.frmRename_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnFolderBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtStartNum;
        private System.Windows.Forms.CheckBox chkFill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSufix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.CheckBox chkPrefix;
        private System.Windows.Forms.CheckBox chkSuffix;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ProgressBar pgbCopy;
        private System.Windows.Forms.FolderBrowserDialog fbdTarget;
    }
}