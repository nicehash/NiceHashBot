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
        public int ID { get { return decimal.ToInt32(numericUpDown1.Value); } internal set { numericUpDown1.Value = value; } }
        public string Key { get { return textBox1.Text; } internal set { textBox1.Text = value; } }
        public string TwoFASecret { get { return textBox2.Text; } internal set { textBox2.Text = value; } }

        public string ProxyHost { get { return textBox3.Text; } internal set { textBox3.Text = value; } }
        public int ProxyPort { get { return decimal.ToInt32(numericUpDown2.Value); } internal set { numericUpDown2.Value = value; } }
        public string ProxyUsername { get { return textBox4.Text; } internal set { textBox4.Text = value; } }
        public string ProxyPassword { get { return textBox5.Text; } internal set { textBox5.Text = value; } }

        public FormSettings(SettingsContainer OldSettings)
        {
            InitializeComponent();

            this.ID = OldSettings.APIID;
            this.Key = OldSettings.APIKey;
            this.TwoFASecret = OldSettings.TwoFactorSecret;
            this.ProxyHost = OldSettings.ProxyHost;
            this.ProxyPort = OldSettings.ProxyPort;
            this.ProxyUsername = OldSettings.ProxyUsername;
            this.ProxyPassword = OldSettings.ProxyPassword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ID == 0)
            {
                MessageBox.Show("Please, set API ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numericUpDown1.Focus();
                return;
            }

            if (this.Key.Length == 0)
            {
                MessageBox.Show("Please, set API Key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.nicehash.com/index.jsp?p=account");
        }
    }
}
