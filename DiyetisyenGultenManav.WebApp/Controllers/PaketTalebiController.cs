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
using DiyetisyenGultenManav.WebApp.Data;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class PaketTalebiController : Controller
    {
        PaketTalebiManager paketTalebiManager = new PaketTalebiManager();

        // GET: PaketTalebi
        public ActionResult Index()
        {
            return View(paketTalebiManager.List()); ;
        }

        // GET: PaketTalebi/Details/5
        public ActionResult Details(int? id)
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

        // POST: PaketTalebi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaketTalebi paketTalebi = paketTalebiManager.Find(x => x.Id == id);
            paketTalebiManager.Delete(paketTalebi);
            return RedirectToAction("Index");
        }
    }
}