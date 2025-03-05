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
using System.Windows.Forms.DataVisualization.Charting;

namespace APP
{
    public partial class memgraph : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public memgraph()
        {
            InitializeComponent();
        }

        private void memgraph_Load(object sender, EventArgs e)
        {
            PlotMember();
        }
        

    private void PlotMember()
    {
        // Create a new chart
        Chart memberCountChart = new Chart();
        memberCountChart.Size = new System.Drawing.Size(600, 400);
        memberCountChart.Dock = DockStyle.Top;

        // Set chart title
        memberCountChart.Titles.Add("Member Count by Type");

        // Create chart area
        ChartArea chartArea = new ChartArea();
        memberCountChart.ChartAreas.Add(chartArea);


            chartArea.AxisX.Title = "Membership Types";


            chartArea.AxisY.Title = "Total Members";

            // Create series
            Series series = new Series();
        series.ChartType = SeriesChartType.Column;
        series.Name = "Member Count";
        memberCountChart.Series.Add(series);

        // SQL query to get count of members by type
        string query = @"SELECT Type, COUNT(*) AS MemberCount
                    FROM Members
                    GROUP BY Type";

        // Execute SQL query
        using (SQLiteConnection con = new SQLiteConnection(connectionstring))
        {
            con.Open();
            using (SQLiteCommand cmd = new SQLiteCommand(query, con))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    // Add data points to the series
                    while (reader.Read())
                    {
                        string type = reader["Type"].ToString();
                        int count = Convert.ToInt32(reader["MemberCount"]);
                        series.Points.AddXY(type, count);
                    }
                }
            }
        }

        // Add chart to the form
        this.Controls.Add(memberCountChart);
    }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
