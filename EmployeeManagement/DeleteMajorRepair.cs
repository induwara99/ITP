using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class DeleteMajorRepair : Form
    {
        public DeleteMajorRepair()
        {
            InitializeComponent();

            string invoiceNo = ViewRepairs.mjinvoiceNo;
            textBox1.Text = invoiceNo;
            textBox1.Enabled = false;
            textBox5.Enabled = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "DELETE FROM MajorRepair WHERE invoiceNo = '" + textBox1.Text + "'";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted Successfully");

            Form fm2 = new RepairCategory();
            this.Hide();
            fm2.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //Setting Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;

        string sql;

        //Getting the vehicle Details
        public void getVehicleDetails(String vehNo)
        {
            sql = "SELECT * FROM Vehicle WHERE vehNo = '" + vehNo + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox5.Text = dr[0].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fm2 = new RepairCategory();
            this.Hide();
            fm2.Show();
        }
    }
}
