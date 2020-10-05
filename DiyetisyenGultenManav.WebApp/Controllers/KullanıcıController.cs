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
namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class KullanıcıController : Controller
    {
        private KullanıcıManager kullanıcıManager = new KullanıcıManager();

        public ActionResult Index()
        {
            return View(kullanıcıManager.List());
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
            if (ModelState.IsValid)
            {
                // todo : düzeltilecek
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
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,Username,Email,Password,ProfileImageFileName,DogumTarihi,TelefonNumarası,Boy,Kilo,Yas,Meslek,Sehir,ActivateGuid,IsActive,IsAdmin,IsOnline,IsNormal,IsPayOnline,CreatedOn,ModifiedOn,ModifiedUsername")] Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                // todo : düzenlenecek
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
            kullanıcıManager.Delete(kullanıcı);
            return RedirectToAction("Index");
        }
    }
}
