using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    public class APIMethodVersion
    {
        [JsonProperty(PropertyName = "api_version")]
        public string APIVersion;
    }
}
