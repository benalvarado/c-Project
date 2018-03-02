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
    public partial class MassExecuteForme : Form
    {
        public MassExecuteForme()
        {
            InitializeComponent();
        }

        private void MassExecuteForme_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void executeBtn_Click(object sender, EventArgs e)
        {            
            List<string> computerList = GroupofRemoteComputersClass.computerNames.Split(',').ToList();

            foreach (var result in computerList)
            {
                richTextBox1.AppendText(result);
                richTextBox1.AppendText("psexec -s -i \\\\" + result + " " + executeTxtBox.Text);

                foreach (string str in PowerShell.Create().AddScript("psexec -s -i \\\\" + result + " " + executeTxtBox.Text).AddCommand("Out-String").Invoke<string>())
                    richTextBox1.AppendText(str);
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
