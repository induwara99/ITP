using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement1 p1 = new ProfitManagement1();
            p1.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement8 f8 = new ProfitManagement8();
            f8.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement20 p20 = new ProfitManagement20();
            p20.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage2 f1 = new Homepage2();
            f1.Show();
        }
    }
}
