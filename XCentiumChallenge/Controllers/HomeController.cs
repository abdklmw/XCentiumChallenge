using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCentiumChallenge.Models;

namespace XCentiumChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DisplayResults(string url)
        {
            //fetch api results



            return View();
        }
    }
}