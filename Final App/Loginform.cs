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
    public partial class Loginform : Form
    {

        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Loginform()
        {
            InitializeComponent();
            this.AcceptButton = loginbtn;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string name = tbname.Text;
            string pass = tbpass.Text;

            // Check if name and password are not empty
            if (name == "" || pass == "")
            {
                MessageBox.Show("Please enter both name and password.");
                return;
            }

            
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM Employees WHERE Name = @Name AND Password = @Password";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Password", pass);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // If a record is found, login successful
                            //MessageBox.Show("Login Successful!");
                            this.Close();
                         
                        }
                        else
                        {
                            // If no record found, login failed
                            MessageBox.Show("Invalid name or password.");
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
