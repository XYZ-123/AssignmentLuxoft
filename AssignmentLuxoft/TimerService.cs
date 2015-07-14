﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentLuxoft
{
    using System.IO;
    using System.Timers;

    using AssignmentLuxoft.Contracts;
    using AssignmentLuxoft.Models;

    public class TimerServiceNewFileEventArgs : EventArgs
    {
        public FileMetaInfo NewFile { get; set; }
    }

    public class TimerServiceNewTradesEventArgs : EventArgs
    {
        public List<Trade> Trades { get; set; }
    }

    public class TimerService
    {
        private Timer timer;

        private HashSet<string> files;
 
        public TimerService(ILoaderManager loaderManager)
        {
            if (loaderManager == null)
                throw new ArgumentNullException("loaderManager");

            this.LoaderManager = loaderManager;
            timer = new Timer();
            files = new HashSet<string>();
            timer.Elapsed += Tick;
            timer.Start();
        }

        public ILoaderManager LoaderManager { get; private set; }

        public double Interval
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }

        public string DirectoryToWatch { get; set; }

        public event EventHandler<TimerServiceNewFileEventArgs> OnNewFile = delegate { };

        public event EventHandler<TimerServiceNewTradesEventArgs> OnNewTrades = delegate { };

        private void Tick(object sender, ElapsedEventArgs e)
        {

            var filePaths = Directory.GetFiles(this.DirectoryToWatch);

            foreach (var filePath in filePaths)
            {

                if (this.files.Add(filePath))
                {
                    var newFile = new FileMetaInfo{Name = Path.GetFileName(filePath), Extension = Path.GetExtension(filePath)};
                    this.OnNewFile(this, new TimerServiceNewFileEventArgs { NewFile = newFile });

                    // No loader means - file type is not supported
                    var loader = this.LoaderManager.GetTradeLoader(newFile.Extension);

                    if (loader != null)
                    {
                        var fileStream = File.OpenRead(filePath);
                        loader.ExtractTrades(fileStream).ContinueWith(
                            (task) =>
                                {
                                    fileStream.Close();
                                    if (task.Status == TaskStatus.RanToCompletion)
                                    {
                                        this.OnNewTrades(
                                            this,
                                            new TimerServiceNewTradesEventArgs { Trades = task.Result });
                                    }
                                });
                    }
                }
            }
        }
    }
}
