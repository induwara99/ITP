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
    public partial class SearchVehicle : Form
    {
        public SearchVehicle()
        {
            InitializeComponent();
           
        }


        private void Search_BTN_Click(object sender, EventArgs e)
        {
            display();
        }

        private void FnametextBox1_TextChanged(object sender, EventArgs e)
        {
            VNumtextBox2.Text = "";
            VIdIDtextBox3.Text = "";
            display();
        }

        private void PhonetextBox2_TextChanged(object sender, EventArgs e)
        {
            OwnertextBox1.Text = "";
            VIdIDtextBox3.Text = "";
            display();
        }

        private void Emp_ID_textBox3_TextChanged(object sender, EventArgs e)
        {
            VNumtextBox2.Text = "";
            OwnertextBox1.Text = "";
            display();
        }

        void display()
        {
            SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
            DataTable dt = new DataTable();


            if (OwnertextBox1.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from VRegi where Owner LIKE '" + OwnertextBox1.Text + "%'", con);
                sda.Fill(dt);

            }
            else if (VNumtextBox2.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from VRegi where VNum LIKE '" + VNumtextBox2.Text + "%'", con);
                sda.Fill(dt);
            }
            else if (VIdIDtextBox3.Text.Length > 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from VRegi where VId LIKE '" + VIdIDtextBox3.Text + "%'", con);
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
            VehicleMain H = new VehicleMain();
            H.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            VehicleMain VM = new VehicleMain();
            VM.Show();
        }

        private void SearchVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
