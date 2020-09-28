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
    public partial class booking2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader sdr;
        String auno;
        String sql;
        SqlCommand cmd;
        bool Mode = true;

        public booking2()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void booking2_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void validateDetails()
        {
            if (ResNo.Text == "")
            {
                MessageBox.Show("Please enter registration number");
            }
            else if(CName.Text == "")
            {
                MessageBox.Show("Please enter customer name");
            }
            else if(Did.Text == "")
            {
                MessageBox.Show("Please enter driver ID");
            }
            else if(Rdate.Text == "")
            {
                MessageBox.Show("Please enter date");
            }
            else if(VNumber.Text == "")
            {
                MessageBox.Show("Please enter vehicle number");
            }
            else
            {
                insertDetails();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            validateDetails();
        }

        public void insertDetails()
        {
            String reservationnumber = ResNo.Text;
            String customername = CName.Text;
            String driverid = Did.Text;
            String reservationdate = Rdate.Text;
            String vehiclenumber = VNumber.Text;


            if (Mode == true)
            {
                sql = "insert into Booking ([Reservation No],[Customer Name],[Driver ID],[Reservation Date],[Vehicle Number])values(@reservationnumber , @customername ,@driverid,@reservationdate,@vehiclenumber )";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@reservationnumber", reservationnumber);
                cmd.Parameters.AddWithValue("@customername", customername);
                cmd.Parameters.AddWithValue("@driverid", driverid);
                cmd.Parameters.AddWithValue("@reservationdate", reservationdate);
                cmd.Parameters.AddWithValue("@vehiclenumber", vehiclenumber);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Entered");

            }
            else
            {

            }

            con.Close();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            booking1 b1 = new booking1();
            b1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
