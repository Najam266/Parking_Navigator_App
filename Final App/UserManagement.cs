using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace APP
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            userprofile up = new userprofile();
            up.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BookingUser bookingUser = new BookingUser();
            bookingUser.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regularuser regularuser = new Regularuser();
            regularuser.ShowDialog();
        }
    }
}
