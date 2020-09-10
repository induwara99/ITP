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
    public partial class EmployeeMain : Form
    {
        public EmployeeMain()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VehicleMain vh = new VehicleMain();
            this.Hide();
            vh.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeRegistration c = new EmployeeRegistration();
            c.Show();
        }

        private void EmployeeMain_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeUpdateDelete Ud = new EmployeeUpdateDelete();
            Ud.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
           SearchEmployee SE = new SearchEmployee();
            SE.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SearchVehicleR vh = new SearchVehicleR();
            this.Hide();
            vh.Show();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Homepage2 vh = new Homepage2();
            this.Hide();
            vh.Show();
        }
    }
}
