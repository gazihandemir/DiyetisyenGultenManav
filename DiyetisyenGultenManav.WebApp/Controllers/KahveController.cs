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

    public class KahveController : Controller
    {
        KahveManager kahveManager = new KahveManager();
        // GET: Kahve
        public ActionResult Index()
        {
            var Listeleme = kahveManager.ListQueryable().OrderBy(x => x.CreatedOn);
            return View(Listeleme);
        }

        // GET: Kahve/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          BusinessLayerResult<Kahve> res  = kahveManager.GetKahveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Kahve Bulunamadı",
                    RedirectingUrl = "/Kahve/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // GET: Kahve/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kahve/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kahve kahve)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kahve> res = kahveManager.CreateKahve(kahve);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Kahve Oluşturulamadı.",
                        RedirectingUrl = "/Kahve/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Kahve/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessLayerResult<Kahve> res = kahveManager.GetKahveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Kahve Bulunamadı",
                    RedirectingUrl = "/Kahve/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // POST: Kahve/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kahve kahve)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kahve> res = kahveManager.UpdateKahve(kahve);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Kahve Güncellenemedi",
                        RedirectingUrl = "/Kahve/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Kahve/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessLayerResult<Kahve> res = kahveManager.GetKahveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Kahve Bulunamadı",
                    RedirectingUrl = "/Kahve/Index",
                    IsRedirecting = true,
                    RedirectingTimeout = 1000

                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // POST: Kahve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessLayerResult<Kahve> res = kahveManager.GetRemoveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Kahve Silinemedi",
                    RedirectingUrl = "/Kahve/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return RedirectToAction("Index");
        }
    }
}
