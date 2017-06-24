using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkAlertSystem
{
    abstract class NetworkTracker
    {
        public abstract bool CheckIfOverThreshHold(NetworkUsageData[] DataUsage, float ThreshHoldMbps);
       
        public abstract NetworkUsageData[] GetAllInterfacesDataUsage();
    }

    

    
}
