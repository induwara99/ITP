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
    public partial class Customerregister : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlDataReader dr;
        bool Mode = true;


        public Customerregister()
        {
            InitializeComponent();
        }

        private void validateDetails()
        {
            if(FirstNameTB.Text == "")
            {

                MessageBox.Show("type the first name");
            }

            else if(NICTB.Text == "")
            {
                MessageBox.Show("Enter your NIC number");
            }

            else if(AddressTB.Text == "")
            {
                MessageBox.Show("Enter your address");
            }

            else if(CntNoTB.Text == "")
            {
                MessageBox.Show("Enter your contact number");
            }
     
            else if (EmailTB.Text == "")
            {
                MessageBox.Show("Enter your email address");
            }

            else if(CareerTB.Text == "")
            {
                MessageBox.Show("Enter your career");
            }

            else if(!(cusgendermale.Checked || cusgenderfemale.Checked))
            {
                MessageBox.Show("Select your gender");
            }

            else
            {
                insertValuesIntoDB();
                formReset();
            }
        }

        public void formReset()
        { 
            this.FirstNameTB.Text = "";
            this.LastNTB.Text = "";
            this.NICTB.Text = "";
            this.AddressTB.Text = "";
            this.CntNoTB.Text = "";
            this.EmailTB.Text = "";
            this.CareerTB.Text = "";
            this.cusgendermale.Checked = false;
            this.cusgenderfemale.Checked = false;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cusregbtn_Click(object sender, EventArgs e)
        {
            validateDetails();

        }

        private void insertValuesIntoDB()
        {
            String Gender;

            if (cusgendermale.Checked)
            {
                Gender = cusgendermale.Text.ToString();
            }
            else
            {
                Gender = cusgenderfemale.Text.ToString();
            }

            con.Open();

            String CustomerInsertQuery = "insert into CUSTOMER(FirstName,LastName,NIC,Address,ContactNo,Email,Career,BOD,Gender,Registerdate)values(@FirstName,@LastName,@NIC,@Address,@ContactNo,@Email,@Career,@BOD,@Gender,@Registerdate)";
            SqlCommand cmd = new SqlCommand(CustomerInsertQuery, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@FirstName", this.FirstNameTB.Text.Trim());
            cmd.Parameters.Add("@LastName", this.LastNTB.Text.Trim());
            cmd.Parameters.Add("@NIC", this.NICTB.Text.Trim());
            cmd.Parameters.Add("@Address", this.AddressTB.Text.Trim());
            cmd.Parameters.Add("@ContactNo", this.CntNoTB.Text.Trim());
            cmd.Parameters.Add("@Email", this.EmailTB.Text.Trim());
            cmd.Parameters.Add("@Career", this.CareerTB.Text.Trim());
            cmd.Parameters.Add("@BOD", this.BODTB.Value.ToString().Trim());
            cmd.Parameters.Add("@Gender", Gender.Trim());
            cmd.Parameters.Add("@Registerdate", this.regdTB.Value.ToString().Trim());



            cmd.ExecuteNonQuery();

            MessageBox.Show("Success");
        }

        private void backhome_Click(object sender, EventArgs e)
        {
            customerhome form2 = new customerhome();
            this.Hide();
            form2.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Homepage2 hm = new Homepage2();
            this.Hide();
            hm.Show();
        }
    }
}
