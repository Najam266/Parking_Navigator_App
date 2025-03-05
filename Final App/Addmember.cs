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
using static System.Net.Mime.MediaTypeNames;

namespace APP
{
    public partial class Addmember : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";
        public Addmember()
        {
            InitializeComponent();
        }
        private void usertable1()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM user";

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
        private void usertable2()
        {
            string ID = textid.Text;

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT Distinct Registration_No,Car_Type from History where UserID=@ID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView2.DataSource = dt;
                    }
                }
            }

        }
        private void add_user1()
        {
            string name = textname.Text;
            string phone = textphone.Text;


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please enter all details");
                return;
            }


            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                // Check if the user already exists
                string checkQuery = "SELECT Id FROM user WHERE Name = @name AND Phone_no = @phone";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@phone", phone);

                    object userId = checkCmd.ExecuteScalar();

                    if (userId != null)
                    {
                        MessageBox.Show($"  User already exists\n\n\t ID: {userId}");
                        return; // Exit the function without adding the user
                    }
                    else
                    {
                        MessageBox.Show("The user is not in the database\nInsert the user first!");
                        this.Close();
                    }
                }

            }


        }
        private void add_mem()
        {
            string ID = textid.Text;
            string name = textname.Text;
            string vehicle = boxtype.SelectedItem?.ToString();
            string registration = carno.Text;
            string Type = box1.SelectedItem?.ToString();
            int price = 0;


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(vehicle)
                || string.IsNullOrWhiteSpace(registration))
            {
                MessageBox.Show("Please enter all details");
                return;
            }
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                // Check if the membership already exists
                string checkQuery = "SELECT COUNT(*) FROM Members WHERE UserId = @ID AND Name = @name AND RegistrationNo = @registration AND Type = @Type AND CarType = @vehicle";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@ID", ID);
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@registration", registration);
                    checkCmd.Parameters.AddWithValue("@vehicle", vehicle);
                    checkCmd.Parameters.AddWithValue("@Type", Type);

                    int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existingCount > 0)
                    {
                        MessageBox.Show("Membership already exists.");
                        return;
                    }
                }
                if(Type=="Gold")
                {
                    price = 200;
                }
                if (Type == "Silver")
                {

                    price = 150;
                }
                if (Type == "Bronze")
                {

                    price = 100;
                }

                using (SQLiteConnection con1 = new SQLiteConnection(connectionstring))
                {
                    con1.Open();

                    string query2 = "INSERT INTO Members (UserId,Name,RegistrationNo,Type,CarType,Charges) VALUES (@ID,@name, @registration,@Type,@vehicle,@price)";
                    using (SQLiteCommand cmd = new SQLiteCommand(query2, con1))
                    {

                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@registration", registration);
                        cmd.Parameters.AddWithValue("@vehicle", vehicle);
                        cmd.Parameters.AddWithValue("@Type", Type);
                        cmd.Parameters.AddWithValue("@price", price);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("MemberShip Added successfully!");


                        }
                        else
                        {
                            MessageBox.Show("Failed to Add.");
                        }
                    }

                }



            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Addmember_Load(object sender, EventArgs e)
        {
            usertable1();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_user1();
            usertable1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_mem();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void box1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            usertable2();
        }
    }
}
