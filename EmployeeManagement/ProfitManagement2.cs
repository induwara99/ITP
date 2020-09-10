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
    public partial class ProfitManagement2 : Form
    {
        public static String EmployeeId;

        public ProfitManagement2()
        {
            InitializeComponent();
            

    }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement33 p33 = new ProfitManagement33();
            //p33.ShowDialog();

            EmployeeId = textsearchid.Text;

            //this.Hide();
            p33.Show();
        }

        private void textsearchid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement1 p1 = new ProfitManagement1();
            p1.Show();
        }
    }
}
