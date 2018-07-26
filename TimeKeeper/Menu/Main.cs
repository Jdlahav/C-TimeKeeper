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
    public partial class Main : Form
    {
        SqlConnection Conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JDL-PC\Documents\Visual Studio 2017\Projects\TimeKeeper\TimeKeeper\Database.mdf;Integrated Security=True");

        public Main()
        {
            InitializeComponent();
            InitializeList();
        }

        //Populates the projects list
        private void InitializeList()
        {
            using (Conn)
            using (SqlDataAdapter Adapter = new SqlDataAdapter("Select * from Project", Conn))    
            {
                DataTable DT = new DataTable();
                Adapter.Fill(DT);
                ProjectsList.DisplayMember = "Name";
                ProjectsList.ValueMember = "Id";
                ProjectsList.DataSource = DT;
                ProjectsList.DoubleClick += new EventHandler(ProjectsList_DoubleClick);
            }
        }
        //TO-DO: Fix item selection, the correct object is being selected, however output is "System.Data.DataRowView".
        private void ProjectsList_DoubleClick(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedItem != null)
            {
                MessageBox.Show(ProjectsList.SelectedItem.ToString());
            }
        }
    }
}
