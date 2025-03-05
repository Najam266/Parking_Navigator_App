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
    public partial class Add_employee : Form
    {

        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Add_employee()
        {
            InitializeComponent();
        }


        private void Add_employee_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string pass = tbPass.Text;
            string des = tbdes.Text;

           
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(des))
            {
                MessageBox.Show("Please enter name, password, and designation.");
                return;
            }

           
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "INSERT INTO Employees (Name, Password, Designation) VALUES (@name, @pass, @des)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@des", des);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee inserted successfully!");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert employee.");
                    }
                }
            }

        }
    }
}
