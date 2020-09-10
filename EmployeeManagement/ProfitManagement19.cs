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
using System.Configuration;

namespace VehicleManagement
{
    public partial class ProfitManagement19 : Form
    {
        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;

        public ProfitManagement19()
        {
            InitializeComponent();
            ProfitManagement18 pro18 = new ProfitManagement18();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        public void getfueldetails()
        {
            con.Open();
            this.textfuelid.Text = ProfitManagement18.fuelid;

            string sqlSelectquery = "SELECT * FROM DETAILS_FOR_FUEL WHERE fuelid =" + ProfitManagement18.fuelid;

            cmd = new SqlCommand(sqlSelectquery, con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textfuelamount.Text = dr.GetValue(1).ToString();
            }


            con.Close();
        }

        private void ProfitManagement19_Load(object sender, EventArgs e)
        {
            getfueldetails();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            string update = "UPDATE DETAILS_FOR_FUEL set fuelamount = '" + this.textfuelamount.Text.ToString() + "'  where fuelid = '" + this.textfuelid.Text + "'";
            cmd = new SqlCommand(update, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string update2 = "UPDATE PROFIT set amount_for_fuel = '" + this.textfuelamount.Text.ToString() + "'  where fuel_id = '" + this.textfuelid.Text + "'";
            cmd = new SqlCommand(update2, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();

            this.Hide();
            ProfitManagement5 p5 = new ProfitManagement5();
            p5.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();
            string delete = "DELETE DETAILS_FOR_FUEL where fuelid = '" + this.textfuelid.Text + "'";
            cmd = new SqlCommand(delete, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string delete2 = "DELETE PROFIT where fuel_id = '" + this.textfuelid.Text + "'";
            cmd = new SqlCommand(delete2, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();


            con.Close();

            this.Hide();
            ProfitManagagement4 p4 = new ProfitManagagement4();
            p4.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }
    }
}
