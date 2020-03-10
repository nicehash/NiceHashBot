using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHB3
{
    public partial class PoolForm : Form
    {
        ApiConnect ac;

        public PoolForm(ApiConnect ac, int mode, JToken pool)
        {
            InitializeComponent();
            this.Show();
            this.ac = ac;

            if (mode == 1)
            {
                this.Text = "Add pool";
                this.buttonAdd.Visible = true;
            }
            else if (mode == 2)
            {
                this.Text = "Edit pool " + pool["id"];
                this.buttonEdit.Visible = true;
            }
            else if (mode == 3)
            {
                this.Text = "Delete pool" + pool["id"];
                this.buttonDelete.Visible = true;
            }

            foreach (JObject obj in ac.algorithms)
            {
                this.comboAlgorithm.Items.Add(obj["algorithm"]);
            }
            this.comboAlgorithm.SelectedIndex = 0;

            if (mode == 2 || mode == 3) {
                this.textName.Text = "" + pool["name"];
                this.comboAlgorithm.SelectedItem = pool["algorithm"];
                this.textUrl.Text = "" + pool["stratumHostname"];
                this.textPort.Text = "" + pool["stratumPort"];
                this.textUsername.Text = "" + pool["username"];
                this.textPassword.Text = "" + pool["password"];
                this.textId.Text = "" + pool["id"];
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ac.deletePool(this.textId.Text);
            this.Close();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ac.editPool(this.textName.Text, ""+this.comboAlgorithm.SelectedItem, this.textUrl.Text, this.textPort.Text, this.textUsername.Text, this.textPassword.Text, this.textId.Text);
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ac.addPool(this.textName.Text, ""+this.comboAlgorithm.SelectedItem, this.textUrl.Text, this.textPort.Text, this.textUsername.Text, this.textPassword.Text);
            this.Close();
        }
    }
}
