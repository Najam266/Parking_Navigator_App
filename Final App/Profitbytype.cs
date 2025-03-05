using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace APP
{
    
    public partial class Profitbytype : Form
    {

        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Profitbytype()
        {
            InitializeComponent();
        }

        private void Profitbytype_Load(object sender, EventArgs e)
        {

        }
        private void tableshow()
        {
            
            string cartyp = comboBox1.SelectedItem?.ToString();
            if (cartyp == "SUV")
            {
                showS("SUV");
            }
            if (cartyp == "Sedan")
            {
                showS("Sedan");
            }
            if (cartyp == "Jeep")
            {
                showS("Jeep");
            }
            if (cartyp == "Van")
            {
                showS("Van");
            }
            if (cartyp == "Bike")
            {
                showS("Bike");
            }
            if (cartyp == "EV")
            {
                showS("EV");
            }


        }
        private void showS(string typname)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT Name,Car_Type,Price from History where Car_Type=@typname";
                string query2= "SELECT SUM(Price) AS TotalPrice FROM History WHERE Car_Type = @typname";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@typname", typname);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView1.DataSource = dt;
                    }
                }
                using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                {
                    cmd.Parameters.AddWithValue("@typname", typname);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableshow();
        }

        
    }
}
