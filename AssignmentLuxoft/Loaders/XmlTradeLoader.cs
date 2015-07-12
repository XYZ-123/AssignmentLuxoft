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
    public class XmlTradeLoader : ITradeLoader
    {
        public List<Trade> ExtractTrades(Stream source)
        {
            throw new NotImplementedException();
        }

        public string SupportedSourceType { get { return "Xml"; } }

        public bool IsActive { get; set; }
    }
}
