using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    public class APIError
    {
        [JsonProperty(PropertyName = "error")]
        public string Text;
    }
}
