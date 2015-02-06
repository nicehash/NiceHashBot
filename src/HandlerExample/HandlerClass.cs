using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net; // For generating HTTP requests and getting responses.
using NiceHashBotLib; // Include this for Order class, which contains stats for our order.
using Newtonsoft.Json; // For JSON parsing of remote APIs.

public class HandlerClass
{
    /// <summary>
    /// This method is called every 0.5 seconds.
    /// </summary>
    /// <param name="OrderStats">Order stats - do not change any properties or call any methods. This is provided only as read-only object.</param>
    /// <param name="MaxPrice">Current maximal price. Change this, if you would like to change the price.</param>
    /// <param name="NewLimit">Current speed limit. Change this, if you would like to change the limit.</param>
    public static void HandleOrder(ref Order OrderStats, ref double MaxPrice, ref double NewLimit)
    {
        // Following line of code makes the rest of the code to run only once per minute.
        if ((++Tick % 120) != 0) return;

        // Perform check, if order has been created at all. If not, stop executing the code.
        if (OrderStats == null) return;

        // Retreive JSON data from API server. Replace URL with your own API request URL.
        string JSONData = GetHTTPResponseInJSON("http://www.coinwarz.com/v1/api/coininformation/?apikey=<API_KEY>&cointag=<COIN>");
        if (JSONData == null) return;

        // Serialize returned JSON data.
        CoinwarzResponse Response;
        try
        {
            Response = JsonConvert.DeserializeObject<CoinwarzResponse>(JSONData);
        }
        catch
        {
            return;
        }

        // Check if exchange rate is provided - at least one exchange must be included.
        if (Response.Data.ExchangeRates.Length == 0) return;
        double ExchangeRate = Response.Data.ExchangeRates[0].ToBTC;

        // Calculate mining profitability in BTC per 1 TH of hashpower.
        double HT = Response.Data.Difficulty * (Math.Pow(2.0, 32) / (1000000000000.0));
        double CPD = Response.Data.BlockReward * 24.0 * 3600.0 / HT;
        double C = CPD * ExchangeRate;

        // Subtract service fees.
        C -= 0.04 * C;

        // Subtract minimal % profit we want to get.
        C -= 0.01 * C;

        // Set new maximal price.
        MaxPrice = Math.Floor(C * 10000) / 10000;

        // Example how to print some data on console...
        Console.WriteLine("Adjusting order #" + OrderStats.ID.ToString() + " maximal price to: " + MaxPrice.ToString("F4"));
    }

    /// <summary>
    /// Data structure used for serializing JSON response from CoinWarz. 
    /// It allows us to parse JSON with one line of code and easily access every data contained in JSON message.
    /// </summary>
    #pragma warning disable 0649
    class CoinwarzResponse
    {
        public bool Success;
        public string Message;
        
        public class DataStruct
        {
            public string CoinName;
            public string CoinTag;
            public int BlockCount;
            public double Difficulty;
            public double BlockReward;
            public bool IsBlockExplorerOnline;
            public bool IsExchangeOnline;
            public string Algorithm;
            public class ExchangeRateStruct
            {
                public string Exchange;
                public double ToUSD;
                public double ToBTC;
                public double Volume;
                public double TimeStamp;
            }
            public ExchangeRateStruct[] ExchangeRates;
            public double BlockTimeInSeconds;
            public string HealthStatus;
            public string Message;
        }
        public DataStruct Data;
    }
    #pragma warning restore 0649


    /// <summary>
    /// Property used for measuring time.
    /// </summary>
    private static int Tick = -10;


    // Following methods do not need to be altered.
    #region PRIVATE_METHODS

    /// <summary>
    /// Get HTTP JSON response for provided URL.
    /// </summary>
    /// <param name="URL">URL.</param>
    /// <returns>JSON data returned by webserver or null if error occured.</returns>
    private static string GetHTTPResponseInJSON(string URL)
    {
        try
        {
            HttpWebRequest WReq = (HttpWebRequest)WebRequest.Create(URL);
            WReq.Timeout = 60000;
            WebResponse WResp = WReq.GetResponse();
            Stream DataStream = WResp.GetResponseStream();
            DataStream.ReadTimeout = 60000;
            StreamReader SReader = new StreamReader(DataStream);
            string ResponseData = SReader.ReadToEnd();
            if (ResponseData[0] != '{')
                throw new Exception("Not JSON data.");

            return ResponseData;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion
}
