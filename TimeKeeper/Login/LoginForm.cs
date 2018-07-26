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

namespace TimeKeeper
{
    public partial class LoginForm : Form
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JDL-PC\Documents\Visual Studio 2017\Projects\TimeKeeper\TimeKeeper\Database.mdf;Integrated Security=True");
        public LoginForm()
        {
            InitializeComponent();
        }
        //Verifies login information and allows access to verified users.
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter("select count(*) from \"User\" where Username='" + textBox1.Text + "' and Password ='" + textBox2.Text + "'", Conn);
            DataTable DT = new DataTable();
            Adapter.Fill(DT);
            if (DT.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Main menu = new Main();
                menu.Show();
            } 
            else
            {
                MessageBox.Show("Login Credentials Incorrect");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Registration menu button handler
        private void button2_Click(object sender, EventArgs e)
        {
            Register Reg = new Register();
            Reg.Show();
        }
    }
}
