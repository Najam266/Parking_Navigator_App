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
    public partial class Parkingslot : Form
    {
        public Parkingslot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Disabledslots disabledslots = new Disabledslots();
            disabledslots.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Floor1slots floor1slots = new Floor1slots();
            floor1slots.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Floor2slots floor2slots = new Floor2slots();
            floor2slots.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Floor3slots floor3slots = new Floor3slots();
            floor3slots.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Evfloor evfloor = new Evfloor();
            evfloor.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Allslotsview allslotsview = new Allslotsview();
            allslotsview.Show();
        }
    }
}
