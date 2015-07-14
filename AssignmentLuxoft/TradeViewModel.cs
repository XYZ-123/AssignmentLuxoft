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
        public TradeViewModel(TimerService timerService, Dispatcher dispatcher)
        {
            if (timerService == null)
                throw new ArgumentNullException("timerService");

            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");

            this.TimerService = timerService;
            this.Dispatcher = dispatcher;
            this.Loaders = new ObservableCollection<TradeLoaderBase>(this.TimerService.LoaderManager.Loaders);
            this.Files = new ObservableCollection<FileMetaInfo>();
            this.Results = new ObservableCollection<Trade>();
            this.TimerService.OnNewFile += this.TimerService_OnNewFile;
            this.TimerService.OnNewTrades += this.TimerService_OnNewTrades;
        }

        void TimerService_OnNewTrades(object sender, TimerServiceNewTradesEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                foreach (var trade in e.Trades)
                {
                    this.Results.Add(trade);
                }
            });
        }

        private void TimerService_OnNewFile(object sender, TimerServiceNewFileEventArgs e)
        {
            this.Dispatcher.Invoke(
                () =>
                    {
                        this.Files.Add(e.NewFile);
                    });
        }

        private TimerService TimerService;

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
                return TimerService.DirectoryToWatch;
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
                return TimerService.Interval;
            }
        }
    }
}