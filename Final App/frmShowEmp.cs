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
    public partial class frmShowEmp : Form
    {
        string connectionstring = "Data Source = C:\\Users\\apple\\source\\repos\\APP\\parking.db; version = 3";
        public frmShowEmp()
        {
            InitializeComponent();
        }

        private void showEmployees()
        {
           
            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM Employees";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void frmShowEmp_Load(object sender, EventArgs e)
        {
            showEmployees();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
