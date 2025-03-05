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
    public partial class Silverfeed : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Silverfeed()
        {
            InitializeComponent();
        }
        private void showsil(string typname)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = @"SELECT DISTINCT f.Name,f.Registration_No,f.Feedbacks from Feed f inner join History h on f.UserID=h.UserId inner join Members m on h.UserID=m.UserId  where m.Type=@typname";
                string query2 = @"SELECT count( DISTINCT f.Registration_No) FROM Feed f inner join History h on f.UserID=h.UserId inner join Members m on h.UserID=m.UserId  where m.Type=@typname";
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
        private void Silverfeed_Load(object sender, EventArgs e)
        {
            showsil("Silver");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
