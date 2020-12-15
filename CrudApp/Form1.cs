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
        //this will keep us in track of the buttons we clicked (According to the state)
        string WhatDidIJustClick = "";

        //These Controls will help on creating a popup on the Update phase 
        //Bonus Controls
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

        Label malabel = new Label()
        {
            Text = "Username",
            Location = new Point(10, 10)
        };
        //End of Bonus Controls

        //Queries ===> we will be using these instead of writing everything in there
        string addQuery = "insert into [Table] values (@Username,@Email,@password)";
        string updateQuery = "update[Table] set Email = @Email, password = @password where username = @Username";
        string deleteQuery = "Delete [Table] where username=@Username";
        //bonus (Data base name)
        string DBName = @"Data Source=DESKTOP-QJQOIK3\MSSQLSERVER01;Initial Catalog=CrudApp;Integrated Security=True";

        //WE ARE GOING TO DISABLE USLESS CONTROLS WHEN WE CLICK A BUTTON

        //This Funtions will Reset/Enable every Control so we can reuse everything
        public void initState()
        {
            if (WhatDidIJustClick == "")
            {
                //enabling...
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        //disabling stuff when other stuff is clicked
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

        //this is the SUBMIT button and it takes on concideration the last button clicked (to know what to do)
        private void button5_Click(object sender, EventArgs e)
        {
            //Connecting to the DB
            SqlConnection connecting = new SqlConnection(DBName);
            connecting.Open();

            //Here we clciked on Delete so we are running a delete query 
            if (WhatDidIJustClick == "button4")
            {
                SqlCommand command = new SqlCommand(deleteQuery, connecting);
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.ExecuteNonQuery();

            } 
            //running an insertion query because button1 (Add) was the last to be clicked
            else if (WhatDidIJustClick == "button1")
            {
                SqlCommand command = new SqlCommand(addQuery, connecting);
                command.Parameters.AddWithValue("@Username", textBox1.Text);
                command.Parameters.AddWithValue("@Email", textBox2.Text);
                command.Parameters.AddWithValue("@password", textBox3.Text);
                command.ExecuteNonQuery();
            } 
            //the update query (currently not working)
            else if (WhatDidIJustClick == "button3")
            {
                SqlCommand command = new SqlCommand(updateQuery, connecting);
                command.Parameters.AddWithValue("@Username", feild.Text);
                command.Parameters.AddWithValue("@Email", textBox2.Text);
                command.Parameters.AddWithValue("@password", textBox3.Text);
                command.ExecuteNonQuery();
            }
            connecting.Close();
            //we are sitting everything to the inital state 
            WhatDidIJustClick = "";
            initState();
        }

        //This one is for getting the data and shwoing it on the gridView
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

        //Abort Button to re-Intialize things
        private void button7_Click(object sender, EventArgs e)
        {
            WhatDidIJustClick = "";
            initState();
        }

        //Here we are creating a form to specify what we want to update exactly (in this case username kind of the id)
        private void button3_Click(object sender, EventArgs e)
        {
            //disabling
            WhatDidIJustClick = "button3";
            textBox1.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = false;

            Form popUp = new Form();

            //adding the stuff on the variables here
            popUp.Controls.Add(feild);
            popUp.Controls.Add(malabel);
            popUp.Controls.Add(botona);

            popUp.Show();
            //extiing popUp
            botona.Click += botona_clicked;
            void botona_clicked(object botona_sender, EventArgs botona_e) => popUp.Close();
        }


    }
}
