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
    public partial class ProfitManagement21 : Form
    {
        //ESTABLISH THE CONNECTION
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;
        string sql;
        bool Mode = true;


        int TotalSalary;
        //public DateTime Year1;
        //public DateTime Year2;

        public static String totalsalary;
        public static String totaltrips;
        public static String totalrepaires;
        public static String totalfuel;

        public ProfitManagement21()
        {
            InitializeComponent();



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void ProfitManagement21_Load(object sender, EventArgs e)
        {

            //Year1 = DateTime.Parse(ProfitManagement20.year.ToString()+"-01");
            //Year2 = DateTime.Parse(ProfitManagement20.year.ToString() + "-31");
            //where date between @Year1 and @Year2
            con.Open();
            String sql = "select sum(salary_for_employees), sum(amount_for_trips), sum(amount_for_repaires), sum(amount_for_fuel) from PROFIT";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@Year1", "2020-09-01");
            //cmd.Parameters.AddWithValue("@Year2", "2020-09-31");
            dr = cmd.ExecuteReader();

            while (dr.Read())

            {

                texttotalsalary.Text = dr[0].ToString();
                texttotaltrips.Text = dr[1].ToString();
                texttotalrepaires.Text = dr[2].ToString();
                texttotalfuel.Text = dr[3].ToString();



            }






            con.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            totalsalary = texttotalsalary.Text;
            totaltrips = texttotaltrips.Text;
            totalrepaires = texttotalrepaires.Text;
            totalfuel = texttotalfuel.Text;

            ProfitManagement22 p22 = new ProfitManagement22();
            p22.Show();


        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            totalsalary = texttotalsalary.Text;
            totaltrips = texttotaltrips.Text;
            totalrepaires = texttotalrepaires.Text;
            totalfuel = texttotalfuel.Text;

            ProfitManagement22 p22 = new ProfitManagement22();
            p22.Show();
        }
    }
}
