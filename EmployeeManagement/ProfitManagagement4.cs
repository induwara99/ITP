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
    public partial class ProfitManagagement4 : Form
    {
        public ProfitManagagement4()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement33 p3 = new ProfitManagement33();
            p3.Show();
        }
    }
}
