using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    public class APIStatsCurrent
    {
        [JsonProperty(PropertyName = "stats")]
        public APIStats[] AllStats;
    }

    public class APIStats
    {
        [JsonProperty(PropertyName = "algo")]
        public int Algorithm;

        [JsonProperty(PropertyName = "speed")]
        public double TotalSpeed;
    }
}
