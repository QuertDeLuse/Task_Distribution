﻿using System;
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
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {                    
                    dbData.Select("INSERT INTO [dbo].[Users] VALUES (" +
                    "'" + textBox1.Text + "'," +
                    "'" + textBox2.Text + "')");

                    MessageBox.Show("Регистрация прошла успешно!");
                    this.Close();
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
    }
}
