using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace NiceHashBotLib
{
    class APIOrdersGet
    {
        [JsonProperty(PropertyName = "orders")]
        public List<Order> Orders = null;
    }
}
