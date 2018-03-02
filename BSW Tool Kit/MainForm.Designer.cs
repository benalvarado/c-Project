namespace BSW_Tool_Kit
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.targetComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupOfRemoteComputersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printerInstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.massExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.executeBtn = new System.Windows.Forms.Button();
            this.runBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.targetComputerToolStripMenuItem,
            this.miscToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // targetComputerToolStripMenuItem
            // 
            this.targetComputerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localComputerToolStripMenuItem,
            this.remoteComputerToolStripMenuItem,
            this.groupOfRemoteComputersToolStripMenuItem});
            this.targetComputerToolStripMenuItem.Name = "targetComputerToolStripMenuItem";
            this.targetComputerToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.targetComputerToolStripMenuItem.Text = "Target Computer";
            // 
            // localComputerToolStripMenuItem
            // 
            this.localComputerToolStripMenuItem.Checked = true;
            this.localComputerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localComputerToolStripMenuItem.Name = "localComputerToolStripMenuItem";
            this.localComputerToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.localComputerToolStripMenuItem.Text = "Local Computer";
            this.localComputerToolStripMenuItem.Click += new System.EventHandler(this.localComputerToolStripMenuItem_Click);
            // 
            // remoteComputerToolStripMenuItem
            // 
            this.remoteComputerToolStripMenuItem.Name = "remoteComputerToolStripMenuItem";
            this.remoteComputerToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.remoteComputerToolStripMenuItem.Text = "Remote Computer";
            this.remoteComputerToolStripMenuItem.Click += new System.EventHandler(this.remoteComputerToolStripMenuItem_Click);
            // 
            // groupOfRemoteComputersToolStripMenuItem
            // 
            this.groupOfRemoteComputersToolStripMenuItem.Name = "groupOfRemoteComputersToolStripMenuItem";
            this.groupOfRemoteComputersToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.groupOfRemoteComputersToolStripMenuItem.Text = "Group of Remote Computers";
            this.groupOfRemoteComputersToolStripMenuItem.Click += new System.EventHandler(this.groupOfRemoteComputersToolStripMenuItem_Click);
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printerInstallToolStripMenuItem,
            this.massCopyToolStripMenuItem,
            this.massExecuteToolStripMenuItem,
            this.runAsToolStripMenuItem});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.miscToolStripMenuItem.Text = "Misc.";
            // 
            // printerInstallToolStripMenuItem
            // 
            this.printerInstallToolStripMenuItem.Name = "printerInstallToolStripMenuItem";
            this.printerInstallToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.printerInstallToolStripMenuItem.Text = "Printer Install";
            this.printerInstallToolStripMenuItem.Click += new System.EventHandler(this.printerInstallToolStripMenuItem_Click);
            // 
            // massCopyToolStripMenuItem
            // 
            this.massCopyToolStripMenuItem.Name = "massCopyToolStripMenuItem";
            this.massCopyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.massCopyToolStripMenuItem.Text = "Mass Copy";
            this.massCopyToolStripMenuItem.Click += new System.EventHandler(this.massCopyToolStripMenuItem_Click);
            // 
            // massExecuteToolStripMenuItem
            // 
            this.massExecuteToolStripMenuItem.Name = "massExecuteToolStripMenuItem";
            this.massExecuteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.massExecuteToolStripMenuItem.Text = "Mass Execute";
            this.massExecuteToolStripMenuItem.Click += new System.EventHandler(this.massExecuteToolStripMenuItem_Click);
            // 
            // runAsToolStripMenuItem
            // 
            this.runAsToolStripMenuItem.Name = "runAsToolStripMenuItem";
            this.runAsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.runAsToolStripMenuItem.Text = "Run As";
            this.runAsToolStripMenuItem.Click += new System.EventHandler(this.runAsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ping Computer",
            "Computer Serial Number",
            "Computer Model",
            "Computer Mac Address",
            "Operating System",
            "Logged User",
            "Printer",
            "Install Test"});
            this.comboBox1.Location = new System.Drawing.Point(460, 62);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(162, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(460, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 2;
            // 
            // executeBtn
            // 
            this.executeBtn.Location = new System.Drawing.Point(629, 62);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(75, 23);
            this.executeBtn.TabIndex = 3;
            this.executeBtn.Text = "Execute";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.executeBtn_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(629, 90);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 23);
            this.runBtn.TabIndex = 4;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 120);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(692, 292);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(409, 87);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(722, 424);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.executeBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "BSW Tool Kit";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem targetComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupOfRemoteComputersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printerInstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem massExecuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button executeBtn;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem runAsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    }
}

