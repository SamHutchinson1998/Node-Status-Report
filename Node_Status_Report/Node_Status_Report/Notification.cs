using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node_Status_Report
{
    class Notification
    {
        // Input format for incoming notifications.
        public string monitoring_notif;
        public string generated_notif;
        public string name;
        public string status;
        public string name2;

        // A HELLO notification. 
        public Notification(string mon_notif, string gen_notif, string Name, string Status)
        {
            this.monitoring_notif = mon_notif;
            this.generated_notif = gen_notif;
            this.name = Name;
            this.status = Status;
        }
        // A LOST or FOUND notification. 
        public Notification(string mon_notif, string gen_notif, string Name, string Status,
            string Name2)
        {
            this.monitoring_notif = mon_notif;
            this.generated_notif = gen_notif;
            this.name = Name;
            this.status = Status;
            this.name2 = Name2;
        }
    }
}
