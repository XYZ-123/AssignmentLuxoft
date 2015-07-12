using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentLuxoft.Contracts;

namespace AssignmentLuxoft.Loaders
{
    public static class LoaderSelector
    {
        static LoaderSelector()
        {
            Loaders = new List<ITradeLoader>();
            //Logic for taking loaders is here
        }

        public static List<ITradeLoader> Loaders { get; internal set; }

        public static ITradeLoader GetTradeLoader(string sourceType)
        {
            foreach (var tradeLoader in Loaders)
            {
                if (tradeLoader.IsActive && tradeLoader.SupportedSourceType.Equals(sourceType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return tradeLoader;
                }
            }

            throw new NotSupportedException("Source type: " + sourceType + " is not supported");
        }
    }
}
