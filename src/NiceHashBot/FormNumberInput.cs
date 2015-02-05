using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NiceHashBot
{
    public partial class FormNumberInput : Form
    {
        public double Value;

        public FormNumberInput(string TitleText, double MinValue, double MaxValue, double DefaultValue, int DecimalPlaces)
        {
            InitializeComponent();

            this.Text = TitleText;
            this.numericUpDown1.Minimum = new decimal(MinValue);
            this.numericUpDown1.Maximum = new decimal(MaxValue);
            this.numericUpDown1.Value = new decimal(DefaultValue);
            this.numericUpDown1.DecimalPlaces = DecimalPlaces;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Value = decimal.ToDouble(numericUpDown1.Value);
            Close();
        }
    }
}
