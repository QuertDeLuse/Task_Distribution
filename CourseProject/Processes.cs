﻿using System;
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
        //bool isLogin = false;

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

        //Delete One
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

        //Delete all
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

        private void button2_Click(object sender, EventArgs e)
        {
            Tasks tasksForm = new Tasks();
            this.Hide();
            tasksForm.Show();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Executors executors = new Executors();
            this.Hide();
            executors.Show();
        }

        //Match as a complete
        private void button10_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedRows.Count < 2) || (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells.Count < 2))
            {
                try
                {
                    var rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    var processID = dataGridView1.Rows[rowIndex].Cells[0].Value;

                    DataTable process = dbData.Select("SELECT * FROM [dbo].[Processes] WHERE processID = '" + processID + "'");

                    dbData.Select("INSERT INTO [dbo].[CompleteProcesses] VALUES (" +
                    "'" + process.Rows[0][1] + "'," +
                    "'" + process.Rows[0][2] + "'," +
                    "'" + process.Rows[0][3] + "'," +
                    "'" + process.Rows[0][4] + "'," +

                    "'" + process.Rows[0][5] + "'," +
                    "'" + process.Rows[0][6] + "'," +
                    "'" + process.Rows[0][7] + "'," +
                    "'" + process.Rows[0][8] + "')");


                    dbData.Select("DELETE FROM [dbo].[Processes] WHERE processID = '" + processID + "'");

                    dbData.Select("DELETE FROM [dbo].[Tasks] WHERE taskID = '" + process.Rows[0][1] + "'");


                    dataGridView1.Rows.Clear();
                    update();

                    MessageBox.Show("Процесс успешно отмечен как выполненный!");
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

        private void Processes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        //Auth
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    DataTable dt = dbData.Select("SELECT * FROM [dbo].[Users] WHERE login = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'");

                    if (dt.Rows.Count != 0)
                    {                        
                        dbData.isLogin = true;
                        auth.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль!");
                    }
                 }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            } 
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        //Reg
        private void button13_Click(object sender, EventArgs e)
        {
            Reg regForm = new Reg();
            regForm.ShowDialog();
        }
               

        private void Processes_Shown(object sender, EventArgs e)
        {
            if (dbData.isLogin)
            {
                auth.Visible = false;
            }
        }
    }    
}
