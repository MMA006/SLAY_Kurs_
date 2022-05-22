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
    public partial class Form4 : Form
    {
        

        public Form4()
        {
            InitializeComponent();
        }
        public Form4(Form1 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
        }
        public Form4(Form2 f)
        {
            InitializeComponent();
            f.BackColor = Color.White;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        
    }
}
