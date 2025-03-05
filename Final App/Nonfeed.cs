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
    public partial class Nonfeed : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Nonfeed()
        {
            InitializeComponent();
        }

        private void Nonfeed_Load(object sender, EventArgs e)
        {
            shownon();
            
        }
        private void shownon()
        {
            
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = @"SELECT DISTINCT f.Name,f.Registration_No,f.Feedbacks from Feed f inner join History h on f.UserID=h.UserId where h.Membership_status='No'";
                string query2 = @"SELECT count(DISTINCT f.Registration_No) FROM Feed f inner join History h on f.UserID=h.UserId where h.Membership_status='No'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
