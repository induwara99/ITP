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
    public partial class ProfitManagement17 : Form
    {
        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;

        public ProfitManagement17()
        {
            InitializeComponent();
            ProfitManagement16 pro16 = new ProfitManagement16();
        }

        public void getrepairdetails()
        {
            con.Open();
            this.textrepairid.Text = ProfitManagement16.vehiclerepairnumber;

            string sqlSelectquery = "SELECT * FROM DETAILS_OF_REPAIRES WHERE reid =" + ProfitManagement16.vehiclerepairnumber;

            cmd = new SqlCommand(sqlSelectquery, con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textrepairnumber.Text = dr.GetValue(0).ToString();
                textrepairamount.Text = dr.GetValue(2).ToString();
            }


            con.Close();
        }

        private void ProfitManagement17_Load(object sender, EventArgs e)
        {
            getrepairdetails();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            string update = "UPDATE DETAILS_OF_REPAIRES set reamount = '" + this.textrepairamount.Text.ToString() + "'  where reid = '" + this.textrepairid.Text + "'";
            cmd = new SqlCommand(update, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string update2 = "UPDATE PROFIT set amount_for_repaires = '" + this.textrepairamount.Text.ToString() + "'  where repair_id = '" + this.textrepairid.Text + "'";
            cmd = new SqlCommand(update, con);
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
            string delete = "DELETE DETAILS_OF_REPAIRES where reid = '" + this.textrepairid.Text + "'";
            cmd = new SqlCommand(delete, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string delete2 = "DELETE PROFIT where repair_id = '" + this.textrepairid.Text + "'";
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
