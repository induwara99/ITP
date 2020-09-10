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
    public partial class MajorRepairReportUpdate : Form
    {
        public MajorRepairReportUpdate()
        {
            InitializeComponent();

            string invoice = ViewRepairs.mjinvoiceNo;

            textBox2.Text = invoice;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);
            textBox6.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;

            load();

            float total = calcTotal();
            textBox1.Text = total.ToString();

            textBox1.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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
                textBox3.Text = dr[0].ToString();
                textBox5.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
            }
            con.Close();
        }

        //Calculate Total Variable
        float sparePrice;
        float labPrice;

        //REtrieve data to the table
        public void load()
        {
            sql = "SELECT * FROM MajorRepair WHERE invoiceNo = '" + textBox2.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);

                sparePrice = float.Parse(dr[5].ToString());
                labPrice = float.Parse(dr[7].ToString());
                textBox6.Text = dr[1].ToString();
            }

            con.Close();
        }


        //Calculate the Total
        public float calcTotal()
        {
            return sparePrice + labPrice;
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            RepairCategory rt = new RepairCategory();
            this.Hide();
            rt.Show();
        }
    }
}
