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
    public partial class Employee : Form
    {

        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_employee employee = new Add_employee();
            employee.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Employee employee = new Delete_Employee();
            employee.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Change_Pass changePass = new Change_Pass();
            changePass.ShowDialog();
        }

        private void btnCheckEmp_Click(object sender, EventArgs e)
        {
            frmShowEmp frm = new frmShowEmp();
            frm.Show();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }

}
    
