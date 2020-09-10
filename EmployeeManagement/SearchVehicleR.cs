using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class SearchVehicleR : Form
    {
        public SearchVehicleR()
        {
            InitializeComponent();
            Displaynotify();
            /*this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;*/

        }

        //Notification
        protected void Displaynotify()
        {
            try
            {
                notifyIcon1.Icon = new System.Drawing.Icon(Path.GetFullPath(@"C:\USERS\ASUS\DOCUMENTS\VEHICLEDB.MDF"));
                notifyIcon1.Text = "Vehicle Repair Notification";
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipTitle = "Welcome to Vehicle Repair Management";
                notifyIcon1.BalloonTipText = "Click Here to see details of todays notifications";
                notifyIcon1.ShowBalloonTip(100);
            }
            catch (Exception ex)
            {
            }
        } 


        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void searchVehicles1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public static string vehNo;

        private void button10_Click(object sender, EventArgs e)
        {
            vehNo = textBox1.Text;

            SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
            string query = "SELECT* FROM Vehicle WHERE vehNo='" + textBox1.Text + "'";
            SqlDataAdapter sd = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sd.Fill(dt);

            if (dt.Rows.Count == 1)
            {

                RepairCategory fm2 = new RepairCategory();
                this.Hide();
                fm2.Show();
            }
            else{
                MessageBox.Show("Vehicle Not found in application");
                textBox1.Clear();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static string getVehNo()
        {
            return vehNo;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Homepage2 vh = new Homepage2();
            this.Hide();
            vh.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Notification nt = new Notification();
            this.Hide();
            nt.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeMain vh = new EmployeeMain();
            this.Hide();
            vh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VehicleMain vh = new VehicleMain();
            this.Hide();
            vh.Show();
        }
    }
}
