// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoaderSelector.cs" company="">
//   
// </copyright>
// <summary>
//   The loader selector.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AssignmentLuxoft.Loaders
{
    using System;
    using System.Collections.Generic;

    using AssignmentLuxoft.Contracts;

    /// <summary>
    /// The loader selector.
    /// </summary>
    public class LoaderManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoaderManager"/> class.
        /// </summary>
        public LoaderManager()
        {
            this.Loaders = new List<TradeLoaderBase>();
            this.Initialize();
        }

        public LoaderManager(List<TradeLoaderBase> loaders)
        {
            this.Loaders = loaders;
        }

        /// <summary>
        /// Gets the loaders.
        /// </summary>
        public List<TradeLoaderBase> Loaders { get; internal set; }

        /// <summary>
        /// The get trade loader.
        /// </summary>
        /// <param name="sourceType">
        /// The source type.
        /// </param>
        /// <returns>
        /// The <see cref="ITradeLoader"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public TradeLoaderBase GetTradeLoader(string sourceType)
        {
            foreach (var tradeLoader in Loaders)
            {
                if (tradeLoader.IsActive
                    && tradeLoader.SupportedSourceType.Equals(sourceType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return tradeLoader;
                }
            }

            throw new NotSupportedException("Source type: " + sourceType + " is not supported");
        }

        private void Initialize()
        {
            
        }
    }
}