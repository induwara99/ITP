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
    public partial class ProfitManagement33 : Form
    {
        public ProfitManagement33()
        {
            InitializeComponent();
            ProfitManagement2 Pm2 = new ProfitManagement2();
            
            
            //String getid = ID;  
        }

        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;


       

        private void ProfitManagement33_Load(object sender, EventArgs e)
        {
            getempdetails();
        }


        public void getempdetails()
        {
            con.Open();
            this.textemployeeidd.Text = ProfitManagement2.EmployeeId;

            string sqlSelectquery = "SELECT * FROM Enter_Salary_Details WHERE employeeid ="+ ProfitManagement2.EmployeeId;

            cmd = new SqlCommand(sqlSelectquery, con);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();

            while (dr.Read()) {

                textemployeename.Text = dr.GetValue(1).ToString();
                textemployeeamount.Text = dr.GetValue(2).ToString();



            }


            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
                con.Open();
                string update = "UPDATE Enter_Salary_Details set employeename = '" + this.textemployeename.Text.ToString() + "' , amount = '" + this.textemployeeamount.Text.ToString() + "' where employeeid = '"+this.textemployeeidd.Text+"'";
                cmd = new SqlCommand(update, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                

                con.Close();

                this.Hide();
                ProfitManagement5 p5 = new ProfitManagement5();
                p5.Show();


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            string update = "DELETE Enter_Salary_Details where employeeid = '"+this.textemployeeidd.Text+ "'";
            cmd = new SqlCommand(update, con);
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

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement2 p2 = new ProfitManagement2();
            p2.Show();
        }
    }
    

}
   

