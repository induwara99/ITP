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
    public partial class AddMinorRepair : Form
    {
        public AddMinorRepair()
        {
            InitializeComponent();

            autonoNotify();
            autono();
            textBox2.Enabled = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            label25.Enabled = false;
            dateTimePicker2.Enabled = false;

            groupBox1.Enabled = false;
            groupBox2.Enabled = false;

            dateTimePicker1.Enabled = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        //Setting Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd,cmd1,cmd2;
        SqlDataReader dr;

        string sql;
        string sql1;
        string sql2;
        public static String invoiceNo;

        bool Mode = true;

        public void autono()
        {
            sql = "SELECT invoiceNo FROM MinorRepair ORDER BY invoiceNo desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int no = int.Parse(dr[0].ToString()) + 1;
                invoiceNo = no.ToString("0000");
            }
            else if (Convert.IsDBNull(dr))
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

        public static String NotifyID;

        public void autonoNotify()
        {
            sql = "SELECT notifyID FROM Notification ORDER BY notifyID desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int no = int.Parse(dr[0].ToString()) + 1;
                NotifyID = no.ToString("0000");
            }
            else if (Convert.IsDBNull(dr))
            {
                NotifyID = "0000";
            }
            else
            {
                NotifyID = "0000";
            }
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            bool ischecked;
            if (ischecked = radioButton3.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            bool ischecked;
            if (ischecked = radioButton4.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            string invoiceNo = textBox2.Text;
            string vehNo = textBox5.Text;
            string size = textBox7.Text;
            string model = textBox8.Text;
            string qty = textBox9.Text;
            string price = textBox10.Text;

            if (!string.IsNullOrEmpty(size) && !string.IsNullOrEmpty(model) && !string.IsNullOrEmpty(qty) && !string.IsNullOrEmpty(price))
            {
                if (Mode == true)
                {
                    sql = "INSERT INTO MinorRepair VALUES(@inNo,@date,@vehNo);";
                    sql1 = "INSERT INTO TireChange VALUES(@inNo,@siz,@mod,@qty,@price);";

                    con.Open();
                    cmd = new SqlCommand(sql, con);
                    cmd1 = new SqlCommand(sql1, con);
                    cmd.Parameters.AddWithValue("@inNo", invoiceNo);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@vehNo", vehNo);
                    cmd1.Parameters.AddWithValue("@inNo", invoiceNo);
                    cmd1.Parameters.AddWithValue("@siz", size);
                    cmd1.Parameters.AddWithValue("@mod", model);
                    cmd1.Parameters.AddWithValue("@qty", qty);
                    cmd1.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Record Added Successfully");

                    TireChangeReport fm7 = new TireChangeReport();
                    this.Hide();
                    fm7.Show();
                }
                else
                {
                    MessageBox.Show("Oops something went wrong");
                }
            }
            else
            {
                MessageBox.Show("All the fields should be filled!!!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Text;
            string invoiceNo = textBox2.Text;
            string vehNo = textBox5.Text;
            DateTime nextDate = dateTimePicker2.Value.Date;
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

            string descrip = textBox12.Text;
            string price = textBox13.Text;

            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(descrip) && !string.IsNullOrEmpty(price))
            {
                if (Mode == true)
                {
                    sql = "INSERT INTO MinorRepair VALUES(@inNo,@date,@vehNo);";
                    sql1 = "INSERT INTO Service VALUES(@inNo,@typ,@des,@price);";
                    sql2 = "INSERT INTO Notification VALUES(@notId,@vvehNo,@nexDate,@invoice);";
                    con.Open();
                    cmd = new SqlCommand(sql, con);
                    cmd1 = new SqlCommand(sql1, con);
                    cmd2 = new SqlCommand(sql2, con);
                    cmd.Parameters.AddWithValue("@inNo", invoiceNo);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@vehNo", vehNo);
                    cmd1.Parameters.AddWithValue("@inNo", invoiceNo);
                    cmd1.Parameters.AddWithValue("@typ", type);
                    cmd1.Parameters.AddWithValue("@des", descrip);
                    cmd1.Parameters.AddWithValue("@price", price);
                    cmd2.Parameters.AddWithValue("@notId", NotifyID);
                    cmd2.Parameters.AddWithValue("@vvehNo", vehNo);
                    cmd2.Parameters.AddWithValue("@nexDate", nextDate);
                    cmd2.Parameters.AddWithValue("@invoice", invoiceNo);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Record Added Successfully");

                    ServiceReport fm8 = new ServiceReport();
                    this.Hide();
                    fm8.Show();
                }
                else
                {
                    MessageBox.Show("Oops something went wrong");
                }
            }
            else
            {
                MessageBox.Show("All the fields should be filled!!!!!");
            }


        }

        public static string getInvoice()
        {
            return invoiceNo;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
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

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
        }

        private void textBox7_CursorChanged(object sender, EventArgs e)
        {
 
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            label16.Visible = true;
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            label23.Visible = true;
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            label24.Visible = true;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bool ischecked;
            if (ischecked = radioButton1.Checked)
            {
                label25.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else
            {
                label25.Enabled = false;
                dateTimePicker2.Enabled = false;
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        


    }
}
