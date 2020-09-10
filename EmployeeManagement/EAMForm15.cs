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
    public partial class EAMForm15 : Form
    {
        public EAMForm15()
        {
            InitializeComponent();
        }



        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm3 eam3 = new EAMForm3();
            eam3.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm14 eam14 = new EAMForm14();
            eam14.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm2 eam2 = new EAMForm2();
            eam2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm1 eam1 = new EAMForm1();
            eam1.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm3 eam2 = new EAMForm3();
            eam2.Show();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm2 eam2 = new EAMForm2();
            eam2.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            EAMForm14 eam14 = new EAMForm14();
            eam14.Show();
        }
    }
}
