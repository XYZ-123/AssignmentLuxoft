using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AssignmentLuxoft.Loaders;

namespace AssignmentLuxoft
{
    using System.Collections.ObjectModel;

    using AssignmentLuxoft.Contracts;
    using AssignmentLuxoft.Models;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.TimerService = new TimerService(App.UnityContainer.Resolve<ILoaderManager>());

            this.TimerService.Interval = Convert.ToDouble(ConfigurationManager.AppSettings["FileSystemWatchInterval"]);

            this.TimerService.DirectoryToWatch = ConfigurationManager.AppSettings["DirectoryToWatch"];

            this.DataContext = new TradeViewModel(this.TimerService, this.Dispatcher);
        }

        private TimerService TimerService{ get; set; }
    }
}
