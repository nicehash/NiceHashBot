using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    class APIAlgorithmInfo
    {
        [JsonProperty(PropertyName = "algo")]
        public int ID;

        [JsonProperty(PropertyName = "name")]
        public string Name;

        [JsonProperty(PropertyName = "min_limit")]
        public double MinimalLimit;

        [JsonProperty(PropertyName = "down_step")]
        public double PriceDownStep;

        [JsonProperty(PropertyName = "multi")]
        public double Multiplier;

        [JsonProperty(PropertyName = "speed_text")]
        public string SpeedText;
    }

    class APIBuyInfo
    {
        [JsonProperty(PropertyName = "algorithms")]
        public APIAlgorithmInfo[] Algorithms;

        [JsonProperty(PropertyName = "down_time")]
        public int DownStepTime;
    }
}
