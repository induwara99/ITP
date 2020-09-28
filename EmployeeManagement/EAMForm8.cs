using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace VehicleManagement
{
    public partial class EAMForm8 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;

        public EAMForm8()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm4 eam4 = new EAMForm4();
            eam4.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void displayStatus()
        {
            con.Open();

            sql = "SELECT * from LEAVE where Emp_ID = " + empTxt.Text;
                //+ "and Date = " +  ;

            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
           
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                statusTxt.Text = dr.GetValue(6).ToString();

            }

            con.Close();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            displayStatus();
        }

        private void Calender_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
    }
}
