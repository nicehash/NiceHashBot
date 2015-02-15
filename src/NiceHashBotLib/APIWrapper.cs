using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace NiceHashBotLib
{
    public class APIWrapper
    {
        #region PUBLIC_PROPERTIES
        /// <summary>
        /// API Version compatible with.
        /// </summary>
        public readonly static string API_VERSION_COMPATIBLE = "1.0.10";

        /// <summary>
        /// URLs for NiceHash services.
        /// </summary>
        public readonly static string[] SERVICE_LOCATION = { "https://www.nicehash.com", "https://www.westhash.com" };

        /// <summary>
        /// Names for NiceHash services.
        /// </summary>
        public readonly static string[] SERVICE_NAME = { "NiceHash", "WestHash" };

        /// <summary>
        /// Names for algorithms.
        /// </summary>
        public readonly static string[] ALGORITHM_NAME = { "Scrypt", "SHA256", "Scrypt-A.-Nf.", "X11", "X13", "Keccak", "X15", "Nist5", "NeoScrypt", "Lyra2RE" };

        /// <summary>
        /// Total number of algorithms.
        /// </summary>
        public readonly static int NUMBER_OF_ALGORITHMS = 10;

        /// <summary>
        /// Price decrease steps for all algorithms.
        /// </summary>
        public readonly static double[] PRICE_DECREASE_STEP = { -0.001, -0.0001, -0.002, -0.001, -0.001, -0.0001, -0.001, -0.001, -0.01, -0.002 };

        /// <summary>
        /// Price decrase interval - it is 10 minutes.
        /// </summary>
        public readonly static TimeSpan PRICE_DECREASE_INTERVAL = new TimeSpan(0, 10, 1);

        /// <summary>
        /// API ID.
        /// </summary>
        public static string APIID;

        /// <summary>
        /// API Key.
        /// </summary>
        public static string APIKey;

        /// <summary>
        /// 2FA Secret used for generating 2FA codes.
        /// </summary>
        public static string TwoFASecret;

        /// <summary>
        /// If provided APIID and APIKey are valid, this is set to true.
        /// </summary>
        public static bool ValidAuthorization;

        #endregion

        #region PRIVATE_PROPERTIES

        private static object CacheLock = new object();
        private static CachedOrderList[,] CachedOList = new CachedOrderList[SERVICE_LOCATION.Length, NUMBER_OF_ALGORITHMS];
        private static CachedStats[,] CachedSList = new CachedStats[SERVICE_LOCATION.Length, NUMBER_OF_ALGORITHMS];

        #endregion

        #region PUBLIC_METHODS
        /// <summary>
        /// Initialize API with certain ID and Key.
        /// </summary>
        /// <param name="ID">API ID.</param>
        /// <param name="Key">API Key.</param>
        /// <returns>True if initialization has succeeded.</returns>
        public static bool Initialize(string ID, string Key)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            ValidAuthorization = false;

            LibConsole.OpenConsole();
            LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Initializating API Wrapper with ID=" + ID.ToString() + " and Key=" + Key);
            LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "This program is compatible with API version " + API_VERSION_COMPATIBLE);

            APIID = ID;
            APIKey = Key;

            // Verify API version
            string RemoteAPIVersion = GetRemoteAPIVersion();
            if (RemoteAPIVersion == null)
            {
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.ERROR, "Failed to get API Version.");
                return false;
            }

            LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Remote API version is " + RemoteAPIVersion);

            if (RemoteAPIVersion != API_VERSION_COMPATIBLE)
            {
                // If API version has changed, only print warning. Program may still work correctly after all.
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.WARNING, "Service API has changed. This program may not work fully correctly.");
            }

            APIBalance Balance = GetBalance();
            if (Balance == null)
            {
                // If we were unable to get balance, then id and key are incorrect.
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.ERROR, "Unable to get balance. Are ID and Key correct?");
                return false;
            }

            LibConsole.WriteLine(LibConsole.TEXT_TYPE.INFO, "Provided ID and Key are correct!");

            ValidAuthorization = true;
            return true;
        }

        /// <summary>
        /// Get remote API version.
        /// </summary>
        /// <returns>API version in string (format X.Y.Z).</returns>
        public static string GetRemoteAPIVersion()
        {
            Result<APIMethodVersion> R = Request<Result<APIMethodVersion>>(0, null, false, null);
            if (R == null) return null;
            return R.Data.APIVersion;
        }

        /// <summary>
        /// Get balance for account matching API ID and Key.
        /// </summary>
        /// <returns>APIBalance which contains confirmed and pending balance.</returns>
        public static APIBalance GetBalance()
        {
            Result<APIBalance> R = Request<Result<APIBalance>>(0, "balance", true, null);
            if (R == null) return null;
            return R.Data;
        }

        /// <summary>
        /// Get list of all orders.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <param name="ForceReCache">Set this to true to recache order list.</param>
        /// <returns>Array list of orders.</returns>
        public static List<Order> GetAllOrders(int ServiceLocation, int Algorithm, bool ForceReCache)
        {
            lock (CacheLock)
            {
                if (ForceReCache || CachedOList[ServiceLocation, Algorithm] == null || (CachedOList[ServiceLocation, Algorithm].ObtainTime + TimeSpan.FromSeconds(29.0) < DateTime.Now))
                {
                    CachedOList[ServiceLocation, Algorithm] = new CachedOrderList();
                    CachedOList[ServiceLocation, Algorithm].OrderList = GetOrders(ServiceLocation, Algorithm, "orders.get", false);
                    CachedOList[ServiceLocation, Algorithm].ObtainTime = DateTime.Now;
                }

                return CachedOList[ServiceLocation, Algorithm].OrderList;
            }
        }

        /// <summary>
        /// Get list of orders owned by account with initialized API ID and Key.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <returns>Array list of orders.</returns>
        public static List<Order> GetMyOrders(int ServiceLocation, int Algorithm)
        {
            return GetOrders(ServiceLocation, Algorithm, "orders.get&my", true);
        }

        /// <summary>
        /// Create new order.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <param name="BTCAmount">Order amount in BTC.</param>
        /// <param name="Price">Order price.</param>
        /// <param name="Limit">Order limit in GH/s (TH/s for Algorithm 1 - SHA256). 0 for unlimited.</param>
        /// <param name="PoolInfo">Pool information.</param>
        /// <returns>Order number - ID. If failed to create, 0 is returned.</returns>
        public static int OrderCreate(int ServiceLocation, int Algorithm, double BTCAmount, double Price, double Limit, Pool PoolInfo)
        {
            Dictionary<string, string> ReqParams = new Dictionary<string, string>();
            ReqParams.Add("algo", Algorithm.ToString());
            ReqParams.Add("amount", BTCAmount.ToString("F8"));
            ReqParams.Add("price", Price.ToString("F4"));
            ReqParams.Add("limit", Limit.ToString("F2"));
            ReqParams.Add("pool_host", PoolInfo.Host);
            ReqParams.Add("pool_port", PoolInfo.Port.ToString());
            ReqParams.Add("pool_user", PoolInfo.User);
            ReqParams.Add("pool_pass", PoolInfo.Password);

            if (TwoFASecret != null)
            {
                string Pin = ThirdPartyTools.GoogleAuthenticator.GeneratePin(TwoFASecret);
                ReqParams.Add("code", Pin);
            }

            Result<APISuccess> R = Request<Result<APISuccess>>(ServiceLocation, "orders.create", true, ReqParams);
            if (R == null) return 0;
            else
            {
                // Parse order number
                int a = R.Data.Text.IndexOf('#');
                if (a < 0) return 0;
                int b = R.Data.Text.IndexOf(' ', a + 1);
                if (b < 0) return 0;
                string OrderIDString = R.Data.Text.Substring(a + 1, b - a - 1);
                return int.Parse(OrderIDString);
            }
        }

        /// <summary>
        /// Refill order.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <param name="OrderID">Order number - ID.</param>
        /// <param name="BTCAmount">Amount to refill in BTC.</param>
        /// <returns>True if refill was successful.</returns>
        public static bool OrderRefill(int ServiceLocation, int Algorithm, int OrderID, double BTCAmount)
        {
            Dictionary<string, string> ReqParams = new Dictionary<string, string>();
            ReqParams.Add("algo", Algorithm.ToString());
            ReqParams.Add("amount", BTCAmount.ToString("F8"));
            ReqParams.Add("order", OrderID.ToString());

            Result<APISuccess> R = Request<Result<APISuccess>>(ServiceLocation, "orders.refill", true, ReqParams);
            if (R == null) return false;
            else return true;
        }

        /// <summary>
        /// Set order price. Only price increase allowed.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <param name="OrderID">Order number - ID.</param>
        /// <param name="Price">New order price.</param>
        /// <returns>New order price. If price was not changed, -1 is returned.</returns>
        public static double OrderSetPrice(int ServiceLocation, int Algorithm, int OrderID, double Price)
        {
            Dictionary<string, string> ReqParams = new Dictionary<string, string>();
            ReqParams.Add("algo", Algorithm.ToString());
            ReqParams.Add("price", Price.ToString("F4"));
            ReqParams.Add("order", OrderID.ToString());

            Result<APISuccess> R = Request<Result<APISuccess>>(ServiceLocation, "orders.set.price", true, ReqParams);
            if (R == null) return -1;
            else
            {
                // Get new price.
                int a = R.Data.Text.IndexOf(':');
                string OrderPriceString = R.Data.Text.Substring(a + 2);
                return double.Parse(OrderPriceString);
            }
        }

        /// <summary>
        /// Set order limit.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <param name="OrderID">Order number - ID.</param>
        /// <param name="Limit">New order limit in GH/s (TH/s for Algorithm 1 - SHA256). 0 for unlimited.</param>
        /// <returns>New order limit. If limit was not changed, -1 is returned.</returns>
        public static double OrderSetLimit(int ServiceLocation, int Algorithm, int OrderID, double Limit)
        {
            Dictionary<string, string> ReqParams = new Dictionary<string, string>();
            ReqParams.Add("algo", Algorithm.ToString());
            ReqParams.Add("limit", Limit.ToString("F2"));
            ReqParams.Add("order", OrderID.ToString());

            Result<APISuccess> R = Request<Result<APISuccess>>(ServiceLocation, "orders.set.limit", true, ReqParams);
            if (R == null) return -1;
            else
            {
                // Get new limit.
                int a = R.Data.Text.IndexOf(':');
                string OrderLimitString = R.Data.Text.Substring(a + 2);
                return double.Parse(OrderLimitString);
            }
        }

        /// <summary>
        /// Decrease order price.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <param name="OrderID">Order number - ID.</param>
        /// <returns>New order price. If price was not decreased, -1 is returned.</returns>
        public static double OrderSetPriceDecrease(int ServiceLocation, int Algorithm, int OrderID)
        {
            Dictionary<string, string> ReqParams = new Dictionary<string, string>();
            ReqParams.Add("algo", Algorithm.ToString());
            ReqParams.Add("order", OrderID.ToString());

            Result<APISuccess> R = Request<Result<APISuccess>>(ServiceLocation, "orders.set.price.decrease", true, ReqParams);
            if (R == null) return -1;
            else
            {
                // Get new price.
                int a = R.Data.Text.IndexOf(':');
                string OrderPriceString = R.Data.Text.Substring(a + 2);
                return double.Parse(OrderPriceString);
            }
        }

        /// <summary>
        /// Remove order.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <param name="OrderID">Order number - ID.</param>
        /// <returns>True if order was removed.</returns>
        public static bool OrderRemove(int ServiceLocation, int Algorithm, int OrderID)
        {
            Dictionary<string, string> ReqParams = new Dictionary<string, string>();
            ReqParams.Add("algo", Algorithm.ToString());
            ReqParams.Add("order", OrderID.ToString());

            Result<APISuccess> R = Request<Result<APISuccess>>(ServiceLocation, "orders.remove", true, ReqParams);
            if (R == null) return false;
            return true;
        }

        /// <summary>
        /// Get total available speed for certain algorithm.
        /// </summary>
        /// <param name="ServiceLocation">Service location; 0 for NiceHash, 1 for WestHash.</param>
        /// <param name="Algorithm">Algorithm number.</param>
        /// <returns>Total speed in GH/s or -1 if error.</returns>
        public static double GetTotalSpeed(int ServiceLocation, int Algorithm)
        {
            lock (CacheLock)
            {
                if (CachedSList[ServiceLocation, Algorithm] == null || (CachedSList[ServiceLocation, Algorithm].ObtainTime + TimeSpan.FromSeconds(29.0) < DateTime.Now))
                {
                    double TS = GetTotalSpeedForAlgorithm(ServiceLocation, Algorithm);
                    if (TS >= 0)
                    {
                        CachedSList[ServiceLocation, Algorithm] = new CachedStats();
                        CachedSList[ServiceLocation, Algorithm].TotalSpeed = TS;
                        CachedSList[ServiceLocation, Algorithm].ObtainTime = DateTime.Now;
                    }
                    else return TS;
                }

                return CachedSList[ServiceLocation, Algorithm].TotalSpeed;
            }
        }

        #endregion

        #region PRIVATE_METHODS

        private static double GetTotalSpeedForAlgorithm(int ServiceLocation, int Algorithm)
        {
            Result<APIStatsCurrent> R = Request<Result<APIStatsCurrent>>(ServiceLocation, "stats.global.current", false, null);
            if (R == null) return -1;
            else
            {
                foreach (APIStats S in R.Data.AllStats)
                    if (S.Algorithm == Algorithm)
                        return S.TotalSpeed;

                return 0;
            }
        }

        private static T Request<T>(int ServiceLocation, string Method, bool AppendCredentials, Dictionary<string, string> Parameters)
        {
            string URL = SERVICE_LOCATION[ServiceLocation] + "/api";

            if (Method != null)
            {
                URL += "?method=" + Method;
                if (AppendCredentials)
                {
                    URL += "&id=" + APIID;
                    URL += "&key=" + APIKey;
                }

                if (Parameters != null)
                {
                    // Append all parameters
                    foreach (KeyValuePair<string, string> Entry in Parameters)
                        URL += "&" + Entry.Key + "=" + Entry.Value;
                }
            }

            string ResponseData;
            try
            {
                HttpWebRequest WReq = (HttpWebRequest)WebRequest.Create(URL);
                WReq.Timeout = 60000;
                WebResponse WResp = WReq.GetResponse();
                Stream DataStream = WResp.GetResponseStream();
                DataStream.ReadTimeout = 60000;
                StreamReader SReader = new StreamReader(DataStream);
                ResponseData = SReader.ReadToEnd();
                if (ResponseData[0] != '{')
                    throw new Exception("Not JSON data.");
            }
            catch (Exception ex)
            {
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.ERROR, ex.Message);
                return default(T);
            }

            try
            {
                // Try to parse with error first, so we see if method failed.
                Result<APIError> Err = JsonConvert.DeserializeObject<Result<APIError>>(ResponseData);
                if (Err.Data.Text != null)
                {
                    LibConsole.WriteLine(LibConsole.TEXT_TYPE.WARNING, "Remote message: '" + Err.Data.Text + "' for request method '" + Method + "'");
                    return default(T);
                }

                T Response = JsonConvert.DeserializeObject<T>(ResponseData);
                return Response;
            }
            catch (Exception ex)
            {
                LibConsole.WriteLine(LibConsole.TEXT_TYPE.ERROR, ex.Message);
                return default(T);
            }
        }

        private static List<Order> GetOrders(int ServiceLocation, int Algorithm, string Method, bool AppendCredentials)
        {
            Dictionary<string, string> ReqParams = new Dictionary<string, string>();
            ReqParams.Add("algo", Algorithm.ToString());
            Result<APIOrdersGet> R = Request<Result<APIOrdersGet>>(ServiceLocation, Method, AppendCredentials, ReqParams);
            if (R == null) return null;
            else
            {
                foreach (Order O in R.Data.Orders)
                    O.ServiceLocation = ServiceLocation;

                return R.Data.Orders;
            }
        }

        #endregion
    }
}
