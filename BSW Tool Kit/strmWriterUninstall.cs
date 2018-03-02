using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSW_Tool_Kit
{
    class strmWriterUninstall
    {
        public static string prntlst(string str)
        {
            //declare variables
            string printerList = str;
           
            StreamWriter writer = null;
            StringBuilder strBuilder = null;
            string dir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
            string strFileName = "PrinterList";
            //check if the folder exists
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                string paths = Path.Combine(dir, strFileName + ".log");
                strBuilder = new StringBuilder("--- Printer ");
                strBuilder.Append("List ---");
                writer = new StreamWriter(paths, true);
                writer.Write(strBuilder);
                writer.Close();
            }

            string path = Path.Combine(dir, strFileName + ".log");
            strBuilder = new StringBuilder("\r\n");
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterList.log", string.Empty);
            strBuilder.Append(str);
            //   strBuilder.Append(str);
            writer = new StreamWriter(path, true);
            writer.Write(strBuilder);
            writer.Close();

            string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory +@"Logs\PrinterList.log");
            text = text.Replace("Name : ", "");
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterList.log", text);
          //  var myFile = File.Create(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterList.log");
         //   myFile.Close();
            //  (AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterList.log")

            return null;
        }

        public static string prntPortlst(string str)
        {
            //declare variables
            string printerList = str;

            StreamWriter writer = null;
            StringBuilder strBuilder = null;
            string dir = AppDomain.CurrentDomain.BaseDirectory + "Logs";
            string strFileName = "PrinterHostList";
            //check if the folder exists
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
                string paths = Path.Combine(dir, strFileName + ".log");
                strBuilder = new StringBuilder("--- Printer Host ");
                strBuilder.Append("List ---");
                writer = new StreamWriter(paths, true);
                writer.Write(strBuilder);
                writer.Close();
            }

            string path = Path.Combine(dir, strFileName + ".log");
            strBuilder = new StringBuilder("\r\n");
            strBuilder.Append(str);
            //   strBuilder.Append(str);
            writer = new StreamWriter(path, true);
            writer.Write(strBuilder);
            writer.Close();

            string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterHostList.log");
            text = text.Replace("HostAddress : ", "");
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"Logs\PrinterHostList.log", text);

            return null;
        }
    }
}
