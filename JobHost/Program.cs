using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace JobHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost svh = new ServiceHost(typeof(JobsService.JobsService)))
            {
                svh.Open();
                Console.WriteLine("host started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
