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
    public partial class ProfitManagement20 : Form
    {
        public static String year;

        public ProfitManagement20()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f1 = new Form2();
            f1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String Comboboxvalue = comboBox1.SelectedItem.ToString();
            String Comboboxvalue2 = comboBox2.SelectedItem.ToString();

            if (comboBox1.SelectedItem == "September")
            {
                year = comboBox2.SelectedItem.ToString() + "-" + "09";

            }




            if (Comboboxvalue == "September" && Comboboxvalue2 == "2020")
            {
                this.Hide();
                ProfitManagement21 prof21 = new ProfitManagement21();
                prof21.Show();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void getdate()
        {
            
           

        }
            
    }
}
