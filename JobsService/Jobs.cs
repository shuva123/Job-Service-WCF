using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace JobsService
{
    [DataContract]
    public class Jobs
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string Job { get; set; }

        //[DataMember]
        //public DataTable JobsTable
        //{
        //    get;
        //    set;
        //}
    }
}
