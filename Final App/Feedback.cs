using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goldfeed goldfeed = new Goldfeed();
            goldfeed.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Silverfeed silverfeed = new Silverfeed();
            silverfeed.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Allfeeds allfeeds = new Allfeeds();
            allfeeds.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BronzeFeed bronze = new BronzeFeed();
            bronze.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Nonfeed nonfeed = new Nonfeed();
            nonfeed.ShowDialog();
        }
    }
}
