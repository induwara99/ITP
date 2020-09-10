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
    public partial class EAMForm12 : Form
    {
        public EAMForm12()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm4 eam4 = new EAMForm4();
            eam4.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm4 eam4 = new EAMForm4();
            eam4.Show();
        }
    }
}
