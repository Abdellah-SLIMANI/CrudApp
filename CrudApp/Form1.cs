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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connecting = new SqlConnection(@"Data Source=DESKTOP-QJQOIK3\MSSQLSERVER01;Initial Catalog=CrudApp;Integrated Security=True");
            connecting.Open();
            SqlCommand command = new SqlCommand("insert into [Table] values (@Username,@Email,@password)",connecting);
            command.Parameters.AddWithValue("@Username", textBox1.Text);
            command.Parameters.AddWithValue("@Email", textBox2.Text);
            command.Parameters.AddWithValue("@password", textBox3.Text);
            command.ExecuteNonQuery();
            connecting.Close();
        }
    }
}
