using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BSW_Tool_Kit;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security;

namespace BSW_Tool_Kit
{
    public partial class MainForm : Form
    {
        static string rc = RemoteComputerClass.computerName;
        static string lh = LocalHostClass.localComputer;
        static string goc = GroupofRemoteComputersClass.computerNames;

        public MainForm()
        { 
            InitializeComponent();
        }
        
        #region TargetComputers>Toolstrip
        public void localComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = true;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = false;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = true;
            TargetComputerState.remotestateCheck = false;
            TargetComputerState.groupstateCheck = false;
        }

        public void remoteComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteComputerForm remoteForm = new RemoteComputerForm();
            remoteForm.Show();

            ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = true;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = false;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = false;
            TargetComputerState.remotestateCheck = true;
            TargetComputerState.groupstateCheck = false;
        }

        public void groupOfRemoteComputersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupofRemoteComputersForm computerGroupForm = new GroupofRemoteComputersForm();
            computerGroupForm.Show();

            ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = true;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = false;
            TargetComputerState.remotestateCheck = false;
            TargetComputerState.groupstateCheck = true;
        }
        #endregion

        #region Misc.>Toolstrip
        private void printerInstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterInstallForm printerForm = new PrinterInstallForm();
            printerForm.Show();
        }

        private void massCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MassCopyForm masscopyForm = new MassCopyForm();
            masscopyForm.Show();
        }

        private void massExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MassExecuteForme massexecuteForm = new MassExecuteForme();
                massexecuteForm.Show();
        }

        private void runAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunAsForm runasForm = new RunAsForm();
            runasForm.ShowDialog(this);
        }

        #region File Menu>Toolstrip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ExecuteBtn_click
        private void executeBtn_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        if (TargetComputerState.groupstateCheck == true)
                        {
                            List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                            foreach (var result in computers)
                            {
                                richTextBox1.AppendText(result);
                                foreach (string str in PowerShell.Create().AddScript("ping " + result).AddCommand("Out-String").Invoke<string>())
                                    richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.remotestateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(RemoteComputerClass.computerName);
                            foreach (string str in PowerShell.Create().AddScript("ping " + RemoteComputerClass.computerName).AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.localstateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(LocalHostClass.localComputer);
                            foreach (string str in PowerShell.Create().AddScript("ping " + LocalHostClass.localComputer).AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        if (TargetComputerState.groupstateCheck == true)
                        {
                            List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                            foreach (var result in computers)
                            {
                                richTextBox1.AppendText(result);
                                foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + result + " Win32_BIOS | Select-Object SerialNumber | Format-List").AddCommand("Out-String").Invoke<string>())
                                    richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.remotestateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(RemoteComputerClass.computerName);
                            foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + RemoteComputerClass.computerName + " Win32_BIOS | Select-Object SerialNumber | Format-List").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.localstateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(LocalHostClass.localComputer);
                            foreach (string str in PowerShell.Create().AddScript("Get - WMIObject - computer " + LocalHostClass.localComputer + " Win32_BIOS | Select - Object SerialNumber | Format - List").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        if (TargetComputerState.groupstateCheck == true)
                        {
                            List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                            foreach (var result in computers)
                            {
                                richTextBox1.AppendText(result);
                                foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + result + " Win32_ComputerSystem | Format-List Name,Domain,Manufacturer,Model,SystemType").AddCommand("Out-String").Invoke<string>())
                                    richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.remotestateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(RemoteComputerClass.computerName);
                            foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + RemoteComputerClass.computerName + " Win32_ComputerSystem | Format-List Name,Domain,Manufacturer,Model,SystemType").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.localstateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(LocalHostClass.localComputer);
                            foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + LocalHostClass.localComputer + " Win32_ComputerSystem | Format-List Name,Domain,Manufacturer,Model,SystemType").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        if (TargetComputerState.groupstateCheck == true)
                        {
                            List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                            foreach (var result in computers)
                            {
                                richTextBox1.AppendText(result);
                                foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + result + " -class Win32_NetworkAdapterConfiguration | select Description,MacAddress").AddCommand("Out-String").Invoke<string>())
                                    richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.remotestateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(RemoteComputerClass.computerName);
                            foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + RemoteComputerClass.computerName + " -class Win32_NetworkAdapterConfiguration | select Description,MacAddress").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.localstateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(LocalHostClass.localComputer);
                            foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + LocalHostClass.localComputer + " -class Win32_NetworkAdapterConfiguration | select Description,MacAddress").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    break;
                case 4:
                    {
                        if (TargetComputerState.groupstateCheck == true)
                        {
                            List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                            foreach (var result in computers)
                            {
                                richTextBox1.AppendText(result);
                                foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -Class Win32_OperatingSystem -computer " + result + " | Select-Object Caption").AddCommand("Out-String").Invoke<string>())
                                    richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.remotestateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(RemoteComputerClass.computerName);
                            foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -Class Win32_OperatingSystem -computer " + RemoteComputerClass.computerName + " | Select-Object Caption").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.localstateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(LocalHostClass.localComputer);
                            foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -Class Win32_OperatingSystem -computer " + LocalHostClass.localComputer + " | Select-Object Caption").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    break;
                case 5:
                    {
                        if (TargetComputerState.groupstateCheck == true)
                        {
                            List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                            foreach (var result in computers)
                            {
                                richTextBox1.AppendText(result);
                                foreach (string str in PowerShell.Create().AddScript("Get-WmiObject Win32_LoggedOnUser -ComputerName " + result + " | Select Antecedent -Unique").AddCommand("Out-String").Invoke<string>())
                                    richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.remotestateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(RemoteComputerClass.computerName);
                            foreach (string str in PowerShell.Create().AddScript("Get-WmiObject Win32_LoggedOnUser -ComputerName " + RemoteComputerClass.computerName + " | Select Antecedent -Unique").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.localstateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(LocalHostClass.localComputer);
                            foreach (string str in PowerShell.Create().AddScript("Get-WmiObject Win32_LoggedOnUser -ComputerName " + LocalHostClass.localComputer + " | Select Antecedent -Unique").AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    break;
                case 6:
                    {
                        if (TargetComputerState.groupstateCheck == true)
                        {
                            List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                            foreach (var result in computers)
                            {
                                richTextBox1.AppendText(result);
                                foreach (string str in PowerShell.Create().AddScript("Get-WmiObject Win32_Printer -ComputerName " + result).AddCommand("Out-String").Invoke<string>())
                                    richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.remotestateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(RemoteComputerClass.computerName);
                            foreach (string str in PowerShell.Create().AddScript("Get-WmiObject Win32_Printer -ComputerName " + RemoteComputerClass.computerName).AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                        else if (TargetComputerState.localstateCheck == true)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            //RunCommand();
                            richTextBox1.AppendText(LocalHostClass.localComputer);
                            foreach (string str in PowerShell.Create().AddScript("Get-WmiObject Win32_Printer -ComputerName " + LocalHostClass.localComputer).AddCommand("Out-String").Invoke<string>())
                            {
                                richTextBox1.AppendText(str);
                                Cursor.Current = Cursors.Default;
                            }
                        }
                    }
                    break;
            }
        }
        #endregion
        class passwordGlobalVariable
        {
            public static SecureString var;
        }
        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            SecureString passWord = new SecureString();
            foreach (char c in textBox1.Text.ToCharArray())
            {
                passWord.AppendChar(c);
            }
            passwordGlobalVariable.var = passWord;
        }
        #region runBtn_click
        private void runBtn_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process running = new Process();
            try
            {

                running.StartInfo.UseShellExecute = false;
                running.StartInfo.FileName = "msiexec";
                running.StartInfo.UserName = "dlbei_000";
                running.StartInfo.Password = passwordGlobalVariable.var;
                running.StartInfo.Domain = "";
                running.StartInfo.Arguments = "/i " + "C:\\Users\\dlbei_000\\Desktop\\SecureAuthOTP_1.1.8.msi" + " ALLUSERS=\" \"";
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
#endregion

        private void MainForm_Load(object sender, EventArgs e)
        { 
            TargetComputerState.localstateCheck = true;
            TargetComputerState.remotestateCheck = false;
            TargetComputerState.groupstateCheck = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }
    }
}
#endregion
