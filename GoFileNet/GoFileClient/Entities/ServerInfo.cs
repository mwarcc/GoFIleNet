using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFileNet.GoFileNet.Entities
{
    public class ServerInfo
    {
        public string Name { get; set; }
    }

    public class ServerData
    {
        [JsonProperty("server")]
        public string Server { get; set; }
    }
}
