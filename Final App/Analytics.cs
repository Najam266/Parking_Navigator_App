﻿using APP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Analytics : Form
    {
        public Analytics()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cartypegraph cartypegraph = new Cartypegraph();
            cartypegraph.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            memgraph memgraph = new memgraph();
            memgraph.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            memfeedgraph memfeedgraph = new memfeedgraph();
            memfeedgraph.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Carcountsgrph carcountsgrph = new Carcountsgrph();
            carcountsgrph.Show();
        }
    }
}
