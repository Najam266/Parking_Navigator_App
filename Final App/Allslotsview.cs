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
    public partial class Allslotsview : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Allslotsview()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void showslotEV()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM EV";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView4.DataSource = dt;
                    }
                }
            }
        }
        private void showslot1()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM Floor1 ";

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
        private void showslot2()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM Floor2 ";

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
        private void showslot3()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM Floor3 ";

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
        private void showslotDis()
        {

            using (SQLiteConnection con = new SQLiteConnection(connectionstring))
            {
                con.Open();

                string query = "SELECT * FROM Disabled ";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();

                        dt.Load(reader);

                        dataGridView5.DataSource = dt;
                    }
                }
            }
        }

        private void Allslotsview_Load(object sender, EventArgs e)
        {
            showslot1();
            showslot2();
            showslot3();
            showslotDis();
            showslotEV();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
