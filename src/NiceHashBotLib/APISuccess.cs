using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    public class APISuccess
    {
        [JsonProperty(PropertyName = "success")]
        public string Text;
    }
}
