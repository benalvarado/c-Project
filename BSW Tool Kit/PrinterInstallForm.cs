using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// To-Do-List:
/// Clean up code into a more readable format
/// </summary>
namespace BSW_Tool_Kit
{
    public partial class PrinterInstallForm : Form
    {
        
        public PrinterInstallForm()
        {
            InitializeComponent();
        }
               
        // Common Variables
        string assemblyLoc = System.Reflection.Assembly.GetExecutingAssembly().Location;
        
        // Driver Directory Base
        static string driverDirectBase = string.Empty;
        
        // Driver INF Base
        static string driverDirectBaseInf = string.Empty;

        // Driver path directed
        static string driversDirectory = string.Empty;

        // Name of the installed Drive
        static string theDriverName = string.Empty;

        // base directory
        static string crntDir = AppDomain.CurrentDomain.BaseDirectory;
        static string crntDirParsedWhiteSpace = WhiteSpaceParsing.parsedResult(crntDir);

        // parsed info
        static string currentDir = AppDomain.CurrentDomain.BaseDirectory + @"Resources\cPrinter.ps1";
        static string parsedWhiteSpace = WhiteSpaceParsing.parsedResult(currentDir);

        static string createPrinterPortDir = AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinterPort.ps1";
        static string cppparsedWhiteSpace = WhiteSpaceParsing.parsedResult(createPrinterPortDir);

        static string installPrintDriverDir = AppDomain.CurrentDomain.BaseDirectory + @"Logs\InstallPrintDriver.ps1";
        static string ipdparsedWhiteSpace = WhiteSpaceParsing.parsedResult(installPrintDriverDir);

        static string createPrinterDir = AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinter.ps1";
        static string cpparsedWhiteSpace = WhiteSpaceParsing.parsedResult(createPrinterDir);

        static string copyinstPrinterDir = AppDomain.CurrentDomain.BaseDirectory + @"Logs\CopyinstDriver.ps1";
        static string cipparsedWhiteSpace = WhiteSpaceParsing.parsedResult(createPrinterDir);

        // HP Laser Jet 400 Driver Directory and inf
        static string hpLaserJet400 = AppDomain.CurrentDomain.BaseDirectory + driverDirectBase;
        static string hpLaserJet400Parsed = WhiteSpaceParsing.parsedResult(hpLaserJet400);

        static string hpLaserJet400inf = AppDomain.CurrentDomain.BaseDirectory + driverDirectBaseInf;
        static string hpLaserJet400infParsed = WhiteSpaceParsing.parsedResult(hpLaserJet400);

        // HP Laser Jet 400 MFP Driver Directory and inf
        static string hpLaserJet400MFP = AppDomain.CurrentDomain.BaseDirectory + driverDirectBase;
        static string hpLaserJet400MFPParsed = WhiteSpaceParsing.parsedResult(hpLaserJet400MFP);

        static string hpLaserJet400MFPinf = AppDomain.CurrentDomain.BaseDirectory + driverDirectBaseInf;
        static string hpLaserJet400MFPinfParsed = WhiteSpaceParsing.parsedResult(hpLaserJet400MFPinf);

        // HP Laser Jet 1320 Driver Directory and inf
        static string hpLaserJet1320 = AppDomain.CurrentDomain.BaseDirectory + driverDirectBase;
        static string hpLaserJet1320Parsed = WhiteSpaceParsing.parsedResult(hpLaserJet1320);

        static string hpLaserJet1320inf = AppDomain.CurrentDomain.BaseDirectory + driverDirectBaseInf;
        static string hpLaserJet1320infParsed = WhiteSpaceParsing.parsedResult(hpLaserJet1320inf);

        // HP Laser Jet 2727 Driver Directoryand inf
        static string hpLaserJet2727 = AppDomain.CurrentDomain.BaseDirectory + driverDirectBase;
        static string hpLaserJet2727Parsed = WhiteSpaceParsing.parsedResult(hpLaserJet2727);

        static string hpLaserJet2727inf = AppDomain.CurrentDomain.BaseDirectory + driverDirectBaseInf;
        static string hpLaserJet2727infParsed = WhiteSpaceParsing.parsedResult(hpLaserJet2727inf);

        // HP Laser Jet 4345 Driver Directory and inf
        static string hpLaserJect4350 = AppDomain.CurrentDomain.BaseDirectory + driverDirectBase;
        static string hpLaserJect4350Parsed = WhiteSpaceParsing.parsedResult(hpLaserJect4350);

