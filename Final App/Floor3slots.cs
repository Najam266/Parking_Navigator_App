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
    public partial class Floor3slots : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Floor3slots()
        {
            InitializeComponent();
        }
        private void showslot3()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM Floor3 ";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
        private void Floor3slots_Load(object sender, EventArgs e)
        {
            showslot3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
