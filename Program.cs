using System;
using System.Net.NetworkInformation;
namespace NetworkAlertSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            WindowsNetworkTracker Tracker = new WindowsNetworkTracker();
            WindowsAlertSystem Alerter = new WindowsAlertSystem();
            while (running)
            {
                NetworkUsageData[] Usage = Tracker.GetAllInterfacesDataUsage();
                if (Tracker.CheckIfOverThreshHold(Usage, 0.1F)) {
                    Alerter.AlertUserIsOverThreshHold();
                }
            }
        }



      
    }
}
