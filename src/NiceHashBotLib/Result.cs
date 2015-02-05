using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NiceHashBotLib
{
    public class Result<T>
    {
        [JsonProperty(PropertyName = "result")]
        public T Data;

        [JsonProperty(PropertyName = "method")]
        public object Method;
    }
}
