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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain em = new EmployeeMain();
            em.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain vm = new VehicleMain();
            vm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void insertDriver_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertDriver id = new InsertDriver();
            id.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void retrieveDriver_Click(object sender, EventArgs e)
        {
            this.Hide();
            show show = new show();
            show.Show();
        }

        private void updateDriver_Click(object sender, EventArgs e)
        {
            this.Hide();
            edit edit = new edit();
            edit.Show();
        }

        private void driverManagemenr_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void deleteDriver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete del = new Delete();
            del.Show();
        }

        private void home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage2 hm = new Homepage2();
            hm.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void logOut1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void profitManagement_Click(object sender, EventArgs e)
        {

        }

        private void customerManagement_Click(object sender, EventArgs e)
        {

        }

        private void vehicleRepair_Click(object sender, EventArgs e)
        {

        }
    }
}
