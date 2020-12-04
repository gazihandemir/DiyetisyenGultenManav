using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.BusinessLayer.Results;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.WebApp.Filters;
using DiyetisyenGultenManav.WebApp.ViewModels;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    [Auth]
    [AuthAdmin]
    [Exc]
    public class KullanıcıController : Controller
    {
        private KullanıcıManager kullanıcıManager = new KullanıcıManager();

        public ActionResult Index(string Ara)
        {
            if (Ara != null)
            {
                return View(kullanıcıManager.ListQueryable().Where(x => x.Username.Contains(Ara) || Ara == null));
            }
            else
            {
                return View(kullanıcıManager.List());
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = kullanıcıManager.Find(x => x.Id == id.Value);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kullanıcı kullanıcı)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("ActivateGuid");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanıcı> res = kullanıcıManager.Insert(kullanıcı);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(kullanıcı);
                }
                return RedirectToAction("Index");
            }
            return View(kullanıcı);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = kullanıcıManager.Find(x => x.Id == id.Value);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kullanıcı kullanıcı)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("ActivateGuid");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanıcı> res = kullanıcıManager.Update(kullanıcı);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(kullanıcı);
                }
                return RedirectToAction("Index");
            }
            return View(kullanıcı);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcı kullanıcı = kullanıcıManager.Find(x => x.Id == id.Value);
            if (kullanıcı == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanıcı kullanıcı = kullanıcıManager.Find(x => x.Id == id);
            BusinessLayerResult<Kullanıcı> resFind = kullanıcıManager.GetUserById(id);
            if (resFind.Result.ProfileImageFileName != null)
            {
                System.IO.File.Delete(Server.MapPath($"~/ImageProfil/{resFind.Result.ProfileImageFileName}")); // klasörden fotoğraf silme
            }
            if (resFind.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = resFind.Errors,
                    Title = "Blog Yazısı Bulunamadı",
                    RedirectingUrl = "/BlogYazısı/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            kullanıcıManager.Delete(kullanıcı);
            return RedirectToAction("Index");
        }
    }
}
