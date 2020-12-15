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

        string WhatDidIJustClick = "";

        public void initState()
        {
            if (WhatDidIJustClick == "")
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WhatDidIJustClick = "button2";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WhatDidIJustClick = "button1";
            button3.Enabled = false;
            button4.Enabled = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            WhatDidIJustClick = "button4";
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connecting = new SqlConnection(@"Data Source=DESKTOP-QJQOIK3\MSSQLSERVER01;Initial Catalog=CrudApp;Integrated Security=True");
            connecting.Open();

            if (WhatDidIJustClick == "button4")
            {
                SqlCommand command = new SqlCommand("Delete [Table] where username=@Username", connecting);
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.ExecuteNonQuery();

            } else if (WhatDidIJustClick == "button1")
            {
                SqlCommand command = new SqlCommand("insert into [Table] values (@Username,@Email,@password)", connecting);
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.Parameters.AddWithValue("@Email", textBox2.Text);
                command.Parameters.AddWithValue("@password", textBox3.Text);
                command.ExecuteNonQuery();
            } else if (WhatDidIJustClick == "button3")
            {

            }
            connecting.Close();
            WhatDidIJustClick = "";
            initState();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection connecting = new SqlConnection(@"Data Source=DESKTOP-QJQOIK3\MSSQLSERVER01;Initial Catalog=CrudApp;Integrated Security=True");
            connecting.Open();
            SqlCommand command = new SqlCommand("Select * from [Table]", connecting);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable dataTab = new DataTable();
            data.Fill(dataTab);
            dataGridView1.DataSource = dataTab;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WhatDidIJustClick = "";
            initState();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form popUp = new Form();

            Label label4 = new Label()
            {
                Text = "Username",
                Location = new Point(10, 10)
            };

            TextBox feild = new TextBox()
            {
                Location = new Point(10, 50),
                TabIndex = 11
            };

            Button botona = new Button()
            {
                Text = "Submit",
                Location = new Point(10, 100),
            };

            popUp.Controls.Add(feild);
            popUp.Controls.Add(label4);
            popUp.Controls.Add(botona);

            popUp.Show();
            botona.Click += botona_clicked;
            void botona_clicked(object seander, EventArgs ea)
            {
                popUp.Close();
            }
        }


    }
}
