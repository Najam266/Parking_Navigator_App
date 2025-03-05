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

    public partial class Feedform : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Feedform()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void showtable()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT UserID,Name,Registration_No FROM History";

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
        private void check_feed()
        {
            string name = text.Text;
            string Reg = textNO.Text;
            


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(Reg))
            {
                MessageBox.Show("Please enter all details");
                return;
            }


            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                // Check if the user already exists
                string checkQuery = "SELECT UserID FROM History WHERE Name = @name AND Registration_No = @Reg";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@Reg", Reg);

                    object userId = checkCmd.ExecuteScalar();

                    if (userId != null)
                    {
                        MessageBox.Show($"  User exists in Database\n\n\t  ID: {userId}");
                        return;
                         // Exit the function without adding the user
                    }
                    else
                    {
                        MessageBox.Show("  User do not exists in Database");
                        return;
                         
                    }
                }
               



            }


        }
        private void counter()
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                string query2 = "Select count(FeedId) from Feed ";
                using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                {


                    object result = cmd.ExecuteScalar(); // ExecuteScalar to get single value

                    if (result != null)
                    {
                        int rowCount = Convert.ToInt32(result); // Convert the result to int
                        label6.Text = rowCount.ToString(); // Display the count in label4
                    }
                    else
                    {
                        label6.Text = "0"; // No rows returned
                    }
                }
            }
        }
        private void add_feed()
        {

            string name = text.Text;
            string Reg = textNO.Text;
            string ID = textID.Text;
            string feeds = richTextBox1.Text;


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(Reg) || string.IsNullOrWhiteSpace(ID) || string.IsNullOrWhiteSpace(feeds))
            {
                MessageBox.Show("Please enter all details");
                return;
            }


            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
               
                string query = "INSERT INTO Feed (UserId,Name,Registration_No,Feedbacks) VALUES (@ID,@name,@Reg,@feeds)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@Reg", Reg);
                    cmd.Parameters.AddWithValue("@feeds", feeds);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Feedback Added succesfully!");
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Failed to insert user.");
                    }

                }
            }

        }
        private void Feedform_Load(object sender, EventArgs e)
        {
            showtable();
            counter();
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            check_feed();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_feed();
          
        }
    }
}
