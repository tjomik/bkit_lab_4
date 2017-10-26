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
using System.Diagnostics;

namespace LAB_4
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "openFileDialog1")
            {
                MessageBox.Show("Выберете файл");
            }
            else
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                ReadingFile(openFileDialog1.FileName);
                timer.Stop();

                TimeSpan time = timer.Elapsed;

                string elapsedTime = String.Format("{0:00}.{1:00}",time.Seconds, time.Milliseconds);
                label2.Text = elapsedTime+" Seconds";
            }
        }
        public List<string> ReadingFile(string fileName)
        {
            File.OpenRead(fileName);
            string text = File.ReadAllText(fileName);
            List<string> textByWords = new List<string>();

            string[] words = text.Split(' ', '.', ',', '?' , '!', ':', ';' );
            foreach (string temp in words)
            {
                if (textByWords.Contains(temp)) continue;
                textByWords.Add(temp);
            }
            return textByWords;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Текстовые файлы|*.txt";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            List<string> textByWords = ReadingFile(openFileDialog1.FileName);
            if (textByWords.Contains(textBox2.Text))
            {
                MessageBox.Show("Текст содержит слово: " + textBox2.Text);
                listBox1.Items.Add(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Текст не содержит слово: " + textBox2.Text);
            }
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsedTime = String.Format("{0:00}.{1:00}", time.Seconds, time.Milliseconds);
            label3.Text = elapsedTime + " Seconds";
        }
    }
}
