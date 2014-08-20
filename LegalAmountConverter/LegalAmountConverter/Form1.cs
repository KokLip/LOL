using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LegalAmountConverter
{
    public partial class LegalAmountConverter : Form
    {
        public LegalAmountConverter()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(txtAmount.Text);
            try
            {
                if (number < 0)
                {
                    throw new NegativeNumberException();
                }
            }
            catch (NegativeNumberException error)
            {
                MessageBox.Show(error.Message);
            }
            English english = new English(number);
            if (number >= 0) 
            label3.Text = english.Converter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(txtAmount.Text);
            try
            {
                if (number < 0)
                {
                    throw new NegativeNumberException();
                }
            }
            catch (NegativeNumberException error)
            {
                MessageBox.Show(error.Message);
            }
            Melayu melayu = new Melayu(number);
            if (number >= 0)
            label3.Text = melayu.Converter();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
