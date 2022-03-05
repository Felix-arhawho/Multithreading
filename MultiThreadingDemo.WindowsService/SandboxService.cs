using MutiThreadingDemo.DataAccess.Repositories;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MultiThreadingDemo.WindowsService
{
    public partial class SandboxService : ServiceBase
    {
        private Logger _logger;
        private readonly ThreadProcessorRepository _threadProcessorRepository;
        public SandboxService()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _threadProcessorRepository = new ThreadProcessorRepository();

            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _logger.Info("Service have started running at " + DateTime.Now.ToString());

            var userDetailsTimer = new Timer
            {
                Interval = new TimeSpan(0, 3, 0).TotalMilliseconds,
                Enabled = true
            };

            userDetailsTimer.Elapsed += GenerateUserDetails;

            var collectiveInformationTimer = new Timer
            {
                Interval = new TimeSpan(0, 6, 0).TotalMilliseconds,
                Enabled = true
            };
            //Another way of setting the method to run for a specified period of time.
            collectiveInformationTimer.Elapsed += new ElapsedEventHandler(GenerateCollectiveInformation);

            var namesWithNullValueTimer = new Timer
            {
                Interval = new TimeSpan(0, 5, 0).TotalMilliseconds,
                Enabled = true
            };

            namesWithNullValueTimer.Elapsed += ProcessNamesWithNullValue;
        }

        protected override void OnStop()
        {
            _logger.Info("Service have stopped running at " + DateTime.Now.ToString());
        }

        private void GenerateUserDetails(object sender, ElapsedEventArgs e)
        {
            _threadProcessorRepository.GenerateUserDetails();
        }

        private void GenerateCollectiveInformation(object sender, ElapsedEventArgs e)
        {
            _threadProcessorRepository.GenerateCollectiveInformation();
        }

        private void ProcessNamesWithNullValue(object sender, ElapsedEventArgs e)
        {
            _threadProcessorRepository.ProcessNamesWithNullValue();
        }
    }
}