using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobServiceClient2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            JobServiceReference.JobsServiceClient jobsServiceClient = new JobServiceReference.JobsServiceClient();
             
            return View(jobsServiceClient.OpeningJobs());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}