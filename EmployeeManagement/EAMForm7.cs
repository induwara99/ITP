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
using System.Configuration;

namespace VehicleManagement
{

    public partial class EAMForm7 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        string sql;
        bool Mode = true;

        public EAMForm7()
        {
            InitializeComponent();
        }

        private void validateDetails()
        {
            int checkNumber;

            if( emp_IDtxt.Text == "" || !(int.TryParse((emp_IDtxt.Text.ToString()), out checkNumber )))
            {
                MessageBox.Show("Insert employee ID");
            }

            else if (!(fulldayBtn.Checked || halfdayBtn.Checked || halfdayEBtn.Checked))
            {
                MessageBox.Show("Select shift");
            }

            else if (reasonCombo.SelectedItem == null)
            {
                MessageBox.Show("Select reason");
            }

            else
            {
                insertLeaveDetails();
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void submit_Click(object sender, EventArgs e)
        {
            validateDetails();
        }

        private void insertLeaveDetails()
        {
            String emp_ID = emp_IDtxt.Text;
            String date = dateTxt.Text;
            String other = otherTxt.Text;
            String reason = reasonCombo.SelectedItem.ToString();
            String shift;

            if (fulldayBtn.Checked)
            {
                shift = fulldayBtn.Text.ToString();
            }
            else if (halfdayBtn.Checked)
            {
                shift = halfdayBtn.Text.ToString();
            }
            else
            {
                shift = halfdayEBtn.Text.ToString();
            }

            if (Mode == true)
            {
                sql = "insert into LEAVE (Emp_ID, Date, Shift, Reason, If_other) values (@emp_ID, @Date, @shift, @reason, @other)";

                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@emp_ID", emp_IDtxt.Text);
                cmd.Parameters.AddWithValue("@Date", dateTxt.Value.ToString());
                cmd.Parameters.AddWithValue("@shift", shift);
                cmd.Parameters.AddWithValue("@reason", reasonCombo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@other", otherTxt.Text.Trim());

                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");

                con.Close();
            }
        }

        private void halfdayBtn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void reasonCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm4 eam4 = new EAMForm4();
            eam4.Show();
        }
    }
}
