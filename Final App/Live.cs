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
    public partial class Live : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";
        public Live()
        {
            InitializeComponent();
        }

        private void Live_Load(object sender, EventArgs e)
        {
            showhistory();
        }
        private void showhistory()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string Query = "SELECT Name, Registration_NO,Car_Type,Floor_No,Slot FROM Parking";

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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
