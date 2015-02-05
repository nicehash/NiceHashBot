using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    public class APIBalance
    {
        [JsonProperty(PropertyName = "balance_confirmed")]
        public double Confirmed;

        [JsonProperty(PropertyName = "balance_pending")]
        public double Pending;
    }
}
