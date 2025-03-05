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
    public partial class Revenue : Form
    {
        public Revenue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TotProfits totProfits = new TotProfits();
            totProfits.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profitbytype profitbytype = new Profitbytype();
            profitbytype.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Profitbymembers profitbymembers = new Profitbymembers();
            profitbymembers.Show();
        }
    }
}
