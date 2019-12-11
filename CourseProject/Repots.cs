using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClosedXML.Excel;

namespace CourseProject
{
    public partial class Repots : Form
    {
        public Repots()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Processes processesForm = new Processes();
            this.Hide();
            processesForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tasks tasksForm = new Tasks();
            this.Hide();
            tasksForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Executors executorsForm = new Executors();
            this.Hide();
            executorsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            History historyForm = new History();
            this.Hide();
            historyForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Repots_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Process Report
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                XLWorkbook wb = new XLWorkbook();
                DataTable dt = dbData.Select("SELECT * FROM [dbo].[Processes]");
                wb.Worksheets.Add(dt, "Processes");
                wb.SaveAs("Processes.xlsx");

                MessageBox.Show("Отчет успешно сформирован!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
            
        }

        //Complete Process Report
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                XLWorkbook wb = new XLWorkbook();
                DataTable dt = dbData.Select("SELECT * FROM [dbo].[CompleteProcesses]");
                wb.Worksheets.Add(dt, "CompleteProcesses");
                wb.SaveAs("CompleteProcesses.xlsx");

                MessageBox.Show("Отчет успешно сформирован!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        //Tasks Report
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                XLWorkbook wb = new XLWorkbook();
                DataTable dt = dbData.Select("SELECT * FROM [dbo].[Tasks]");
                wb.Worksheets.Add(dt, "Tasks");
                wb.SaveAs("Tasks.xlsx");

                MessageBox.Show("Отчет успешно сформирован!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }

        //Executors Report
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                XLWorkbook wb = new XLWorkbook();
                DataTable dt = dbData.Select("SELECT * FROM [dbo].[Executors]");
                wb.Worksheets.Add(dt, "Executors");
                wb.SaveAs("Executors.xlsx");

                MessageBox.Show("Отчет успешно сформирован!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }
    }
}