        static string hpLaserJect4350inf = AppDomain.CurrentDomain.BaseDirectory + driverDirectBaseInf;
        static string hpLaserJect4350infParsed = WhiteSpaceParsing.parsedResult(hpLaserJect4350inf);

        // Universal 32bit Driver Directory and inf
        static string universalDriver32bit = AppDomain.CurrentDomain.BaseDirectory + driverDirectBase;
        static string universalDriver32bitParsed = WhiteSpaceParsing.parsedResult(universalDriver32bit);

        static string universalDriver32bitinf = AppDomain.CurrentDomain.BaseDirectory + driverDirectBaseInf;
        static string universalDriver32bitinfParsed = WhiteSpaceParsing.parsedResult(universalDriver32bitinf);

        // Universal 64bit Driver Directory and inf
        static string universalDriver64bit = AppDomain.CurrentDomain.BaseDirectory + driverDirectBase;
        static string universalDriver64bitParsed = WhiteSpaceParsing.parsedResult(universalDriver64bit);

        static string universalDriver64bitinf = AppDomain.CurrentDomain.BaseDirectory + driverDirectBaseInf;
        static string universalDriver64bitinfParsed = WhiteSpaceParsing.parsedResult(universalDriver64bitinf);

        #region Driver base path and .infpath
        // Driver base path and .inf path
        public void printerModelTxtBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath;
           // Set the directories for Printer Drivers/inf. During the writing of this we switched to the standard of one printer driver and a set of standard printers.
            if (printerModelTxtBox.SelectedIndex == 0)
            {
                pictureBox1.ImageLocation = crntDir + @"PrinterImages\hp400IMG.bmp";
                // pictureBox1.ImageLocation = strPath + "/hp400IMG.bmp";
                driverDirectBase = @"Printers\HPUniversalPrintDriver\pcl6x32";
                driverDirectBaseInf = @"Printers\HPUniversalPrintDriver\pcl6x32\hpcu186c.inf";
                //   driversDirectory = universalDriver64bitParsed + @"HPUniversalPrintDriver\pcl6x32";
                theDriverName = "HP Universal PCL 6";
            }
            else if (printerModelTxtBox.SelectedIndex == 1)
            {
                pictureBox1.ImageLocation = crntDir + @"PrinterImages\400MFP.bmp";
                driverDirectBase = @"Printers\HPUniversalPrintDriver\pcl6x32";
                driverDirectBaseInf = @"Printers\HPUniversalPrintDriver\pcl6x32\hpcu186c.inf";
                theDriverName = "HP Universal PCL 6";
            }
            else if (printerModelTxtBox.SelectedIndex == 2)
            {
                pictureBox1.ImageLocation = crntDir + @"PrinterImages\LaserJet1320.bmp";
                driverDirectBase = @"Printers\Laserjet1320-pcl5-x32";
                driverDirectBaseInf = @"Printers\Laserjet1320-pcl5-x32\hpbuio170l.inf";
                theDriverName = "HP 1320 PCL 5";
            }
            else if (printerModelTxtBox.SelectedIndex == 3)
            {
                pictureBox1.ImageLocation = crntDir + @"PrinterImages\LaserJet2727.bmp";
                driverDirectBase = @"Printers\HPUniversalPrintDriver\pcl6x32";
                driverDirectBaseInf = @"Printers\HPUniversalPrintDriver\pcl6x32\hpcu186c.inf";
                theDriverName = "HP Universal PCL 6";
            }
            else if (printerModelTxtBox.SelectedIndex == 4)
            {
                pictureBox1.ImageLocation = crntDir + @"PrinterImages\laserJet4350.bmp";
                driverDirectBase = @"Printers\HPUniversalPrintDriver\pcl6x32";
                driverDirectBaseInf = @"Printers\HPUniversalPrintDriver\pcl6x32\hpcu186c.inf";
                theDriverName = "HP Universal PCL 6";
            }
            else if (printerModelTxtBox.SelectedIndex == 5)
            {
                pictureBox1.ImageLocation = crntDir + @"PrinterImages\UniversalPrinter.bmp";
                driverDirectBase = @"Printers\HPUniversalPrintDriver\pcl6x32";
                driverDirectBaseInf = @"Printers\HPUniversalPrintDriver\pcl6x32\hpcu186c.inf";
                theDriverName = "HP Universal PCL 6";
            }
            else if (printerModelTxtBox.SelectedIndex == 6)
            {
                pictureBox1.ImageLocation = crntDir + @"PrinterImages\UniversalPrinter.bmp";
                driverDirectBase = @"Printers\HPUniversalPrintDriver\pcl6x32";
                driverDirectBaseInf = @"Printers\HPUniversalPrintDriver\pcl6x32\hpcu186c.inf";
                theDriverName = "HP Universal PCL 6";
            }
        }
        #endregion


