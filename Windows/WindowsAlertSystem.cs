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
        public override void AlertUserIsOverThreshHold(string Message = "You are currently over the threshold!")
        {
            NotifyIcon Notification = new NotifyIcon();
            Notification.Visible = true;

            Notification.Icon = System.Drawing.SystemIcons.Information;
            Notification.BalloonTipTitle = "Network Usage Tracker";
            Notification.BalloonTipText = "You are currently over the threshold!";

            Notification.ShowBalloonTip(1);
            Notification.Dispose();

        }
    }
}
