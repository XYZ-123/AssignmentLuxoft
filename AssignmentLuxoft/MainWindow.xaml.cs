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
using File = AssignmentLuxoft.Models.File;

namespace AssignmentLuxoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new TradeViewModel();
            CreateFileSystemWatcher();
        }
        private void CreateFileSystemWatcher()
        {
            var timer = new Timer
            {
                Interval = Convert.ToDouble(ConfigurationManager.AppSettings["FileSystemWatchInterval"])
            };
            timer.Elapsed += Tick;
            timer.Start();

        }

        void Tick(object sender, ElapsedEventArgs e)
        {
           //Debug.Write(string.Join(",",Directory.GetFiles(((TradeViewModel)DataContext).DirectoryToWatch)));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
