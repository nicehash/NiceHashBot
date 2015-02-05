using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NiceHashBot
{
    public partial class FormSettings : Form
    {
        public int ID;
        public string Key;
        public string TwoFASecret;

        public FormSettings(int OldID, string OldKey, string OldTwoFASecret)
        {
            InitializeComponent();

            numericUpDown1.Value = OldID;
            textBox1.Text = OldKey;
            textBox2.Text = OldTwoFASecret;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = decimal.ToInt32(numericUpDown1.Value);
            if (ID == 0)
            {
                MessageBox.Show("Please, set API ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Focus();
                return;
            }

            Key = textBox1.Text;
            if (Key.Length == 0)
            {
                MessageBox.Show("Please, set API Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            TwoFASecret = textBox2.Text;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nicehash.com/index.jsp?p=account");
        }
    }
}
