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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Endbook leavepark = new Endbook();
            leavepark.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Policies_Updataion policies_Updataion   = new Policies_Updataion();
                policies_Updataion.ShowDialog();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingUser bookingUserbooking = new BookingUser();
            bookingUserbooking.ShowDialog();
        }
    }
}
