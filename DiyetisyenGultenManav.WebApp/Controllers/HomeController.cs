using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BusinessLayer.test test = new BusinessLayer.test();
            // test.InsertTest();
            //  test.UpdateTest();
            // test.DeleteTest();
            test.YorumTest();
            return View();
        }
    }
}