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
    public partial class MassCopyForm : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();

        public MassCopyForm()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            ofd.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (ofd.InitialDirectory != null)
            {
                // Open document 
                string filename = ofd.FileName;
                listBox1.Items.Add(filename);
            }
        }

        private void MassCopyForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = copyBtn;
            this.AllowDrop = true;
            this.DragEnter += MassCopyForm_DragEnter;
            this.DragDrop += MassCopyForm_DragDrop;
        }
        private void MassCopyForm_DragDrop(object sender, DragEventArgs e)
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
                            listBox1.Items.Add(fileLoc);
                        }
                    }
                }
            }
        }
        private void MassCopyForm_DragEnter(object sender, DragEventArgs e)
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

        private void removeBtn_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }
    }
}
