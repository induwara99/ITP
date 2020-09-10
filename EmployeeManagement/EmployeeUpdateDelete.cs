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
    public partial class EmployeeUpdateDelete : Form
    {
        public EmployeeUpdateDelete()
        {
            InitializeComponent();
            load();
        }

        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        String proid;
        String sql;
        bool Mode = true;
        string id;

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




        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeUpdateDelete_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                txtempno.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getID(id);




            }
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from employee where empID = @empID";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@empID", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Record Successfull Deleted!. ");

                con.Close();


            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string Eregno = txtempno.Text;
            string Efname = txtfname.Text;
            string Elname = txtlname.Text;
            string Eemail = txtemail.Text;
            string Eaddress = txtadd.Text;
            string Epnumber = txtphone.Text;
            string EPosition = txtPosition.Text;
            string Egender = txtgender.SelectedItem.ToString();

            if (Mode == false)
            {

                sql = "update employee set fname = @fname, lname= @lname, email= @email, address = @address, pnumber = @pnumber, Position = @Position, gender = @gender where empID = @empID";
                con.Open();
                cmd = new SqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@fname", Efname);
                cmd.Parameters.AddWithValue("@lname", Elname);
                cmd.Parameters.AddWithValue("@email", Eemail);
                cmd.Parameters.AddWithValue("@address", Eaddress);
                cmd.Parameters.AddWithValue("@pnumber", Epnumber);
                cmd.Parameters.AddWithValue("@Position", EPosition);
                cmd.Parameters.AddWithValue("@gender", Egender);
                cmd.Parameters.AddWithValue("@empID", id);

                //Execute the Query
                cmd.ExecuteNonQuery();
                MessageBox.Show(" All Employee Details are Successfuly Updated!! ");

                txtempno.Enabled = true;
                Mode = true;

                

            }
            else
            {
                MessageBox.Show("!! Details are Not Updated !! ");
            }

            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            load();
            

            txtfname.Clear();
            txtlname.Clear();
            txtemail.Clear();
            txtadd.Clear();
            txtphone.Clear();


            txtfname.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeMain EM = new EmployeeMain();
            EM.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

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
