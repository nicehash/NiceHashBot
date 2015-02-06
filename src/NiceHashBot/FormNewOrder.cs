using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NiceHashBotLib;

namespace NiceHashBot
{
    public partial class FormNewOrder : Form
    {
        private Pool[] Pools;
        private bool AdvancedOptionsShown;

        public FormNewOrder()
        {
            InitializeComponent();

            foreach (string A in APIWrapper.SERVICE_NAME)
                this.comboBox1.Items.Add(A);

            foreach (string A in APIWrapper.ALGORITHM_NAME)
                this.comboBox2.Items.Add(A);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            RefreshPoolList();
            AdvancedOptionsShown = true;
            linkLabel1_LinkClicked(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain.ShowFormPools();
        }

        public void RefreshPoolList()
        {
            comboBox3.Items.Clear();

            Pools = PoolContainer.GetAll();
            foreach (Pool P in Pools)
            {
                comboBox3.Items.Add(P.Label);
            }
        }

        private void FormNewOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.FormNewOrderInstance = null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1)
            {
                label5.Text = "TH/s";
                label8.Text = "BTC/TH/Day";
                label11.Text = "BTC/TH/Day";
            }
            else
            {
                label5.Text = "GH/s";
                label8.Text = "BTC/GH/Day";
                label11.Text = "BTC/GH/Day";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AdvancedOptionsShown)
            {
                linkLabel1.Text = "Show advanced options";
                this.Size = new Size(this.Size.Width, 215);
            }
            else
            {
                linkLabel1.Text = "Hide advanced options";
                this.Size = new Size(this.Size.Width, 340);
            }

            AdvancedOptionsShown = !AdvancedOptionsShown;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex < 0)
            {
                MessageBox.Show("You have to select pool for this order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus();
                return;
            }

            double Limit = decimal.ToDouble(numericUpDown1.Value);
            double MaxPrice = decimal.ToDouble(numericUpDown2.Value);
            int OrderID = decimal.ToInt32(numericUpDown3.Value);
            double StartPrice = decimal.ToDouble(numericUpDown4.Value);
            double StartAmount = decimal.ToDouble(numericUpDown5.Value);

            if (AdvancedOptionsShown)
            {
                OrderContainer.Add(comboBox1.SelectedIndex, comboBox2.SelectedIndex, MaxPrice, Limit, Pools[comboBox3.SelectedIndex], OrderID, StartPrice, StartAmount, textBox1.Text);
            }
            else
            {
                OrderContainer.Add(comboBox1.SelectedIndex, comboBox2.SelectedIndex, MaxPrice, Limit, Pools[comboBox3.SelectedIndex]);
            }

            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "CSharp dynamic link library|*.dll";
            OFD.Multiselect = false;
            OFD.InitialDirectory = Application.StartupPath;
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = OFD.FileName;
            }
        }
    }
}
