using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleManagement
{
    public partial class ProfitManagement22 : Form
    {
        public ProfitManagement22()
        {

            InitializeComponent();
            ProfitManagement21 p21 = new ProfitManagement21();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void ProfitManagement22_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = ProfitManagement21.totalsalary;
            this.textBox2.Text = ProfitManagement21.totaltrips;
            this.textBox3.Text = ProfitManagement21.totalrepaires;
            this.textBox4.Text = ProfitManagement21.totalfuel;

            float num = float.Parse(textBox1.Text);
            float num2 = float.Parse(textBox2.Text);
            float num3 = float.Parse(textBox3.Text);
            float num4 = float.Parse(textBox4.Text);

            float profit = num2 - (num + num3 + num4);
            string finalprofit = Convert.ToString(profit);

            this.textBox5.Text = finalprofit;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}