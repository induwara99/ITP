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
    public partial class ServiceReportUpdate : Form
    {
        public ServiceReportUpdate()
        {
            InitializeComponent();

            string invoice = ViewRepairs.serinvoiceNo;

            textBox2.Text = invoice;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);
            textBox6.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;

            load();

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
                textBox3.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
            }
            con.Close();
        }

        public void load()
        {
            sql = "SELECT m.invoiceNo,m.repDate,s.type,s.descrip,s.amount FROM MinorRepair m,Service s WHERE m.invoiceNo = s.invoiceNo AND s.invoiceNo = '" + textBox2.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3],dr[4]);
                textBox6.Text = dr[4].ToString();
                textBox1.Text = dr[1].ToString();
            }

            con.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            RepairCategory rt = new RepairCategory();
            this.Hide();
            rt.Show();
        }
    }
}
