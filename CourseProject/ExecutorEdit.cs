using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class ExecutorEdit : Form
    {
        int internalExecutorID;

        public ExecutorEdit(object executorID)
        {
            InitializeComponent();

            internalExecutorID = Convert.ToInt32(executorID);

            DataTable executorInfoTable = dbData.Select("SELECT * FROM [dbo].[Executors] WHERE executorID = '" + internalExecutorID + "'");

            textBox1.Text = executorInfoTable.Rows[0][1].ToString().Trim();
            textBox2.Text = executorInfoTable.Rows[0][2].ToString().Trim();
            textBox3.Text = executorInfoTable.Rows[0][3].ToString().Trim();
            textBox4.Text = executorInfoTable.Rows[0][4].ToString().Trim();
            textBox5.Text = executorInfoTable.Rows[0][5].ToString().Trim();
            textBox6.Text = executorInfoTable.Rows[0][6].ToString().Trim();
            textBox7.Text = executorInfoTable.Rows[0][7].ToString().Trim();
            textBox8.Text = executorInfoTable.Rows[0][8].ToString().Trim();
            textBox9.Text = executorInfoTable.Rows[0][9].ToString().Trim();          

        }

        //Edit
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" ||
                textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                try
                {
                    //Changes in Executors

                    dbData.Select("UPDATE [dbo].[Executors] SET nickName = '" + textBox1.Text + "' WHERE executorID = '" + internalExecutorID + "' ");

                    dbData.Select("UPDATE [dbo].[Executors] SET firstName = '" + textBox2.Text + "' WHERE executorID = '" + internalExecutorID + "' ");
                    dbData.Select("UPDATE [dbo].[Executors] SET secondName = '" + textBox3.Text + "' WHERE executorID = '" + internalExecutorID + "' ");
                    dbData.Select("UPDATE [dbo].[Executors] SET fatherName = '" + textBox4.Text + "' WHERE executorID = '" + internalExecutorID + "' ");

                    dbData.Select("UPDATE [dbo].[Executors] SET qualification = '" + textBox5.Text + "' WHERE executorID = '" + internalExecutorID + "' ");
                    dbData.Select("UPDATE [dbo].[Executors] SET specialization = '" + textBox6.Text + "' WHERE executorID = '" + internalExecutorID + "' ");

                    dbData.Select("UPDATE [dbo].[Executors] SET rating = '" + textBox7.Text + "' WHERE executorID = '" + internalExecutorID + "' ");              

                    dbData.Select("UPDATE [dbo].[Executors] SET phoneNumber = '" + textBox8.Text + "' WHERE executorID = '" + internalExecutorID + "' ");
                    dbData.Select("UPDATE [dbo].[Executors] SET eMail = '" + textBox9.Text + "' WHERE executorID = '" + internalExecutorID + "' ");


                    //Changes in Processes
                    dbData.Select("UPDATE [dbo].[Processes] SET executorNickname = '" + textBox1.Text + "' WHERE executorID = '" + internalExecutorID + "' ");
                    dbData.Select("UPDATE [dbo].[Processes] SET executorQualification = '" + textBox5.Text + "' WHERE executorID = '" + internalExecutorID + "' ");
                    dbData.Select("UPDATE [dbo].[Processes] SET executorRating = '" + textBox7.Text + "' WHERE executorID = '" + internalExecutorID + "' ");
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }


                this.Close();
            }
        }
    }
}
