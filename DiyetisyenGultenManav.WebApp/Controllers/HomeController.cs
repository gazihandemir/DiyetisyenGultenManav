using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.Entities;
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
        /* BusinessLayer.test test = new BusinessLayer.test();
       // test.InsertTest();
       //  test.UpdateTest();
       // test.DeleteTest();
         test.YorumTest(); */
        {
            BlogYazısıManager nm = new BlogYazısıManager();
            return View(nm.getAllBlogYazısı());
        }
        public ActionResult ByKategori(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            KategoriManager cm = new KategoriManager();
            Kategori kate = cm.GetKategoriById(id.Value);
            if (kate == null)
            {
                return HttpNotFound();
            }
            return View("Index", kate.BlogYazıları);
        }
    }
}