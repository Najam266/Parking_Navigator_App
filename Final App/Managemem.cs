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
    public partial class Managemem : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Managemem()
        {
            InitializeComponent();
        }

        private void Managemem_Load(object sender, EventArgs e)
        {
            showprices1();
        }
        private void showprices1()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT CarType,Gold,Silver,Bronze FROM Pricing ";

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
        private void tableshow2()
        {

            string cartyp = selectcar.SelectedItem?.ToString();
            if (cartyp == "SUV")
            {
                tableshow1("SUV");
            }
            if (cartyp == "Sedan")
            {
                tableshow1("Sedan");
            }
            if (cartyp == "Jeep")
            {
                tableshow1("Jeep");
            }
            if (cartyp == "Van")
            {
                tableshow1("Van");
            }
            if (cartyp == "Bike")
            {
                tableshow1("Bike");
            }
            if (cartyp == "EV")
            {
                tableshow1("EV");
            }
        }
        private void tableshow1(string crt)
        {

            string cartyp1 = comboBox1.SelectedItem?.ToString();
            if (cartyp1 == "Gold")
            {
                updations("Gold",crt);
            }
            if (cartyp1 == "Silver")
            {
                updations("Silver", crt);
            }
            if (cartyp1 == "Bronze")
            {
                updations("Bronze", crt);
            }
           
        }
        private void updations(string type,string type2)
        {
            string pric = textBox1.Text;
            string typ = type;
            string typ2 = type2;

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = $"UPDATE Pricing SET {typ} =@pric  WHERE CarType=@typ2 ";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@pric", pric);
                    cmd.Parameters.AddWithValue("@typ", typ);
                    cmd.Parameters.AddWithValue("@typ2", typ2);


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
        private void button3_Click(object sender, EventArgs e)
        {
            showprices1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableshow2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
