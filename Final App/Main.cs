using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WindowsFormsApp1;
using WindowsFormsApp2;

namespace APP
{
    public partial class Main : Form 
    {


        public Main()
        {
            InitializeComponent();

            Loginform form = new Loginform();
            form.ShowDialog();
            form.Close();
            LoadForm(new Afterlogin());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new Developers());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrice_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_2(object sender, EventArgs e)
        {

        }
        public void LoadForm(Form form)
        {

            this.Formloader.Controls.Clear();

            Form newForm = (Form)Activator.CreateInstance(form.GetType());

            newForm.Dock = DockStyle.Fill;
            newForm.TopLevel = false;
            newForm.TopMost = true;
            newForm.FormBorderStyle = FormBorderStyle.None;
            
            this.Formloader.Controls.Add(newForm);

            newForm.Show();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadForm(new Homepage());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            LoadForm(new UserManagement());
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {

            LoadForm(new Analytics());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadForm(new Feedback());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LoadForm(new History());    
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            LoadForm(new Membership());

        }

        private void btnPrice_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Pricing());
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            LoadForm(new Reservation());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadForm(new Employee());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadForm(new Revenue ());
        }

        private void btnParkslot_Click(object sender, EventArgs e)
        {
            LoadForm(new Parkingslot());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LoadForm(new Afterlogin());

        }

        private void Formloader_Paint(object sender, PaintEventArgs e)
        {
            LoadForm(new Afterlogin());
        }

        private void pictureBox3_Click_3(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
