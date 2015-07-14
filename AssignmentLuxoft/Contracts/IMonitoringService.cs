using System;

namespace AssignmentLuxoft.Contracts
{
    public interface IMonitoringService
    {
        ILoaderManager LoaderManager { get; }
        double Interval { get; set; }
        string DirectoryToWatch { get; set; }
        event EventHandler<MonitoringServiceNewFileEventArgs> OnNewFile;
        event EventHandler<MonitoringServiceNewTradesEventArgs> OnNewTrades;
    }
}