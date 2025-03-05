using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP
{
    public partial class Allfeeds : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Allfeeds()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void showfeeds()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT  Distinct Name,Registration_No,Feedbacks FROM Feed";
                string query2 = "SELECT count(DISTINCT Registration_No) FROM Feed ";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView1.DataSource = dt;
                    }
                }
                using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                {
                    
                    object result = cmd.ExecuteScalar(); // ExecuteScalar to get single value

                    if (result != null)
                    {
                        int rowCount = Convert.ToInt32(result); // Convert the result to int
                        label4.Text = rowCount.ToString(); // Display the count in label4
                    }
                    else
                    {
                        label4.Text = "0"; // No rows returned
                    }
                }

            }

        }

        private void Allfeeds_Load(object sender, EventArgs e)
        {
            showfeeds();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
