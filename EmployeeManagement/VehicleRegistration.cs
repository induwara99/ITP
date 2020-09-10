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
    public partial class VehicleRegistration : Form
    {
        public VehicleRegistration()
        {
            InitializeComponent();
            Autono();
            load();
        }

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        String proid;
        String sql;
        bool Mode = true;
        string id;
        
        //Auto number Generate Part..

            public void Autono()
        {
            sql = "SELECT VId from Vregi order by VId desc";
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

            txtVID.Text = proid.ToString();

            con.Close();
        }

        //Create function for Retrieve the data to table
        
        public void load()
        {
            sql = "select * from Vregi";
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

            sql = "select * from Vregi where VId= '" + id + "'   ";
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
     
        private void validateDetails()
        {
            if(txtVNo.Text == "")
            {
                MessageBox.Show("Enter vehicle number");
            }
            else if(txtVCon.SelectedItem == null)
            {
                MessageBox.Show("Select the condition");
            }
            else if(txtOwner.Text == "")
            {
                MessageBox.Show("Enter the owner's name");
            }
            else if (txtadd.Text == "")
            {
                MessageBox.Show("Enter address");
            }
            else if(txtphone.Text == "")
            {
                MessageBox.Show("Enter the phone number");
            }
            else if (txtgender.SelectedItem == null)
            {
                MessageBox.Show("Select the gender");
            }
            else
            {
                InsertDetails();
            }
        }

        //Add Button
        //Insert Data to Database code part
        private void button10_Click(object sender, EventArgs e)
        {
            validateDetails();

        }

        private void InsertDetails()
        {
            string Vid = txtVID.Text;
            string VNo = txtVNo.Text;
            string VCon = txtVCon.SelectedItem.ToString();
            string VOwner = txtOwner.Text;
            string Vaddress = txtadd.Text;
            string Vpnumber = txtphone.Text;
            string VOgender = txtgender.SelectedItem.ToString();

            if (Mode == true)
            {
                sql = "insert into Vregi(VId,VNum,VCon,Owner,Address,PNum,Gen) values(@VID,@VNum,@VCon,@Owner,@address,@pnumber,@gender)";
                con.Open();
                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@VID", Vid);
                cmd.Parameters.AddWithValue("@VNum", VNo);
                cmd.Parameters.AddWithValue("@VCon", VCon);
                cmd.Parameters.AddWithValue("@Owner", VOwner);
                cmd.Parameters.AddWithValue("@address", Vaddress);
                cmd.Parameters.AddWithValue("@pnumber", Vpnumber);
                cmd.Parameters.AddWithValue("@gender", VOgender);
                cmd.ExecuteNonQuery();

                MessageBox.Show("All Vehicle Details are Recorded Successfuly.");


                //After Add or Edit the Employee Record we have to Clear the fix
                txtVNo.Clear();
                txtOwner.Clear();
                txtadd.Clear();
                txtphone.Clear();


                txtVNo.Focus();

            }
            else
            {
                MessageBox.Show("!! Details are NOT Recorded Successfuly. !!");

            }

            con.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {

            load();
            Autono();

            txtVNo.Clear();
            txtOwner.Clear();
            txtadd.Clear();
            txtphone.Clear();


            txtVNo.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain EM = new VehicleMain();
            EM.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain EM = new VehicleMain();
            EM.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain VM = new VehicleMain();
            VM.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
