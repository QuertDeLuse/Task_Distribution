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
    public partial class addTask : Form
    {       
        public addTask()
        {
            InitializeComponent();            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                dbData.Select("INSERT INTO [dbo].[Tasks] VALUES (" +
                    "'" + textBox1.Text + "'," +
                    "'" + textBox2.Text + "'," +
                    "'" + comboBox1.SelectedItem + "'," +
                    "'" + comboBox2.SelectedItem + "'," +                    
                    "'" + comboBox3.SelectedItem + "')");

                this.Close();
            }
        }
    }
}
