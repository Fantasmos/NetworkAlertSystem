using System;
using System.Net.NetworkInformation;
namespace NetworkAlertSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            float ThreshHold = GetThreshHold();
            Console.WriteLine("The threshold is set to: " + ThreshHold + "Mbps");
            WindowsNetworkTracker Tracker = new WindowsNetworkTracker();
            WindowsAlertSystem Alerter = new WindowsAlertSystem();
            while (running)
            {
                NetworkUsageData[] Usage = Tracker.GetAllInterfacesDataUsage();
                if (Tracker.CheckIfOverThreshHold(Usage, ThreshHold)) {
                    Alerter.AlertUserIsOverThreshHold();
                }
            }
        }

        //This should be its own class, but for its simplicity this suits our needs enough
        static float GetThreshHold()
        {
            float DefaultThreshHold = 1F;
            try {
                float ThreshHold = float.Parse(System.IO.File.ReadAllText("ThreshHold.txt"));
                return ThreshHold;
            }
            catch {
                return DefaultThreshHold;
            }
        }


      
    }
}
