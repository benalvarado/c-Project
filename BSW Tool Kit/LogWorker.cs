using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;



namespace BSW_Tool_Kit
{
    class LogWorker
    {

            public static string logging(string computerName, string printerHostName, string printerModel, string printerName, string errorLog)
            {
            //declare variables
            string cpu = computerName;
            string prntHostName = printerHostName;
            string prntModel = printerModel;
            string prntName = printerName;
            string erLog = errorLog;
            DateTime dt = new DateTime();
           

            StreamWriter writer = null;
            StringBuilder strBuilder = null;
            string dir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
            string strFileName = "LogFile";
            //check if the folder exists
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                string paths = Path.Combine(dir, strFileName + ".log");
                strBuilder = new StringBuilder("--- Printer ");
                strBuilder.Append("Logs ---");
                writer = new StreamWriter(paths, true);
                writer.Write(strBuilder);
                writer.Close();
            }
            // write to log file
            string path = Path.Combine(dir, strFileName + ".log");
            strBuilder = new StringBuilder("\r\nLog : ");
            strBuilder.Append(computerName + ",");
            strBuilder.Append(printerHostName + "," + printerModel + "," + printerName + String.Format(",{0:yyyy/MMM/dd h:mmtt,}", DateTime.Now.ToString()) + "\n" + errorLog);
            writer = new StreamWriter(path, true);
            writer.Write(strBuilder);
            writer.Close();
            return null;
            }
    }
}