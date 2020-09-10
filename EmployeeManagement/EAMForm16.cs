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
    public partial class EAMForm16 : Form
    { 
    SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
    SqlCommand cmd;
    string sql;
    bool Mode = true;

    
        public EAMForm16()
        {
            InitializeComponent();
            LEAVERetrive();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm4 eam4 = new EAMForm4();
            eam4.Show();
        }

        private void LEAVERetrive()
        {
            if (Mode == true)
            {
                con.Open();

                sql = "SELECT * FROM LEAVE WHERE Status = 'Pending'";
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter Attendance = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();
                Attendance.Fill(DT);
                this.LEAVETable.DataSource = DT;

                con.Close();

            }
        }

        private void LEAVETable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            String LID = LIDText.Text;
            String status = approveCombo.SelectedItem.ToString();

            sql = "UPDATE LEAVE SET Status = @status where Leave_ID = @LID";

            con.Open();
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@LID", LID);
            cmd.Parameters.AddWithValue("@status", status);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated");
            con.Close();
            LEAVERetrive();
        }

        private void LIDText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
