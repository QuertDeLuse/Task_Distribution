using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject
{
    

    public class dbData
    {
        public static bool isLogin = false;

        public static DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable("dataBase");

            SqlConnection sqlConnection = new SqlConnection("Data Source = Nikita-ПК\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=tds;");
            sqlConnection.Open();
            SqlCommand sqlCommnand = sqlConnection.CreateCommand();
            sqlCommnand.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommnand);
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public class Process
        {
            public int processID { get; set; }
            public int taskID { get; set; }
            public string taskName { get; set; }
            public string taskImportance { get; set; }
            public string taskUrgency { get; set; }
            public int executorID { get; set; }
            public string executorNickname { get; set; }
            public string executorQualification { get; set; }
            public int ExecutorRating { get; set; }
        }

        public class ProcessManager
        {
            public static List<Process> GetProcesses()
            {
                var processes = new List<Process>();
                
                DataTable processesData = Select("SELECT * FROM [dbo].[Processes]");

                for (int i = 0; i < processesData.Rows.Count; i++)
                {
                    var process = new Process();
                    
                    process.processID = Convert.ToInt32(processesData.Rows[i][0]);
                    process.taskID = Convert.ToInt32(processesData.Rows[i][1]);
                    process.taskName = processesData.Rows[i][2].ToString();                    
                    process.taskImportance = processesData.Rows[i][3].ToString();
                    process.taskUrgency = processesData.Rows[i][4].ToString();
                    process.executorID = Convert.ToInt32(processesData.Rows[i][5]);
                    process.executorNickname = processesData.Rows[i][6].ToString();
                    process.executorQualification = processesData.Rows[i][7].ToString();
                    process.ExecutorRating = Convert.ToInt32(processesData.Rows[i][8]);

                    processes.Add(process);
                }              

                return processes;
            }
        }



        public class Taskq
        {         
            public int taskID { get; set; }
            public string miniDescr { get; set; }
            public string fullDescr { get; set; }
            public string urgency { get; set; }
            public string importance { get; set; }
            public string complexity { get; set; }
        }

        public class TaskqManager
        {
            public static List<Taskq> GetTasks()
            {
                var tasks = new List<Taskq>();

                DataTable tasksData = Select("SELECT * FROM [dbo].[Tasks]");

                for (int i = 0; i < tasksData.Rows.Count; i++)
                {
                    var task = new Taskq();

                    task.taskID = Convert.ToInt32(tasksData.Rows[i][0]);                  
                    task.miniDescr = tasksData.Rows[i][1].ToString();
                    task.fullDescr = tasksData.Rows[i][2].ToString();
                    task.urgency = tasksData.Rows[i][3].ToString();
                    task.importance = tasksData.Rows[i][4].ToString();
                    task.complexity = tasksData.Rows[i][5].ToString();

                    tasks.Add(task);
                }

                return tasks;
            }
        }



        public class Executor
        {
            public int executorID { get; set; }
            public string nickName { get; set; }
            public string firstName { get; set; }
            public string secondName { get; set; }
            public string fathersName { get; set; }
            public string qualification { get; set; }
            public string specialization { get; set; }
            public int rating { get; set; }
            public string phoneNumber { get; set; }
            public string email { get; set; }
        }

        public class ExecutorManager
        {
            public static List<Executor> GetExecutors()
            {
                var executors = new List<Executor>();

                DataTable executorsData = Select("SELECT * FROM [dbo].[Executors]");

                for (int i = 0; i < executorsData.Rows.Count; i++)
                {
                    var executor = new Executor();

                    executor.executorID = Convert.ToInt32(executorsData.Rows[i][0]);
                    executor.nickName = executorsData.Rows[i][1].ToString();

                    executor.firstName = executorsData.Rows[i][2].ToString();
                    executor.secondName = executorsData.Rows[i][3].ToString();
                    executor.fathersName = executorsData.Rows[i][4].ToString();
                    executor.qualification = executorsData.Rows[i][5].ToString();
                    executor.specialization = executorsData.Rows[i][6].ToString();

                    executor.rating = Convert.ToInt32(executorsData.Rows[i][7]);
                    executor.phoneNumber = executorsData.Rows[i][8].ToString();
                    executor.email = executorsData.Rows[i][9].ToString();

                    executors.Add(executor);
                }

                return executors;
            }
        }



        public class CompleteProcess
        {
            public int processID { get; set; }
            public int taskID { get; set; }
            public string taskName { get; set; }
            public string taskImportance { get; set; }
            public string taskUrgency { get; set; }
            public int executorID { get; set; }
            public string executorNickname { get; set; }
            public string executorQualification { get; set; }
            public int ExecutorRating { get; set; }
        }

        public class CompleteProcessesManager
        {
            public static List<CompleteProcess> GetCompleteProcesses()
            {
                var completeProcesses = new List<CompleteProcess>();

                DataTable completeProcessesData = Select("SELECT * FROM [dbo].[CompleteProcesses]");

                for (int i = 0; i < completeProcessesData.Rows.Count; i++)
                {
                    var completeProcess = new CompleteProcess();

                    completeProcess.processID = Convert.ToInt32(completeProcessesData.Rows[i][0]);
                    completeProcess.taskID = Convert.ToInt32(completeProcessesData.Rows[i][1]);
                    completeProcess.taskName = completeProcessesData.Rows[i][2].ToString();
                    completeProcess.taskImportance = completeProcessesData.Rows[i][3].ToString();
                    completeProcess.taskUrgency = completeProcessesData.Rows[i][4].ToString();
                    completeProcess.executorID = Convert.ToInt32(completeProcessesData.Rows[i][5]);
                    completeProcess.executorNickname = completeProcessesData.Rows[i][6].ToString();
                    completeProcess.executorQualification = completeProcessesData.Rows[i][7].ToString();
                    completeProcess.ExecutorRating = Convert.ToInt32(completeProcessesData.Rows[i][8]);

                    completeProcesses.Add(completeProcess);
                }

                return completeProcesses;
            }
        }

    }
}
