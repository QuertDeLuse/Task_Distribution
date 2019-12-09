using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static CourseProject.dbData;

namespace CourseProject
{
    public partial class History : Form
    {
        List<CompleteProcess> completeProceses = new List<CompleteProcess>();

        public History()
        {
            InitializeComponent();
            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void History_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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


        void update()
        {
            completeProceses = dbData.CompleteProcessesManager.GetCompleteProcesses();

            for (int i = 0; i < completeProceses.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = completeProceses[i].processID;
                dataGridView1.Rows[i].Cells[1].Value = completeProceses[i].taskID;
                dataGridView1.Rows[i].Cells[2].Value = completeProceses[i].taskName;
                dataGridView1.Rows[i].Cells[3].Value = completeProceses[i].taskImportance;
                dataGridView1.Rows[i].Cells[4].Value = completeProceses[i].taskUrgency;
                dataGridView1.Rows[i].Cells[5].Value = completeProceses[i].executorID;
                dataGridView1.Rows[i].Cells[6].Value = completeProceses[i].executorNickname;
                dataGridView1.Rows[i].Cells[7].Value = completeProceses[i].executorQualification;
                dataGridView1.Rows[i].Cells[8].Value = completeProceses[i].ExecutorRating;
            }
        }

        //Update
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            update();
        }

        //Delete One
        private void button6_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2) || (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count < 2))
            {
                try
                {
                    var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    var processID = dataGridView1.Rows[rowIndex].Cells[0].Value;

                    dbData.Select("DELETE FROM [dbo].[CompleteProcesses] WHERE processID = '" + processID + "'");

                    dataGridView1.Rows.Clear();
                    update();

                    MessageBox.Show("Удаление прошло успешно!");
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }

            }
            else
            {
                MessageBox.Show("Нужно выбрать одну строку в таблице или одну ячейку таблицы!");
            }
        }

        //Delete All
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dbData.Select("DELETE FROM [dbo].[CompleteProcesses]");

                dataGridView1.Rows.Clear();
                update();

                MessageBox.Show("Удаление прошло успешно!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
        }
    }
}
