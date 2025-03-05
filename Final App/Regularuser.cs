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
    public partial class Regularuser : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Regularuser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void showsreg()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT Distinct Name,Car_Type FROM History where Booking='No' " ;

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

        private void Regularuser_Load(object sender, EventArgs e)
        {
            showsreg();
        }
    }
}
