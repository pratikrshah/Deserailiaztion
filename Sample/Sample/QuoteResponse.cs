using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR
{
    public class QuoteResponse
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public string @id { get; set; }
        public IEnumerable<Quote> quotes { get; set; }
    }

    public class Quote
    {
        public string ask { get; set; }
        public string bid { get; set; }
        public string chg { get; set; }
        public string chg_sign { get; set; }
        public string chg_t { get; set; }
        public string exch { get; set; }
        public string last { get; set; }
        public string pchg { get; set; }
        public string symbol { get; set; }
        public string vl { get; set; }
    }
}
