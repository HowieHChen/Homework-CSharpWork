using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Homework5
{
    public partial class Form1 : Form
    {
        string fileContents = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileName = Path.GetFileName(filePath);
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContents = string.Empty;
                        fileContents += reader.ReadToEnd();
                    }
                    label1.Text = fileName;
                }
            }
            MessageBox.Show("The selected file is located at " + filePath, "Done", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Environment.CurrentDirectory;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileName = Path.GetFileName(filePath);
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContents += reader.ReadToEnd();
                    }
                    label2.Text = fileName;
                }
            }
            MessageBox.Show("The selected file is located at " + filePath, "Done", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dirPath = "Data";
            string filePath = "\\output.txt";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            using (StreamWriter writer = new StreamWriter(dirPath + filePath, false)) 
            {
                writer.Write(fileContents);
            }
            string absolutePath = System.Environment.CurrentDirectory + "\\" +dirPath + filePath;
            MessageBox.Show("File saved to " + absolutePath, "Done", MessageBoxButtons.OK);
        }
    }
}
