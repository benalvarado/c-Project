using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace BSW_Tool_Kit
{
    class ReadPrinterNamestoList
    {
        //public static string HostWorker(List<string> hostingList)
        public static List<string> hostingList()
        {
            string f = AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterList.log";

            List<string> lines = new List<string>();
            List<string> newlines = new List<string>();

            using (StreamReader r = new StreamReader(f))
            {
                string line;
                //&& line != ""
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            foreach (string s in lines)
            {
                 if (TargetComputerState.remotestateCheck == true)
                {
                    foreach (string str in PowerShell.Create().AddScript("gwmi win32_printer -ComputerName " + RemoteComputerClass.computerName + " | %{ $printer = $_.Name; $port = $_.portname; gwmi win32_tcpipprinterport -computername " + RemoteComputerClass.computerName + " | where { $_.Name - eq $port } | select @{name=\"printername\"; expression={$printer}}, hostaddress }").AddCommand("Out-String").Invoke<string>())
                    {
                        newlines.Add(str);
                    }
                }
                else if (TargetComputerState.localstateCheck == true)
                {
                    foreach (string str in PowerShell.Create().AddScript("gwmi win32_printer -ComputerName " + "sw1409-14536" + " | %{ $printer = $_.Name; $port = $_.portname; gwmi win32_tcpipprinterport -computername " + "sw1409-14536" + " | where { $_.Name - eq $port } | select @{ name = \"printername\"; expression={$printer} }, hostaddress }").AddCommand("Out-String").Invoke<string>())
                    {
                        newlines.Add(str);
                    }
                }
            }
           
            return newlines;
        }
    }
}

