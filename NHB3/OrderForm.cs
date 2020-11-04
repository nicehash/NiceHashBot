using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHB3
{
    public partial class OrderForm : Form
    {
        ApiConnect ac;
        JObject algo;

        string lastFixedAlgo = "";
        string lastFixedMarket = "";
        string lastFixedLimit = "";
        bool edit = false;

        public OrderForm(ApiConnect ac)
        {
            InitializeComponent();
            this.Show();
            this.ac = ac;
            
            this.currencyLbl.Text = ac.currency;
            
            //pools dropdown
            this.comboPools.DisplayMember = "name";
            this.comboPools.ValueMember = "id";

            foreach (JObject obj in ac.algorithms)
            {
                this.comboAlgorithm.Items.Add(obj["algorithm"]);
            }
            this.comboAlgorithm.SelectedIndex = 0;
        }

        private void comboAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get algo settings
            foreach (JObject obj in ac.algorithms)
            {
                if (this.comboAlgorithm.SelectedItem.Equals(obj["algorithm"]))
                {
                    this.algo = obj;
                }
            }

            //set lbls
            this.priceLbl.Text = ac.currency + "/" + this.algo["displayMarketFactor"] + "/day";
            this.limitLbl.Text = this.algo["displayMarketFactor"] + "/second";
            this.priceDetailsLbl.Text = "> 0";
            this.limitDetailsLbl.Text = "> " + this.algo["minSpeedLimit"] + " AND < " + this.algo["maxSpeedLimit"] + " OR 0 // no speed limit";
            this.amountDetailsLbl.Text = "> " + this.algo["minimalOrderAmount"];

            this.tbLimit.Text = ""+this.algo["minSpeedLimit"];
            this.tbAmount.Text = ""+this.algo["minimalOrderAmount"];

            //filter pools
            this.comboPools.Items.Clear();
            this.comboPools.ResetText();
            this.comboPools.SelectedIndex = -1;

            foreach (JObject pool in ac.getPools(false))
            {
                if (this.comboAlgorithm.SelectedItem.Equals(pool["algorithm"])) {
                    this.comboPools.Items.Add(pool);
                }
            }

            if (!edit) {
                formDataUpdate();
            }
        }

        private void formChanged(object sender, EventArgs e)
        {
            if (!edit) {
                formDataUpdate();
            }
        }

        private void formDataUpdate() {
            this.tbPrice.Enabled   = true;
            this.btnCreate.Enabled = true;
            this.lblPool.Visible   = false;
            this.lblCreate.Visible = false;
            this.lblErrorCreate.Visible = false;

            if (this.comboPools.SelectedItem == null) {
                this.btnCreate.Enabled = false;
                this.lblPool.Visible = true;
                return;
            }

            string algo = "" + this.comboAlgorithm.SelectedItem;
            string limit = "" + this.tbLimit.Text;
            string market = "EU";
            if (this.rbUSA.Checked) {
                market = "USA";
            }

            if (this.rbFixed.Checked)
            {
                JObject response = ac.getFixedPrice(algo, limit, market);

                this.btnCreate.Enabled = false;
                this.lblCreate.Visible = true;

                if (response["fixedMax"] != null && response["fixedPrice"] != null)
                {
                    this.tbPrice.Text = "" + response["fixedPrice"];
                    this.tbPrice.Enabled = false;
                    this.limitDetailsLbl.Text = "> " + this.algo["minSpeedLimit"] + " AND < " + response["fixedMax"];

                    this.btnCreate.Enabled = true;
                    this.lblCreate.Visible = false;
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string algo = ""+this.comboAlgorithm.SelectedItem;
            string market = "EU";
            if (this.rbUSA.Checked)
            {
                market = "USA";
            }
            string type = "STANDARD";
            if (this.rbFixed.Checked)
            {
                type = "FIXED";
            }
            JObject pool = (JObject)this.comboPools.SelectedItem;

            string price  = ""+this.tbPrice.Text;
            string limit  = ""+this.tbLimit.Text;
            string amount = ""+this.tbAmount.Text;

            JObject order = ac.createOrder(algo, market, type, ""+pool["id"], price, limit, amount);
            if (order["id"] != null)
            {
                this.lblErrorCreate.Visible = false;
                setEditMode(order);
            }
            else 
            {
                this.lblErrorCreate.Visible = true;
            }
        }

        public void setEditMode(JObject order) {
            edit = true;

            this.Text = "Edit order " + order["id"];
            this.tabControl1.Enabled = true;

            this.lblErrorCreate.Visible = false;
            this.lblPool.Visible = false;
            this.lblCreate.Visible = false;

            this.btnCreate.Visible = false;
            this.comboAlgorithm.Enabled = false;
            this.comboPools.Enabled = false;
            this.rbEU.Enabled = false;
            this.rbUSA.Enabled = false;
            this.rbStd.Enabled = false;
            this.rbFixed.Enabled = false;
            this.tbPrice.Enabled = false;
            this.tbLimit.Enabled = false;
            this.tbAmount.Enabled = false;

            if (order["type"]["code"].Equals("FIXED")) {
                this.tbNewLimit.Enabled = false;
                this.tbNewPrice.Enabled = false;
                this.btnUpdate.Enabled = false;
            } else {
                this.tbNewLimit.Enabled = true;
                this.tbNewPrice.Enabled = true;
                this.btnUpdate.Enabled = true;
            }

            //set values
            this.tbId.Text = ""+order["id"];
            this.comboAlgorithm.SelectedItem = order["algorithm"]["algorithm"];
            if ((""+order["market"]).Equals("EU"))
            {
                this.rbEU.Checked = true;
                this.rbUSA.Checked = false;
            } else {
                this.rbEU.Checked = false;
                this.rbUSA.Checked = true;
            }

            if ((""+order["type"]["code"]).Equals("STANDARD"))
            {
                this.rbStd.Checked = true;
                this.rbFixed.Checked = false;
            } else {
                this.rbStd.Checked = false;
                this.rbFixed.Checked = true;
            }

            int idx = 0;
            foreach (JObject pool in this.comboPools.Items) {
                if (order["pool"]["id"].Equals(pool["id"])) {
                    break;
                }
                idx++;
            }
            this.comboPools.SelectedIndex = idx;

            this.tbPrice.Text = "" + order["price"];
            this.tbLimit.Text = "" + order["limit"];
            this.tbAmount.Text = "" + order["amount"];
            
            this.tbNewAmount.Text = "" + this.algo["minimalOrderAmount"];
            this.tbAvailableAmount.Text = "" + order["availableAmount"];
            this.tbNewPrice.Text = "" + order["price"];
            this.tbNewLimit.Text = "" + order["limit"];

            this.priceDetailsLbl2.Text = "step down < " + this.algo["priceDownStep"];
            this.amountDetailsLbl2.Text = "> " + this.algo["minimalOrderAmount"];
            this.limitDetailsLbl2.Text = "> " + this.algo["minSpeedLimit"] + " AND < " + this.algo["maxSpeedLimit"] + " OR 0";
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            string amount = "" + this.tbNewAmount.Text;
            string id = "" + this.tbId.Text;

            JObject order = ac.refillOrder(id, amount);
            if (order["id"] != null)
            {
                this.lblErrorCreate.Visible = false;
                setEditMode(order);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string algo = "" + this.comboAlgorithm.SelectedItem;
            string price = "" + this.tbNewPrice.Text;
            string limit = "" + this.tbNewLimit.Text;
            string id = "" + this.tbId.Text;

            JObject order = ac.updateOrder(algo, id, price, limit);
            if (order["id"] != null)
            {
                this.lblErrorCreate.Visible = false;
                setEditMode(order);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string id = "" + this.tbId.Text;

            JObject order = ac.cancelOrder(id);
            if (order["id"] != null)
            {
                this.Close();
            }
        }
                
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string id = "" + this.tbId.Text;
            ApiConnect.OrdersSettings cos = ac.readOrdersSettings();

            foreach (var order in cos.OrderList) {
                if (id.Equals(order.Id)) {
                    this.tbMaxPrice.Text = ""+order.MaxPrice;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string id = "" + this.tbId.Text;

            ApiConnect.OrdersSettings wos = ac.readOrdersSettings();
            wos.OrderList = new List<ApiConnect.OrderSettings>();

            ApiConnect.OrdersSettings cos = ac.readOrdersSettings();
            
            bool added = false;
            foreach (var order in cos.OrderList)
            {
                if (id.Equals(order.Id))
                {
                    order.MaxPrice = this.tbMaxPrice.Text;
                    added = true;
                }
                wos.OrderList.Add(order);
            }

            if (!added) {
                ApiConnect.OrderSettings osNew = new ApiConnect.OrderSettings();
                osNew.Id = id;
                osNew.MaxPrice = this.tbMaxPrice.Text;
                wos.OrderList.Add(osNew);
            }

            String fileName = Path.Combine(Directory.GetCurrentDirectory(), "orders.json");
            File.WriteAllText(fileName, JsonConvert.SerializeObject(wos));
            this.Close();
        }
    }
}