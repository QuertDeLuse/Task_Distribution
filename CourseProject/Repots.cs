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
    public partial class Repots : Form
    {
        public Repots()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Processes processesForm = new Processes();
            this.Hide();
            processesForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tasks tasksForm = new Tasks();
            this.Hide();
            tasksForm.Show();
        }

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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Repots_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Process Report
        private void button9_Click(object sender, EventArgs e)
        {

        }

        //Complete Process Report
        private void button6_Click(object sender, EventArgs e)
        {

        }

        //Tasks Report
        private void button7_Click(object sender, EventArgs e)
        {

        }

        //Executors Report
        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
