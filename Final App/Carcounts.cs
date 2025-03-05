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
    public partial class Carcounts : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";
        public Carcounts()
        {
            InitializeComponent();
        }

        private void showcount()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string Query = "SELECT Car_Type, count(Car_Type) as Count FROM History group by Car_Type";

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
        private void counter()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                string query2 = "Select count(History_id) from History";
                using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                {


                    object result = cmd.ExecuteScalar(); // ExecuteScalar to get single value

                    if (result != null)
                    {
                        int rowCount = Convert.ToInt32(result); // Convert the result to int
                        label6.Text = rowCount.ToString(); // Display the count in label4
                    }
                    else
                    {
                        label6.Text = "0"; // No rows returned
                    }
                }
            }
        }
        private void Carcounts_Load(object sender, EventArgs e)
        {
            showcount();
            counter();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
