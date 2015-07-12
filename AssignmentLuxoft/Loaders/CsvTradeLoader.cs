using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentLuxoft.Contracts;

namespace AssignmentLuxoft.Loaders
{
    public class CsvTradeLoader : ITradeLoader
    {
        public List<Models.Trade> ExtractTrades(System.IO.Stream source)
        {
            throw new NotImplementedException();
        }

        public string SupportedSourceType
        {
            get { return "Csv"; }
        }

        public bool IsActive { get; set; }
    }
}
