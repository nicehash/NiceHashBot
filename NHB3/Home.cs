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
using static NHB3.ApiConnect;

namespace NHB3
{
    public partial class Home : Form
    {
        ApiConnect ac;
        string currency = "TBTC";
        bool botRunning = false;
        JArray orders;
        JArray market;

        System.Threading.Timer timer;

        public Home()
        {
            InitializeComponent();
            ac = new ApiConnect();

            ApiSettings saved = ac.readSettings();
            OrdersSettings orders = ac.readOrdersSettings();

            if (saved.OrganizationID != null) {
                ac.setup(saved);

                if (saved.Enviorment == 1) {
                    currency = "BTC";
                }
                ac.currency = currency;
                refreshBalance();
                refreshOrders(false);
                ac.getPools(true);

                timer = new System.Threading.Timer(
                    e => runBot(),
                    null,
                    TimeSpan.Zero,
                    TimeSpan.FromSeconds(60));
            }
        }

        private void api_Click(object sender, EventArgs e)
        {
            ApiForm af = new ApiForm(ac);
            af.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void pools_Click(object sender, EventArgs e)
        {
            PoolsForm pf = new PoolsForm(ac);
            pf.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void botToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BotForm bf = new BotForm();
            bf.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm of = new OrderForm(ac);
            of.FormBorderStyle = FormBorderStyle.FixedSingle;
            of.FormClosed += new FormClosedEventHandler(f_FormClosed); //refresh orders
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshOrders(false);
        }

        private void balanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshBalance();
        }

        private void refreshBalance() {
            if (ac.connected)
            {
                JObject balance = ac.getBalance(currency);
                if (balance != null)
                {
                    this.toolStripStatusLabel2.Text = "Balance: " + balance["available"] + " " + currency;
                }
            } else {
                this.toolStripStatusLabel2.Text = "Balance: N/A " + currency;
            }
        }

        private void refreshOrders(bool fromThread)
        {
            //read custom order settings
            ApiConnect.OrdersSettings cos = ac.readOrdersSettings();

            if (ac.connected)
            {
                orders = ac.getOrders();

                //filter out data
                JArray cleanOrders = new JArray();
                foreach (JObject order in orders)
                {
                    JObject cleanOrder = new JObject();
                    cleanOrder.Add("id", ""+order["id"]);
                    cleanOrder.Add("market", "" + order["market"]);
                    cleanOrder.Add("pool", "" + order["pool"]["name"]);
                    cleanOrder.Add("type", (""+order["type"]["code"]).Equals("STANDARD") ? "standard" : "fixed");
                    cleanOrder.Add("algorithm", "" + order["algorithm"]["algorithm"]);
                    cleanOrder.Add("amount", "" + order["amount"]);
                    cleanOrder.Add("payedAmount", "" + order["payedAmount"]);
                    cleanOrder.Add("availableAmount", "" + order["availableAmount"]);
                    
                    float payed = float.Parse("" + order["payedAmount"], CultureInfo.InvariantCulture);
                    float available = float.Parse("" + order["availableAmount"], CultureInfo.InvariantCulture);
                    float spent_factor = payed / available * 100;

                    cleanOrder.Add("spentPercent", "" + spent_factor.ToString("0.00")+ "%");
                    cleanOrder.Add("limit", "" + order["limit"]);
                    cleanOrder.Add("price", "" + order["price"]);

                    //max price
                    cleanOrder.Add("maxPrice", getMaxPrice("" + order["id"], cos));

                    cleanOrder.Add("rigsCount", "" + order["rigsCount"]);
                    cleanOrder.Add("acceptedCurrentSpeed", "" + order["acceptedCurrentSpeed"]);
                    cleanOrders.Add(cleanOrder);
                }

                if (fromThread)
                {
                    dataGridView1.Invoke((MethodInvoker)delegate
                    {
                        dataGridView1.DataSource = cleanOrders;
                    });
                } else
                {
                    dataGridView1.DataSource = cleanOrders;
                }

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.AllowUserToOrderColumns = true;
                dataGridView1.AllowUserToResizeColumns = true;
            }
        }

        private string getMaxPrice(string id, ApiConnect.OrdersSettings cos) {
            foreach (var order in cos.OrderList)
            {
                if (id.Equals(order.Id))
                {
                    return order.MaxPrice;
                }
            }
            return "";
        }

        private void refreshMarket() {
            if (ac.connected)
            {
                market = ac.getMarket();
            }
        }

        private void autoPilotOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Stopped";
            botRunning = false;
        }

