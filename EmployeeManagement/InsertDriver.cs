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
    public partial class InsertDriver : Form
    {

        public InsertDriver()
        {
            InitializeComponent();
            autonum();
        }

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader sdr;
        String auno;
        String sql;
        SqlCommand cm;
        bool mode = true; 

        public void autonum()
        {
            sql = "Select regno from driverdetails order by regno desc";
            cm = new SqlCommand(sql, con);
            con.Open();
            sdr = cm.ExecuteReader();

            if (sdr.Read())
            {
                int id = int.Parse(sdr[0].ToString()) + 1;
                auno = id.ToString("0000");
            }
            else if (Convert.IsDBNull(sdr))
            {
                auno = ("0001");
            }
            else
            {
                auno = ("0001");
            }

            txtDRegNo.Text = auno.ToString();

            con.Close();
        }


        private void validateDetails()
        {
            if(txtDName.Text == "")
            {
                MessageBox.Show("please enter the name");
            }
            else if(txtDNic.Text == "")
            {
                MessageBox.Show("Please enter the NIC");
            }
            else if(txtDContact.Text == "")
            {
                MessageBox.Show("please enter contact Number");
            }
            else if(txtDAddress.Text == "") {
                MessageBox.Show("please enter the Address");
            }
            else if(txtDExp.Text == "")
            {
                MessageBox.Show("please enter the years of experience");
            }
            else
            {
                insertDetails();
            }
        }

        private void InsertDriver_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            validateDetails();

        }

        public void insertDetails()
        {
            String regno = txtDRegNo.Text;
            String date = DateTime.Today.ToString();
            String name = txtDName.Text;
            String nic = txtDNic.Text;
            String num = txtDContact.Text;
            String address = txtDAddress.Text;
            String exp = txtDExp.Text;

            if (mode == true)
            {
                sql = "insert into driverdetails(regno,date,name,nic,contactno,address,exp)values(@regno,@date,@name,@nic,@contactno,@address,@exp)";
                con.Open();
                cm = new SqlCommand(sql, con);
                cm.Parameters.AddWithValue("@regno", regno);
                cm.Parameters.AddWithValue("@date", date);
                cm.Parameters.AddWithValue("@name", name);
                cm.Parameters.AddWithValue("@nic", nic);
                cm.Parameters.AddWithValue("@contactno", num);
                cm.Parameters.AddWithValue("@address", address);
                cm.Parameters.AddWithValue("@exp", exp);
                cm.ExecuteNonQuery();
                MessageBox.Show("Data Added Successfully");


                txtDRegNo.Clear();
                txtDName.Clear();
                txtDNic.Clear();
                txtDContact.Clear();
                txtDAddress.Clear();
                txtDExp.Clear();




            }
            con.Close();
            autonum();
        }

        private void driverManagemenr_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void logOut2_Click(object sender, EventArgs e)
        {

        }

        private void customerManagement_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void txtDExp_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void customerManagement_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain home = new VehicleMain();
            home.Show();
        }
    }
}
