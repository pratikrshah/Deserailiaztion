using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStatus
{
    public class MarketStatus
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public string Id { get; set; }
        public string date { get; set; }
        public Status status { get; set; }
        public string message { get; set; }
        public string unixtime { get; set; }
    }

    public class Status
    {
        public string current { get; set; }
        public string next { get; set; }
        public string change_at { get; set; }
    }
}