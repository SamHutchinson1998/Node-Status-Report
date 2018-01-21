using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node_Status_Report
{
    class Notifications
    {

        public List<Notification> notifications;

        public Notifications(List<Notification> notification)
        {
            this.notifications = notification;
        }

        public void SortbyDesc()
        {
            /*
             *  The list will need to be sorted in descending order
             *  (reversed) as the specified output in the specification
             *  looked as if the required program will read the input file
             *  bottom to top.
             */

            notifications.Reverse();
        }
        public List<Output> Report()
        {
            List<Output> outputs = new List<Output>(); // Store all the outputs in the require output format. 

            foreach (Notification item in notifications)
            {
                switch (item.status.ToLower().ToString()) // Loop through the list and add outputs based on the notification. 
                {
                    case "hello":
                    case "found":
                        outputs.AddRange(GetOutput(item, true)); // Node is ALIVE.
                        break;
                    case "lost":
                        outputs.AddRange(GetOutput(item, false)); // Node is DEAD.
                        break;
                }
            }
            return outputs;
        }

        private List<Output> GetOutput(Notification item, bool notif_status)
        {
            /* 
             * One notification may produce up to two outputs as a node has to be alive to send a LOST or FOUND 
             * notification, as well as output the result from the node which is LOST or FOUND.
            */

            List<Output> outputs = new List<Output>(); 

            string name = item.name;
            string status;
            string timeStamp = item.monitoring_notif;
            string notification = item.status;

            if (notif_status)
            {
                status = "ALIVE";
            }
            else
            {
                status = "DEAD";
            }

            if (item.name2 == null) // If no second node is present in the notification i.e. a HELLO notification.
            {
                Output output = new Output(name, status, timeStamp, name, notification);
                outputs.Add(output);
            }
            else // If a second node is present i.e. a LOST or FOUND notification. 
            {
                string name3 = item.name2;

                // Add another notification for the first node being ALIVE as that node will need to aslo report as ALIVE in order to send the notification. 

                Output output = new Output(name, "ALIVE", timeStamp, name, notification, name3); 
                outputs.Add(output);

                output = new Output(name3, status, timeStamp, name, notification, name3);
                outputs.Add(output);

            }
            return outputs;
        }
        

    }
}
