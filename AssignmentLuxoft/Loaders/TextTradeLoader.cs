// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextTradeLoader.cs" company="">
//   
// </copyright>
// <summary>
//   The text trade loader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AssignmentLuxoft.Loaders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using AssignmentLuxoft.Contracts;
    using AssignmentLuxoft.Models;

    /// <summary>
    ///     The text trade loader.
    /// </summary>
    public class TextTradeLoader : TradeLoaderBase
    {
        /// <summary>
        ///     Gets the supported source type.
        /// </summary>
        public override string SupportedSourceType
        {
            get
            {
                return ".txt";
            }
        }

        /// <summary>
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

            var returnList = new List<Trade>();

            using (var sr = new StreamReader(source))
            {
                // Skip header
                sr.ReadLine();

                while (sr.Peek() > -1)
                {
                    var line = sr.ReadLine().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
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