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
    public partial class EmployeeRegistration : Form
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
            Autono();
            load();
        }

        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        String proid;
        String sql;
        bool Mode = true;
        string id;
        
        //Auto number Generate Part..

            public void Autono()
        {
            sql = "SELECT empID from employee order by empID desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proid = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("00001");
            }
            else
            {
                proid =("00001");
            }

            txtempno.Text = proid.ToString();

            con.Close();
        }

        //Create function for Retrieve the data to table
        
        public void load()
        {
            sql = "select * from employee";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6],dr[7]);

            }

            con.Close();

        }


        public void getID(String id)
        {

            sql = "select * from employee where empID= '" + id + "'   ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtempno.Text = dr[0].ToString();
                txtfname.Text = dr[1].ToString();
                txtlname.Text = dr[2].ToString();
                txtemail.Text = dr[3].ToString();
                txtadd.Text = dr[4].ToString();
                txtphone.Text = dr[5].ToString();
                txtPosition.Text = dr[6].ToString();
                txtgender.Text = dr[7].ToString();


            }

            con.Close();

        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        
        //Add Button
        //Insert Data to Database code part
        private void button10_Click(object sender, EventArgs e)
        {

            validateInsert();
        }

        private void insertDetails()
        {

            string Eregno = txtempno.Text;
            string Efname = txtfname.Text;
            string Elname = txtlname.Text;
            string Eemail = txtemail.Text;
            string Eaddress = txtadd.Text;
            string Epnumber = txtphone.Text;
            string Eposition = txtPosition.Text;
            string Egender = txtgender.SelectedItem.ToString();

            if (Mode == true)
            {
                sql = "insert into employee(empID,fname,lname,email,address,pnumber,Position,gender) values(@empID,@fname,@lname,@email,@address,@pnumber,@Position,@gender)";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@empID", Eregno);
                cmd.Parameters.AddWithValue("@fname", Efname);
                cmd.Parameters.AddWithValue("@lname", Elname);
                cmd.Parameters.AddWithValue("@email", Eemail);
                cmd.Parameters.AddWithValue("@address", Eaddress);
                cmd.Parameters.AddWithValue("@pnumber", Epnumber);
                cmd.Parameters.AddWithValue("@Position", Eposition);
                cmd.Parameters.AddWithValue("@gender", Egender);
                cmd.ExecuteNonQuery();

                MessageBox.Show("All Employee Details are Recorded Successfuly.");


                //After Add or Edit the Employee Record we have to Clear the fix
                txtfname.Clear();
                txtlname.Clear();
                txtemail.Clear();
                txtadd.Clear();
                txtphone.Clear();


                txtfname.Focus();

            }
            else
            {
                MessageBox.Show("!! Details are NOT Recorded Successfuly. !!");

            }

            con.Close();

        }

        private void validateInsert()
        {

            if(txtfname.Text == "")
            {

                MessageBox.Show("please Insert Employee First name !! ");

            }else if(txtlname.Text == "")
            {

                MessageBox.Show("Please enter Employee Last Name !!");
            }
            else if(txtemail.Text == "")
            {
                MessageBox.Show("Please Enter Employee Email !!");
            }
            else if(txtadd.Text == "")
            {
                MessageBox.Show("Please Enter Employee Address !!");
            }
            else if(txtphone.Text == "")
            {
                MessageBox.Show("Please Enter Employee Phone Number !!");

            }
            else if(txtPosition.Text == "")
            {
                MessageBox.Show("Please Enter Employee Position");


            }
            else if(txtgender.SelectedItem == null)
            {
                MessageBox.Show("Please Select Gender !!");
            }
            else
            {
                insertDetails();
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {

            load();
            Autono();

            txtfname.Clear();
            txtlname.Clear();
            txtemail.Clear();
            txtadd.Clear();
            txtphone.Clear();


            txtfname.Focus();



        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain EM = new EmployeeMain();
            EM.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain SE = new EmployeeMain();
            SE.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EmployeeMain emp = new EmployeeMain();
            this.Hide();
            emp.Show();
        }
    }
}
