using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node_Status_Report
{
    class Outputs
    {
        public List<Output> outputs;
        public List<Output> reportedoutputs = new List<Output>();
        public Outputs(List<Output> Outputs)
        {
            this.outputs = Outputs;
        }

        public void report()
        {
            /*
             * Group objects by Node name, then generate a list of notifications
             * for each node and store the lists in verifiedinputs.
            */
            var verifiedoutputs = outputs.GroupBy(x => x.name).Select(x => x.ToList()).ToList();

            foreach (var node in verifiedoutputs)
            {
                for (int i = 0; i < node.Count; i++)
                {
                    if (node[i].status.ToLower().ToString() == "alive")
                    {
                        reportedoutputs.Add(node[i]);
                        break; // Once a node has shown as alive, there is no need to go further through the list as we now know that the node is alive, so move on to the next list of notifications.
                    }
                    if(node[i].status.ToLower().ToString() == "dead")
                    {
                        /*
                         * Just because a notification implies a node is dead, doesn't mean that they may show
                         * up as alive later on through the input file! 
                         * 
                         * Hence, a node can only be truly dead if they have only shown up as being LOST, without saying
                         * HELLO or that they FOUND another node (or FOUND itself). The node must be alive in order to send those kinds
                         * of notifications.
                         */

                        if(i == node.Count - 1)
                        {
                            reportedoutputs.Add(node[i]);
                            break; // Move on to next list of nodes once it has found a node matching the aforementioned condition. 
                        }
                        else
                        {
                            continue; // Otherwise move on to the next notification / list of nodes.
                        }
                    }
                }
            }

            OutputReport();
        }

        private void OutputReport()
        {
            foreach (Output output in reportedoutputs) // Output the results to the Terminal / console.
            {
                if (output.name3 == null)
                {
                    Console.WriteLine(output.name + " " + output.status + " " + output.mon_time_stamp + " " + output.name2 + " " + output.notification);
                }
                else
                {
                    Console.WriteLine(output.name + " " + output.status + " " + output.mon_time_stamp + " " + output.name2 + " " + output.notification + " " + output.name3);
                }
            }
        }
    }
}
