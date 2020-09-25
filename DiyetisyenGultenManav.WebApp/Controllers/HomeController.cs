using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.ValueObjects;
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
            return View("Index", kate.BlogYazıları.OrderByDescending(x => x.ModifiedOn).ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                KullanıcıManager km = new KullanıcıManager();
                BusinessLayerResult<Kullanıcı> res = km.RegisterUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError(" ", x));
                    return View(model);
                }
                return RedirectToAction("RegisterOk");
            }
            return View(model);


            /*   if (ModelState.IsValid)
            {
                  if (model.Username == "aaa")
                  {
                      ModelState.AddModelError("", "Kullanıcı Adı kullanılıyor");
                  }
                  if (model.Email == "aaa@aa.com")
                  {
                      ModelState.AddModelError("", "e-posta adresi  kullanılıyor");
                  }
              }
             foreach (var item in ModelState)
              {
                  if (item.Value.Errors.Count > 0)
                  {
                      return View(model);
                  }
              }
          */

        }
        public ActionResult UserActivate()
        {
            return View();
        }
        public ActionResult RegisterOk()
        {
            return View();
        }
    }
}