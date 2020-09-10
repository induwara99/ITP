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
    public partial class AddMajorRepair : Form
    {
        public AddMajorRepair()
        {
            InitializeComponent();

            autono();
            textBox2.Enabled = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            dateTimePicker1.Enabled = false;

           /* this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;*/

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
   
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        //Setting Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;

        string sql;
        public static String invoiceNo;
        bool Mode = true;

        //Generate auto number for invoice No
        public void autono()
        {
            sql = "SELECT invoiceNo FROM MajorRepair ORDER BY invoiceNo desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int no = int.Parse(dr[0].ToString()) + 1;
                invoiceNo = no.ToString("0000");
            }
            else if(Convert.IsDBNull(dr))
            {
                invoiceNo = "0000";
            }
            else
            {
                invoiceNo = "0000";
            }

            textBox2.Text = invoiceNo.ToString();

            con.Close();

        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            string invoiceNo = textBox2.Text;
            string vehNo = textBox5.Text;
            /*string model = textBox3.Text;
            string yom = textBox4.Text;*/
            string des = textBox7.Text;
            
            string type = "";
            bool isChecked;
            if (isChecked = radioButton1.Checked)
            {
                type = radioButton1.Text;
            }
            else if (isChecked = radioButton2.Checked)
            {
                type = radioButton2.Text;
            }
            else
            {
                type = radioButton.Text;
            }

            string spare = textBox8.Text;
            string spprice = textBox9.Text;
            string labdet = textBox10.Text;
            string labpri = textBox11.Text;

            if (!string.IsNullOrEmpty(des) && !string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(spare) && !string.IsNullOrEmpty(spprice) && !string.IsNullOrEmpty(labdet) && !string.IsNullOrEmpty(labpri))
            {
                if (Mode == true)
                {
                    sql = "INSERT INTO MajorRepair VALUES(@inNo,@date,@des,@type,@spare,@sprice,@labdet,@labpr,@vehNo);";
                    con.Open();
                    cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@inNo", invoiceNo);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@des", des);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@spare", spare);
                    cmd.Parameters.AddWithValue("@sprice", spprice);
                    cmd.Parameters.AddWithValue("@labdet", labdet);
                    cmd.Parameters.AddWithValue("@labpr", labpri);
                    cmd.Parameters.AddWithValue("@vehNo", vehNo);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Added successfully");

                    MajorRepairReport fm6 = new MajorRepairReport();
                    this.Hide();
                    fm6.Show();

                }
                else
                {
                    MessageBox.Show("Oops something went wrong");
                }
            }
            else
            {
                MessageBox.Show("All fields should be filled!!!!!!");
            }
        }

        //Getting the invoiceNo
        public static string getInvoice()
        {
            return invoiceNo;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RepairCategory rt = new RepairCategory();
            this.Hide();
            rt.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SearchVehicleR sr = new SearchVehicleR();
            this.Hide();
            sr.Show();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
                label11.Visible = true;
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            label20.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
