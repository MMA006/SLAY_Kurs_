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
    public partial class Form5 : Form
    {
        public Form5(Form2 f)
        {
            InitializeComponent();
        }
        public Form5(Form1 f)
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            Process process = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();

            process.StartInfo = startInfo;

            startInfo.FileName = @"C:\Users\nabyn\source\repos\SLAY_Kurs_\Файл-справка.pdf";
            process.Start();

        }

    }
}
