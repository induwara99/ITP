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
    public partial class Homepage2 : Form
    {
        public Homepage2()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            EmployeeMain em = new EmployeeMain();
            this.Hide();
            em.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SearchVehicleR sr = new SearchVehicleR();
            this.Hide();
            sr.Show();
     
        }

        private void label5_Click(object sender, EventArgs e)
        {
            VehicleMain vh = new VehicleMain();
            this.Hide();
            vh.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            customerhome ch = new customerhome();
            this.Hide();
            ch.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form1 DM = new Form1();
            this.Hide();
            DM.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            EAMForm1 AM = new EAMForm1();
            this.Hide();
            AM.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            booking1 BM = new booking1();
            this.Hide();
            BM.Show();
        }
    }
}
