using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCarProp
{
    public partial class RentCar : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public RentCar()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_dias.Text, "[^0-9]"))
            {
                txt_dias.Text = txt_dias.Text.Remove(txt_dias.Text.Length - 1);
            }
        }

        private void txt_monto_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_monto.Text, "[^0-9]"))
            {
                txt_monto.Text = txt_monto.Text.Remove(txt_monto.Text.Length - 1);
            }
        }
    }
}
