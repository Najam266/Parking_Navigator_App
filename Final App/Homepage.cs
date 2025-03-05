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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addnewuser addnewuser = new Addnewuser();
            addnewuser.Show();
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBooking addBooking = new AddBooking();
            addBooking.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginform loginform = new Loginform();
            loginform.ShowDialog();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Live live = new Live();
            live.Show();
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            Addmember addmember = new Addmember();
            addmember.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Leavepark leavepark = new Leavepark();
            leavepark.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Feedform feedform = new Feedform();
            feedform.ShowDialog();
        }
    }
}
