using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLAY_Kurs_
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();

            toolStripStatusLabel1.Text = string.Format("текущие дата и время :" + "{0:F}", DateTime.Now);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Class1.eps = 0.1;

                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        Class1.eps = 0.1;
                        break;
                    case 1:
                        Class1.eps = 0.01;
                        break;
                    case 2:
                        Class1.eps = 0.001;
                        break;
                    case 3:
                        Class1.eps = 0.0001;
                        break;
                    case 4:
                        Class1.eps = 0.00001;
                        break;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           // textBox2.Text = textBox2.Text.Replace(".", ",");
            try
            {
                Class1.n = Convert.ToInt32(numericUpDown1.Value);
               
            }
            catch
            {

                if (MessageBox.Show("количесвто уравнений не указано", "выйти ",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }
            }
            try
            {
                double a = 0.1;
                double b = 0;
                
                //Class1.eps = Convert.ToDouble(textBox2.Text);

                if (Class1.eps <= a && Class1.eps!=b)
                {
                    Hide();
                    Form2 dalee = new Form2(this);
                    // dalee.numericUpDown1.Value=numericUpDown1.Value ;
                    dalee.Owner = (this);
                    dalee.ShowDialog();
                    this.Show();
                }
                else
                {
                    if (MessageBox.Show("Точность введена неверно", "ВЫЙТИ?",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Environment.Exit(1);
                    }
                }
            }
            catch
            {
                if (MessageBox.Show("Точность не указана, либо введена неверно", "ВЫЙТИ?",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.* ";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string date = DateTime.Now.ToLongDateString();
            string time = DateTime.Now.ToLongTimeString();


        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //    if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',')) && !((e.KeyChar == '.')))
            //    {
            //        textBox2.Text = textBox2.Text.Replace(",", ".");
            //        if (e.KeyChar != (char)Keys.Back)
            //        {
            //            if (MessageBox.Show("Неверный формат ввода\n\tНеобходимо исправить", "Продолжить?",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //            {//закрыть
            //             //Dispose();
            //                Environment.Exit(1);
            //            }

            //            e.Handled = true;
            //        }
        }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {
          
            }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 об_Авторе = new Form4(this);
            об_Авторе.ShowDialog();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы, уверены, что хотите завершить работу!", "Выход",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void свойстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();

            process.StartInfo = startInfo;

            startInfo.FileName = @"C:\Users\nabyn\source\repos\SLAY_Kurs_\Файл-справка.pdf";
            process.Start();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }