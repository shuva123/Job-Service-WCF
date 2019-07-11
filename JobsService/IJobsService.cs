using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace JobsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IJobsService" in both code and config file together.
    [ServiceContract]
    public interface IJobsService
    {
        [OperationContract]
         List<Jobs> OpeningJobs();

        [OperationContract]
        List<Jobs> OpeningJobsByRole(string role);
    }
}
