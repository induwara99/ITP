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
    public partial class VehicleMain : Form
    {
        public VehicleMain()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleRegistration c = new VehicleRegistration();
            c.Show();
        }

        private void EmployeeMain_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleUpdateDelete Ud = new VehicleUpdateDelete();
            Ud.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
           SearchVehicle SE = new SearchVehicle();
            SE.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            EmployeeMain em = new EmployeeMain();
            em.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Homepage2 vh = new Homepage2();
            this.Hide();
            vh.Show();
        }
    }
}
