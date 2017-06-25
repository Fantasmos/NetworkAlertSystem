using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAlertSystem
{
    class ConsoleAlert : AlertSystem
    {
        public override void AlertUserIsOverThreshHold(string Message = "You are currently over the threshold!")
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Threshhold Reached!");
            Console.ForegroundColor = previous;
        }

        public override void PrintCurrentData(NetworkUsageData[] NiDataUsageCollection)
        {
            Console.WriteLine();
            Console.WriteLine(System.DateTime.Now.TimeOfDay);
            foreach (NetworkUsageData NiDataUsage in NiDataUsageCollection) {
                Console.WriteLine(string.Format("{0} \r\n Received: {1}Mbps \r\n Sent: {2}Mbps", NiDataUsage.Name, Math.Round(NiDataUsage.ReceivedMbps, 2), Math.Round(NiDataUsage.SentMbps, 2)));
            }
        }
    }
}
