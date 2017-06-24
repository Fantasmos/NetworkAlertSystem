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

            NetworkUsageData[] NiDataUsage = new NetworkUsageData[instancename.Length];
           
            for (int i = 0; i < instancename.Length; i++)
            {
                
                PerformanceCounter dataSentCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instancename[i]);
                PerformanceCounter dataReceivedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", instancename[i]);
                dataSentCounter.NextValue();
                dataReceivedCounter.NextValue();

                Thread.Sleep(1000);
                PerformanceCounter bandwidthCounter = new PerformanceCounter("Network Interface", "Current Bandwidth", instancename[i]);
                float bandwidth = bandwidthCounter.NextValue();
                NiDataUsage[i] = new NetworkUsageData();
                NiDataUsage[i].Name = instancename[i];
                NiDataUsage[i].ReceivedMbps = dataReceivedCounter.NextValue() * 8 / 1000 / 1000;
                NiDataUsage[i].SentMbps = dataSentCounter.NextValue() * 8 /1000 / 1000; 
                Console.WriteLine(string.Format("{0} \r\n Received: {1}Mbps \r\n Sent: {2}Mbps", NiDataUsage[i].Name,Math.Round(NiDataUsage[i].ReceivedMbps,2),Math.Round(NiDataUsage[i].SentMbps,2)));
                
            }
            Console.WriteLine();
            return NiDataUsage;
        }
    }
}
