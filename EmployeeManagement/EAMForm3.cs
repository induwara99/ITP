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
    public partial class EAMForm3 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
       

        public EAMForm3()
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

        private void insertID()
        {
            String emp_ID = empText.Text;
            String CurrentDate = DateTime.Today.ToString();
            String CurrentTime = DateTime.Now.TimeOfDay.ToString();



            sql = "INSERT into ATTENDANCE (Emp_ID, Date, Arrival_Time) values (@emp_ID, @CurrentDate, @CurrentTime)";

            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@emp_ID", emp_ID);
            cmd.Parameters.AddWithValue("@CurrentTime", CurrentTime);
            cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);

            cmd.ExecuteNonQuery();


            MessageBox.Show("Added");
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm15 eam15 = new EAMForm15();
            eam15.Show();
        }
    }
}
