using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace VehicleManagement
{
    public partial class ProfitManagement15 : Form
    {
        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;

        public ProfitManagement15()
        {
            InitializeComponent();
            ProfitManagement14 pro14 = new ProfitManagement14();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gettripdetails()
        {
            con.Open();
            this.texttripid.Text = ProfitManagement14.TripId;

            string sqlSelectquery = "SELECT * FROM ENTER_DETAILS_FOR_TRIPS WHERE tripid =" + ProfitManagement14.TripId;

            cmd = new SqlCommand(sqlSelectquery, con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                texttripamount.Text = dr.GetValue(1).ToString();

            }


            con.Close();
        }

        private void ProfitManagement15_Load(object sender, EventArgs e)
        {
            gettripdetails();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            string update = "UPDATE ENTER_DETAILS_FOR_TRIPS set tripamount = '" + this.texttripamount.Text.ToString() +  "' where tripid = '" + this.texttripid.Text + "'";
            cmd = new SqlCommand(update, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string update2 = "UPDATE PROFIT set amount_for_trips = '" + this.texttripamount.Text.ToString() + "' where trip_id = '" + this.texttripid.Text + "'";
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
            string delete = "DELETE ENTER_DETAILS_FOR_TRIPS where tripid = '" + this.texttripid.Text + "'";
            cmd = new SqlCommand(delete, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            string delete1 = "DELETE PROFIT where trip_id = '" + this.texttripid.Text + "'";
            cmd = new SqlCommand(delete1, con);
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

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement14 p14 = new ProfitManagement14();
            p14.Show();
        }
    }
    }

