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
    public partial class TireChangeUpdate : Form
    {
        public TireChangeUpdate()
        {
            InitializeComponent();

            string invoiceNo = ViewRepairs.tirinvoiceNo;
            textBox2.Text = invoiceNo;
            textBox2.Enabled = false;
            textBox1.Enabled = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);

            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;

            loadMinorTireDetails();
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

        public void loadMinorTireDetails()
        {
            sql = "SELECT m.repDate,t.size,t.model,t.qty,t.unitPrice  FROM MinorRepair m,TireChange t WHERE m.invoiceNo = t.invoiceNo AND m.vehNo = '" + textBox5.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox7.Text = dr[1].ToString();
                textBox8.Text = dr[2].ToString();
                textBox9.Text = dr[3].ToString();
                textBox10.Text = dr[4].ToString();
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newsize = textBox7.Text;
            string model = textBox8.Text;
            string qty = textBox9.Text;
            string price = textBox10.Text;

            if (!string.IsNullOrEmpty(newsize) && !string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(qty) && !string.IsNullOrEmpty(price))
            {
                sql = "UPDATE TireChange SET size=@siz,model=@mod,qty=@qt,unitPrice=@pri WHERE invoiceNo = '" + textBox2.Text + "'";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@siz", newsize);
                cmd.Parameters.AddWithValue("@mod", model);
                cmd.Parameters.AddWithValue("@qt", qty);
                cmd.Parameters.AddWithValue("@pri", price);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");

                TireChangeReportUpdate fm13 = new TireChangeReportUpdate();
                this.Hide();
                fm13.Show();
            }
            else
            {
                MessageBox.Show("All fields should be filled!!!!!!!!!!!");
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ViewRepairs vp = new ViewRepairs();
            this.Hide();
            vp.Show();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            label13.Visible = true;
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            label16.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
