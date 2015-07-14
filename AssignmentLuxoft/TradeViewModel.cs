// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TradeViewModel.cs" company="">
//   
// </copyright>
// <summary>
//   The trade view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace AssignmentLuxoft
{
    using System;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Windows;
    using System.Windows.Threading;

    using AssignmentLuxoft.Contracts;
    using AssignmentLuxoft.Loaders;
    using AssignmentLuxoft.Models;

    /// <summary>
    /// The trade view model.
    /// </summary>
    public class TradeViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TradeViewModel"/> class.
        /// </summary>
        public TradeViewModel(IMonitoringService monitoringService, Dispatcher dispatcher)
        {
            if (monitoringService == null)
                throw new ArgumentNullException("monitoringService");

            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");

            this.MonitoringService = monitoringService;
            this.Dispatcher = dispatcher;
            this.Loaders = new ObservableCollection<TradeLoaderBase>(this.MonitoringService.LoaderManager.Loaders);
            this.Files = new ObservableCollection<FileMetaInfo>();
            this.Results = new ObservableCollection<Trade>();
            this.MonitoringService.OnNewFile += this.MonitoringServiceOnNewFile;
            this.MonitoringService.OnNewTrades += this.MonitoringServiceOnNewTrades;
        }

        void MonitoringServiceOnNewTrades(object sender, MonitoringServiceNewTradesEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                foreach (var trade in e.Trades)
                {
                    this.Results.Add(trade);
                }
            });
        }

        private void MonitoringServiceOnNewFile(object sender, MonitoringServiceNewFileEventArgs e)
        {
            this.Dispatcher.Invoke(
                () =>
                    {
                        this.Files.Add(e.NewFile);
                    });
        }

        private IMonitoringService MonitoringService;

        private Dispatcher Dispatcher;

        public ObservableCollection<TradeLoaderBase> Loaders { get; set; }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        public ObservableCollection<FileMetaInfo> Files { get; set; }

        /// <summary>
        /// Gets or sets the directory to watch.
        /// </summary>
        public string DirectoryToWatch
        {
            get
            {
                return MonitoringService.DirectoryToWatch;
            }
        }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        public ObservableCollection<Trade> Results { get; set; }

        /// <summary>
        /// Gets or sets the check frequency.
        /// </summary>
        /// <value>
        /// The check frequency.
        /// </value>
        public double CheckFrequency
        {
            get
            {
                return MonitoringService.Interval;
            }
        }
    }
}