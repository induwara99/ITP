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
    public partial class MajorRepairUpdate : Form
    {
        public MajorRepairUpdate()
        {
            InitializeComponent();

            string invoiceNo = ViewRepairs.mjinvoiceNo;
            textBox2.Text = invoiceNo;
            textBox2.Enabled = false;
            textBox1.Enabled = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);

            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;

            loadMajorDetails();

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
                textBox5.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
            }
            con.Close();
        }

        public void loadMajorDetails()
        {
            sql = "SELECT repDate,descrip,type,sparePart,sparePrice,labour,labCharge FROM MajorRepair WHERE vehNo = '" + textBox5.Text + "' AND invoiceNo = '"+ textBox2.Text +"'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox7.Text = dr[1].ToString();

                if (dr[2].ToString() == "Repair")
                {
                    radioButton1.Checked = true;
                }
                else if (dr[2].ToString() == "Replace")
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton.Checked = true;
                }
                textBox8.Text = dr[3].ToString();
                textBox9.Text = dr[4].ToString();
                textBox10.Text = dr[5].ToString();
                textBox11.Text = dr[6].ToString();

         
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newdescrip = textBox7.Text;
            string newtype = "";
            bool isChecked;
            if (isChecked = radioButton1.Checked)
            {
                newtype = radioButton1.Text;
            }
            else if (isChecked = radioButton2.Checked)
            {
                newtype = radioButton2.Text;
            }
            else
            {
                newtype = radioButton.Text;
            }

            string newspare = textBox8.Text;
            string newprice = textBox9.Text;
            string labdet = textBox10.Text;
            string chr = textBox11.Text;

            if (!string.IsNullOrEmpty(newdescrip) && !string.IsNullOrEmpty(newtype) && !string.IsNullOrEmpty(newspare) && !string.IsNullOrEmpty(newprice) && !string.IsNullOrEmpty(labdet) && !string.IsNullOrEmpty(chr))
            {
                sql = "UPDATE MajorRepair SET descrip=@des,type=@typ,sparepart=@sp,sparePrice=@pri,labour=@lab,labCharge = @chr WHERE invoiceNo = '" + textBox2.Text + "'";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@des", newdescrip);
                cmd.Parameters.AddWithValue("@typ", newtype);
                cmd.Parameters.AddWithValue("@sp", newspare);
                cmd.Parameters.AddWithValue("@pri", newprice);
                cmd.Parameters.AddWithValue("@lab", labdet);
                cmd.Parameters.AddWithValue("@chr", chr);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");

                MajorRepairReportUpdate fm11 = new MajorRepairReportUpdate();
                this.Hide();
                fm11.Show();
            }
            else
            {
                MessageBox.Show("All fields should be filled!!!!!!!!!!!!");
            }


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ViewRepairs vp = new ViewRepairs();
            this.Hide();
            vp.Show();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            label20.Visible = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
