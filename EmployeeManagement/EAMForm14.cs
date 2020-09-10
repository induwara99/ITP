using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace VehicleManagement
{
    public partial class EAMForm14 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        string sql;
        bool Mode = true;

        public EAMForm14()
        {
            InitializeComponent();
            AttendanceTableRetreive();
        }

        public void AttendanceTableRetreive()
        {
            String CurrentDate = DateTime.Today.ToString();

            if (Mode == true)
            {
                con.Open();

                sql = "SELECT * FROM ATTENDANCE WHERE Date = @CurrentDate";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);

                SqlDataAdapter Attendance = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                Attendance.Fill(DT);
                this.AttendanceTable.DataSource = DT;

                

                con.Close();

            }

        }

        public void EAMForm14_Load(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm15 eam15 = new EAMForm15();
            eam15.Show();
        }
    }
}
