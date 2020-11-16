﻿using System;
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
    public class PaketController : Controller
    {
        PaketManager paketManager = new PaketManager();
        // GET: Paket
        public ActionResult Index()
        {
            return View(paketManager.ListQueryable().OrderByDescending(x => x.ModifiedOn));
        }

        // GET: Paket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paket paket = paketManager.Find(x => x.Id == id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            return View(paket);
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paket paket = paketManager.Find(x => x.Id == id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            return View(paket);
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
                Paket db_paket = paketManager.Find(x => x.Id == paket.Id);
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

                return RedirectToAction("Index");
            }
            return View(paket);
        }

        // GET: Paket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paket paket = paketManager.Find(x => x.Id == id);
            if (paket == null)
            {
                return HttpNotFound();
            }
            return View(paket);
        }

        // POST: Paket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paket paket = paketManager.Find(x => x.Id == id);
            paketManager.Delete(paket);
            return RedirectToAction("Index");
        }

    }
}
