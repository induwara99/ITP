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
    public partial class ProfitManagement10 : Form
    {
        public ProfitManagement10()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
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
            ProfitManagement9 p9 = new ProfitManagement9();
            p9.Show();
        }
    }
}
