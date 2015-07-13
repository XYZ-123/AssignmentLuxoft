using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentLuxoft.Loaders;
using AssignmentLuxoft.Models;

namespace AssignmentLuxoft
{
    public class TradeViewModel
    {
        public TradeViewModel()
        {
            this.LoaderManager = new LoaderManager();
            Files = new List<File>();
            DirectoryToWatch = ConfigurationManager.AppSettings["DirectoryToWatch"];
        }

        public LoaderManager LoaderManager { get; set; }

        public List<File> Files { get; set; }

        public string DirectoryToWatch { get; set; }
    }
}
