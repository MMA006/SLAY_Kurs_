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
using ExcelDataReader;
using System.IO;
using System.Drawing.Printing;

namespace SLAY_Kurs_
{
    public partial class Form2 : Form
    {
        private string filename=string.Empty;
        private DataTableCollection tableCollection = null;

        int[,] A = new int[Class1.n,Class1.n]; //массив а
        int[] B = new int[Class1.n];//массив б
        double [] X= new double[Class1.n];//массив нулевых значений
        
        Random random= new Random();
        
        public Form2(Form1 f)
        {
            InitializeComponent();

        }
        public void SLAY()
        {
       //     try
       //     {
       //         ZEIDEL zeidel = new ZEIDEL(A, B, Class1.n, X);
       //         bool IsDiagonal = zeidel.Diagonali();
       //         if (IsDiagonal == true)
       //         {
       //             textBox2.Text += Environment.NewLine + "В матрице А есть диагогальное перобладание \n\t";
       //         }
       //         else
       //         {
       //             textBox2.Text += Environment.NewLine + "В матрице А нет диагонального преобладния \n\t";
       //             if (MessageBox.Show("В матрице А нет диагонального преобладния, решение может быть не найдено или будет найдено с ошибкой!\n\t", "выйти  ",
       //MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
       //             {
       //                 Environment.Exit(1);
       //             }

       //         }
       //         textBox2.Text += Environment.NewLine+"Нулевое приближение";
               
                
       //             for (int i = 0; i < Class1.n; i++)
       //             {
       //                 X[i] = 0;
       //             textBox2.Text += Environment.NewLine+"Xo" + "=" + X[i] + "";
       //         }

                
       //         zeidel.RESHENIE();
       //         for (int j = 0; j < Class1.n; j++)
       //         {

       //                 textBox3.Text += Environment.NewLine + "X" + (j + 1) + "=" + zeidel.korni[j];
                    
       //         }
       //         textBox2.Text += (Environment.NewLine + "Количество итераций:" + zeidel.k + "");

       //     }
       //     catch (Exception ex)
       //     {
       //         MessageBox.Show(ex.Message);
       //     }
        }
        public void KLAVIATERA()
        {
            //try
            //{
            //    int i, j;
            //    for (i = 0; i < Class1.n; i++)
            //    {
            //        for (j = 0; j < Class1.n; j++)
            //        {
            //            A[i, j] = Convert.ToInt32(dataGridView1[j,i].Value);
            //        }

            //    }
            //    for (i = 0; i < Class1.n; i++)
            //    {
            //        B[i] = Convert.ToInt32(dataGridView2[0, i].Value);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void Highlight()//выделение
        {
            try
            {
                if (dataGridView1.Rows != null && dataGridView1.Columns != null)

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            if (i == j) { dataGridView1[i, j].Style.BackColor = Color.Red; }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       // public void RANDOM()
        //{
        //    try
        //    {
        //        int i, j;
        //        for (i = 0; i < Class1.n; i++)
        //        {
        //            for (j = 0; j < Class1.n; j++)
        //            {
        //                dataGridView1[j,i].Value = random.Next(1, 10);
        //                A[i, j] = Convert.ToInt32(dataGridView1[j,i].Value);
        //            }

        //        }

        //        for (i = 0; i < Class1.n; ++i)
        //        {
        //            dataGridView2[0, i].Value = random.Next(1, 10);
        //            B[i] = Convert.ToInt32(dataGridView2[0, i].Value);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}
       private void Form2_Load(object sender, EventArgs e)
        {
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            

            Highlight();
            try
            {
                int i, j;
                for (i = 0; i < Class1.n; i++)
                {
                    for (j = 0; j < Class1.n; j++)
                    {
                        A[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
                    }
                }
                for (i = 0; i < Class1.n; i++)
                {
                    B[i] = Convert.ToInt32(dataGridView2[0, i].Value);
                }

                ZEIDEL zeidel = new ZEIDEL(A, B, Class1.n, X);
                bool IsDiagonal = zeidel.Diagonali();
                if (IsDiagonal == true)
                {
                    textBox2.Text += Environment.NewLine + "В матрице А есть диагогальное перобладание \n\t";
                }
                else
                {
                    textBox2.Text += Environment.NewLine + "В матрице А нет диагонального преобладния \n\t";
                    if (MessageBox.Show("В матрице А нет диагонального преобладния, решение может быть не найдено или будет найдено с ошибкой!\n\tПРОДОЛЖИТЬ?\n\t", "ПРОДОЛЖИТЬ? ",
       MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                    {
                        if (MessageBox.Show("Вы уверены ,что не хотите продолжить работу дальше ?", "Выйти?",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            Environment.Exit(1);
                    }

                }
                textBox2.Text += Environment.NewLine + "Нулевое приближение";


                for (int m = 0; m < Class1.n; m++)
                {
                    X[m] = 0;
                    textBox2.Text += Environment.NewLine + "Xo" + "=" + X[m] + "";
                }
                zeidel.RESHENIE();
                textBox2.Text += Environment.NewLine + "Ответы:";
                for (int w = 0; w < Class1.n; w++)
                {

                    textBox2.Text += Environment.NewLine + "X" + (w + 1) + "=" + zeidel.korni[w];

                }
                textBox2.Text += (Environment.NewLine + "Количество итераций:" + zeidel.k + "");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (radioButton2.Enabled == true)
            {
                
                SLAY();
                Highlight();


            }
              
                
        }
                        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
              
                dataGridView1.AllowUserToAddRows = false;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView1.RowCount = Class1.n;
                dataGridView1.ColumnCount = Class1.n;

                dataGridView2.RowCount = Class1.n;
                dataGridView2.ColumnCount = 1;

                dataGridView1.ColumnHeadersHeight = 150;
                dataGridView2.Columns[0].HeaderCell.Value = "b";

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int k = i + 1;
                    dataGridView1.Rows[i].HeaderCell.Value = "" + k;
                    dataGridView1.Columns[i].HeaderCell.Value = "x." + k;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (dataGridView1.Rows != null) ;
                if (dataGridView2.Rows != null) ;
            }

            catch
            {
                if (MessageBox.Show("количесвто уравнений не указано", "выйти ",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }

            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = DBNull.Value;
                }
            }
            if (radioButton2.Checked == true)
            {
                radioButton1.Enabled = false;
                dataGridView1.ReadOnly = false;
                dataGridView2.ReadOnly = false;

                int i, j;
                for (i = 0; i < Class1.n; i++)
                {
                    for (j = 0; j < Class1.n; j++)
                    {
                        dataGridView1[j, i].Value = random.Next(1, 10);
                        A[i, j] = Convert.ToInt32(dataGridView1[j, i].Value);
                    }

                }

                for (i = 0; i < Class1.n; ++i)
                {
                    dataGridView2[0, i].Value = random.Next(1, 10);
                    B[i] = Convert.ToInt32(dataGridView2[0, i].Value);

                }

            }
            


            
        }
      
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из программы?", "Выход",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {//закрыть
                //Dispose();
                if (MessageBox.Show("Сохранить значения?", "",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = saveFileDialog1.FileName;
                    System.IO.File.WriteAllText(filename, textBox2.Text);
                    MessageBox.Show("Файл сохранен");
                    Environment.Exit(1);
                }
                else
                {
                    Environment.Exit(1);
                }

                  
            }
        }


        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

           TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '-')) )
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    //        if (MessageBox.Show("Неверный формат ввода\n\tНеобходимо исправить!", "Продолжить ?",
                    //MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    //        {//закрыть
                    //         //Dispose();
                    //            Environment.Exit(1);
                    //        }
                    string message = "Неверный формат ввода";
                    string title = "внимание";
                    MessageBox.Show(message, title);
                    e.Handled = true;
                }
            }
    
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
                radioButton2.Enabled = false;
                //dataGridView1.ReadOnly = false;
                //dataGridView2.ReadOnly = false;
            try
            {
                
                dataGridView1.AllowUserToAddRows = false;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView1.RowCount = Class1.n;
                dataGridView1.ColumnCount = Class1.n;

                dataGridView2.RowCount = Class1.n;
                dataGridView2.ColumnCount = 1;

                dataGridView1.ColumnHeadersHeight = 150;
                dataGridView2.Columns[0].HeaderCell.Value = "b";

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int k = i + 1;
                    dataGridView1.Rows[i].HeaderCell.Value = "" + k;
                    dataGridView1.Columns[i].HeaderCell.Value = "x." + k;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                if (dataGridView1.Rows != null) ;
                if (dataGridView2.Rows != null) ;
            }

            catch
            {
                if (MessageBox.Show("количесвто уравнений не указано", "выйти ",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Environment.Exit(1);
                }

            }



        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form4 об_Авторе = new Form4(this);
            об_Авторе.ShowDialog();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сохранить значения?", "",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(filename, textBox2.Text);
                MessageBox.Show("Файл сохранен");
                //Environment.Exit(1);
            }
            //else
            //{
            //    Environment.Exit(1);
            //}
        }
        

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();

