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
    public partial class booking6 : Form
    {
        public static String bookingid;

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader sdr;
        String auno;
        String sql;
        SqlCommand cmd;
        bool Mode = true;

        public booking6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            bookingid = ResNo.Text;
            booking3 b3 = new booking3();
            b3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            booking1 b1 = new booking1();
            b1.Show();
        }
    }
}
