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
    public partial class addExecutor : Form
    {
        public addExecutor()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || 
                textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                dbData.Select("INSERT INTO [dbo].[Executors] VALUES (" +
                    "'" + textBox1.Text + "'," +
                    "'" + textBox2.Text + "'," +
                    "'" + textBox3.Text + "'," +
                    "'" + textBox4.Text + "'," +
                    "'" + textBox5.Text + "'," +
                    "'" + textBox6.Text + "'," +
                    "'" + textBox7.Text + "'," +
                    "'" + textBox8.Text + "'," +
                    "'" + textBox9.Text + "')");

                this.Close();
            }
        }
    }
}
