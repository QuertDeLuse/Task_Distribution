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
    public partial class TaskEdit : Form
    {
        int internalTaskID;
        public TaskEdit(object taskID)
        {
            InitializeComponent();

            internalTaskID = Convert.ToInt32(taskID);

            DataTable taskInfoTable = dbData.Select("SELECT * FROM [dbo].[Tasks] WHERE taskID = '"+ internalTaskID + "'");

            textBox1.Text = taskInfoTable.Rows[0][1].ToString();
            textBox2.Text = taskInfoTable.Rows[0][2].ToString();          
                    
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(taskInfoTable.Rows[0][3].ToString().Trim());
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf(taskInfoTable.Rows[0][4].ToString().Trim());
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf(taskInfoTable.Rows[0][5].ToString().Trim());
        }


        //Edit
        private void button9_Click(object sender, EventArgs e)
        {
            //UPDATE orders SET Price =

            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                try
                {
                    //Changes in Tasks
                    dbData.Select("UPDATE [dbo].[Tasks] SET miniDescr = '" + textBox1.Text + "' WHERE taskID = '" + internalTaskID + "' ");
                    dbData.Select("UPDATE [dbo].[Tasks] SET fullDescr = '" + textBox2.Text + "' WHERE taskID = '" + internalTaskID + "' ");
                    dbData.Select("UPDATE [dbo].[Tasks] SET urgency = '" + comboBox1.SelectedItem + "' WHERE taskID = '" + internalTaskID + "' ");
                    dbData.Select("UPDATE [dbo].[Tasks] SET importance = '" + comboBox2.SelectedItem + "' WHERE taskID = '" + internalTaskID + "' ");
                    dbData.Select("UPDATE [dbo].[Tasks] SET complexity = '" + comboBox3.SelectedItem + "' WHERE taskID = '" + internalTaskID + "' ");

                    //Changes in Process
                    dbData.Select("UPDATE [dbo].[Processes] SET taskName = '" + textBox1.Text + "' WHERE taskID = '" + internalTaskID + "' ");
                    dbData.Select("UPDATE [dbo].[Processes] SET taskImportance = '" + comboBox2.SelectedItem + "' WHERE taskID = '" + internalTaskID + "' ");
                    dbData.Select("UPDATE [dbo].[Processes] SET taskUrgency = '" + comboBox1.SelectedItem + "' WHERE taskID = '" + internalTaskID + "' ");
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
