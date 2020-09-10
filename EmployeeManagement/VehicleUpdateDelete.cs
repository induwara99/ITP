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
    public partial class VehicleUpdateDelete : Form
    {
        public VehicleUpdateDelete()
        {
            InitializeComponent();
            load();
        }

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        String proid;
        String sql;
        bool Mode = true;
        string id;

        public void load()
        {
            sql = "select * from VRegi";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);

            }

            con.Close();

        }

        public void getID(String id)
        {

            sql = "select * from VRegi where VId= '" + id + "'   ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtVID.Text = dr[0].ToString();
                txtVNo.Text = dr[1].ToString();
                txtVCon.Text = dr[2].ToString();
                txtOwner.Text = dr[3].ToString();
                txtadd.Text = dr[4].ToString();
                txtphone.Text = dr[5].ToString();
                txtgender.Text = dr[6].ToString();


            }

            con.Close();

        }




        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain VM = new VehicleMain();
            VM.Show();
        }

        private void EmployeeUpdateDelete_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                txtVID.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getID(id);




            }
            else if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from VRegi where VId = @VID";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@VID", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Record Successfull Deleted!. ");

                con.Close();


            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            string VId = txtVID.Text;
            string VNo = txtVNo.Text;
            string VCon = txtVCon.SelectedItem.ToString();
            string VOwn = txtOwner.Text;
            string Vaddress = txtadd.Text;
            string Vpnumber = txtphone.Text;
            string Vgender = txtgender.SelectedItem.ToString();

            if (Mode == false)
            {
          
                sql = "update VRegi set VNum = @VNum, VCon= @VCon, Owner= @Owner, address = @address, PNum = @pnumber, Gen = @gender where VId = @VID";
                con.Open();
                cmd = new SqlCommand(sql, con);


                cmd.Parameters.AddWithValue("@VNum", VNo);
                cmd.Parameters.AddWithValue("@VCon", VCon);
                cmd.Parameters.AddWithValue("@Owner", VOwn);
                cmd.Parameters.AddWithValue("@address", Vaddress);
                cmd.Parameters.AddWithValue("@pnumber", Vpnumber);
                cmd.Parameters.AddWithValue("@gender", Vgender);
                cmd.Parameters.AddWithValue("@VID", VId);

                //Execute the Query
                cmd.ExecuteNonQuery();
                MessageBox.Show(" All Employee Details are Successfuly Updated!! ");

                txtVID.Enabled = true;
                Mode = true;
                
            }
            else
            {
                MessageBox.Show("Details Not Updated!!");
            }

            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            load();
            

            txtVNo.Clear();
            txtOwner.Clear();
            txtadd.Clear();
            txtphone.Clear();


            txtVNo.Focus();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain VM = new VehicleMain();
            VM.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain VM = new VehicleMain();
            VM.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
