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
using System.Configuration;

namespace TimeKeeper
{
    public partial class Register : Form
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JDL-PC\Documents\Visual Studio 2017\Projects\TimeKeeper\TimeKeeper\Database.mdf;Integrated Security=True");
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conn.Open();
            //Very basic "Does the username exist?" check
            SqlDataAdapter Adapter = new SqlDataAdapter("select count(*) from \"User\" where Username='" + textBox1.Text + "'", Conn);
            DataTable DT = new DataTable();
            Adapter.Fill(DT);
            if (DT.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Username already in use");
            } 
            //Password verification check.
            else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match");
            }
            else
            {
                //Inserts a new user into the User table.
                SqlCommand Cmd = new SqlCommand("insert into \"User\" values (@Username, @Password, @FirstName, @LastName, @Email)", Conn);
                Cmd.Parameters.AddWithValue("Username", textBox1.Text);
                Cmd.Parameters.AddWithValue("Password", textBox2.Text);
                Cmd.Parameters.AddWithValue("FirstName", textBox3.Text);
                Cmd.Parameters.AddWithValue("LastName", textBox4.Text);
                Cmd.Parameters.AddWithValue("Email", textBox5.Text);
                Cmd.ExecuteNonQuery();
            }
            Conn.Close();       
        }
    }
}
