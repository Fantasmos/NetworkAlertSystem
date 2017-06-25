using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace NetworkAlertSystem
{
    class WindowsAlertSystem : AlertSystem
    {
        public override void PrintCurrentData(NetworkUsageData[] NiDataUsageCollection) { }
        NotifyIcon Notification = new NotifyIcon();

        public WindowsAlertSystem() {
            Notification.Icon = System.Drawing.SystemIcons.Information;
            Notification.BalloonTipTitle = "Network Usage Tracker";
            Notification.BalloonTipText = "You are currently over the threshold!";
        }
        public override void AlertUserIsOverThreshHold(string Message = "You are currently over the threshold!")
        {
            Notification.Visible = true;
            Notification.ShowBalloonTip(1);
        }
    }
}
