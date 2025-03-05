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
    public partial class TotProfits : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public TotProfits()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showtot()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT Name, Car_Type, Price FROM History";
                string query2 = "SELECT SUM(Price) AS TotalPrice FROM History";

                // Load data into DataGridView
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView1.DataSource = dt;
                    }
                }

                // Retrieve and display total price
                using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            // Get the sum value from the reader
                            decimal totalPrice;
                            if (reader["TotalPrice"] != DBNull.Value)
                            {
                                totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                                label4.Text = totalPrice.ToString(); // Display the sum value
                            }
                            else
                            {
                                // Handle case when no rows are returned
                                label4.Text = "0"; // Or display any other default value
                            }
                        }
                        else
                        {
                            // Handle case when no rows are returned
                            label4.Text = "0"; // Or display any other default value
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TotProfits_Load(object sender, EventArgs e)
        {
            showtot();
        }
    }
}
