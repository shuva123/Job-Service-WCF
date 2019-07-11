using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobService.Models
{
    public class Jobs
    {
        private int _id;
        private string _role;
        private string _jobs;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public string Job
        {
            get { return _jobs; }
            set { _jobs = value; }
        }
    }
}
