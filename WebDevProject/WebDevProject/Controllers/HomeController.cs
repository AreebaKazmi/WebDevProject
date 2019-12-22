using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDevProject.Views.Account;

namespace WebDevProject.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();

        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
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

        public int Myapi()
        {
            var results = (from Name in db.People select Name).ToList().Count();
            return (results);
        }
    }
}