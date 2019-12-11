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
    public partial class Tasks : Form
    {
        List<Taskq> tasks = new List<Taskq>();

        public Tasks()
        {
            InitializeComponent();
            update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tasks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Open Processes
        private void button1_Click(object sender, EventArgs e)
        {            
            Processes processesForm = new Processes();
            this.Hide();
            processesForm.Show();            
        }

        //Add new task
        private void button9_Click(object sender, EventArgs e)
        {
            addTask addTaskForm = new addTask();
            addTaskForm.ShowDialog();
        }

        //Update
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            update();
        }

        void update()
        {
            tasks = dbData.TaskqManager.GetTasks();

            for (int i = 0; i < tasks.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = tasks[i].taskID;
                dataGridView1.Rows[i].Cells[1].Value = tasks[i].miniDescr;
                dataGridView1.Rows[i].Cells[2].Value = tasks[i].fullDescr;
                dataGridView1.Rows[i].Cells[3].Value = tasks[i].urgency;
                dataGridView1.Rows[i].Cells[4].Value = tasks[i].importance;
                dataGridView1.Rows[i].Cells[5].Value = tasks[i].complexity;
            }
        }

        //Delete one
        private void button6_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2) || (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count < 2))
            {
                try
                {
                    var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    var taskID = dataGridView1.Rows[rowIndex].Cells[0].Value;

                    dbData.Select("DELETE FROM [dbo].[Tasks] WHERE taskID = '" + taskID + "'");

                    dataGridView1.Rows.Clear();
                    update();

                    MessageBox.Show("Удаление прошло успешно!");
                }
                catch
                {
                    MessageBox.Show("Невозможно удалить задание, если оно где-то уже использовано!");
                }

            }
            else
            {
                MessageBox.Show("Нужно выбрать одну строку в таблице или одну ячейку таблицы!");
            }
        }

        //Delete all
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dbData.Select("DELETE FROM [dbo].[Tasks]");

                dataGridView1.Rows.Clear();
                update();

                MessageBox.Show("Удаление прошло успешно!");
            }
            catch
            {
                MessageBox.Show("Невозможно удалить все задания, если хотя бы одно где-то уже использовано!");
            }
        }

        private void Tasks_Activated(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            update();
        }

        //Open Executors
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

        private void button11_Click(object sender, EventArgs e)
        {
            Repots repotsForm = new Repots();
            this.Hide();
            repotsForm.Show();
        }
    }
}
