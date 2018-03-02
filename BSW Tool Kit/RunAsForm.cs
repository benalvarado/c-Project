using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using System.IO;

/*
 *   Darrell Beiner
 * 
 *   Program Scope: 
 *   To provide functionality of Install's, uninstall's, and repairs with out having to
 *   give a user admin rights. To run with any user logged in or on shared devices.
 *   
 *   Programming and Logic Updates: 3\11\2016
 *   domaincheckbox
 *   domaintext box 
 *   Domain authentication for user profiles
 *   Improved logic for error checking
 */

namespace BSW_Tool_Kit
{
    public partial class RunAsForm : Form
    {
        public RunAsForm()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        //  globalvariable class to hold the passwords encoded variable.
        class passwordGlobalVariable
        {
            public static SecureString var;
        }

        // to deal with the encoding of the password text box
        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            SecureString passWord = new SecureString();
            foreach (char c in passwordTextBox.Text.ToCharArray())
            {
                passWord.AppendChar(c);
            }
            passwordGlobalVariable.var = passWord;
        }
        private void browseBtn_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (ofd.InitialDirectory != null)
            {
                // Open document 
                string filename = ofd.FileName;
                browseTxtBox.Text = filename;
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RunAsForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnStart;
            this.AllowDrop = true;
            this.DragEnter += RunAsForm_DragEnter;
            this.DragDrop += RunAsForm_DragDrop;
        }
        private void RunAsForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void RunAsForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    if (File.Exists(fileLoc))
                    {
                        browseTxtBox.Text = fileLoc;
                    }
                }
            }
        }

        // admin check box functions
        private void adminBox_CheckedChanged_1(object sender, EventArgs e)
        {
            domainBox.Checked = false;
            domainTextBox.ReadOnly = true;
            userTextBox.ReadOnly = true;
            userTextBox.Text = "Administrator";
            domainTextBox.Text = "";
        }

        //domain check box functions
        private void domainBox_CheckedChanged_1(object sender, EventArgs e)
        {
            adminBox.Checked = false;
            // domainTextBox.ReadOnly = false;
            userTextBox.ReadOnly = false;
            userTextBox.Text = "";
            domainTextBox.Text = "swntdomain";
        }
        //run this if extension is .msi
            
        private void msi()
        {
            Process running = new Process();
            try
            {
                
                running.StartInfo.UseShellExecute = false;
                running.StartInfo.FileName = "msiexec";
                running.StartInfo.UserName = userTextBox.Text;
                running.StartInfo.Password = passwordGlobalVariable.var;
                running.StartInfo.Domain = domainTextBox.Text;
                running.StartInfo.Arguments = "/i " + browseTxtBox.Text + " ALLUSERS=\" \"";
                running.Start();
            }
            catch (Win32Exception)
            {

                string message = "User Name, Password or Domain may be incorrect";
                string caption = "Error Dectected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // this.Close();
                }
            }
        }

        // if the extension is not .msi try to run this; should only work for .exe extensions
        private void exe()
        {
            Process running = new Process();
            try
            {
                running.StartInfo.UseShellExecute = false;
                running.StartInfo.FileName = browseTxtBox.Text;
                running.StartInfo.UserName = userTextBox.Text;
                running.StartInfo.Password = passwordGlobalVariable.var;
                running.StartInfo.Domain = domainTextBox.Text;
                running.StartInfo.Arguments = "";
                running.Start();
            }
            catch (Win32Exception)
            {
                string message = "User Name, Password, Domain or File type may be incorrect";
                string caption = "Error Dectected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // this.Close();
                }
            }
        }
        private void fieldsnodest()
        {

            if (userTextBox.Text == "")
            {
                string message = "User Name Field is empty!";
                string caption = "Error Dectected in User Name Text Box";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (passwordTextBox.Text == "")
            {
                string message = "Password Field is empty!";
                string caption = "Error Dectected in Password Text Box";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                startcpl();
            }
        }

        private void fields()
        {

            if (userTextBox.Text == "")
            {
                string message = "User Name Field is empty!";
                string caption = "Error Dectected in User Name Text Box";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (passwordTextBox.Text == "")
            {
                string message = "Password Field is empty!";
                string caption = "Error Dectected in Password Text Box";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (browseTxtBox.Text == "")
            {
                string message = "Destination Path is empty!";
                string caption = "Error Dectected in Path";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                runprogram();
            }
        }

        private void checkboxes()
        {
            if (adminBox.Checked == false & domainBox.Checked == false)
            {
                string message = "Please Check Box for Local Admin or Domain User";
                string caption = "Error Dectected in Check Boxes";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                fields();
            }
        }

        private void checkboxesnodest()
        {
            if (adminBox.Checked == false & domainBox.Checked == false)
            {
                string message = "Please Check Box for Local Admin or Domain User";
                string caption = "Error Dectected in Check Boxes";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                fieldsnodest();
            }
        }

        private void runprogram()
        {
            string extend = Path.GetExtension(browseTxtBox.Text);
            if (extend == ".msi")
            {
                msi();
            }
            else if (extend == ".exe")
            {
                exe();
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            checkboxes();
        }
        private void startcpl()
        {
            Process running = new Process();
            try
            {
                running.StartInfo.UseShellExecute = false;
                running.StartInfo.FileName = "C:\\Windows\\System32\\Control.exe";
                running.StartInfo.UserName = userTextBox.Text;
                running.StartInfo.Password = passwordGlobalVariable.var;
                running.StartInfo.Domain = domainTextBox.Text;
                running.StartInfo.Arguments = "appwiz.cpl";
                running.Start();
            }
            catch (Win32Exception)
            {
                string message = "User Name, Password or Domain may be incorrect";
                string caption = "Error Dectected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    // this.Close();
                }
            }
        }
        private void addRemoveBtn_Click(object sender, EventArgs e)
        {
            checkboxesnodest();
        }
    }
}
