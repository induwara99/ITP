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
    public partial class ProfitManagement13 : Form
    {
        public ProfitManagement13()
        {
            InitializeComponent();
            
            
        }

        private void validateCategory()
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a category");
            }
            else
            {
                selectCategory();
            }
        }

        private void selectCategory()
        {
            String Comboboxvalue = comboBox1.SelectedItem.ToString();

            if (Comboboxvalue == "Trips")
            {

                this.Hide();
                ProfitManagement14 prof14 = new ProfitManagement14();
                prof14.Show();

            }

            if (Comboboxvalue == "Trips")
            {

                this.Hide();
                ProfitManagement14 prof14 = new ProfitManagement14();
                prof14.Show();

            }

            if (Comboboxvalue == "Vehicle Repairs")
            {

                this.Hide();
                ProfitManagement16 prof16 = new ProfitManagement16();
                prof16.Show();

            }

            if (Comboboxvalue == "Fuel Reciepts")
            {

                this.Hide();
                ProfitManagement18 prof18 = new ProfitManagement18();
                prof18.Show();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            validateCategory();





        }

        private void ProfitManagement13_Load(object sender, EventArgs e)
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
            ProfitManagement12 p12 = new ProfitManagement12();
            p12.Show();
        }
    }
}
