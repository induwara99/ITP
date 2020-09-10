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
    public partial class booking3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader sdr;
        String auno;
        String sql;
        SqlDataReader dr;
        SqlCommand cmd;
        bool Mode = true;
        public booking3()
        {
            InitializeComponent();
            booking6 b6 = new booking6();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            booking1 b1 = new booking1();
            b1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void getbookingdeials()
        {
            con.Open();
            this.ResNo.Text = booking6.bookingid;

            string sqlselectquery = "select * from Booking where [Reservation No] = " + booking6.bookingid;

            cmd = new SqlCommand(sqlselectquery,con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                CName.Text = dr.GetValue(1).ToString();
                Did.Text = dr.GetValue(2).ToString();
                Rdate.Text = dr.GetValue(3).ToString();
                VNumber.Text = dr.GetValue(4).ToString();
               
            }
            con.Close();
        }

        private void booking3_Load(object sender, EventArgs e)
        {
            getbookingdeials();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            booking1 b1 = new booking1();
            b1.Show();
        }
    }
        }
        
            
 
