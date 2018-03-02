using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSW_Tool_Kit
{
    public partial class GroupofRemoteComputersForm : Form
    {
        public GroupofRemoteComputersForm()
        {
            InitializeComponent();
        }
        private void GroupofRemoteComputersForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string fileLoc in filePaths)
                {
                    if (File.Exists(fileLoc))
                    {
                        string line;
                        var file = new System.IO.StreamReader(fileLoc);
                        while ((line = file.ReadLine()) != null)
                        {
                            listBox1.Items.Add(line);
                        }
                    }
                }
            }
        }
        private void GroupofRemoteComputersForm_DragEnter(object sender, DragEventArgs e)
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
        private void addBtn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            var myList = string.Join(",", listBox1.Items.Cast<string>());
            GroupofRemoteComputersClass.computerNames = myList;
            this.Close();
        }

        private void GroupofRemoteComputersForm_Load(object sender, EventArgs e)
        {

            if (GroupofRemoteComputersClass.computerNames != null) { 
                List<string> groupComputers = GroupofRemoteComputersClass.computerNames.Split(',').ToList();

                foreach (var computer in groupComputers)
                {
                    listBox1.Items.Add(computer);
                }
            }

            this.AcceptButton = addBtn;
            this.AllowDrop = true;
            this.DragEnter += GroupofRemoteComputersForm_DragEnter;
            this.DragDrop += GroupofRemoteComputersForm_DragDrop;
        }
    }
}
