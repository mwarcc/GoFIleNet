using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFileNet.GoFileNet.Entities
{
    public class AccountInfo
    {
        public string Status { get; set; }
        public AccountData Data { get; set; }
    }
    public class AccountData
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Tier { get; set; }
        public string Token { get; set; }
        public string RootFolder { get; set; }
        public StatsCurrent StatsCurrent { get; set; }
    }

    public class StatsCurrent
    {
        public int FileCount { get; set; }
        public int FolderCount { get; set; }
        public long Storage { get; set; }
        public long TrafficWebDownloaded { get; set; }
    }
}
