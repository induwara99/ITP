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
        public String Year1;
        public String Year2;

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
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void ProfitManagement21_Load(object sender, EventArgs e)
        {

            Year1 = ProfitManagement20.year.ToString()+"-01";
            Year2 = ProfitManagement20.year.ToString() + "-31";
            //where date between @Year1 and @Year2
            con.Open();
            String sql = "select sum(salary_for_employees), sum(amount_for_trips), sum(amount_for_repaires), sum(amount_for_fuel) from PROFIT where date between 2020-09-01 and 2020-09-30";
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
           // cmd.Parameters.AddWithValue("@Year1", Year1);
            //cmd.Parameters.AddWithValue("@Year2", Year2);
            dr = cmd.ExecuteReader();

            while (dr.Read())

            {

                texttotalsalary.Text = dr[0].ToString();
                texttotaltrips.Text = dr[1].ToString();
                texttotalrepaires.Text = dr[2].ToString();
                texttotalfuel.Text = dr[3].ToString();

           

            }

            totalsalary = (dr[0].ToString());
           



            con.Close();

        }
    }
}
