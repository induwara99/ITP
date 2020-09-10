using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
            notifyDetails();

            dateTimePicker1.Enabled = false;
        }

        //Setting Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;

        string sql;

        public void notifyDetails()
        {
            //sql = "SELECT n.notifyID,n.vehNo,v.vehModel FROM Notification n,Vehicle v WHERE n.vehNo = v.vehNo AND n.serDate = '"+ dateTimePicker1.Text + "'";
            sql = "SELECT n.notifyID,n.vehNo,v.vehModel FROM Notification n,Vehicle v WHERE  n.vehNo = v.vehNo AND serDate = '" + dateTimePicker1.Value.Date + "'  ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2]);

            }

            con.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SearchVehicleR sr = new SearchVehicleR();
            this.Hide();
            sr.Show();
        }
    }
}
