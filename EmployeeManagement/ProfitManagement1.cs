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
    public partial class ProfitManagement1 : Form
    {
        public ProfitManagement1()
        {
            InitializeComponent();
           
        }

        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataReader dr;
        string sql;
        string sql2;
        bool Mode = true;


       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProfitManagement1_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            validateDetails();

        }

        public void validateDetails()
        {

            int validateNum;
            float validateAmount;

            if(textemployeeid.Text == "" || !(int.TryParse((textemployeeid.Text.ToString()), out validateNum)))
            {
                MessageBox.Show("Please enter Employee ID");
            }
            else if(textemployeename.Text == "")
            {
                MessageBox.Show("Please enter Employee Name");
            }
            /*else if(textemployeeamount.Text == "" || !(float.TryParse((textemployeeamount.Text.ToString(), out validateAmount)))
            {
                MessageBox.Show("Please enter Employee Amount");
            }*/
            else
            {
                insertDetails();
            }
        }

        public void insertDetails()
        {
            string employeeid = textemployeeid.Text; //ASSIGNING THE VALUES
            string employeename = textemployeename.Text;
            string employeeamount = textemployeeamount.Text;

            if (Mode == true)
            {
                sql = "insert into Enter_Salary_Details (employeeid,employeename,amount)values(@employeeid,@employeename,@amount)";//INSERT DATA TO Enter_Salary_Details TABLE
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@employeeid", employeeid);
                cmd.Parameters.AddWithValue("@employeename", employeename);
                cmd.Parameters.AddWithValue("@amount", employeeamount);
                cmd.ExecuteNonQuery();

                sql = "insert into PROFIT (emp_id , salary_for_employees)values(@employeeid , @amount)";//INSERT DATA TO TOTAL_PROFIT TABLE
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@employeeid", employeeid);
                cmd.Parameters.AddWithValue("@amount", employeeamount);
                cmd.ExecuteNonQuery();

            }
            else
            {

            }

            con.Close();

            this.Hide();
            ProfitManagement7 p7 = new ProfitManagement7();
            p7.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();//REDIRECTING TO NEXT PAGE
            ProfitManagement2 p2 = new ProfitManagement2();
            p2.Show();
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
            Form2 f1 = new Form2();
            f1.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage2 Hm = new Homepage2();
            Hm.Show();
        }
    }
    }

