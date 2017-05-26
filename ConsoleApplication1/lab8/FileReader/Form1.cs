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

namespace FileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = "";
                string fileName = openFileDialog1.FileName;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        richTextBox1.Text += line + "\n";
                    }                    
                }
            }
            
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
                {
                    sw.WriteLine(richTextBox1.Text);
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            richTextBox1.Width = Width;
            richTextBox1.Height = Height;
        }
    }
}
