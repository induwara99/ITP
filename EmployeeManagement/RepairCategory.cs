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
    public partial class RepairCategory : Form
    {
        public RepairCategory()
        {
            InitializeComponent();

            label7.Text = SearchVehicleR.getVehNo();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddMajorRepair fm3 = new AddMajorRepair();
            this.Hide();
            fm3.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddMinorRepair fm4 = new AddMinorRepair();
            this.Hide();
            fm4.Show();
        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViewRepairs fm9 = new ViewRepairs();
            this.Hide();
            fm9.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SearchVehicleR sr1 = new SearchVehicleR();
            this.Hide();
            sr1.Show();
        }


    }
}
