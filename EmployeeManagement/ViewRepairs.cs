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
    public partial class ViewRepairs : Form
    {
        public ViewRepairs()
        {
            InitializeComponent();

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            string vehNo = SearchVehicleR.getVehNo();
            getVehicleDetails(vehNo);

            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;

            loadMajor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            dataGridView3.Visible = false;

            loadMinorTyre();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;

            loadMinorService();
        }

        //Setting Sql Connection
        SqlConnection con = new SqlConnection(@"Data Source=ROG;Initial Catalog=VehicleDB;Integrated Security=True;Pooling=False");
        SqlCommand cmd;
        SqlDataReader dr;

        string sql;

        //Getting the vehicle Details
        public void getVehicleDetails(String vehNo)
        {
            sql = "SELECT * FROM Vehicle WHERE vehNo = '" + vehNo + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox5.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
            }
            con.Close();
        }

        public static string mjinvoiceNo;
        public static string tirinvoiceNo;
        public static string serinvoiceNo;

        public void loadMajor()
        {
            sql = "SELECT * FROM MajorRepair WHERE vehNo = '" + textBox5.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4],dr[5],dr[6],dr[7]);

            }

            con.Close();
        }

        public void loadMinorTyre()
        {
            sql = "SELECT m.invoiceNo,m.repDate,t.size,t.model,t.qty,t.unitPrice FROM MinorRepair m,TireChange t WHERE m.invoiceNo = t.invoiceNo AND m.vehNo = '" + textBox5.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView2.Rows.Clear();

            while (dr.Read())
            {
                dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
            }

            con.Close();
        }

        public void loadMinorService()
        {
            sql = "SELECT s.invoiceNo,m.repDate,s.type,s.descrip,s.amount FROM MinorRepair m,Service s WHERE m.invoiceNo = s.invoiceNo AND m.vehNo = '" + textBox5.Text + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView3.Rows.Clear();

            while (dr.Read())
            {
                dataGridView3.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
            }

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Col9"].Index && e.RowIndex >= 0)
            {
                mjinvoiceNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                MajorRepairUpdate fm10 = new MajorRepairUpdate();
                this.Hide();
                fm10.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Col10"].Index && e.RowIndex >= 0)
            {
                //Delete
                mjinvoiceNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                DeleteMajorRepair fm16 = new DeleteMajorRepair();
                this.Hide();
                fm16.Show();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Column7"].Index && e.RowIndex >= 0)
            {
                tirinvoiceNo = dataGridView2.CurrentRow.Cells[0].Value.ToString();

                TireChangeUpdate fm12 = new TireChangeUpdate();
                this.Hide();
                fm12.Show();
            }
            else if (e.ColumnIndex == dataGridView2.Columns["Column8"].Index && e.RowIndex >= 0)
            {
                tirinvoiceNo = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                //Delete

                DeleteTireChange fm17 = new DeleteTireChange();
                this.Hide();
                fm17.Show();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView3.Columns["Column14"].Index && e.RowIndex >= 0)
            {
                serinvoiceNo = dataGridView3.CurrentRow.Cells[0].Value.ToString();

                ServiceUpdate fm14 = new ServiceUpdate();
                this.Hide();
                fm14.Show();
            }
            else if (e.ColumnIndex == dataGridView3.Columns["Column15"].Index && e.RowIndex >= 0)
            {
                serinvoiceNo = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                //Delete

                DeleteService fm18 = new DeleteService();
                this.Hide();
                fm18.Show();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RepairCategory rt = new RepairCategory();
            this.Hide();
            rt.Show();
        }
    }
}
