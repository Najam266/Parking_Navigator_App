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
    public partial class Carcountsgrph : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";
        public Carcountsgrph()
        {
            InitializeComponent();
        }

       
    private void PlotCarTypeCount()
    {
        // Create a new chart
        Chart carTypeChart = new Chart();
        carTypeChart.Size = new System.Drawing.Size(600, 400);
        carTypeChart.Dock = DockStyle.Fill;

        // Set chart title
        carTypeChart.Titles.Add("Car Type Count");

        // Create chart area
        ChartArea chartArea = new ChartArea();
        carTypeChart.ChartAreas.Add(chartArea);

        // Set X axis label
        chartArea.AxisX.Title = "Car Type";

        // Set Y axis label
        chartArea.AxisY.Title = "Count";

        // Create series
        Series series = new Series();
        series.ChartType = SeriesChartType.Column;
        series.Name = "Car Type Count";
        carTypeChart.Series.Add(series);

        // SQL query to retrieve car type count data
        string query = @"SELECT Car_Type, COUNT(*) AS CarTypeCount
                    FROM History
                    GROUP BY Car_Type";

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
                        string carType = reader["Car_Type"].ToString();
                        int carTypeCount = Convert.ToInt32(reader["CarTypeCount"]);
                        series.Points.AddXY(carType, carTypeCount);
                    }
                }
            }
        }

        // Add chart to the form
        this.Controls.Add(carTypeChart);
    }

    private void Carcountsgrph_Load(object sender, EventArgs e)
        {
            PlotCarTypeCount();
        }
    }
}
