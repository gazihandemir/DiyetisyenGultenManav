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
    public class PaketController : Controller
    {
        PaketManager paketManager = new PaketManager();
        // GET: Paket
        public ActionResult Index(string Ara)
        {
            if (Ara != null)
            {
                return View();
            }
            else
            {
                return View(paketManager.ListQueryable().OrderByDescending(x => x.ModifiedOn));
            }
        }

        // GET: Paket/Details/5
        public ActionResult Details(int? id)
        {
            /*   if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Paket paket = paketManager.Find(x => x.Id == id);
               if (paket == null)
               {
                   return HttpNotFound();
               } */
            BusinessLayerResult<Paket> res = paketManager.GetPaketById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Detayı Bulunamadı",
                    RedirectingUrl = "/Paket/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // GET: Paket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Paket paket)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                paketManager.Insert(paket);
                return RedirectToAction("Index");
            }

            return View(paket);
        }

        // GET: Paket/Edit/5
        public ActionResult Edit(int? id)
        {
            /*   if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Paket paket = paketManager.Find(x => x.Id == id);
               if (paket == null)
               {
                   return HttpNotFound();
               }
            */
            BusinessLayerResult<Paket> res = paketManager.GetPaketById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Bulunamadı",
                    RedirectingUrl = "/Paket/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // POST: Paket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paket paket)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                /*   Paket db_paket = paketManager.Find(x => x.Id == paket.Id);
                   db_paket.Isim = paket.Isim;
                   db_paket.Fiyat = paket.Fiyat;
                   db_paket.Süresi = paket.Süresi;

                   db_paket.OzellikBirRed = paket.OzellikBirRed;
                   db_paket.OzellikBir = paket.OzellikBir;

                   db_paket.OzellikIkiRed = paket.OzellikIkiRed;
                   db_paket.OzellikIki = paket.OzellikIki;

                   db_paket.OzellikUcRed = paket.OzellikUcRed;
                   db_paket.OzellikUc = paket.OzellikUc;

                   db_paket.Renk = paket.Renk;
                   db_paket.RenkButton = paket.RenkButton;

                   db_paket.Aciklama = paket.Aciklama;
                   paketManager.Update(db_paket);
                */
                BusinessLayerResult<Paket> res = paketManager.UpdatePaket(paket);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Paket Güncellenemedi",
                        RedirectingUrl = "/Paket/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Paket/Delete/5
        public ActionResult Delete(int? id)
        {
            /*   if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               Paket paket = paketManager.Find(x => x.Id == id);
               if (paket == null)
               {
                   return HttpNotFound();
               }
            */
            BusinessLayerResult<Paket> res = paketManager.GetPaketById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Bulunamadı",
                    RedirectingUrl = "/Paket/Index",
                    IsRedirecting = true,
                    RedirectingTimeout = 1000

                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // POST: Paket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //   Paket paket = paketManager.Find(x => x.Id == id);
            // paketManager.Delete(paket);
            BusinessLayerResult<Paket> res = paketManager.GetRemoveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Silinemedi",
                    RedirectingUrl = "/Paket/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return RedirectToAction("Index");
        }

    }
}
