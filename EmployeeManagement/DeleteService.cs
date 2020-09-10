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
    public partial class DeleteService : Form
    {
        public DeleteService()
        {
            InitializeComponent();

            string invoiceNo = ViewRepairs.serinvoiceNo;
            textBox1.Text = invoiceNo;
            textBox1.Enabled = false;

            textBox5.Enabled = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //Setting Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd, cmd1,cmd2;
        SqlDataReader dr;

        string sql;
        string sql1;
        string sql2;

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

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "DELETE FROM MinorRepair WHERE invoiceNo = '" + textBox1.Text + "';";
            sql1 = "DELETE FROM Service WHERE invoiceNo = '" + textBox1.Text + "'; ;";
            sql2 = "DELETE FROM Notification WHERE invoiceNo = '" + textBox1.Text + "';";
            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd1 = new SqlCommand(sql1, con);
            cmd2 = new SqlCommand(sql2, con);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted Successfully");

            Form fm2 = new RepairCategory();
            this.Hide();
            fm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fm2 = new RepairCategory();
            this.Hide();
            fm2.Show();
        }
    }
}
