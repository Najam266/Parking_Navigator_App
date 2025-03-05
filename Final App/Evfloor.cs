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
    public partial class Evfloor : Form
    {
        string connectionstring = "Data Source = C:\\Users\\apple\\source\\repos\\APP\\parking.db; Version = 3";
        public Evfloor()
        {
            InitializeComponent();
        }
        private void showslotEV()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM EV";

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

        private void Evfloor_Load(object sender, EventArgs e)
        {
            showslotEV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
