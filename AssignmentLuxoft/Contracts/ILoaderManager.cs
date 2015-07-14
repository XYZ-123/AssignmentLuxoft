using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLuxoft.Contracts
{
    public interface ILoaderManager
    {
        /// <summary>
        /// Gets the trade loader.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns>Null if no loader was found</returns>
        /// <returns>tradeLoader if found</returns>
        TradeLoaderBase GetTradeLoader(string sourceType);
        List<TradeLoaderBase> Loaders { get; }
    }
}
