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
    public partial class Processes : Form
    {
        List<Process> processes = new List<Process>();

        public Processes()
        {
            InitializeComponent();
            update();
        }

        //Update
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            update();
        }

        //Add One
        private void button9_Click(object sender, EventArgs e)
        {
            addProcess addProcessForm = new addProcess(processes);
            addProcessForm.ShowDialog();
        }


        

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Delete
        private void button6_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2) || (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count < 2))
            {
                try
                {
                    var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    var processID = dataGridView1.Rows[rowIndex].Cells[0].Value;

                    dbData.Select("DELETE FROM [dbo].[Processes] WHERE processID = '" + processID + "'");

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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dbData.Select("DELETE FROM [dbo].[Processes]");

                dataGridView1.Rows.Clear();
                update();

                MessageBox.Show("Удаление прошло успешно!");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
            }
            
        }

        private void Processes_Activated(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            update();
        }


        void update()
        {      
            processes = dbData.ProcessManager.GetProcesses();

            for (int i = 0; i < processes.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = processes[i].processID;
                dataGridView1.Rows[i].Cells[1].Value = processes[i].taskID;
                dataGridView1.Rows[i].Cells[2].Value = processes[i].taskName;
                dataGridView1.Rows[i].Cells[3].Value = processes[i].taskImportance;
                dataGridView1.Rows[i].Cells[4].Value = processes[i].taskUrgency;
                dataGridView1.Rows[i].Cells[5].Value = processes[i].executorID;
                dataGridView1.Rows[i].Cells[6].Value = processes[i].executorNickname;
                dataGridView1.Rows[i].Cells[7].Value = processes[i].executorQualification;
                dataGridView1.Rows[i].Cells[8].Value = processes[i].ExecutorRating;
            }
        }

        
    }    
}
