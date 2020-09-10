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
    public partial class booking8 : Form
    {
        public booking8()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            booking5 b5 = new booking5();
            b5.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            booking1 b1 = new booking1();
            b1.Show();
        }
    }
}
