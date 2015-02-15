using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    public class Order
    {
        #region PUBLIC_PROPERTIES
        /// <summary>
        /// Order number - ID.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int ID;

        /// <summary>
        /// Order algorithm.
        /// </summary>
        [JsonProperty(PropertyName = "algo")]
        public int Algorithm;

        /// <summary>
        /// True if order is alive.
        /// </summary>
        [JsonProperty(PropertyName = "alive")]
        public bool Alive;

        /// <summary>
        /// Remaining BTC balance for this order.
        /// </summary>
        [JsonProperty(PropertyName = "btc_avail")]
        public double BTCAvailable;

        /// <summary>
        /// Speed limit in GH/s (TH/s for algorithm 1 - SHA256). 0 means unlimited.
        /// </summary>
        [JsonProperty(PropertyName = "limit_speed")]
        public double SpeedLimit;

        /// <summary>
        /// Order price in BTC/GH/s (BTC/TH/s for algorithm 1 - SHA256).
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public double Price;

        /// <summary>
        /// Current order speed in GH/s.
        /// </summary>
        [JsonProperty(PropertyName = "accepted_speed")]
        public double Speed;

        /// <summary>
        /// Number of miners currently working on order.
        /// </summary>
        [JsonProperty(PropertyName = "workers")]
        public int Workers;

        /// <summary>
        /// End time in how many milliseconds have passed since January 1, 1970, 00:00:00 GMT.
        /// </summary>
        [JsonProperty(PropertyName = "end")]
        public ulong EndTime;

        /// <summary>
        /// Type of the order (0 = standard, 1 = fixed)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public int OrderType;

        /// <summary>
        /// Service location (0 for NiceHash, 1 for WestHash).
        /// </summary>
        [JsonIgnore]
        public int ServiceLocation;

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// Blank constructor for JSON parsing.
        /// </summary>
        public Order()
        {
        }

        /// <summary>
        /// Make a memory copy of existing order.
        /// </summary>
        /// <param name="O">Existing order.</param>
        public Order(Order O)
        {
            ID = O.ID;
            Algorithm = O.Algorithm;
            Alive = O.Alive;
            BTCAvailable = O.BTCAvailable;
            SpeedLimit = O.SpeedLimit;
            Price = O.Price;
            Speed = O.Speed;
            Workers = O.Workers;
            EndTime = O.EndTime;
            ServiceLocation = O.ServiceLocation;
        }

        /// <summary>
        /// Remove this order.
        /// </summary>
        /// <returns>True if order was removed.</returns>
        public bool Remove()
        {
            return APIWrapper.OrderRemove(ServiceLocation, Algorithm, ID);
        }

        /// <summary>
        /// Refill this order.
        /// </summary>
        /// <param name="BTCAmount">Amount of BTC to refill.</param>
        /// <returns>True if order was refilled.</returns>
        public bool Refill(double BTCAmount)
        {
            return APIWrapper.OrderRefill(ServiceLocation, Algorithm, ID, BTCAmount);
        }

        /// <summary>
        /// Set price for this order. Only price increase allowed.
        /// </summary>
        /// <param name="Price">New order price.</param>
        /// <returns>New order price. If price was not changed, -1 is returned.</returns>
        public double SetPrice(double Price)
        {
            return APIWrapper.OrderSetPrice(ServiceLocation, Algorithm, ID, Price);
        }

        /// <summary>
        /// Set limit for this order
        /// </summary>
        /// <param name="Limit">New order limit in GH/s (TH/s for Algorithm 1 - SHA256). 0 for unlimited.</param>
        /// <returns>New order limit. If limit was not changed, -1 is returned.</returns>
        public double SetLimit(double Limit)
        {
            return APIWrapper.OrderSetLimit(ServiceLocation, Algorithm, ID, Limit);
        }

        /// <summary>
        /// Decrease order price for this order.
        /// </summary>
        /// <returns>New order price. If price was not decreased, -1 is returned.</returns>
        public double SetPriceDecrease()
        {
            return APIWrapper.OrderSetPriceDecrease(ServiceLocation, Algorithm, ID);
        }

        #endregion
    }
}
