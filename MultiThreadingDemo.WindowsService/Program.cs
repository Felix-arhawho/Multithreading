using MutiThreadingDemo.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingDemo.WindowsService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new SandboxService()
            };
            ServiceBase.Run(ServicesToRun);

            //var threadProcessor = new ThreadProcessorRepository();
            //threadProcessor.GenerateUserDetails();
        }
    }
}
