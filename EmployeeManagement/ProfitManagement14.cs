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
    public partial class ProfitManagement14 : Form
    {
        public static string TripId;

        public ProfitManagement14()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProfitManagement15 p15 = new ProfitManagement15();
            TripId = texttripid.Text;
            p15.Show();
        }

        private void ProfitManagement14_Load(object sender, EventArgs e)
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
            ProfitManagement13 p13 = new ProfitManagement13();
            p13.Show();
        }
    }
}
