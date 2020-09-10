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
    public partial class ProfitManagement9 : Form
    {
        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;



        public ProfitManagement9()
        {
            InitializeComponent();
        }

        private void ProfitManagement9_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string tripid = texttripid.Text; //ASSIGNING THE VALUES
            string tripamount = texttripamout.Text;
            

            if (Mode == true)
            {
                sql = "insert into Enter_DETAILS_FOR_TRIPS (tripid,tripamount)values(@tripid , @tripamount)";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@tripid", tripid);
                cmd.Parameters.AddWithValue("@tripamount", tripamount);
                cmd.ExecuteNonQuery();

                sql = "insert into PROFIT (trip_id , amount_for_trips)values(@tripid , @tripamount)";
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@tripid", tripid);
                cmd.Parameters.AddWithValue("@tripamount", tripamount);
                cmd.ExecuteNonQuery();
                

            }
            else
            {

            }

            con.Close();

            this.Hide();
            ProfitManagement10 p10 = new ProfitManagement10();
            p10.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement8 p8 = new ProfitManagement8();
            p8.Show();
        }
    }
}

