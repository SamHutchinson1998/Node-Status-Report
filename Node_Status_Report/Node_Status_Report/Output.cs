using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node_Status_Report
{
    class Output
    {
        // Standard format for what the output would look like. 

        public string name;
        public string status;
        public string mon_time_stamp;
        public string name2;
        public string notification;
        public string name3;

        // If the notification is HELLO
        public Output(string Name, string Status, string Mon_Time_Stamp, string Name2,
            string Notification)
        {
            this.name = Name;
            this.status = Status;
            this.mon_time_stamp = Mon_Time_Stamp;
            this.name2 = Name2;
            this.notification = Notification;
        }
        // If the notification is LOST or FOUND. 
        public Output(string Name, string Status, string Mon_Time_Stamp, string Name2,
            string Notification, string Name3)
        {
            this.name = Name;
            this.status = Status;
            this.mon_time_stamp = Mon_Time_Stamp;
            this.name2 = Name2;
            this.notification = Notification;
            this.name3 = Name3;
        }
    }
}
