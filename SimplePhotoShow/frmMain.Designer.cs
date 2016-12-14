namespace SimplePhotoShow
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.txtFullPath = new System.Windows.Forms.TextBox();
            this.picCurr = new System.Windows.Forms.PictureBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.filleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTimer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInteval = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.picLast = new System.Windows.Forms.PictureBox();
            this.picNext = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrShow = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picCurr)).BeginInit();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).BeginInit();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.AllowDrop = true;
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(12, 27);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFiles.Size = new System.Drawing.Size(314, 238);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.Click += new System.EventHandler(this.lstFiles_Click);
            this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
            this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
            this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
            this.lstFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstFiles_KeyUp);
            // 
            // txtFullPath
            // 
            this.txtFullPath.Location = new System.Drawing.Point(12, 271);
            this.txtFullPath.Name = "txtFullPath";
            this.txtFullPath.ReadOnly = true;
            this.txtFullPath.Size = new System.Drawing.Size(314, 20);
            this.txtFullPath.TabIndex = 1;
            // 
            // picCurr
            // 
            this.picCurr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCurr.Location = new System.Drawing.Point(335, 43);
            this.picCurr.Name = "picCurr";
            this.picCurr.Size = new System.Drawing.Size(224, 126);
            this.picCurr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCurr.TabIndex = 3;
            this.picCurr.TabStop = false;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filleToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(569, 24);
            this.mnuMain.TabIndex = 4;
            this.mnuMain.Text = "menuStrip1";
            // 
            // filleToolStripMenuItem
            // 
            this.filleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripMenuItem1,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripMenuItem2,
            this.mnuExit});
            this.filleToolStripMenuItem.Name = "filleToolStripMenuItem";
            this.filleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.filleToolStripMenuItem.Text = "&File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(152, 22);
            this.mnuNew.Text = "&New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(152, 22);
            this.mnuOpen.Text = "&Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(152, 22);
            this.mnuSave.Text = "&Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "E&xit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTimer,
            this.mnuInteval,
            this.mnuShowScreen});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            // 
            // mnuTimer
            // 
            this.mnuTimer.Checked = true;
            this.mnuTimer.CheckOnClick = true;
            this.mnuTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuTimer.Name = "mnuTimer";
            this.mnuTimer.Size = new System.Drawing.Size(201, 22);
            this.mnuTimer.Text = "T&imer enabled";
            // 
            // mnuInteval
            // 
            this.mnuInteval.Name = "mnuInteval";
            this.mnuInteval.Size = new System.Drawing.Size(201, 22);
            this.mnuInteval.Text = "Set inter&val: 4 sec";
            this.mnuInteval.Click += new System.EventHandler(this.setInterval4SecToolStripMenuItem_Click);
            // 
            // mnuShowScreen
            // 
            this.mnuShowScreen.Name = "mnuShowScreen";
            this.mnuShowScreen.Size = new System.Drawing.Size(201, 22);
            this.mnuShowScreen.Text = "Show screen: Secondary";
            this.mnuShowScreen.Click += new System.EventHandler(this.mnuShowScreen_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(332, 253);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(61, 51);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(399, 253);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(158, 51);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // picLast
            // 
            this.picLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLast.Location = new System.Drawing.Point(335, 188);
            this.picLast.Name = "picLast";
            this.picLast.Size = new System.Drawing.Size(105, 59);
            this.picLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLast.TabIndex = 7;
            this.picLast.TabStop = false;
            // 
            // picNext
            // 
            this.picNext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picNext.Location = new System.Drawing.Point(454, 188);
            this.picNext.Name = "picNext";
            this.picNext.Size = new System.Drawing.Size(105, 59);
            this.picNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNext.TabIndex = 8;
            this.picNext.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(332, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Last:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Next:";
            // 
            // tmrShow
            // 
            this.tmrShow.Tick += new System.EventHandler(this.tmrShow_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hint: Use CTRL+UP/DOWN to rearrange items.";
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(152, 22);
            this.mnuSaveAs.Text = "Save &as";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 316);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picNext);
            this.Controls.Add(this.picLast);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.picCurr);
            this.Controls.Add(this.txtFullPath);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Simple Photo Show";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCurr)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.TextBox txtFullPath;
        private System.Windows.Forms.PictureBox picCurr;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem filleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTimer;
        private System.Windows.Forms.ToolStripMenuItem mnuInteval;
        private System.Windows.Forms.PictureBox picLast;
        private System.Windows.Forms.PictureBox picNext;
        private System.Windows.Forms.ToolStripMenuItem mnuShowScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.Timer tmrShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
    }
}

