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
    public partial class customerhome : Form
    {

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader dr;
        bool Mode = true;

        public customerhome()
        {
            InitializeComponent();
        }

        public void RetrieveCustomerDetails()
        {
            con.Open();

            String CustomerRetrieveQuery = "select * from CUSTOMER";
            SqlCommand cmd = new SqlCommand(CustomerRetrieveQuery, con);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            this.CustomerDT.DataSource = DT;

            con.Close();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Homepage2 hm = new Homepage2();
            this.Hide();
            hm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void customerhome_Load(object sender, EventArgs e)
        {
            RetrieveCustomerDetails();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void registbt_Click(object sender, EventArgs e)
        {
            Customerregister form1 = new Customerregister();
            this.Hide();
            form1.Show();
            
            
        }

        private void CustomerDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void custsearch_Click_1(object sender, EventArgs e)
        {
            CustomerUpDT form = new CustomerUpDT();
            this.Hide();
            form.Show();
            

        }
    }
    
}
