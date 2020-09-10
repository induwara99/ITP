using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VehicleManagement
{
    public partial class show : Form
    {
        public show()
        {
            InitializeComponent();
            display();
        }

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader sdr;
        String sql;
        SqlCommand cm;

        private void EmployeeManagement_Click(object sender, EventArgs e)
        {

        }

        private void show_Load(object sender, EventArgs e)
        {

        }

        private void driverManagemenr_Click(object sender, EventArgs e)
        {

        }

        private void customerManagement_Click(object sender, EventArgs e)
        {

        }

        private void vehicleManagement_Click(object sender, EventArgs e)
        {

        }

        private void vehicleRepair_Click(object sender, EventArgs e)
        {

        }

        private void VehicleManagement_Click(object sender, EventArgs e)
        {

        }

        private void employeeAttendance_Click(object sender, EventArgs e)
        {

        }

        private void profitManagement_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void driverManagemenr_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            display();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            

        }

        public void display()
        {

            DataTable dt = new DataTable();

            if (sRegNo.Text.Length > 0)
            {

                SqlDataAdapter sda = new SqlDataAdapter("select * from driverdetails where [regno] like '" + sRegNo.Text + "%' ", con);
                sda.Fill(dt);

            }
            else if (SName.Text.Length > 0)
            {

                SqlDataAdapter sda = new SqlDataAdapter("select * from driverdetails where [name] like '" + SName.Text + "%' ", con);
                sda.Fill(dt);

            }
            else if (SContactNo.Text.Length > 0)
            {

                SqlDataAdapter sda = new SqlDataAdapter("select * from driverdetails where [contactno] like '" + SContactNo.Text + "%' ", con);
                sda.Fill(dt);

            }
            dataview1.DataSource = dt;

        }

        private void sRegNo_TextChanged(object sender, EventArgs e)
        {
            SName.Clear();
            SContactNo.Clear();
            display();

        }

        private void SName_TextChanged(object sender, EventArgs e)
        {
            sRegNo.Clear();
            SContactNo.Clear();
            display();
        }

        private void SContactNo_TextChanged(object sender, EventArgs e)
        {
            sRegNo.Clear();
            SName.Clear();
            display();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
