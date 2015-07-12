using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AssignmentLuxoft.Models;

namespace AssignmentLuxoft.Contracts
{
    public interface ITradeLoader
    {
        List<Trade> ExtractTrades(Stream source);

        string SupportedSourceType { get; }

        bool IsActive { get; set; }
    }
}
