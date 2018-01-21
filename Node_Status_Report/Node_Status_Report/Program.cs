using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Node_Status_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Notifications> notif_list = NodeStatusFactory.LoadInput(args[0]); // Extract and store the contents of the input file
                Notifications notif = null;

                List<Output> outputs = new List<Output>(); // List of outputs generated from the file

                foreach (Notifications notification in notif_list)
                {
                    notif = notification;
                    notif.SortbyDesc(); // Sort the list by descending order
                    outputs = outputs.Concat(notif.Report()).ToList(); // Generate a report of the outputs and add them to the list.
                }

                Outputs output = new Outputs(outputs);
                output.report(); // Further refine the report so that it produces the final result for each node.
                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error processing file! ");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
