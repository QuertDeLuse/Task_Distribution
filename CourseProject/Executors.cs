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
    public partial class Executors : Form
    {
        List<Executor> executors = new List<Executor>();

        public Executors()
        {
            InitializeComponent();
            update();
        }

        //Exit
        private void Executors_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Update
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            update();
        }

        void update()
        {
            executors = dbData.ExecutorManager.GetExecutors();

            for (int i = 0; i < executors.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = executors[i].executorID;
                dataGridView1.Rows[i].Cells[1].Value = executors[i].nickName;
                dataGridView1.Rows[i].Cells[2].Value = executors[i].firstName;
                dataGridView1.Rows[i].Cells[3].Value = executors[i].secondName;
                dataGridView1.Rows[i].Cells[4].Value = executors[i].fathersName;
                dataGridView1.Rows[i].Cells[5].Value = executors[i].qualification;
                dataGridView1.Rows[i].Cells[6].Value = executors[i].specialization;
                dataGridView1.Rows[i].Cells[7].Value = executors[i].rating;
                dataGridView1.Rows[i].Cells[8].Value = executors[i].phoneNumber;
                dataGridView1.Rows[i].Cells[9].Value = executors[i].email;
            }
        }

        private void Executors_Activated(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            update();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            addExecutor addExecutorForm = new addExecutor();
            addExecutorForm.ShowDialog();
        }

        //Open Tasks
        private void button2_Click(object sender, EventArgs e)
        {
            Tasks tasksForm = new Tasks();
            this.Hide();
            tasksForm.Show();
        }

        //Open Process
        private void button1_Click(object sender, EventArgs e)
        {
            Processes processesForm = new Processes();
            this.Hide();
            processesForm.Show();
        }

        //Delete One
        private void button6_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2) || (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count < 2))
            {
                try
                {
                    var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    var executorID = dataGridView1.Rows[rowIndex].Cells[0].Value;

                    dbData.Select("DELETE FROM [dbo].[Executors] WHERE executorID = '" + executorID + "'");

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
                dbData.Select("DELETE FROM [dbo].[Executors]");

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