        private void installBtn_Click(object sender, EventArgs e)
        {
            RemoteComputerForm remoteForm = new RemoteComputerForm();
            if (prntHostBox.Text == "")
            {
                string message = "Printer Host Name Field is empty!";
                string caption = "Error Dectected in Printer Host Name Text Box";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (printerModelTxtBox.SelectedItem == null)
            {
                string message = "Select a printer";
                string caption = "Error Dectected in \"Select a Printer\"";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (prntCaptionBox.Text == "")
            {
                string message = "Printer Caption Field is empty!";
                string caption = "Error Dectected in Caption Text Box";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked == true && RemoteComputerClass.computerName == "")
            {
                string message = "Remote computer name field is empty";
                string caption = "Error Dectected in Computer Path";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked == true && GroupofRemoteComputersClass.computerNames == "")
            {
                string message = "Group of Remote computer name field is empty";
                string caption = "Error Dectected in Computer Path";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked == false && ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked == false)
            {
                string message = "No computer Selected";
                string caption = "Error Dectected in Target Computer";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                RunProg();
            }
        }

        private void RunProg()
        {
            string printerCaption = prntCaptionBox.Text;
            string PrinterHost = prntHostBox.Text;
            ModifyProgressBarColor.SetState(progressBar1, 1);
            #region Group region
            if (TargetComputerState.groupstateCheck == true)
            {
                string[] cpinstlines = { "param([string[]] $Computer, [string[]] $Printer, [string[]] $driverName, [string[]] $infPath)",

                "Invoke-Command -ComputerName $Computer {cscript C:\\Windows\\System32\\Printing_Admin_Scripts\\en-US\\prndrvr.vbs - a - m \"$driverName\" - i \"$infPath\"}",
                };

                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CopyinstDriver.ps1", cpinstlines);

                string[] cplines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)\n",

                "Function CreatePrinter",

                "{",
                " param ($PrinterCaption, $PrinterPortName, $DriverName, $ComputerName)",
                "$wmi = ([wmiclass]\"\\\\$ComputerName\\Root\\cimv2:Win32_Printer\")",
                "$Printer = $wmi.CreateInstance()",
                "$Printer.Caption = $PrinterCaption",
                "$Printer.DriverName = $DriverName",
                "$Printer.PortName = $PrinterPortName",
                "$Printer.DeviceID = $PrinterCaption",
                "$Printer.put()",
                "}\n",

                "foreach ($computer in $ComputerList) {",
                "CreatePrinter -PrinterPortName $PrinterPortName -DriverName `",
                "$DriverName -PrinterCaption $PrinterCaption -ComputerName $computer",
                "}"
            };
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinter.ps1", cplines);

                string[] cpplines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)\n",

                "Function CreatePrinterPort",
                        "{",
                "param ($PrinterIP, $PrinterPort, $PrinterPortName, $ComputerName)",
                "$wmi = [wmiclass]\"\\\\$ComputerName\\root\\cimv2:win32_tcpipPrinterPort\"",
                "$wmi.psbase.scope.options.enablePrivileges = $true",
                "$Port = $wmi.createInstance()",
                "$Port.name = $PrinterPortName",
                "$Port.hostAddress = $PrinterIP",
                "$Port.portNumber = $PrinterPort",
                "$Port.SNMPEnabled = $false",
                "$Port.Protocol = 1",
                "$Port.put()",
                "}",

                "foreach ($computer in $ComputerList) {",
                "CreatePrinterPort -PrinterIP $PrinterIP -PrinterPort $PrinterPort `",
                "-PrinterPortName $PrinterPortName -ComputerName $computer",
                    "}",
                };
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinterPort.ps1", cpplines);


