using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Node_Status_Report
{
    class NodeStatusFactory
    {
        public static List<Notifications> LoadInput(string args)
        {
            List<Notifications> notif_list = new List<Notifications>();

            TextReader textIn = new StreamReader(args); // Read in the text file.

            var NumberOfLines = File.ReadLines(args).Count(); // Get number of lines for the text file.

            Notifications notif = GetNotif(textIn, NumberOfLines);
            notif_list.Add(notif); // Add list of notifications to the list.

            return notif_list;
        }
        private static Notifications GetNotif(TextReader textIn, int NumberOfLines)
        {
            List<Notification> notification = new List<Notification>(); // List of notifications.

            for (int i = 0; i < NumberOfLines; i++)
            {
                string line = textIn.ReadLine(); // Read in the current notification. There will only be one notification for each line in the input file.
                string[] words = line.Split(' '); // Split the line up into individual words, as store each work in an array.

                if (words.Length < 5) // If notification is HELLO, In which case there is no need for a second node.
                {
                    string mon_notif = words[0];
                    string gen_notif = words[1];
                    string name = words[2];
                    string status = words[3];

                    Notification notif = new Notification(mon_notif, gen_notif, name, status);
                    notification.Add(notif); // Add object to the list of notifications. 
                }
                else // Else if a notification is a LOST or FOUND one, in which case the there is a need to store the second node.
                {
                    string mon_notif = words[0];
                    string gen_notif = words[1];
                    string name = words[2];
                    string status = words[3];
                    string name2 = words[4];

                    Notification notif = new Notification(mon_notif, gen_notif, name, status, name2);
                    notification.Add(notif); // Add object to the list of notifications. 
                }
            }
            return new Notifications(notification);
        }
    }
}
