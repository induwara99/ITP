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
    public partial class EAMForm2 : Form
    { 

    SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
    SqlCommand cmd;
    SqlDataReader dr;
    string sql;
    bool Mode = true;

        public EAMForm2()
        {
            InitializeComponent();
        }

        private void validateDetails()
        {
            int checkNumber;

            if (empText.Text == "" || !(int.TryParse((empText.Text.ToString()), out checkNumber)))
            {
                MessageBox.Show("Enter employee number");
            }
            else
            {
                insertID();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            validateDetails();
        }

        private void insertID() {
            String emp_ID = empText.Text;

            if (Mode == true)
            {
                String CurrentDate = DateTime.Today.ToString();
                String CurrentTime = DateTime.Now.TimeOfDay.ToString();

                sql = "UPDATE ATTENDANCE SET Leaving_Time = @CurrentTime where Date = @CURDATE and Emp_ID = @emp_ID ";

                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;


                cmd.Parameters.AddWithValue("@CurrentTime", CurrentTime);
                cmd.Parameters.AddWithValue("@CURDATE", CurrentDate);
                cmd.Parameters.AddWithValue("@emp_ID", emp_ID);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");

            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm15 eam15 = new EAMForm15();
            eam15.Show();
        }
    }
}
