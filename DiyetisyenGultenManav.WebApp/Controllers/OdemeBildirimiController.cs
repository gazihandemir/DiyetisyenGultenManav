using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.WebApp.Data;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class OdemeBildirimiController : Controller
    {
        private DiyetisyenGultenManavWebAppContext db = new DiyetisyenGultenManavWebAppContext();

        // GET: OdemeBildirimi
        public ActionResult Index()
        {
            return View(db.OdemeBildirimis.ToList());
        }

        // GET: OdemeBildirimi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeBildirimi odemeBildirimi = db.OdemeBildirimis.Find(id);
            if (odemeBildirimi == null)
            {
                return HttpNotFound();
            }
            return View(odemeBildirimi);
        }

        // GET: OdemeBildirimi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OdemeBildirimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsimSoyisim,BankaIsmi,YatirilanMiktar,TelefonNo,EkAciklamalar,Bildirdi,IsPay,CreatedOn,ModifiedOn,ModifiedUsername")] OdemeBildirimi odemeBildirimi)
        {
            if (ModelState.IsValid)
            {
                db.OdemeBildirimis.Add(odemeBildirimi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(odemeBildirimi);
        }

        // GET: OdemeBildirimi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeBildirimi odemeBildirimi = db.OdemeBildirimis.Find(id);
            if (odemeBildirimi == null)
            {
                return HttpNotFound();
            }
            return View(odemeBildirimi);
        }

        // POST: OdemeBildirimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsimSoyisim,BankaIsmi,YatirilanMiktar,TelefonNo,EkAciklamalar,Bildirdi,IsPay,CreatedOn,ModifiedOn,ModifiedUsername")] OdemeBildirimi odemeBildirimi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(odemeBildirimi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(odemeBildirimi);
        }

        // GET: OdemeBildirimi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeBildirimi odemeBildirimi = db.OdemeBildirimis.Find(id);
            if (odemeBildirimi == null)
            {
                return HttpNotFound();
            }
            return View(odemeBildirimi);
        }

        // POST: OdemeBildirimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OdemeBildirimi odemeBildirimi = db.OdemeBildirimis.Find(id);
            db.OdemeBildirimis.Remove(odemeBildirimi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