            ProcessStartInfo startInfo = new ProcessStartInfo();

            process.StartInfo = startInfo;

            startInfo.FileName = @"C:\Users\nabyn\source\repos\SLAY_Kurs_\Файл-справка.pdf";
            process.Start();

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
       

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }
        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
         
        }

        private void открытьМатрицуАToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                ofd.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;'";

            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            con.Open();
            DataSet ds = new DataSet();
            DataTable schemaTable = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(select, con);
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            // DataTable dt2 = ds2.Tables[0];
            con.Close();
            con.Dispose();
            dataGridView1.DataSource = dt;
            //  dataGridView2.DataSource = dt2;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;

        }

        private void открытьМатрицуBToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.xls;*.xlsx";
            ofd.Filter = "Microsoft Excel (*.xls*)|*.xls*";
            ofd.Title = "Выберите документ для загрузки данных";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Вы не выбрали файл для открытия", "Загрузка данных...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                ofd.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;IMEX=1';";

            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            con.Open();
            DataSet ds = new DataSet();
            DataTable schemaTable = con.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            System.Data.OleDb.OleDbDataAdapter ad = new System.Data.OleDb.OleDbDataAdapter(select, con);
            ad.Fill(ds);
            DataTable dt = ds.Tables[0];
            // DataTable dt2 = ds2.Tables[0];
            con.Close();
            con.Dispose();
            dataGridView2.DataSource = dt;
            //  dataGridView2.DataSource = dt2;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
        }
    }
}
    


