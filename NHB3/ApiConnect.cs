using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHB3
{
    public class ApiConnect
    {
        Api api;
        public JArray algorithms; //hold algo settings
        public JArray buy; //hold buy settings
        public JArray pools = new JArray();
        public bool connected = false;
        public string currency;

        public void setup(ApiSettings settings) {
            this.api       = new Api(getApiUrl(settings.Enviorment), settings.OrganizationID, settings.ApiID, settings.ApiSecret);
            this.connected = true;

            //read algo settings
            string algosResponse = api.get("/main/api/v2/mining/algorithms", false);

            JObject algosObject = JsonConvert.DeserializeObject<JObject>(algosResponse);
            if (algosObject["error_id"] == null)
            {
                algorithms = algosObject["miningAlgorithms"] as JArray;
            }

            //read buy settings
            string buyResponse = api.get("/main/api/v2/public/buy/info", false);

            JObject buyObject = JsonConvert.DeserializeObject<JObject>(buyResponse);
            if (buyObject["error_id"] == null)
            {
                buy = buyObject["miningAlgorithms"] as JArray;
            }
        }

        public JArray getMarket() {
            string marketResponse = api.get("/main/api/v2/public/orders/active2", false);
            if (String.IsNullOrEmpty(marketResponse)) {
                return new JArray();
            }

            JObject marektObject = JsonConvert.DeserializeObject<JObject>(marketResponse);
            if (marektObject["error_id"] == null)
            {
                return marektObject["list"] as JArray;
            }
            return new JArray();
        }

        public JArray getMarketForAlgo(String algorithm)
        {
            string marketResponse = api.get("/main/api/v2/public/orders/active2?algorithm="+algorithm, false);
            if (String.IsNullOrEmpty(marketResponse))
            {
                return new JArray();
            }

            JObject marektObject = JsonConvert.DeserializeObject<JObject>(marketResponse);
            if (marektObject["error_id"] == null)
            {
                return marektObject["list"] as JArray;
            }
            return new JArray();
        }

        public bool settingsOk() {
            string accountsResponse = api.get("/main/api/v2/accounting/accounts2", true);

            JObject accountsObject = JsonConvert.DeserializeObject<JObject>(accountsResponse);
            if (accountsObject["error_id"] == null)
            {
                return true;
            }
            return false;
        }

        public JObject getBalance(string currency) {
            string accountsResponse = api.get("/main/api/v2/accounting/accounts2", true);

            JObject accountsObject = JsonConvert.DeserializeObject<JObject>(accountsResponse);

            if (accountsObject["error_id"] != null)
            {
                //api call failed
                Console.WriteLine("Error reading API ... {0}", accountsObject);
                return null;
            }

            JArray currencies = accountsObject["currencies"] as JArray;
            foreach (JObject obj in currencies)
            {
                string curr = obj["currency"].ToString();
                if (curr.Equals(currency)) {
                    return obj;
                }
            }
            return null;
        }

        public JArray getPools(bool force) {
            if (force)
            {
                string poolsResponse = api.get("/main/api/v2/pools?size=1000", true);
                JObject poolsObject = JsonConvert.DeserializeObject<JObject>(poolsResponse);

                if (poolsObject["error_id"] == null)
                {
                    this.pools = poolsObject["list"] as JArray;
                }
            }
            return this.pools;
        }

        public void deletePool(string id) {
            api.delete("/main/api/v2/pool/"+id, false);
        }

        public void editPool(string name, string algorithm, string url, string port, string username, string password, string id) {
            Dictionary<string, string> pool = new Dictionary<string, string>
            {
                { "id", id },
                { "algorithm", algorithm },
                { "name", name },
                { "username", username },
                { "password", password },
                { "stratumHostname", url },
                { "stratumPort", port }
            };
            api.post("/main/api/v2/pool", JsonConvert.SerializeObject(pool), false);
        }

        public void addPool(string name, string algorithm, string url, string port, string username, string password) {
            Dictionary<string, string> pool = new Dictionary<string, string>
            {
                { "algorithm", algorithm },
                { "name", name },
                { "username", username },
                { "password", password },
                { "stratumHostname", url },
                { "stratumPort", port }
            };
            api.post("/main/api/v2/pool", JsonConvert.SerializeObject(pool), false);
        }

        public JArray getOrders() {
            long ts = Convert.ToInt64(api.time) + (24 * 60 * 1000); //in case of stratum "refresh"

            string ordersResponse = api.get("/main/api/v2/hashpower/myOrders?active=true&op=LE&limit=1000&ts="+ts, true);
            JObject ordersObject = JsonConvert.DeserializeObject<JObject>(ordersResponse);

            if (ordersObject["error_id"] == null)
            {
                return ordersObject["list"] as JArray;
            }
            return new JArray();
        }

        public JObject getFixedPrice(string algo, string limit, string market) {
            Dictionary<string, string> reqParams = new Dictionary<string, string>
            {
                { "algorithm", algo },
                { "limit", limit },
                { "market", market }
            };
            string fixedResponse = api.post("/main/api/v2/hashpower/orders/fixedPrice", JsonConvert.SerializeObject(reqParams), false);
            JObject fixedObject = JsonConvert.DeserializeObject<JObject>(fixedResponse);

            if (fixedObject["error_id"] == null)
            {
                return fixedObject;
            }
            return new JObject();
        }

        public JObject createOrder(string algo, string market, string type, string pool, string price, string limit, string amount) {
            JObject selAlgo = getAlgo(algo);

            Dictionary<string, string> order = new Dictionary<string, string> {
                { "algorithm", algo },
                { "amount", amount },
                { "displayMarketFactor", (string)selAlgo["displayMarketFactor"] },
                { "displayPriceFactor", (string)selAlgo["displayPriceFactor"] },
                { "limit", limit },
                { "market", market },
                { "marketFactor", (string)selAlgo["marketFactor"] },
                { "poolId", pool },
                { "price", price },
                { "priceFactor", (string)selAlgo["priceFactor"] },
                { "type", type }
            };
            string newOrderResponse = api.post("/main/api/v2/hashpower/order", JsonConvert.SerializeObject(order), true);
            JObject orderObject = JsonConvert.DeserializeObject<JObject>(newOrderResponse);

            if (orderObject["error_id"] == null)
            {
                return orderObject;
            }
            return new JObject();
        }

        public JObject refillOrder(string id, string amount) {
            Dictionary<string, string> order = new Dictionary<string, string> {
                { "amount", amount }
            };

            string refillOrderResponse = api.post("/main/api/v2/hashpower/order/"+id+"/refill", JsonConvert.SerializeObject(order), true);
            JObject orderObject = JsonConvert.DeserializeObject<JObject>(refillOrderResponse);

            if (orderObject["error_id"] == null)
            {
                return orderObject;
            }
            return new JObject();
        }

        public JObject updateOrder(string algo, string id, string price, string limit)
        {
            JObject selAlgo = getAlgo(algo);
            Dictionary<string, string> order = new Dictionary<string, string> {
                { "price", price },
                { "limit", limit },
                { "displayMarketFactor", (string)selAlgo["displayMarketFactor"] },
                { "marketFactor", (string)selAlgo["marketFactor"] },
                { "displayPriceFactor", (string)selAlgo["displayPriceFactor"] },
                { "priceFactor", (string)selAlgo["priceFactor"] }
            };

            string editOrderResponse = api.post("/main/api/v2/hashpower/order/" + id + "/updatePriceAndLimit", JsonConvert.SerializeObject(order), true);
            JObject orderObject = JsonConvert.DeserializeObject<JObject>(editOrderResponse);

            if (orderObject["error_id"] == null)
            {
                return orderObject;
            }
            return new JObject();
        }

        public JObject cancelOrder(string id) 
        {
            string deleteOrderResponse = api.delete("/main/api/v2/hashpower/order/" + id, true);
            JObject orderObject = JsonConvert.DeserializeObject<JObject>(deleteOrderResponse);

            if (orderObject["error_id"] == null)
            {
                return orderObject;
            }
            return new JObject();
        }

        public ApiSettings readSettings() { 
            String fileName = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");
            if (File.Exists(fileName))
            {
                ApiSettings saved = JsonConvert.DeserializeObject<ApiSettings>(File.ReadAllText(@fileName));
                return saved;
            }
            return new ApiSettings();
        }

        public JObject getAlgo(string algo) {
            foreach (JObject obj in algorithms)
            {
                if (algo.Equals(""+obj["algorithm"]))
                {
                    return obj;
                }
            }
            return new JObject();
        }

        private string getApiUrl(int Enviorment)
        {
            if (Enviorment == 1)
            {
                return "https://api2.nicehash.com";
            } else if (Enviorment == 99)
            {
                return "https://api-test-dev.nicehash.com";
            }
            return "https://api-test.nicehash.com";
        }

        public class ApiSettings
        {
            public string OrganizationID { get; set; }

            public string ApiID { get; set; }

            public string ApiSecret { get; set; }

            public int Enviorment { get; set; }
        }
    }
}
