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
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    using AssignmentLuxoft.Contracts;

    using Microsoft.Practices.Unity;

    /// <summary>
    ///     The loader selector.
    /// </summary>
    public class LoaderManager : ILoaderManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LoaderManager" /> class.
        /// </summary>
        [InjectionConstructor]
        public LoaderManager()
        {
            this.Loaders = new List<TradeLoaderBase>();
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoaderManager"/> class.
        /// </summary>
        /// <param name="loaders">
        /// The loaders.
        /// </param>
        public LoaderManager(List<TradeLoaderBase> loaders)
        {
            this.Loaders = loaders;
        }

        /// <summary>
        ///     Gets the loaders.
        /// </summary>
        public List<TradeLoaderBase> Loaders { get; private set; }

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
            foreach (var tradeLoader in this.Loaders)
            {
                if (tradeLoader.IsActive
                    && tradeLoader.SupportedSourceType.Equals(sourceType, StringComparison.InvariantCultureIgnoreCase))
                {
                    return tradeLoader;
                }
            }

            return null;
        }

        /// <summary>
        /// The initialize.
        /// </summary>
        internal void Initialize()
        {
            this.Loaders.Clear();

            // Loading internal loaders
            this.Loaders.Add(new CsvTradeLoader());
            this.Loaders.Add(new TextTradeLoader());
            this.Loaders.Add(new XmlTradeLoader());

            // Loading external loaders
            var relativePath = ConfigurationManager.AppSettings["ExternalLoadersRelativePath"];
            var fullPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);

            try
            {
                // Get dlls from plugin directory
                var dllPaths = Directory.GetFiles(fullPath, "*.dll");

                foreach (var dllPath in dllPaths)
                {
                    // Load types and iterate over them to find correct ones
                    var assembly = Assembly.LoadFrom(dllPath);
                    var types = assembly.GetTypes();

                    foreach (var type in types)
                    {
                        if (type.IsClass && type.IsSubclassOf(typeof(TradeLoaderBase)))
                        {
                            this.Loaders.Add((TradeLoaderBase)Activator.CreateInstance(type));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}