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
    public partial class EAMForm4 : Form
    {
        public EAMForm4()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm7 eam7 = new EAMForm7();
            eam7.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm13 eam13 = new EAMForm13();
            eam13.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm8 eam8 = new EAMForm8();
            eam8.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm9 eam9 = new EAMForm9();
            eam9.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm10 eam10 = new EAMForm10();
            eam10.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm16 eam5 = new EAMForm16();
            eam5.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm1 eam1 = new EAMForm1();
            eam1.Show();
        }
    }
}
