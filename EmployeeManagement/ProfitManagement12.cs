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
    public partial class ProfitManagement12 : Form
    {
        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;

        public ProfitManagement12()
        {
            InitializeComponent();
        }

        private void validateID()
        {
            int validateNum;
            float validateAmount;

            if (textfuelid.Text == "" || !(int.TryParse((textfuelid.Text.ToString()), out validateNum)))
            {
                MessageBox.Show("Enter fuel ID");
            }
            else if (textfuelamount.Text == "" || !(float.TryParse((textfuelid.Text.ToString()), out validateAmount)))
            {
                MessageBox.Show("Enter amount");
            }
            else
            {
                InsertID();
            }
        }


        private void button11_Click(object sender, EventArgs e)
        {
            validateID();
        }

        private void InsertID()
        {
            string fuelid = textfuelid.Text; //ASSIGNING THE VALUES
            string fuelamount = textfuelamount.Text;


            if (Mode == true)
            {
                sql = "insert into DETAILS_FOR_FUEL (fuelid,fuelamount)values(@fuelid , @fuelamount)";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@fuelid", fuelid);
                cmd.Parameters.AddWithValue("@fuelamount", fuelamount);
                cmd.ExecuteNonQuery();

                sql = "insert into PROFIT (fuel_id,amount_for_fuel)values(@fuelid , @fuelamount)";
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@fuelid", fuelid);
                cmd.Parameters.AddWithValue("@fuelamount", fuelamount);
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
            ProfitManagement11 p11 = new ProfitManagement11();
            p11.Show();
        }
    }
}
