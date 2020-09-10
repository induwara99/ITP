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
    public partial class ProfitManagement8 : Form
    {
        public ProfitManagement8()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement9 f9 = new ProfitManagement9();
            f9.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement11 p11 = new ProfitManagement11();
            p11.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement12 p12 = new ProfitManagement12();
            p12.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement13 p13 = new ProfitManagement13();
            p13.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement7 p7 = new ProfitManagement7();
            p7.Show();
        }
    }
}
