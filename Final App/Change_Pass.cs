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

namespace WindowsFormsApp3
{
    public partial class Change_Pass : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";
        public Change_Pass()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Change_Pass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = tname.Text;
            string oldpass = told.Text;
            string newpass = tnew.Text;
            string confpass=tcofnew.Text;
            string des = tdes.Text;

            // Check if name, password, and designation are not empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(oldpass) || string.IsNullOrWhiteSpace(des))
            {
                MessageBox.Show("Please enter name, password, and designation.");
                return;
            }
            if (newpass != confpass)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "UPDATE Employees SET Password = @newPass WHERE Name = @name AND Password = @oldPass";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@oldPass", oldpass);
                    cmd.Parameters.AddWithValue("@newPass", newpass);

                    // Execute the query to update the password
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password. Employee not found or old password incorrect.");
                    }
                }
            }
        }
    }
}
