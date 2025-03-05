using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP
{
    public partial class Delete_Employee : Form
    {
        string connectionstring = "Data Source = C:\\Users\\apple\\source\\repos\\APP\\parking.db; Version = 3";
        public Delete_Employee()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string pass = tbPass.Text;
            string des = tbdes.Text;

            // Check if name, password, and designation are not empty
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(des))
            {
                MessageBox.Show("Please enter name, password, and designation.");
                return;
            }

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                // Prepare the query to delete the row based on name, password, and designation
                string query = "DELETE FROM Employees WHERE Name = @name AND Password = @pass AND Designation = @des";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@des", des);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No employee found with the provided details.");
                    }
                }
            }

        }

        private void Delete_Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
