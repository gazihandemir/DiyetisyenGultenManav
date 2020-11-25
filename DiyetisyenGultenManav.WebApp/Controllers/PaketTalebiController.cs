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
using DiyetisyenGultenManav.WebApp.Data;
using DiyetisyenGultenManav.WebApp.ViewModels;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class PaketTalebiController : Controller
    {
        PaketTalebiManager paketTalebiManager = new PaketTalebiManager();

        // GET: PaketTalebi
        public ActionResult Index(string Ara)
        {
            return View(paketTalebiManager.ListQueryable().Where(x => x.IsimSoyisim.Contains(Ara) || Ara == null));
        }

        // GET: PaketTalebi/Details/5
        public ActionResult Details(int? id)
        {
            /*   if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               PaketTalebi paketTalebi = paketTalebiManager.Find(x => x.Id == id);
               if (paketTalebi == null)
               {
                   return HttpNotFound();
               }*/
            BusinessLayerResult<PaketTalebi> res = paketTalebiManager.GetPaketTalebiById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Talebi Detayı Bulunamadı",
                    RedirectingUrl = "/PaketTalebi/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // GET: PaketTalebi/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaketTalebi paketTalebi)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                paketTalebiManager.Insert(paketTalebi);
                return RedirectToAction("Index");
            }

            return View(paketTalebi);
        }

        // GET: PaketTalebi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaketTalebi paketTalebi = paketTalebiManager.Find(x => x.Id == id);
            if (paketTalebi == null)
            {
                return HttpNotFound();
            }
            return View(paketTalebi);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PaketTalebi paketTalebi)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                PaketTalebi db_paketTalebi = paketTalebiManager.Find(x => x.Id == paketTalebi.Id);
                db_paketTalebi.IsimSoyisim = paketTalebi.IsimSoyisim;
                db_paketTalebi.TelefonNo = paketTalebi.TelefonNo;
                db_paketTalebi.Program = paketTalebi.Program;
                db_paketTalebi.EkAciklamalar = paketTalebi.EkAciklamalar;
                paketTalebiManager.Update(db_paketTalebi);
                return RedirectToAction("Index");
            }
            return View(paketTalebi);
        }

        // GET: PaketTalebi/Delete/5
        public ActionResult Delete(int? id)
        {
            /*  if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              PaketTalebi paketTalebi = paketTalebiManager.Find(x => x.Id == id);
              if (paketTalebi == null)
              {
                  return HttpNotFound();
              }*/
            BusinessLayerResult<PaketTalebi> res = paketTalebiManager.GetPaketTalebiById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Talebi Bulunamadı",
                    RedirectingUrl = "/PaketTalebi/Index",
                    IsRedirecting = true,
                    RedirectingTimeout = 3000

                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // POST: PaketTalebi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PaketTalebi paketTalebi = paketTalebiManager.Find(x => x.Id == id);
            //paketTalebiManager.Delete(paketTalebi);
            BusinessLayerResult<PaketTalebi> res = paketTalebiManager.GetRemoveById(id);

            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Talebi Silinemedi",
                    RedirectingUrl = "/PaketTalebi/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return RedirectToAction("Index");
        }
    }
}
