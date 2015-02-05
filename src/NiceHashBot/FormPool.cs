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
    public partial class FormPool : Form
    {
        public FormPool()
        {
            InitializeComponent();

            RefreshList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1 ||
                textBox2.Text.Length < 1 ||
                textBox3.Text.Length < 1 ||
                textBox4.Text.Length < 1)
            {
                MessageBox.Show("Please, fill host, username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PoolContainer.Add(textBox1.Text, textBox2.Text, decimal.ToInt32(numericUpDown1.Value), textBox3.Text, textBox4.Text);
            RefreshList();
        }


        private void RefreshList()
        {
            listView1.Items.Clear();

            Pool[] Pools = PoolContainer.GetAll();
            foreach (Pool P in Pools)
            {
                ListViewItem LVI = new ListViewItem(P.Label);
                LVI.SubItems.Add(P.Host);
                LVI.SubItems.Add(P.Port.ToString());
                LVI.SubItems.Add(P.User);
                LVI.SubItems.Add(P.Password);
                LVI.Tag = P;
                listView1.Items.Add(LVI);
            }

            if (FormMain.FormNewOrderInstance != null)
                FormMain.FormNewOrderInstance.RefreshPoolList();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Pool P = listView1.SelectedItems[0].Tag as Pool;
                textBox1.Text = P.Label;
                textBox2.Text = P.Host;
                numericUpDown1.Value = P.Port;
                textBox3.Text = P.User;
                textBox4.Text = P.Password;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                PoolContainer.Remove(listView1.SelectedIndices[0]);
                RefreshList();
            }
        }

        private void FormPool_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormMain.FormPoolInstance = null;
        }
    }
}
