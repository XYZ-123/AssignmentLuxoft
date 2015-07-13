// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITradeLoader.cs" company="">
//   
// </copyright>
// <summary>
//   The TradeLoader interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AssignmentLuxoft.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using AssignmentLuxoft.Loaders;
    using AssignmentLuxoft.Models;

    /// <summary>
    ///     The TradeLoader base class.
    /// </summary>
    public abstract class TradeLoaderBase
    {
        /// <summary>
        ///     Gets the supported source type.
        /// </summary>
        public virtual string SupportedSourceType
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// The extract trades.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public abstract Task<List<Trade>> ExtractTrades(Stream source);

        /// <summary>
        /// The extract trade.
        /// </summary>
        /// <param name="line">
        /// The line.
        /// </param>
        /// <returns>
        /// The <see cref="Trade"/>.
        /// </returns>
        protected virtual Trade ExtractTrade(string[] line)
        {
            var date = line[ColumnIndexes.Date].Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            var trade = new Trade
                            {
                                Date =
                                    new DateTime(
                                    Convert.ToInt32(date[0]), 
                                    Convert.ToInt32(date[1]), 
                                    Convert.ToInt32(date[2])), 
                                Open = Convert.ToDecimal(line[ColumnIndexes.Open]), 
                                High = Convert.ToDecimal(line[ColumnIndexes.High]), 
                                Low = Convert.ToDecimal(line[ColumnIndexes.Low]), 
                                Close = Convert.ToDecimal(line[ColumnIndexes.Close]), 
                                Volume = Convert.ToInt64(line[ColumnIndexes.Volume])
                            };
            return trade;
        }
    }
}