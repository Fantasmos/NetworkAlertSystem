using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;

namespace NetworkAlertSystem
{
    class WindowsNetworkTracker : NetworkTracker
    {
        
        public override bool CheckIfOverThreshHold(NetworkUsageData[] DataUsage, float ThreshHoldMbps)
        {
            foreach (NetworkUsageData ni in DataUsage) {
                float usage = ni.SentMbps + ni.ReceivedMbps ;
                
                if (ni.SentMbps + usage > ThreshHoldMbps) {
                    return true;
                }
            }
            return false;
        }

        public override NetworkUsageData[] GetAllInterfacesDataUsage()
        {
            

            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            String[] instancename = category.GetInstanceNames();
            int NumberOfNetworkCards = instancename.Length;

            NetworkUsageData[] NiDataUsage = new NetworkUsageData[NumberOfNetworkCards];
            PerformanceCounter[] dataSentCounter = new PerformanceCounter[NumberOfNetworkCards];
            PerformanceCounter[] dataReceivedCounter = new PerformanceCounter[NumberOfNetworkCards];

            for (int i = 0; i < NumberOfNetworkCards; i++) {
                dataSentCounter[i] = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instancename[i]);
                dataReceivedCounter[i] = new PerformanceCounter("Network Interface", "Bytes Received/sec", instancename[i]);
                dataSentCounter[i].NextValue();
                dataReceivedCounter[i].NextValue();
            }

            Thread.Sleep(1000);

            for (int i = 0; i < NumberOfNetworkCards; i++)
            {
                NiDataUsage[i] = new NetworkUsageData();
                NiDataUsage[i].Name = instancename[i];
                NiDataUsage[i].ReceivedMbps = dataReceivedCounter[i].NextValue() * 8 / 1000 / 1000;
                NiDataUsage[i].SentMbps = dataSentCounter[i].NextValue() * 8 /1000 / 1000;
            }
            
            return NiDataUsage;
        }
    }
}
