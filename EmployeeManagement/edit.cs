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
    public partial class edit : Form
    {

        public edit()
        {
            InitializeComponent();
            showDetails();
        }

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader sdr;
        String sql;
        SqlCommand cm;
        bool mode = true;
        String id;


        private void edit_Load(object sender, EventArgs e)
        {

        }

        public void getId(String id)
        {

            sql = "select  * from driverdetails where regno = '" + id + "'";
            cm = new SqlCommand(sql, con);
            con.Open();
            sdr = cm.ExecuteReader();

            while(sdr.Read())
            {

                txtDRegNoUp.Text = sdr[0].ToString();
                txtDDateUp.Text = sdr[1].ToString();
                txtDNameUp.Text = sdr[2].ToString();
                txtDNicUp.Text = sdr[3].ToString();
                txtDContactUp.Text = sdr[4].ToString();
                txtDAddressUp.Text = sdr[5].ToString();
                txtDExpUp.Text = sdr[6].ToString();

            }
            con.Close();

        }

        public void showDetails()
        {

            sql = "select * from driverdetails";
            cm = new SqlCommand(sql, con);
            con.Open();
            sdr = cm.ExecuteReader();
            dataview2.Rows.Clear();

            while (sdr.Read())
            {
                dataview2.Rows.Add(sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6]);
            }

            con.Close();

        }

        private void dataview2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if(e.ColumnIndex == dataview2.Columns["update"].Index && e.RowIndex >= 0)
            {
                
                mode = false;
                txtDRegNoUp.Enabled = false;
                id = dataview2.CurrentRow.Cells[0].Value.ToString();
                getId(id);

            }

        }

        private void driverManagemenr_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        private void comName_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String regno = txtDRegNoUp.Text;
            String date = txtDDateUp.Text;
            String name = txtDNameUp.Text;
            String nic = txtDNicUp.Text;
            String num = txtDContactUp.Text;
            String address = txtDAddressUp.Text;
            String exp = txtDExpUp.Text;
            id = dataview2.CurrentRow.Cells[0].Value.ToString();

            if (mode = true)
            {
                sql = "update driverdetails set date = @date, name = @name, nic = @nic,contactNo = @contactNo, address = @address, exp = @exp where regno = @regno";
                con.Open();
                cm = new SqlCommand(sql, con);
               
                cm.Parameters.AddWithValue("@date", date);
                cm.Parameters.AddWithValue("@name", name);
                cm.Parameters.AddWithValue("@nic", nic);
                cm.Parameters.AddWithValue("@contactno", num);
                cm.Parameters.AddWithValue("@address", address);
                cm.Parameters.AddWithValue("@exp", exp);
                cm.Parameters.AddWithValue("@regno", id);
                cm.ExecuteNonQuery();
                MessageBox.Show("Data updated Successfully");
                txtDRegNoUp.Enabled = false;
                mode = true;
            }
            con.Close();

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            showDetails();
        }

        private void logOut2_Click(object sender, EventArgs e)
        {

        }

        private void txtDRegNoUp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