                string[] cpdlines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)",


                "Function InstallPrinterDriver",
                        "{",
                "Param ($DriverName, $DriverPath, $DriverInf, $ComputerName)",
                "$wmi = [wmiclass]\"\\\\$ComputerName\\Root\\cimv2:Win32_PrinterDriver\"",
                "$wmi.psbase.scope.options.enablePrivileges = $true",
                "$wmi.psbase.Scope.Options.Impersonation = `",
                "[System.Management.ImpersonationLevel]::Impersonate",
                "$Driver = $wmi.CreateInstance()",
                "$Driver.Name = $DriverName",
                "$Driver.DriverPath = $DriverPath",
                "$Driver.InfName = $DriverInf",
                "$wmi.AddPrinterDriver($Driver)",
                "$wmi.put()",
                "}",


                "foreach ($computer in $ComputerList) {",
                "InstallPrinterDriver -DriverName $DriverName -DriverPath `",
                "$DriverPath -DriverInf $DriverInf -ComputerName $computer",
                    "}",
                };
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\InstallPrintDriver.ps1", cpplines);

                List<string> computers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();
                foreach (var result in computers)

                    try
                    {
                        progressBar1.Value = 0;
                        PowerShell.Create().AddScript("Copy-Item -Path " + crntDirParsedWhiteSpace + driverDirectBase + @" -Destination \\" + result + @"\c$\install\Printer -recurse;").AddCommand("Out-String").Invoke<string>();

                        string scriptTextFour = cipparsedWhiteSpace + " " + result + theDriverName + driverDirectBaseInf;
                        label7.Text = "Checking Driver requirements for... " + result;
                        progressBar1.Increment(20);

                        string scriptText = cppparsedWhiteSpace + " " + result + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                        label7.Text = "Creating Printer Port on " + result;
                        textBoxOutput.AppendText("\nCreating Printer Port");
                        progressBar1.Increment(20);
                        textBoxOutput.AppendText(RunScript(scriptText));

                        string scriptTextTwo = ipdparsedWhiteSpace + " " + result + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                        label7.Text = "Installing Printer Driver on " + result;
                        textBoxOutput.AppendText("\nInstalling Printer Driver");
                        progressBar1.Increment(20);
                        textBoxOutput.AppendText(RunScript(scriptTextTwo));

                        string scriptTextThree = cpparsedWhiteSpace + " " + result + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                        label7.Text = "Installing Printer on " + result;
                        textBoxOutput.AppendText("\nInstalling Printer");
                        progressBar1.Increment(20);
                        textBoxOutput.AppendText(RunScript(scriptTextThree));
                        label7.Text = "Installing Complete for " + result;
                        textBoxOutput.AppendText("\nInstallation Complete");
                        progressBar1.Increment(20);
                        string loggedThree = LogWorker.logging(result, PrinterHost, printerModelTxtBox.Text, printerCaption, "Successful");
                        if (checkBox3.Checked == true)
                        {
                            PowerShell.Create().AddScript("Invoke-Command -ComputerName " + result + " -ScriptBlock {(New-Object -ComObject WScript.Network).SetDefaultPrinter(\"" + printerCaption + "\")}").AddCommand("Out-String").Invoke<string>();
                        }
                        Cursor.Current = Cursors.Default;
                    }
                    catch (Exception error)
                    {
                        ModifyProgressBarColor.SetState(progressBar1, 2);
                        progressBar1.Value = 100;
                        label7.Text = "Encountered ERROR on : " + result;
                        textBoxOutput.Text += String.Format(",ERROR\r\nError in script : {0}\r\n", error.Message);
                        System.Threading.Thread.Sleep(2000);
                        ModifyProgressBarColor.SetState(progressBar1, 1);
                        progressBar1.Value = 0;

                        // send to log file
                        string createLogPrinter = result + "," + printerCaption + "," + PrinterHost + "," + String.Format("\r\nError in script : {0}\r\n", error.Message);
                        string loggedThree = LogWorker.logging(result, PrinterHost, printerModelTxtBox.Text, printerCaption, String.Format(",ERROR\r\nError in script : {0}", error.Message));
                    }
            }
            #endregion
            #region remote region
            else if (TargetComputerState.remotestateCheck == true)
            {
                string[] cpinstlines = { "param([string[]] $Computer, [string[]] $Printer, [string[]] $driverName, [string[]] $infPath)",

                "Invoke-Command -ComputerName $Computer {cscript C:\\Windows\\System32\\Printing_Admin_Scripts\\en-US\\prndrvr.vbs - a - m \"$driverName\" - i \"$infPath\"}",
                };

                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CopyinstDriver.ps1", cpinstlines);

                string[] cplines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)\n",


                "Function CreatePrinter",

                "{",
                " param ($PrinterCaption, $PrinterPortName, $DriverName, $ComputerName)",
                "$wmi = ([wmiclass]\"\\\\$ComputerName\\Root\\cimv2:Win32_Printer\")",
                "$Printer = $wmi.CreateInstance()",
                "$Printer.Caption = $PrinterCaption",
                "$Printer.DriverName = $DriverName",
                "$Printer.PortName = $PrinterPortName",
                "$Printer.DeviceID = $PrinterCaption",
                "$Printer.put()",
                "}\n",

                "foreach ($computer in $ComputerList) {",
                "CreatePrinter -PrinterPortName $PrinterPortName -DriverName `",
                "$DriverName -PrinterCaption $PrinterCaption -ComputerName $computer",
                "}"
            };
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinter.ps1", cplines);

                string[] cpplines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)\n",


                "Function CreatePrinterPort",
                        "{",
                "param ($PrinterIP, $PrinterPort, $PrinterPortName, $ComputerName)",
                "$wmi = [wmiclass]\"\\\\$ComputerName\\root\\cimv2:win32_tcpipPrinterPort\"",
                "$wmi.psbase.scope.options.enablePrivileges = $true",
                "$Port = $wmi.createInstance()",
                "$Port.name = $PrinterPortName",
                "$Port.hostAddress = $PrinterIP",
                "$Port.portNumber = $PrinterPort",
                "$Port.SNMPEnabled = $false",
                "$Port.Protocol = 1",
                "$Port.put()",
                "}",

                "foreach ($computer in $ComputerList) {",
                "CreatePrinterPort -PrinterIP $PrinterIP -PrinterPort $PrinterPort `",
                "-PrinterPortName $PrinterPortName -ComputerName $computer",
                    "}",
                };
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinterPort.ps1", cpplines);


                string[] cpdlines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)",


                "Function InstallPrinterDriver",
                        "{",
                "Param ($DriverName, $DriverPath, $DriverInf, $ComputerName)",
                "$wmi = [wmiclass]\"\\\\$ComputerName\\Root\\cimv2:Win32_PrinterDriver\"",
                "$wmi.psbase.scope.options.enablePrivileges = $true",
                "$wmi.psbase.Scope.Options.Impersonation = `",
                "[System.Management.ImpersonationLevel]::Impersonate",
                "$Driver = $wmi.CreateInstance()",
                "$Driver.Name = $DriverName",
                "$Driver.DriverPath = $DriverPath",
                "$Driver.InfName = $DriverInf",
                "$wmi.AddPrinterDriver($Driver)",
                "$wmi.put()",
                "}",


                "foreach ($computer in $ComputerList) {",
                "InstallPrinterDriver -DriverName $DriverName -DriverPath `",
                "$DriverPath -DriverInf $DriverInf -ComputerName $computer",
                    "}",
                };
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\InstallPrintDriver.ps1", cpplines);

                progressBar1.Value = 0;
                ModifyProgressBarColor.SetState(progressBar1, 1);
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    PowerShell.Create().AddScript("Copy-Item -Path " + crntDirParsedWhiteSpace + driverDirectBase + @" -Destination \\" + RemoteComputerClass.computerName + @"\c$\install\Printer -recurse;").AddCommand("Out-String").Invoke<string>();

                    string scriptTextFour = cipparsedWhiteSpace + " " + RemoteComputerClass.computerName + theDriverName + driverDirectBaseInf;
                    label7.Text = "Checking Driver requirements for... " + RemoteComputerClass.computerName;
                    progressBar1.Increment(20);

                    string scriptText = cppparsedWhiteSpace + " " + RemoteComputerClass.computerName + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                    label7.Text = "Creating Printer Port on " + RemoteComputerClass.computerName;
                    textBoxOutput.AppendText("\nCreating Printer Port");
                    progressBar1.Increment(20);
                    textBoxOutput.AppendText(RunScript(scriptText));

                    string scriptTextTwo = ipdparsedWhiteSpace + " " + RemoteComputerClass.computerName + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                    label7.Text = "Installing Printer Driver on " + RemoteComputerClass.computerName;
                    textBoxOutput.AppendText("\nInstalling Printer Driver");
                    progressBar1.Increment(20);
                    textBoxOutput.AppendText(RunScript(scriptTextTwo));

                    string scriptTextThree = cpparsedWhiteSpace + " " + RemoteComputerClass.computerName + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;

                    label7.Text = "Installing Printer on " + RemoteComputerClass.computerName;
                    textBoxOutput.AppendText("\nInstalling Printer");
                    progressBar1.Increment(20);
                    textBoxOutput.AppendText(RunScript(scriptTextThree));
                    label7.Text = "Installing Complete for " + RemoteComputerClass.computerName;
                    textBoxOutput.AppendText("\nInstallation Complete");
                    progressBar1.Increment(20);
                    string createLogPrinter = RemoteComputerClass.computerName + "," + printerCaption + "," + PrinterHost + "," + ": Install Successfull";
                    string loggedThree = LogWorker.logging(RemoteComputerClass.computerName, PrinterHost, printerModelTxtBox.Text, printerCaption, ",Successful");

                    if (checkBox3.Checked == true)
                    {
                        PowerShell.Create().AddScript("Invoke-Command -ComputerName " + RemoteComputerClass.computerName + " -ScriptBlock {(New-Object -ComObject WScript.Network).SetDefaultPrinter(\"" + printerCaption + "\")}").AddCommand("Out-String").Invoke<string>();
                    }
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception error)
                {
                    label7.Text = "Encountered ERROR on : " + RemoteComputerClass.computerName;
                    textBoxOutput.Text += String.Format("\r\nError in script : {0}\r\n", error.Message);
                    // send to log file
                    ModifyProgressBarColor.SetState(progressBar1, 2);
                    string createLogPrinter = RemoteComputerClass.computerName + "," + printerCaption + "," + PrinterHost + "," + String.Format("\r\nError in script : {0}\r\n", error.Message);
                    //string loggedThree = LogWorker.logging(createLogPrinter);
                    string loggedThree = LogWorker.logging(RemoteComputerClass.computerName, PrinterHost, printerModelTxtBox.Text, printerCaption, String.Format(",ERROR\r\nError in script : {0}", error.Message));
                }
            }
            #endregion
            #region local region
            else if (TargetComputerState.localstateCheck == true)
            {
                ModifyProgressBarColor.SetState(progressBar1, 1);
                progressBar1.Value = 0;
                Cursor.Current = Cursors.WaitCursor;
                try
                //RunCommand();
                {

                    string[] cpinstlines = { "param([string[]] $Computer, [string[]] $Printer, [string[]] $driverName, [string[]] $infPath)",

                "Invoke-Command -ComputerName $Computer {cscript C:\\Windows\\System32\\Printing_Admin_Scripts\\en-US\\prndrvr.vbs - a - m \"$driverName\" - i \"$infPath\"}",
                };

                    File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CopyinstDriver.ps1", cpinstlines);

                    string[] cplines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)\n",


                "Function CreatePrinter",

                "{",
                " param ($PrinterCaption, $PrinterPortName, $DriverName, $ComputerName)",
                "$wmi = ([wmiclass]\"\\\\$ComputerName\\Root\\cimv2:Win32_Printer\")",
                "$Printer = $wmi.CreateInstance()",
                "$Printer.Caption = $PrinterCaption",
                "$Printer.DriverName = $DriverName",
                "$Printer.PortName = $PrinterPortName",
                "$Printer.DeviceID = $PrinterCaption",
                "$Printer.put()",
                "}\n",

                "foreach ($computer in $ComputerList) {",
                "CreatePrinter -PrinterPortName $PrinterPortName -DriverName `",
                "$DriverName -PrinterCaption $PrinterCaption -ComputerName $computer",
                "}"
            };
                    File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinter.ps1", cplines);

                    string[] cpplines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)\n",


                "Function CreatePrinterPort",
                        "{",
                "param ($PrinterIP, $PrinterPort, $PrinterPortName, $ComputerName)",
                "$wmi = [wmiclass]\"\\\\$ComputerName\\root\\cimv2:win32_tcpipPrinterPort\"",
                "$wmi.psbase.scope.options.enablePrivileges = $true",
                "$Port = $wmi.createInstance()",
                "$Port.name = $PrinterPortName",
                "$Port.hostAddress = $PrinterIP",
                "$Port.portNumber = $PrinterPort",
                "$Port.SNMPEnabled = $false",
                "$Port.Protocol = 1",
                "$Port.put()",
                "}",

                "foreach ($computer in $ComputerList) {",
                "CreatePrinterPort -PrinterIP $PrinterIP -PrinterPort $PrinterPort `",
                "-PrinterPortName $PrinterPortName -ComputerName $computer",
                    "}",
                };
                    File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\CreatePrinterPort.ps1", cpplines);


                    string[] cpdlines = { "param([string[]] $ComputerList, [string] $PrinterCaption, [string] $PrinterIP, [string] $PrinterPort,[string] $PrinterPortName, [string] $DriverName, [string] $DriverPath, [string] $DriverInf)",


                "Function InstallPrinterDriver",
                        "{",
                "Param ($DriverName, $DriverPath, $DriverInf, $ComputerName)",
                "$wmi = [wmiclass]\"\\\\$ComputerName\\Root\\cimv2:Win32_PrinterDriver\"",
                "$wmi.psbase.scope.options.enablePrivileges = $true",
                "$wmi.psbase.Scope.Options.Impersonation = `",
                "[System.Management.ImpersonationLevel]::Impersonate",
                "$Driver = $wmi.CreateInstance()",
                "$Driver.Name = $DriverName",
                "$Driver.DriverPath = $DriverPath",
                "$Driver.InfName = $DriverInf",
                "$wmi.AddPrinterDriver($Driver)",
                "$wmi.put()",
                "}",


                "foreach ($computer in $ComputerList) {",
                "InstallPrinterDriver -DriverName $DriverName -DriverPath `",
                "$DriverPath -DriverInf $DriverInf -ComputerName $computer",
                    "}",
                };
                    File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"Logs\InstallPrintDriver.ps1", cpplines);

                    PowerShell.Create().AddScript("Copy-Item -Path " + crntDirParsedWhiteSpace + driverDirectBase + @" -Destination \\" + LocalHostClass.localComputer + @"\c$\install\Printer -recurse;").AddCommand("Out-String").Invoke<string>();

                    string scriptTextFour = cipparsedWhiteSpace + " " + LocalHostClass.localComputer + theDriverName + driverDirectBaseInf;
                    label7.Text = "Checking Driver requirements for... " + LocalHostClass.localComputer;
                    progressBar1.Increment(20);

                    string scriptText = cppparsedWhiteSpace + " " + LocalHostClass.localComputer + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                    label7.Text = "Creating Printer Port on " + LocalHostClass.localComputer;
                    textBoxOutput.AppendText("Creating Printer Port");
                    progressBar1.Increment(20);

                    string scriptTextTwo = ipdparsedWhiteSpace + " " + LocalHostClass.localComputer + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                    label7.Text = "Installing Printer Driver on " + LocalHostClass.localComputer;
                    textBoxOutput.AppendText("Installing Printer Driver");
                    progressBar1.Increment(20);

                    string scriptTextThree = cpparsedWhiteSpace + " " + LocalHostClass.localComputer + " " + "\"" + printerCaption + "\"" + " " + PrinterHost + " 9100 p-11397 " + "\"HP Universal Printing PCL 6\" " + crntDirParsedWhiteSpace + driverDirectBase + " " + crntDirParsedWhiteSpace + driverDirectBaseInf;
                    progressBar1.Increment(20);

                    label7.Text = "Installing Printer on " + LocalHostClass.localComputer;
                    label7.Text = "Installing Complete for " + LocalHostClass.localComputer;
                    textBoxOutput.AppendText("Installing Printer");
                    textBoxOutput.AppendText("Installation Complete");

                    textBoxOutput.Text = RunScript(scriptText);
                    textBoxOutput.Text = RunScript(scriptTextTwo);
                    textBoxOutput.Text = RunScript(scriptTextThree);
                    Cursor.Current = Cursors.Default;
                    string loggedThree = LogWorker.logging(LocalHostClass.localComputer, PrinterHost, printerModelTxtBox.Text, printerCaption, "Successful");
                    if (checkBox3.Checked == true)
                    {
                        PowerShell.Create().AddScript("Invoke-Command -ComputerName " + LocalHostClass.localComputer + " -ScriptBlock {(New-Object -ComObject WScript.Network).SetDefaultPrinter(\"" + printerCaption + "\")}").AddCommand("Out-String").Invoke<string>();
                    }
                }
                catch (Exception error)
                {
                    label7.Text = "Encountered ERROR on : " + LocalHostClass.localComputer;
                    textBoxOutput.Text += String.Format("\r\nError in script : {0}\r\n", error.Message);
                    // send to log file
                    ModifyProgressBarColor.SetState(progressBar1, 2);
                    string createLogPrinter = LocalHostClass.localComputer + "," + printerCaption + "," + PrinterHost + "," + String.Format("\r\nError in script : {0}\r\n", error.Message);
                    //  string loggedThree = LogWorker.logging(createLogPrinter);
                    string loggedThree = LogWorker.logging(LocalHostClass.localComputer, PrinterHost, printerModelTxtBox.Text, printerCaption, String.Format(",ERROR\r\nError in script : {0}", error.Message));
                }
            }
            #endregion
        }
        #region Run script
        /// <summary>
        /// Runs the given powershell script and returns the script output.
        /// </summary>
        /// <param name="scriptText">the powershell script text to run</param>
        /// <returns>output of the script</returns>
        private string RunScript(string scriptText)
        {
            // create Powershell runspace and open it
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            pipeline.Commands.Add("Out-String");

            // execute the script and close
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region printer install form load
        private void PrinterInstallForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            if (File.Exists(crntDir + @"Logs\CreatePrinter.ps1"))
            {
                File.Delete(crntDir + @"Logs\CreatePrinter.ps1");
            }
            if (File.Exists(crntDir + @"Logs\CreatePrinterPort.ps1"))
            {
                File.Delete(crntDir + @"Logs\CreatePrinterPort.ps1");
            }
            if (File.Exists(crntDir + @"Logs\InstallPrintDriver.ps1"))
            {
                File.Delete(crntDir + @"Logs\InstallPrintDriver.ps1");
            }
            if (File.Exists(crntDir + @"Logs\CopyinstDriver.ps1"))
            {
                File.Delete(crntDir + @"Logs\CopyinstDriver.ps1");
            }
            if (File.Exists(crntDir + @"Logs\PrinterUninstall.ps1"))
            {
                File.Delete(crntDir + @"Logs\PrinterUninstall.ps1");
            }
            printerModelTxtBox.SelectedIndex = 0;
        }
        #endregion

        #region cancelbtn
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region target toolstrip menu state
        private void groupOfRemoteComputersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupofRemoteComputersForm computerGroupForm = new GroupofRemoteComputersForm();
            computerGroupForm.Show();

    //        ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = true;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = false;
            TargetComputerState.remotestateCheck = false;
            TargetComputerState.groupstateCheck = true;
            
        }

        private void remoteComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteComputerForm remoteForm = new RemoteComputerForm();
            remoteForm.Show();

       //     ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = true;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = false;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = false;
            TargetComputerState.remotestateCheck = true;
            TargetComputerState.groupstateCheck = false;
           
        }

        private void localComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    ((ToolStripMenuItem)localComputerToolStripMenuItem).Checked = true;
            ((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked = false;
            ((ToolStripMenuItem)groupOfRemoteComputersToolStripMenuItem).Checked = false;

            // Sends state of checkboxes to the TargetComputerState class
            TargetComputerState.localstateCheck = true;
            TargetComputerState.remotestateCheck = false;
            TargetComputerState.groupstateCheck = false;
            
        }
        #endregion

        #region Unused region
        private void pnameBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region network printer checkbox
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
                prntHostBox.Text = "";
                prntHostBox.Enabled = true;
            }
        }
        #endregion

        #region usb printer checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                prntHostBox.Text = "USB001";
                prntHostBox.Enabled = false;
            }
        }
        #endregion

        #region progressbarclick
        private void progressBar1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
        }
        #endregion

        #region cancelbtn
        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(3);
        }
        #endregion

        #region checkbox3\default
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion

        #region statuslabel
        private void label7_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region abouttoolstrip
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }
        #endregion

        #region exit tool strip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Printer Uninstall Tool Strip
        private void printerUninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked == false)
            {
                string message = "No computer Selected";
                string caption = "Error Dectected in Target Computer";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else if (((ToolStripMenuItem)remoteComputerToolStripMenuItem).Checked == true && RemoteComputerClass.computerName == "")
            {
                string message = "Remote computer name is empty";
                string caption = "Error Dectected in Target Computer";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                //  Displays the MessageBox
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                PrinterUninstall printerUninstallForm = new PrinterUninstall();
                printerUninstallForm.Show();
            }
        }
        #endregion

        #region printerinstall form loading events

        // To check if a .ps1 file exists... if it does the delete it.
        private void PrinterInstallForm_Load_1(object sender, EventArgs e)
        {
            this.ControlBox = false;
            if (File.Exists(crntDir + @"Logs\CreatePrinter.ps1"))
            {
                File.Delete(crntDir + @"Logs\CreatePrinter.ps1");
            }
            if (File.Exists(crntDir + @"Logs\CreatePrinterPort.ps1"))
            {
                File.Delete(crntDir + @"Logs\CreatePrinterPort.ps1");
            }
            if (File.Exists(crntDir + @"Logs\InstallPrintDriver.ps1"))
            {
                File.Delete(crntDir + @"Logs\InstallPrintDriver.ps1");
            }
            if (File.Exists(crntDir + @"Logs\CopyinstDriver.ps1"))
            {
                File.Delete(crntDir + @"Logs\CopyinstDriver.ps1");
            }
            if (File.Exists(crntDir + @"Logs\PrinterUninstall.ps1"))
            {
                File.Delete(crntDir + @"Logs\PrinterUninstall.ps1");
            }

        }
        #endregion
    }
}