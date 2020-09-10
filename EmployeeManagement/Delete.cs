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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
            showDetails();
        }

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader sdr;
        String sql;
        SqlCommand cm;
        bool mode = true;
        String id;

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void employeeAttendance_Click(object sender, EventArgs e)
        {

        }

        private void VehicleManagement_Click(object sender, EventArgs e)
        {

        }

        private void vehicleManagement_Click(object sender, EventArgs e)
        {

        }

        private void driverManagemenr_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeManagement_Click(object sender, EventArgs e)
        {

        }

       

        private void dataview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataview1.Columns["Remove"].Index && e.RowIndex >= 0)
            {

                mode = false;
                id = dataview1.CurrentRow.Cells[0].Value.ToString();
                sql = "delete  from driverdetails where regno = @id";
                con.Open();
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@id", id);
                cm.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully");
                con.Close();
                showDetails();



            }

        }

        public void showDetails()
        {

            sql = "select * from driverdetails";
            cm = new SqlCommand(sql, con);
            con.Open();
            sdr = cm.ExecuteReader();
            dataview1.Rows.Clear();

            while (sdr.Read())
            {
                dataview1.Rows.Add(sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6]);
            }

            con.Close();

        }

        private void driverManagemenr_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            showDetails();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
