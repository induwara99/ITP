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
    public partial class SearchEmployee : Form
    {
        public SearchEmployee()
        {
            InitializeComponent();
           
        }


        private void Search_BTN_Click(object sender, EventArgs e)
        {
            display();
        }

        private void FnametextBox1_TextChanged(object sender, EventArgs e)
        {
            PhonetextBox2.Text = "";
            Emp_ID_textBox3.Text = "";
            display();
        }

        private void PhonetextBox2_TextChanged(object sender, EventArgs e)
        {
            FnametextBox1.Text = "";
            Emp_ID_textBox3.Text = "";
            display();
        }

        private void Emp_ID_textBox3_TextChanged(object sender, EventArgs e)
        {
            PhonetextBox2.Text = "";
            FnametextBox1.Text = "";
            display();
        }

        void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
            DataTable dt = new DataTable();


            if (FnametextBox1.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from employee where fname LIKE '" + FnametextBox1.Text + "%'", con);
                sda.Fill(dt);

            }
            else if (PhonetextBox2.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from employee where pnumber LIKE '" + PhonetextBox2.Text + "%'", con);
                sda.Fill(dt);
            }
            else if (Emp_ID_textBox3.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from employee where empID LIKE '" + Emp_ID_textBox3.Text + "%'", con);
                sda.Fill(dt);
            }

            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain H = new EmployeeMain();
            H.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain SE = new EmployeeMain();
            SE.Show();
        }

        private void SearchEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
