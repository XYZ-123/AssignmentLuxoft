using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AssignmentLuxoft
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            UnityContainer = new UnityContainer();
            UnityContainer.LoadConfiguration();
        }

        public static IUnityContainer UnityContainer { get; private set; }
    }
}
