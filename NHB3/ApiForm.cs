using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NHB3.ApiConnect;

namespace NHB3
{
    public partial class ApiForm : Form
    {
        ApiConnect ac;
           
        public ApiForm(ApiConnect ac)
        {
            InitializeComponent();
            this.Show();
            this.ac = ac;

            //load current settings
            ApiSettings saved = this.ac.readSettings();
            this.textBox1.Text = saved.OrganizationID;
            this.textBox2.Text = saved.ApiID;
            this.textBox3.Text = saved.ApiSecret;

            if (saved.Enviorment == 0)
            {
                this.radioButton1.Checked = true;
            }
            else if (saved.Enviorment == 1) 
            {
                this.radioButton2.Checked = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/nicehash/rest-clients-demo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.label5.Visible = false; //error
            this.label6.Visible = false; //success

            ApiSettings current = formSettings();
            ac.setup(current);
            if (ac.settingsOk()) {
                this.label6.Visible = true;
                this.button2.Enabled = true;
            } else {
                this.label5.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String fileName = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");
            ApiSettings current = formSettings();
            File.WriteAllText(fileName, JsonConvert.SerializeObject(current));
            this.Close();
        }

        private ApiSettings formSettings() {
            ApiSettings current = new ApiSettings();

            current.OrganizationID = this.textBox1.Text;
            current.ApiID = this.textBox2.Text;
            current.ApiSecret = this.textBox3.Text;

            if (this.radioButton1.Checked == true)
            {
                current.Enviorment = 0;
            }
            else if (this.radioButton2.Checked == true)
            {
                current.Enviorment = 1;
            }
            return current;
        }
    }
}
