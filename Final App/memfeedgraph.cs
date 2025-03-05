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
    public partial class memfeedgraph : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public memfeedgraph()
        {
            InitializeComponent();
        }

        private void memfeedgraph_Load(object sender, EventArgs e)
        {
            PlotFeedbackCountByType();
        }
        

    private void PlotFeedbackCountByType()
    {
        // Create a new chart
        Chart feedbackCountChart = new Chart();
        feedbackCountChart.Size = new System.Drawing.Size(600, 400);
        feedbackCountChart.Dock = DockStyle.Top;

        // Set chart title
        feedbackCountChart.Titles.Add("Feedback Count by Type");

        // Create chart area
        ChartArea chartArea = new ChartArea();
        feedbackCountChart.ChartAreas.Add(chartArea);
            chartArea.AxisX.Title = "Membership Types";


            chartArea.AxisY.Title = "Total feedbacks";

            // Create series
            Series series = new Series();
        series.ChartType = SeriesChartType.Column;
        series.Name = "Feedback Count";
        feedbackCountChart.Series.Add(series);

        // SQL query to get count of feedbacks by Type
        string query = @"SELECT m.Type, COUNT(f.FeedId) AS FeedbackCount
                    FROM Members m
                    LEFT JOIN Feed f ON m.UserId = f.UserId
                    GROUP BY m.Type";

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
                        int count = Convert.ToInt32(reader["FeedbackCount"]);
                        series.Points.AddXY(type, count);
                    }
                }
            }
        }

        // Add chart to the form
        this.Controls.Add(feedbackCountChart);
    }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
