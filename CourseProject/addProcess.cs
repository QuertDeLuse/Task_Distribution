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
    public partial class addProcess : Form
    {
        List<Taskq> tasks = new List<Taskq>();
        List<Executor> executors = new List<Executor>();

        List<dbData.Process> internalProcesses;

        public addProcess(List<dbData.Process> processes)
        {
            InitializeComponent();

            internalProcesses = processes;

            tasks = dbData.TaskqManager.GetTasks();
            executors = dbData.ExecutorManager.GetExecutor();

            DataTable tasksFromDB = dbData.Select("SELECT [miniDescr] FROM [dbo].[Tasks]");
            DataTable executorsFromDB = dbData.Select("SELECT [nickName] FROM [dbo].[Executors]");


            bool isTaskAlreadyExist = false;

            List<string> taskList = new List<string>();

            //Adding task from DB into the taskList
            for (int i = 0; i < tasksFromDB.Rows.Count; i++)
            {
                //Проверка на то, сущ-т ли такая запись уже в процессах, чтобы не было возможности добавить дубликат
                for(int j = 0; j < processes.Count; j++)
                {
                    //сравнение имени задания с каждым именем задания в процессе                    
                    if (tasksFromDB.Rows[i][0].ToString().Trim() == processes[j].taskName.ToString().Trim())
                    {
                        isTaskAlreadyExist = true;
                    }
                }         
                
                if(!isTaskAlreadyExist)                
                    taskList.Add(tasksFromDB.Rows[i][0].ToString().Trim());                   
                
                isTaskAlreadyExist = false;
            }
            comboBox1.DataSource = taskList;
            comboBox1.SelectedIndex = -1;

            
            List<string> executorList = new List<string>();
            for (int i = 0; i < executorsFromDB.Rows.Count; i++)
            {
                executorList.Add(executorsFromDB.Rows[i][0].ToString().Trim());
            }
            comboBox2.DataSource = executorList;
            comboBox2.SelectedIndex = -1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string taskName = comboBox1.Text;
            string nickName = comboBox2.Text;

            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Не все поля заполнены!");
            } 
            else
            {
                DataTable taskFromDB = dbData.Select("SELECT * FROM [dbo].[Tasks] WHERE [miniDescr] = '" + taskName + "' ");
                DataTable executorFromDB = dbData.Select("SELECT * FROM [dbo].[Executors] WHERE [nickName] = '" + nickName + "' ");

                var process = new Process();

                process.processID = internalProcesses.Count+1;
                process.taskID = Convert.ToInt32(taskFromDB.Rows[0][0]);
                process.taskName = taskName;
                process.taskImportance = taskFromDB.Rows[0][4].ToString();
                process.taskUrgency = taskFromDB.Rows[0][3].ToString();

                process.executorID = Convert.ToInt32(executorFromDB.Rows[0][0]);
                process.executorNickname = executorFromDB.Rows[0][1].ToString();
                process.executorQualification = executorFromDB.Rows[0][5].ToString();
                process.ExecutorRating = Convert.ToInt32(executorFromDB.Rows[0][7]);

                internalProcesses.Add(process);
                dbData.Select("INSERT INTO [dbo].[Processes] VALUES ('" + process.processID + "', " +
                    "'" + process.taskID + "'," +
                    "'" + process.taskName + "'," +
                    "'" + process.taskImportance + "'," +
                    "'" + process.taskUrgency + "'," +

                    "'" + process.executorID + "'," +
                    "'" + process.executorNickname + "'," +
                    "'" + process.executorQualification + "'," +
                    "'" + process.ExecutorRating + "')");


                this.Close();
            }            
        }
    }
}
