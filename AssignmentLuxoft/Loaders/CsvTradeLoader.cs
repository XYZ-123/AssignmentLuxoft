// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvTradeLoader.cs" company="">
//   
// </copyright>
// <summary>
//   The csv trade loader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AssignmentLuxoft.Loaders
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using AssignmentLuxoft.Contracts;
    using AssignmentLuxoft.Models;

    /// <summary>
    /// The csv trade loader.
    /// </summary>
    public class CsvTradeLoader : TradeLoaderBase
    {

        /// <summary>
        /// Gets the supported source type.
        /// </summary>
        public override string SupportedSourceType
        {
            get
            {
                return ".csv";
            }
        }

        // <summary>
        /// The extract trades.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="InvalidDataException">
        /// </exception>
        public override async Task<List<Trade>> ExtractTrades(Stream source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            List<Trade> returnList = new List<Trade>();

            using (var sr = new StreamReader(source))
            {
                while (sr.Peek() > -1)
                {
                    var line = sr.ReadLine().Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        var trade = this.ExtractTrade(line);
                        returnList.Add(trade);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidDataException("Provided data is of invalid format", ex);
                    }                  
                }  
            }

            return returnList;
        }
    }
}