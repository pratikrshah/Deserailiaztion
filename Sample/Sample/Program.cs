using MStatus;
using QR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Market Status
            var marketresponse = GetMarketStatus();

            ObjectDumper.Write(marketresponse.response);
            Console.WriteLine("");         
            ObjectDumper.Write(marketresponse.response.status);
            #endregion

            #region Quote Response
            var quoteresponse = GetSymbolResponse();

            foreach (var q in quoteresponse.response.quotes)
            {
                ObjectDumper.Write(q);
                Console.WriteLine("");
            }
            #endregion

            #region Goal to Get
            //Step 1 - Make a request  to web service (This is solved - have code for this)

            //Step 2 - get a response from the webrequest - something like below
            //var v_Response = request.GetResponse();
            //Convert Response Stream to String here
            //var response_xml = .............

            //Step 3 - Send this string XML to the generic method below and should get a typed object back based on the XML passed
            //var marketstatusobject = Deserialize<MarketStatus>(string response_xml)

            #endregion

            Console.ReadLine();
        }

        public static MarketStatus GetMarketStatus()
        {
            var responseElement = XElement.Load("MarketStatus.xml");
            var statusElement = responseElement.Element("status");
            var myobject = new MarketStatus
            {
                response = new MStatus.Response
                {
                    Id = (string)responseElement.Attribute("id"),
                    date = (string)responseElement.Element("date"),
                    message = (string)responseElement.Element("message"),
                    status = new Status
                    {
                        current = (string)statusElement.Element("current"),
                        change_at = (string)statusElement.Element("change_at")
                    }
                }
            };

            return myobject;
        }

        public static QuoteResponse GetSymbolResponse()
        {
            var responseElement = XElement.Load("QuoteResponse.xml");
            var myobject = new QuoteResponse
            {
                response = new QR.Response
                {
                    id = (string)responseElement.Attribute("id"),
                    quotes = (
                        from o in responseElement.Elements("quotes").Elements("quote")
                        select new Quote
                        {
                            ask = (string)o.Element("ask"),
                            bid = (string)o.Element("bid"),
                            chg = (string)o.Element("chg"),
                            chg_sign = (string)o.Element("chg_sign"),
                            chg_t = (string)o.Element("chg_t"),
                            exch = (string)o.Element("exch"),
                            last = (string)o.Element("last"),
                            pchg = (string)o.Element("pchg"),
                            symbol = (string)o.Element("symbol"),
                            vl = (string)o.Element("vl")
                        }).ToArray()
                }
            };

            return myobject;
        }

        //public static T Deserialize<T>(string XML)
        //{
        //    //Step 1: Identify what type of T is using TypeOf - MarketStatus Object or QuoteResponse

        //    //Step 2: Based on type T - call the LINQ to XML implementation
        //    //return ;
        //}
    }
}