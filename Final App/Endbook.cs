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
    public partial class Endbook : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";
        public Endbook()
        {
            InitializeComponent();
        }
        private void showtable()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT Name,Registration_No,Car_Type FROM Parking where Booking='Yes' ";

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
       
        private void check_park()
        {
            string name = textname.Text;
            string Reg = textreg.Text;



            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(Reg))
            {
                MessageBox.Show("Please enter all details");
                return;
            }


            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                // Check if the user already exists
                string checkQuery = "SELECT Car_Type FROM Parking WHERE Name = @name AND Registration_No = @Reg and Booking='Yes'";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@Reg", Reg);

                    object userId = checkCmd.ExecuteScalar();

                    if (userId != null)
                    {
                        MessageBox.Show($"  User car type is\n\nCarType: {userId}");
                        return; // Exit the function without adding the user
                    }
                    else
                    {
                        MessageBox.Show("  User do not exists in Database");
                        return; //
                    }
                }



            }


        }
        private void remove()
        {

            string name = textname.Text;
            string Reg = textreg.Text;
            string type = crtyp.SelectedItem?.ToString();
            string mess = "Vacant";
            int Floor;
            int Slot;
            string fl = "";



            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(Reg) || string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Please enter all details");
                return;
            }


            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                string c1 = "SELECT Floor_No FROM Parking WHERE Name = @name and Registration_No = @Reg and Car_Type=@type";
                string c2 = "SELECT Slot FROM Parking WHERE Name = @name and Registration_No = @Reg and Car_Type=@type";
                using (SQLiteCommand checkCmd = new SQLiteCommand(c1, con))
                {
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@Reg", Reg);
                    checkCmd.Parameters.AddWithValue("@type", type);
                    Floor = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (Floor == 1)
                    {
                        fl = "Floor1";
                    }
                    if (Floor == 2)
                    {
                        fl = "Floor2";
                    }
                    if (Floor == 3)
                    {
                        fl = "Floor3";

                    }
                    if (Floor == 4)
                    {
                        fl = "EV";
                    }
                    if (Floor == 5)
                    {
                        fl = "Disabled";
                    }

                }
                using (SQLiteCommand checkCmd = new SQLiteCommand(c2, con))
                {
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@Reg", Reg);
                    checkCmd.Parameters.AddWithValue("@type", type);
                    Slot = Convert.ToInt32(checkCmd.ExecuteScalar());

                }
                string c3 = $"UPDATE {fl} SET User_id =0, PlateNo = 0, Status = @mess WHERE Slot = @Slot";
                using (SQLiteCommand cmd = new SQLiteCommand(c3, con))
                {

                    cmd.Parameters.AddWithValue("@mess", mess);
                    cmd.Parameters.AddWithValue("@Slot", Slot);



                }
                string query = "Delete from Parking where Name=@name and Registration_No=@Reg and Car_Type=@type";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@Reg", Reg);
                    cmd.Parameters.AddWithValue("@type", type);



                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        DialogResult result = MessageBox.Show("User removed from Parking successfully!\nDo you want to Give Feedback?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Code to navigate to another form
                            // For example:
                            Feedform anotherForm = new Feedform();
                            anotherForm.TopMost = true;
                            anotherForm.Show();


                            // Close the current form
                            this.Close();
                        }
                        else
                        {
                            // Do nothing or return
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Failed to Delete user.");
                    }

                }
            }

        }
        private void Endbook_Load(object sender, EventArgs e)
        {
            showtable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check_park();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            remove();
        }
    }
}
