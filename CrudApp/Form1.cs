using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CrudApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string WhatDidIJustClicked = "";

        public void initState()
        {
            if(WhatDidIJustClicked == "")
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WhatDidIJustClicked = "button2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WhatDidIJustClicked = "button1";
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            WhatDidIJustClicked = "button4";
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connecting = new SqlConnection(@"Data Source=DESKTOP-QJQOIK3\MSSQLSERVER01;Initial Catalog=CrudApp;Integrated Security=True");
            connecting.Open();

            if (WhatDidIJustClicked == "button4")
            {
                SqlCommand command = new SqlCommand("Delete [Table] where username=@Username", connecting);
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.ExecuteNonQuery();

            } else if(WhatDidIJustClicked == "button1")
            {
                SqlCommand command = new SqlCommand("insert into [Table] values (@Username,@Email,@password)", connecting);
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.Parameters.AddWithValue("@Email", textBox2.Text);
                command.Parameters.AddWithValue("@password", textBox3.Text);
                command.ExecuteNonQuery();
            }
            connecting.Close();
            WhatDidIJustClicked = "";
            initState();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    SqlConnection connecting = new SqlConnection(@"Data Source=DESKTOP-QJQOIK3\MSSQLSERVER01;Initial Catalog=CrudApp;Integrated Security=True");
        //    connecting.Open();
        //    SqlCommand command = new SqlCommand("insert into [Table] values (@Username,@Email,@password)",connecting);
        //    command.Parameters.AddWithValue("@Username", textBox1.Text);
        //    command.Parameters.AddWithValue("@Email", textBox2.Text);
        //    command.Parameters.AddWithValue("@password", textBox3.Text);
        //    command.ExecuteNonQuery();
        //    connecting.Close();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    SqlConnection connecting = new SqlConnection(@"Data Source=DESKTOP-QJQOIK3\MSSQLSERVER01;Initial Catalog=CrudApp;Integrated Security=True");
        //    connecting.Open();
        //    SqlCommand command = new SqlCommand("Delete [Table] where username=@Username", connecting);
        //    command.Parameters.AddWithValue("@Username", textBox1.Text);
        //    command.ExecuteNonQuery();
        //    connecting.Close();
        //}
    }
}
