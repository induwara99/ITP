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
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void ProfitManagement22_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}
