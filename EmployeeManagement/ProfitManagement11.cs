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
    public partial class ProfitManagement11 : Form
    {
        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;

        public ProfitManagement11()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void validateDetails()
        {
            int validateNum;
            float validateAmount;

            if(textrename.Text == "" )
            {
                MessageBox.Show("Insert vehicle number");
            }
            else if(textreid.Text == "" || !(int.TryParse((textreid.Text.ToString()), out validateNum)))
            {
                MessageBox.Show("Insert repair ID");
            }
            else if (textreamount.Text == "" || !(float.TryParse((textreamount.Text.ToString()), out validateAmount)))
            {
                MessageBox.Show("Insert amount");
            }
            else
            {
                insertDetails();
            }
        }

        private void insertDetails()
        {
            string repairnumber = textrename.Text; //ASSIGNING THE VALUES
            string repairid = textreid.Text;
            string repairamount = textreamount.Text;

            if (Mode == true)
            {
                sql = "insert into DETAILS_OF_REPAIRES (renumber,reid,reamount)values(@repairnumber, @repairid, @repairamount)";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@repairnumber", repairnumber);
                cmd.Parameters.AddWithValue("@repairid", repairid);
                cmd.Parameters.AddWithValue("@repairamount", repairamount);
                cmd.ExecuteNonQuery();

                sql = "insert into PROFIT (repair_id , amount_for_repaires )values(@repairid, @repairamount)";

                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@repairid", repairid);
                cmd.Parameters.AddWithValue("@repairamount", repairamount);
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

        private void button11_Click(object sender, EventArgs e)
        {
            validateDetails();
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
            ProfitManagement10 p10 = new ProfitManagement10();
            p10.Show();
        }
    }
}
