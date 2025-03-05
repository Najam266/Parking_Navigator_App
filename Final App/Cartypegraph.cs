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

    public partial class Cartypegraph : Form
    {
        string connectionstring = "Data Source=C:\\Users\\apple\\source\\repos\\APP\\parking.db;Version=3;foreign keys=true;";

        public Cartypegraph()
        {
            InitializeComponent();
        }

        private void Cartypegraph_Load(object sender, EventArgs e)
        {
            PlotRevenueByCarType();

        }
        private void PlotRevenueByCarType()
        {

            Chart revenueChart = new Chart();
            revenueChart.Size = new System.Drawing.Size(600, 400);
            revenueChart.Dock = DockStyle.Top;

            
            revenueChart.Titles.Add("Total Revenue by Car Type");

           
            ChartArea chartArea = new ChartArea();
            revenueChart.ChartAreas.Add(chartArea);

          
            chartArea.AxisX.Title = "Car Type";

           
            chartArea.AxisY.Title = "Total Revenue";

            // Create series
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.Name = "Total Revenue";
            series["PixelPointWidth"] = "20";
            revenueChart.Series.Add(series);


            string query = @"SELECT Car_Type, SUM(Price) AS TotalRevenue
                    FROM History
                    GROUP BY Car_Type";

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
                            int totalRevenue = Convert.ToInt32(reader["TotalRevenue"]);
                            series.Points.AddXY(carType, totalRevenue);
                        }
                    }
                }
            }

            this.Controls.Add(revenueChart);
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
