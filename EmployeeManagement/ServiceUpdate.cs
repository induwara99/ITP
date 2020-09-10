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
    public partial class ServiceUpdate : Form
    {
        public ServiceUpdate()
        {
            InitializeComponent();

            string invoiceNo = ViewRepairs.serinvoiceNo;
            textBox2.Text = invoiceNo;
            textBox2.Enabled = false;
            textBox6.Enabled = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);

            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;

            loadMinorServiceDetails();
        }

        private void label6_Click(object sender, EventArgs e)
        {

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

        public void loadMinorServiceDetails()
        {
            sql = "SELECT m.repDate,s.type,s.descrip,s.amount  FROM MinorRepair m,Service s WHERE m.invoiceNo = s.invoiceNo AND m.vehNo = '" + textBox5.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            { 
                textBox6.Text = dr[0].ToString();
                if (dr[1].ToString() == "Full-service")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox12.Text = dr[2].ToString();
                textBox13.Text = dr[3].ToString();
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string type = "";
            bool isChecked;
            if (isChecked = radioButton1.Checked)
            {
                type = radioButton1.Text;
            }
            else
            {
                type = radioButton2.Text;
            }
            string newdescrip = textBox12.Text;
            string newamount = textBox13.Text;

            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(newdescrip) && !string.IsNullOrEmpty(newamount))
            {
                sql = "UPDATE Service SET type=@typ,descrip=@des,amount=@amt WHERE invoiceNo = '" + textBox2.Text + "'";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@typ", type);
                cmd.Parameters.AddWithValue("@des", newdescrip);
                cmd.Parameters.AddWithValue("@amt", newamount);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");

                ServiceReportUpdate fm13 = new ServiceReportUpdate();
                this.Hide();
                fm13.Show();
            }
            else
            {
                MessageBox.Show("All fields should be filled!!!!!!!!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ViewRepairs vp = new ViewRepairs();
            this.Hide();
            vp.Show();
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            label23.Visible = true;
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
    }
}
