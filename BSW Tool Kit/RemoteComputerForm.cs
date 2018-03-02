using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSW_Tool_Kit
{
    public partial class RemoteComputerForm : Form
    {
        
        public RemoteComputerForm()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            RemoteComputerClass.computerName = textBox1.Text;
            this.Close();
        }

        private void RemoteComputerForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = RemoteComputerClass.computerName;
        }
    }
}
