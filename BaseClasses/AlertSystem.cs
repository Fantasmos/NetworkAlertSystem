using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAlertSystem
{
    abstract class AlertSystem
    {
        public abstract void AlertUserIsOverThreshHold(string Message = "You are currently over the threshold!");
        public abstract void PrintCurrentData(NetworkUsageData[] NiDataUsageCollection);

    }
}