        private void autoPilotONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Idle";
            botRunning = true;
            runBot();
        }

        private void editSelectedOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) == 1)
            {
                OrderForm of = new OrderForm(ac);
                of.FormBorderStyle = FormBorderStyle.FixedSingle;
                of.setEditMode((JObject)orders[dataGridView1.SelectedRows[0].Index]);
                of.FormClosed += new FormClosedEventHandler(f_FormClosed); //refresh orders
            }
        }

        private void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            refreshOrders(false);
        }
        
        private void runBot() {
            if (!botRunning) {
                return;
            }

            //read needed data
            String fileName = Path.Combine(Directory.GetCurrentDirectory(), "bot.json");
            if (!File.Exists(fileName))
            {
                return;
            }

            toolStripStatusLabel1.Text = "Working";

            //read order individual settings
            ApiConnect.OrdersSettings cos = ac.readOrdersSettings();

            BotSettings saved = JsonConvert.DeserializeObject<BotSettings>(File.ReadAllText(@fileName));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("bot iteration tasks {0} {1} {2}", saved.reffilOrder, saved.lowerPrice, saved.increasePrice);

            Control.CheckForIllegalCrossThreadCalls = false;
            refreshOrders(true);

            if (saved.lowerPrice || saved.increasePrice) {
                refreshMarket();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("orders to process: {0}", orders.Count);

            //do refill??
            if (saved.reffilOrder) {
                foreach (JObject order in orders)
                {
                    float payed = float.Parse("" + order["payedAmount"], CultureInfo.InvariantCulture);
                    float available = float.Parse("" + order["availableAmount"], CultureInfo.InvariantCulture);
                    float spent_factor = payed/available*100;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("?refill?; order {0}, payed {1}, available {2}, percent {3}", order["id"], payed, available, spent_factor.ToString("0.00"));

                    if (spent_factor > 90)
                    {
                        JObject algo = ac.getAlgo(""+order["algorithm"]["algorithm"]);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("===> refill order for {0}", algo["minimalOrderAmount"]);
                        ac.refillOrder(""+order["id"], ""+algo["minimalOrderAmount"]);
                    }
                }
            }

            //do speed adjust??
            if (saved.lowerPrice || saved.increasePrice) {
                foreach (JObject order in orders) {
                    string order_type = "" + order["type"]["code"];
                    if (order_type.Equals("STANDARD"))
                    {
                        //get order custom settings
                        String omp = getMaxPrice("" + order["id"], cos);
                        float maxOrderPriceLimit = 0F;
                        if (!String.IsNullOrEmpty(omp)) {
                            maxOrderPriceLimit = float.Parse("" + omp, CultureInfo.InvariantCulture);
                        }

                        JObject algo = ac.getAlgo("" + order["algorithm"]["algorithm"]);
                        float order_speed = float.Parse("" + order["acceptedCurrentSpeed"], CultureInfo.InvariantCulture);
                        float rigs_count = float.Parse("" + order["rigsCount"], CultureInfo.InvariantCulture);
                        float order_price = float.Parse("" + order["price"], CultureInfo.InvariantCulture);
                        float price_step_down = float.Parse("" + algo["priceDownStep"], CultureInfo.InvariantCulture);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("?adjust price?; order {0}, speed {1}, rigs {2}, price {3}, step_down {4}, max order limit {5}", order["id"], order_speed, rigs_count, order_price, price_step_down, maxOrderPriceLimit);

                        if (saved.increasePrice && (order_speed == 0 || rigs_count == 0)) {
                            float new_price = (float)Math.Round(order_price + (price_step_down * -1), 4);

                            if (maxOrderPriceLimit > 0 && new_price > maxOrderPriceLimit) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("===> price up denied - max limit enforced {0} {1}", new_price, maxOrderPriceLimit);
                            } 
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("===> price up order to {0}", new_price);
                                ac.updateOrder("" + order["algorithm"]["algorithm"], "" + order["id"], new_price.ToString(new CultureInfo("en-US")), "" + order["limit"]);
                            }
                        } else if (saved.lowerPrice && (order_speed > 0 || rigs_count > 0)) {
                            Dictionary<string, float> market = getOrderPriceRangesForAlgoAndMarket("" + order["algorithm"]["algorithm"], "" + order["market"]);
                            var list = market.Keys.ToList();
                            list.Sort();

                            int idx = 0;
                            foreach (var key in list)
                            {
                                float curr_tier_price = float.Parse(key, CultureInfo.InvariantCulture);
                                if (key.Equals(""+order_price)) {
                                    break;
                                }
                                idx++;
                            }

                            if (idx > 1) {
                                float new_price = (float)Math.Round(order_price + price_step_down, 4);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("===> price down order to {0}", new_price);
                                ac.updateOrder("" + order["algorithm"]["algorithm"], "" + order["id"], new_price.ToString(new CultureInfo("en-US")), "" + order["limit"]);
                            }
                        }
                    }
                }
            }
            toolStripStatusLabel1.Text = "Idle";
        }

        private Dictionary<string, float> getOrderPriceRangesForAlgoAndMarket(string oa, string om)
        {
            var prices = new Dictionary<string, float>();

            foreach (JObject order in market)
            {
                string order_type   = "" + order["type"];
                string order_algo   = "" + order["algorithm"];
                string order_market = "" + order["market"];
                float order_speed   = float.Parse("" + order["acceptedCurrentSpeed"], CultureInfo.InvariantCulture);
                string order_price  = "" + order["price"];

                if (order_type.Equals("STANDARD") && order_algo.Equals(oa) && order_market.Equals(om) && order_speed > 0) {
                    if (prices.ContainsKey(order_price))
                    {
                        prices[order_price] = prices[order_price] + order_speed;
                    }
                    else 
                    {
                        prices[order_price] = order_speed;
                    }
                }
            }
            return prices;
        }
    }
}
