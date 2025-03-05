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
    public partial class AddBooking : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";
        public AddBooking()
        {
            InitializeComponent();
        }
        private void add_user()
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
                }


                string query = "INSERT INTO user (Name,Phone_no) VALUES (@name,@phone)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Added succesfully!");

                    }
                    else
                    {
                        MessageBox.Show("Failed to insert user.");
                    }

                }
            }


        }

        private void showtable()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT Name,Registration_No,Car_Type FROM Parking";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView3.DataSource = dt;
                    }
                }
            }

        }
        private void AddBooking_Load(object sender, EventArgs e)
        {
            usertable();
            showtable();

            showSlot("Floor1");
        }
        private void add_further()
        {
            string ID = textid.Text;
            string name = textname.Text;
            string phone = textphone.Text;
            string vehicle = boxtype.SelectedItem?.ToString();
            string registration = carno.Text;
            string Hours = boxhrs.SelectedItem?.ToString(); // Assuming the combo box is named boxhrs
            string floor = boxfloor.SelectedItem?.ToString(); // Assuming the combo box is named boxfloor
            DateTime date = dateTimePicker1.Value; // Get the date from DateTimePicker
            string slot = textslot.Text;
            string info = "Yes";

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(vehicle)
                || string.IsNullOrWhiteSpace(registration) || string.IsNullOrWhiteSpace(Hours)
            || string.IsNullOrWhiteSpace(floor) || string.IsNullOrWhiteSpace(slot) || string.IsNullOrWhiteSpace(ID))
            {
                MessageBox.Show("Please enter all details");
                return;
            }

            int price = 0;



            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query2 = "INSERT INTO Parking (UserID,Name,Registration_No,Car_Type,Hours,Price,Date,Floor_no,Slot) VALUES (@ID,@name, @registration,@vehicle,@Hours,@price,@date,@floor,@slot)";
                using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                {

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@registration", registration);
                    cmd.Parameters.AddWithValue("@vehicle", vehicle);
                    cmd.Parameters.AddWithValue("@Hours", Hours);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@floor", floor);
                    cmd.Parameters.AddWithValue("@slot", slot);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Parked successfully!");

                    }
                    else
                    {
                        MessageBox.Show("Failed to Park User.");
                    }
                }

            }
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                string query3 = "INSERT INTO History (UserID,Name,Registration_No,Car_Type,Hours,Price,Date,Floor_no,Slot) VALUES (@ID,@name, @registration,@vehicle,@Hours,@price,@date,@floor,@slot)";
                using (SQLiteCommand cmd = new SQLiteCommand(query3, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@registration", registration);
                    cmd.Parameters.AddWithValue("@vehicle", vehicle);
                    cmd.Parameters.AddWithValue("@Hours", Hours);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@floor", floor);
                    cmd.Parameters.AddWithValue("@slot", slot);
                    

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User Added In History successfully!");
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to add User to history.");
                    }
                }

            }
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                string query4 = "Update History set Booking=@info where UserID=@ID AND Name=@name AND Registration_No=@registration";
                using (SQLiteCommand cmd = new SQLiteCommand(query4, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@registration", registration);
                    cmd.Parameters.AddWithValue("@info", info);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Booked");
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to add User to history.");
                    }
                }
               

            

            }
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();
                string query5 = "Update Parking set Booking=@info where UserID=@ID AND Name=@name AND Registration_No=@registration";
                using (SQLiteCommand cmd = new SQLiteCommand(query5, con))
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@registration", registration);
                    cmd.Parameters.AddWithValue("@info", info);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to add User to history.");
                    }
                }



            }
            bool userExists = false;
            using (SQLiteConnection con2 = new SQLiteConnection(connectionstring))
            {
                con2.Open();

                string checkQuery = "SELECT COUNT(*) FROM Members WHERE UserID = @ID AND Name = @name AND RegistrationNo = @registration";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con2))
                {
                    checkCmd.Parameters.AddWithValue("@ID", ID);
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@registration", registration);
                    int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (existingCount > 0)
                    {
                        userExists = true;
                    }
                }
            }
            if (userExists)
            {
                // Update the Parking and History tables
                using (SQLiteConnection con3 = new SQLiteConnection(connectionstring))
                {
                    con3.Open();
                    string updateQuery = "UPDATE Parking SET Membership_status = 'Yes' WHERE UserID = @ID AND Name = @name AND Registration_No = @registration";
                    using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, con3))
                    {
                        updateCmd.Parameters.AddWithValue("@ID", ID);
                        updateCmd.Parameters.AddWithValue("@name", name);
                        updateCmd.Parameters.AddWithValue("@registration", registration);
                        int parkingRowsAffected = updateCmd.ExecuteNonQuery();

                    }

                    // Update the History table
                    string updateQuery2 = "UPDATE History SET Membership_status = 'Yes' WHERE UserID = @ID AND Name = @name AND Registration_No = @registration";
                    using (SQLiteCommand updateCmd2 = new SQLiteCommand(updateQuery2, con3))
                    {
                        updateCmd2.Parameters.AddWithValue("@ID", ID);
                        updateCmd2.Parameters.AddWithValue("@name", name);
                        updateCmd2.Parameters.AddWithValue("@registration", registration);
                        int historyRowsAffected = updateCmd2.ExecuteNonQuery();

                    }
                }

            }
            fillprice();
        }
        private void fillprice()
        {
            string ID = textid.Text;
            string name = textname.Text;
            string registration = carno.Text;
            string Hours = boxhrs.SelectedItem?.ToString();
            string vehicle = boxtype.SelectedItem?.ToString();
            string type = "";
            int hours;

            if (!int.TryParse(Hours, out hours))
            {
                hours = 0;
            }

            int price;

            if (existcheck())
            {
                type = typecheck();

            }

            if (type == "Gold")
            {
                price = fetchprice("Gold");
                price = price * hours;

            }
            else if (type == "Silver")
            {
                price = fetchprice("Silver");
                price = price * hours;
            }
            else if (type == "Bronze")
            {
                price = fetchprice("Bronze");
                price = price * hours;
            }
            else
            {
                price = fetchprice("Simpleprice");
                price = price * hours;
            }

            updateprice(price);



        }
        private int fetchprice(string ct)
        {
            string name = ct;
            string vehicle = boxtype.SelectedItem?.ToString();
            int price = 0;
            if (string.IsNullOrEmpty(ct))
            {
                return 0;
            }
            using (SQLiteConnection con2 = new SQLiteConnection(connectionstring))
            {
                con2.Open();

                string checkQuery = $"SELECT {name} FROM Pricing WHERE CarType = @vehicle";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con2))
                {
                    checkCmd.Parameters.AddWithValue("@vehicle", vehicle);
                    object result = checkCmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int priceFromDb))
                    {
                        price = priceFromDb; // Assign the retrieved price to the variable
                    }
                }


            }



            return price;
        }
        private string typecheck()
        {
            string ID = textid.Text;
            string name = textname.Text;
            string registration = carno.Text;
            string type = null; // Initialize the variable to hold the result

            using (SQLiteConnection con2 = new SQLiteConnection(connectionstring))
            {
                con2.Open();

                string checkQuery = "SELECT Type FROM Members WHERE UserID = @ID AND Name = @name AND RegistrationNo = @registration";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con2))
                {
                    checkCmd.Parameters.AddWithValue("@ID", ID);
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@registration", registration);
                    object result = checkCmd.ExecuteScalar(); // ExecuteScalar returns a single value

                    if (result != null) // Check if a value was returned
                    {
                        type = result.ToString(); // Assign the value to the type variable
                    }
                }
            }

            return type; // Return the value fetched from the database
        }

        private void updateprice(int price)
        {
            string ID = textid.Text;
            string name = textname.Text;
            string registration = carno.Text;
            int typ = price;
            using (SQLiteConnection con10 = new SQLiteConnection(connectionstring))
            {
                con10.Open();
                string updateQuery = $"UPDATE Parking SET Price = {typ} WHERE UserID = @ID AND Name = @name AND Registration_No = @registration";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, con10))
                {
                    updateCmd.Parameters.AddWithValue("@ID", ID);
                    updateCmd.Parameters.AddWithValue("@name", name);
                    updateCmd.Parameters.AddWithValue("@registration", registration);
                    int parkingRowsAffected = updateCmd.ExecuteNonQuery();
                }
            }
            using (SQLiteConnection con11 = new SQLiteConnection(connectionstring))
            {
                con11.Open();
                string updateQuery = $"UPDATE History SET Price = {typ} WHERE UserID = @ID AND Name = @name AND Registration_No = @registration";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, con11))
                {
                    updateCmd.Parameters.AddWithValue("@ID", ID);
                    updateCmd.Parameters.AddWithValue("@name", name);
                    updateCmd.Parameters.AddWithValue("@registration", registration);
                    int parkingRowsAffected = updateCmd.ExecuteNonQuery();
                }
            }
        }
        private bool existcheck()
        {
            string ID = textid.Text;
            string name = textname.Text;
            string registration = carno.Text;
            bool userExists1 = false;
            using (SQLiteConnection con2 = new SQLiteConnection(connectionstring))
            {
                con2.Open();

                string checkQuery = "SELECT count(*) FROM Members WHERE UserID = @ID AND Name = @name AND RegistrationNo = @registration";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con2))
                {
                    checkCmd.Parameters.AddWithValue("@ID", ID);
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@registration", registration);
                    int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (existingCount > 0)
                    {
                        userExists1 = true;
                    }
                }

                if (userExists1)
                {

                    return true;

                }
                else
                {
                    // User does not exist in the Members table, show a message

                    return false;

                }
            }
        }



        private void usertable()
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
        private void floorshow()
        {

            string floor = boxfloor.SelectedItem?.ToString();
            if (floor == "1")
            {
                showSlot("FLoor1");
            }
            if (floor == "2")
            {
                showSlot("FLoor2");
            }
            if (floor == "3")
            {
                showSlot("FLoor3");
            }
            if (floor == "4")
            {
                showSlot("EV");
            }
            if (floor == "5")
            {
                showSlot("Disabled");
            }


        }
        private void showSlot(string tableName)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = $"SELECT Slot,Status FROM {tableName}";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView2.DataSource = dt;
                    }
                }
            }
        }
        private void selectslot()
        {
            string vehicle = boxtype.SelectedItem?.ToString();
            string floor = boxfloor.SelectedItem?.ToString(); // Assuming the combo box is named boxfloor
            //string slot = textslot.Text;
            if (floor == "1" && vehicle != "EV")
            {
                fillslot("Floor1");

            }
            else if (floor == "2" && vehicle != "EV")
            {

                fillslot("Floor2");
            }

            else if (floor == "3" && vehicle != "EV")
            {

                fillslot("Floor3");
            }

            else if (floor == "4" && vehicle != "EV")
            {

                fillslot("Disabled");
            }
            else if (floor == "5" && vehicle == "EV")
            {

                fillslot("EV");
            }
            else
            {

                MessageBox.Show("Wrong floor selected try again!");
                return;
            }


        }
        private bool checkings(string f)
        {
            string slot = textslot.Text;

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query2 = $"select Status from {f} where Slot=@slot";
                using (SQLiteCommand cmd = new SQLiteCommand(query2, con))
                {

                    cmd.Parameters.AddWithValue("@slot", slot);
                    object exis = cmd.ExecuteScalar();

                    if (exis != null)
                    {
                        string statusValue = exis.ToString();
                        if (statusValue == "Occupied")
                        {
                            MessageBox.Show("Selected Slot is not empty on this floor.");
                            return false;
                        }
                        else if (statusValue == "Vacant")
                        {
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Slot not found on this floor.");
                        return false;
                    }


                }
            }
            return false;

        }
        private void fillslot(string FLOOR)
        {
            string f = FLOOR;
            if (checkings(f))
            {
                string ID = textid.Text;
                string registration = carno.Text;
                string slot = textslot.Text;
                string mess = "Occupied";
                using (SQLiteConnection con = new SQLiteConnection(connectionstring))
                {
                    con.Open();

                    string query = $"UPDATE {FLOOR} SET User_id = @ID, PlateNo = @registration, Status = @mess WHERE Slot = @slot";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.Parameters.AddWithValue("@registration", registration);
                        cmd.Parameters.AddWithValue("@mess", mess);
                        cmd.Parameters.AddWithValue("@slot", slot);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            add_further();
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert employee.");
                        }
                    }
                }
            }
            else
            {
                return;
            }

        }

       
        private bool parkingcheck()
        {
            string ID = textid.Text;
            string name = textname.Text;
            string registration = carno.Text;



            using (SQLiteConnection con2 = new SQLiteConnection(connectionstring))
            {
                con2.Open();

                string checkQuery = "SELECT count(*) FROM Parking WHERE UserID = @ID AND Name = @name AND Registration_No = @registration";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkQuery, con2))
                {
                    checkCmd.Parameters.AddWithValue("@ID", ID);
                    checkCmd.Parameters.AddWithValue("@name", name);
                    checkCmd.Parameters.AddWithValue("@registration", registration);
                    int existingCount = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (existingCount > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }


            }
        }

        private void add_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            add_user();
            usertable();
        }

        private void add_Click_1(object sender, EventArgs e)
        {
            if (parkingcheck())
            {
                selectslot();
              
              
            }
            else
            {
                MessageBox.Show("User already in the Parking !");
                return;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            floorshow();
        }
    }
}
