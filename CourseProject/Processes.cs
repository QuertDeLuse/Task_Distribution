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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }    
}
