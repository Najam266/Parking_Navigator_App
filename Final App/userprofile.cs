using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP
{
    public partial class userprofile : Form
    {

        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";


        public userprofile()

        {
            InitializeComponent();
            showUsers();
        }

        private void showUsers()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string Query = "SELECT * FROM user";

                using (SQLiteCommand command = new SQLiteCommand(Query, con))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);

                        dataGridView1.DataSource = dataTable;
                    }
                }

                con.Close();
            }
        }

        //private void AddUser()
        //{
        //    SQLiteConnection con = new SQLiteConnection(connection);

        //    con.Open();


        //    string Query = "INSERT INTO user VALUES(1, 'nigga')";

        //    SQLiteCommand command = new SQLiteCommand(Query, con);

        //    command.ExecuteNonQuery();


        //    con.Close();
        //}

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //AddUser();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userprofile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
