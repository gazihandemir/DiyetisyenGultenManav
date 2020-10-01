using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.Entities;


namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class KategoriController : Controller
    {
        private KategoriManager kategoriManager = new KategoriManager();

        public ActionResult Index()
        {
            return View(kategoriManager.List());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kategoriManager.Find(x => x.Id == id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                kategoriManager.Insert(kategori);
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        // GET: Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kategoriManager.Find(x => x.Id == id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                // TODO : inceli..
                kategoriManager.Update(kategori);
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategori kategori = kategoriManager.Find(x => x.Id == id.Value);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
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
