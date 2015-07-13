using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentLuxoft.Contracts;
using AssignmentLuxoft.Models;

namespace AssignmentLuxoft.Loaders
{
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class XmlTradeLoader : TradeLoaderBase
    {
        /// <summary>
        /// Gets the supported source type.
        /// </summary>
        public override string SupportedSourceType
        {
            get
            {
                return "xml";
            }
        }

        public override async Task<List<Trade>> ExtractTrades(Stream source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var returnList = new List<Trade>();
            try
            {
                var xdoc = XDocument.Load(source);
                var valueNodes = xdoc.XPathSelectElements(@"/values/value");
                foreach (var value in valueNodes)
                {
                    var trade = this.ExtractTrade(value.Attributes().Select(x => x.Value).ToArray());
                    returnList.Add(trade);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Provided data is of invalid format", ex);
            }


            return returnList;

        }
    }
}
