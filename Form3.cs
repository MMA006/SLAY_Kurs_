using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLAY_Kurs_
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
      /*  public Form3(Form2 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
            this.Load += Form3_Load;
        }*/
        private void Form3_Load(object sender, EventArgs e)
        {
           // listBox1.Text =Convert.ToString (Class1.data1);
          //  listBox1.Text = Convert.ToString(Class1.data2);
        }

        void OrderFormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Выход",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {//закрыть
                //Dispose();
                Environment.Exit(1);
            }
            else
            {
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
