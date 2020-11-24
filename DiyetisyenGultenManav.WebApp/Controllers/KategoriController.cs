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
using DiyetisyenGultenManav.WebApp.ViewModels;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class KategoriController : Controller
    {
        private KategoriManager kategoriManager = new KategoriManager();

        public ActionResult Index(string Ara)
        {
            return View(kategoriManager.ListQueryable().Where(x => x.Title.Contains(Ara) || Ara == null));
        }


        public ActionResult Details(int? id)
        {
            /*      if (id == null)
                  {
                      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Kategori kategori = kategoriManager.Find(x => x.Id == id.Value);
                  if (kategori == null)
                  {
                      return HttpNotFound();
                  }*/
            BusinessLayerResult<Kategori> res = kategoriManager.GetKategoriById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Blog Yazısı Oluşturulamadı.",
                    RedirectingUrl = "/Kategori/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kategori kategori)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {                //kategoriManager.Insert(kategori);
                BusinessLayerResult<Kategori> res = kategoriManager.CreateKategori(kategori);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Blog Yazısı Oluşturulamadı.",
                        RedirectingUrl = "/BlogYazısı/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            /*      if (id == null)
                  {
                      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Kategori kategori = kategoriManager.Find(x => x.Id == id.Value);
                  if (kategori == null)
                  {
                      return HttpNotFound();
                  }
            */
            BusinessLayerResult<Kategori> res = kategoriManager.GetKategoriById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Blog Yazısı Bulunamadı",
                    RedirectingUrl = "/BlogYazısı/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategori kategori)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                /*   Kategori kat = kategoriManager.Find(x => x.Id == kategori.Id);
                   kat.Title = kategori.Title;
                   kat.Description = kategori.Description;
                   kategoriManager.Update(kat);
                */
                BusinessLayerResult<Kategori> res = kategoriManager.UpdateKategori(kategori);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Kategoi Güncellenemedi.",
                        RedirectingUrl = "/Kategori/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int? id)
        {
            /*      if (id == null)
                  {
                      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                  }
                  Kategori kategori = kategoriManager.Find(x => x.Id == id.Value);
                  if (kategori == null)
                  {
                      return HttpNotFound();
                  } */
            BusinessLayerResult<Kategori> res = kategoriManager.GetKategoriById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Blog Yazısı Oluşturulamadı.",
                    RedirectingUrl = "/Kategori/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategori kategori = kategoriManager.Find(x => x.Id == id);
            kategoriManager.Delete(kategori);
            return RedirectToAction("Index");
        }
    }
}
