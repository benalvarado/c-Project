namespace BSW_Tool_Kit
{
    partial class RunAsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunAsForm));
            this.adminBox = new System.Windows.Forms.CheckBox();
            this.domainBox = new System.Windows.Forms.CheckBox();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.addRemoveBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.browseTxtBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // adminBox
            // 
            this.adminBox.AutoSize = true;
            this.adminBox.Checked = true;
            this.adminBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.adminBox.Location = new System.Drawing.Point(510, 26);
            this.adminBox.Name = "adminBox";
            this.adminBox.Size = new System.Drawing.Size(115, 17);
            this.adminBox.TabIndex = 1;
            this.adminBox.Text = "&Local Administrator";
            this.adminBox.UseVisualStyleBackColor = true;
            this.adminBox.CheckedChanged += new System.EventHandler(this.adminBox_CheckedChanged_1);
            // 
            // domainBox
            // 
            this.domainBox.AutoSize = true;
            this.domainBox.Location = new System.Drawing.Point(510, 50);
            this.domainBox.Name = "domainBox";
            this.domainBox.Size = new System.Drawing.Size(87, 17);
            this.domainBox.TabIndex = 2;
            this.domainBox.Text = "D&omain User";
            this.domainBox.UseVisualStyleBackColor = true;
            this.domainBox.CheckedChanged += new System.EventHandler(this.domainBox_CheckedChanged_1);
            // 
            // domainTextBox
            // 
            this.domainTextBox.Location = new System.Drawing.Point(510, 73);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.ReadOnly = true;
            this.domainTextBox.Size = new System.Drawing.Size(160, 20);
            this.domainTextBox.TabIndex = 3;
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(510, 101);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.ReadOnly = true;
            this.userTextBox.Size = new System.Drawing.Size(160, 20);
            this.userTextBox.TabIndex = 4;
            this.userTextBox.Text = "Administrator";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(510, 128);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(160, 20);
            this.passwordTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "&Domain:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(441, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "&User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Password:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(513, 157);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(595, 157);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 10;
            this.exitBtn.Text = "E&xit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(12, 128);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(112, 23);
            this.browseBtn.TabIndex = 11;
            this.browseBtn.Text = "&Browse...";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // addRemoveBtn
            // 
            this.addRemoveBtn.Location = new System.Drawing.Point(272, 128);
            this.addRemoveBtn.Name = "addRemoveBtn";
            this.addRemoveBtn.Size = new System.Drawing.Size(147, 23);
            this.addRemoveBtn.TabIndex = 12;
            this.addRemoveBtn.Text = "&Add\\Remove Programs";
            this.addRemoveBtn.UseVisualStyleBackColor = true;
            this.addRemoveBtn.Click += new System.EventHandler(this.addRemoveBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select a file";
            // 
            // browseTxtBox
            // 
            this.browseTxtBox.Location = new System.Drawing.Point(12, 157);
            this.browseTxtBox.Name = "browseTxtBox";
            this.browseTxtBox.Size = new System.Drawing.Size(407, 20);
            this.browseTxtBox.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 87);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // RunAsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(678, 186);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.browseTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addRemoveBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.domainTextBox);
            this.Controls.Add(this.domainBox);
            this.Controls.Add(this.adminBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RunAsForm";
            this.Text = "RunAs";
            this.Load += new System.EventHandler(this.RunAsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox adminBox;
        private System.Windows.Forms.CheckBox domainBox;
        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button addRemoveBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox browseTxtBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}