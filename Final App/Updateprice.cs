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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APP
{
    public partial class Updateprice : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Updateprice()
        {
            InitializeComponent();
        }

        private void updations(string type)
        {
            string pric = textBox1.Text;
            string typ = type;

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "UPDATE Pricing SET Simpleprice =@pric  WHERE CarType=@typ ";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@pric",pric);
                    cmd.Parameters.AddWithValue("@typ", typ);


                    // Execute the query to update the password
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Price updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update price");
                    }
                }
            }

        }
        private void tableshow()
        {

            string cartyp = selectcar.SelectedItem?.ToString();
            if (cartyp == "SUV")
            {
                updations("SUV");
            }
            if (cartyp == "Sedan")
            {
                updations("Sedan");
            }
            if (cartyp == "Jeep")
            {
                updations("Jeep");
            }
            if (cartyp == "Van")
            {
                updations("Van");
            }
            if (cartyp == "Bike")
            {
                updations("Bike");
            }
            if (cartyp == "EV")
            {
                updations("EV");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableshow();
        }

        private void Updateprice_Load(object sender, EventArgs e)
        {
            showprices();
           
        }
        private void showprices()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT CarType,Simpleprice FROM Pricing ";

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

        private void selectcar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showprices();
        }
    }
}
