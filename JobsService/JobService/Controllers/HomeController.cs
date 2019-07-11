using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobService.Models;

namespace JobService.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            JobServiceReference.JobsServiceClient jobsServiceClient = new JobServiceReference.JobsServiceClient();
            JobServiceReference.Jobs job = new JobServiceReference.Jobs();
            job = jobsServiceClient.OpeningJobs();
            DataTable dt = new DataTable();
            return View();
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