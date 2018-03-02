using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSW_Tool_Kit
{
    public partial class PrinterUninstall : Form
    {
        public PrinterUninstall()
        {
            InitializeComponent();
        }

        //common variables
        static string printerUninstallDir = AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterUninstall.ps1";
        static string puparsedWhiteSpace = WhiteSpaceParsing.parsedResult(printerUninstallDir);

        private void PrinterUninstall_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            if (TargetComputerState.groupstateCheck == true)
            {
                List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                foreach (var result in computers)
                {
                    foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -ComputerName " + result + " -class Win32_printer | Format-List Name").AddCommand("Out-String").Invoke<string>())

                        Cursor.Current = Cursors.Default;
                }
            }
            else if (TargetComputerState.remotestateCheck == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + RemoteComputerClass.computerName + " -class Win32_printer | Format-List Name").AddCommand("Out-String").Invoke<string>())
                {
                    strmWriterUninstall.prntlst(str);
                    var lines = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterList.log");
                    foreach (var line in lines)
                    {
                        if (line != null && line != "")
                        {

                        //    listBox1.Items.Add(line);
                            listView1.Items.Add(line);
                            //         PrinterHost();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
            else if (TargetComputerState.localstateCheck == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -computer " + LocalHostClass.localComputer + " -class Win32_printer | Format-List Name").AddCommand("Out-String").Invoke<string>())
                {

                    strmWriterUninstall.prntlst(str);
                    var lines = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterList.log");
                    foreach (var line in lines)
                    {
                        if (line != null && line != "")
                        {
                            
                          //  listBox1.Items.Add(line);
                            System.Windows.Forms.ImageList img = new ImageList();
                            img.ImageSize = new Size(15, 15);
                            img.Images.Add(Image.FromFile(@"c:\users\dbeiner\desktop\BlueCheckMark.bmp"));
                            listView1.SmallImageList = img;

                            //listView1.Items.Add(line, 0);
                            listView1.Items.Add(line);

                            //         PrinterHost();
                        }
                    }
                    Cursor.Current = Cursors.Default;
                }
            }

            //  ReadPrinterNamestoList.hostingList();

        }

        public void PrinterHost()
        {
            //    ReadPrinterNamestoList printerClass = new ReadPrinterNamestoList();
            //   List<string> hostList = ReadPrinterNamestoList.hostingList();
            // hostList.Add(ReadPrinterNamestoList.hostingList);
            //  listBox2.DataSource = hostList;
            if (TargetComputerState.groupstateCheck == true)
            {
                List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                foreach (var result in computers)
                {
                    foreach (string str in PowerShell.Create().AddScript("Get-WMIObject -ComputerName " + result + " -class Win32_printer | Format-List Name").AddCommand("Out-String").Invoke<string>())

                        Cursor.Current = Cursors.Default;
                }
            }
            else if (TargetComputerState.remotestateCheck == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (string str in PowerShell.Create().AddScript("gwmi win32_printer -ComputerName " + LocalHostClass.localComputer + " | %{ $printer = $_.Name; $port = $_.portname; gwmi win32_tcpipprinterport -computername " + LocalHostClass.localComputer + " | where { $_.Name -eq $port } | select @{name=\"printername\";expression={$printer}}, hostaddress }").AddCommand("Out-String").Invoke<string>())
                {
                    listBox2.Items.Add(str);
                    Cursor.Current = Cursors.Default;
                }
            }
            else if (TargetComputerState.localstateCheck == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (string str in PowerShell.Create().AddScript("gwmi win32_printer -ComputerName " + LocalHostClass.localComputer + " | %{ $printer = $_.Name; $port = $_.portname; gwmi win32_tcpipprinterport -computername " + LocalHostClass.localComputer + " | where { $_.Name -eq $port } | select @{name=\"printername\";expression={$printer}}, hostaddress }").AddCommand("Out-String").Invoke<string>())
                {
                    listBox2.Items.Add(str);

                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] cpuninstlines = { "param([string[]] $Computer, [string[]] $Printer)",

            "$a = Get-WmiObject -ComputerName $Computer -query \"SELECT * FROM win32_printer WHERE name ='$Printer'\"",
            "$a.delete()",

                };

            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterUninstall.ps1", cpuninstlines);


            string selectedLstViewPrinter = listView1.SelectedItems[0].Text;
           // string selectedPrinter = listBox1.GetItemText(listBox1.SelectedItem);
            if (TargetComputerState.groupstateCheck == true)
            {
                List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                foreach (var result in computers)
                {
                    // foreach (string str in PowerShell.Create().AddScript(puparsedWhiteSpace + " " + ).AddCommand("Out-String").Invoke<string>())

                    Cursor.Current = Cursors.Default;
                    PrinterUninstall prntForm = new PrinterUninstall();
                    prntForm.Show();
                    this.Dispose(false);
                }
            }
            else if (TargetComputerState.remotestateCheck == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                // foreach (string str in PowerShell.Create().AddScript("$a = Get-WmiObject -ComputerName " + RemoteComputerClass.computerName + " -query \"SELECT * FROM win32_printer WHERE name = \"" + selectedPrinter + "\"\"; $a.delete()").AddCommand("Out-String").Invoke<string>())
                PowerShell.Create().AddScript(puparsedWhiteSpace + " " + RemoteComputerClass.computerName + " " + "\"" + selectedLstViewPrinter + "\"").AddCommand("Out-String").Invoke<string>();
                // PowerShell.Create().AddScript("$a.delete()").AddCommand("Out-String").Invoke<string>();
                //   File.Delete(plparsedWhiteSpace);
                Cursor.Current = Cursors.Default;
                PrinterUninstall prntForm = new PrinterUninstall();
                prntForm.Show();
                this.Dispose(false);
            }
            else if (TargetComputerState.localstateCheck == true)
            {
                Cursor.Current = Cursors.WaitCursor;

                PowerShell.Create().AddScript(puparsedWhiteSpace + " " + LocalHostClass.localComputer + " " + selectedLstViewPrinter).AddCommand("Out-String").Invoke<string>();
                //   PowerShell.Create().AddScript("$a.delete()").AddCommand("Out-String").Invoke<string>();
                //  File.Delete(plparsedWhiteSpace);

                Cursor.Current = Cursors.Default;
                PrinterUninstall prntForm = new PrinterUninstall();
                prntForm.Show();
                this.Dispose(false);
            }
        }

        private void localComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = true;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = false;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = true;
            TargetComputerState.remotestateCheck = false;
            TargetComputerState.groupstateCheck = false;
            PrinterUninstall prntForm = new PrinterUninstall();
            prntForm.Show();
            this.Dispose(false);
        }

        private void remoteComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteComputerFormPRNT remoteForm = new RemoteComputerFormPRNT();
            remoteForm.Show();


            ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = true;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = false;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = false;
            TargetComputerState.remotestateCheck = true;
            TargetComputerState.groupstateCheck = false;
            //  PrinterUninstall prntForm = new PrinterUninstall();

            this.Dispose(false);
        }

        private void groupOfRemoteComputersToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Button to set the default Printer.
        private void button3_Click(object sender, EventArgs e)
        {

          //  string selectedPrinter = listBox1.GetItemText(listBox1.SelectedItem);
          //  string lstselectedPrinter = listView1.GetItemText(listView1.SelectedItem);
            //Invoke-Command -ComputerName sw1409-14536 -ScriptBlock {(New-Object -ComObject WScript.Network).SetDefaultPrinter("test printer") }
          //  PowerShell.Create().AddScript("Invoke-Command -ComputerName " + RemoteComputerClass.computerName + " -ScriptBlock {(New-Object -ComObject WScript.Network).SetDefaultPrinter(\"" + selectedPrinter + "\")}").AddCommand("Out-String").Invoke<string>();
            string selectedLstViewPrinter = listView1.SelectedItems[0].Text;
            PowerShell.Create().AddScript("Invoke-Command -ComputerName " + RemoteComputerClass.computerName + " -ScriptBlock {(New-Object -ComObject WScript.Network).SetDefaultPrinter(\"" + selectedLstViewPrinter + "\")}").AddCommand("Out-String").Invoke<string>();

        }
    }
    }