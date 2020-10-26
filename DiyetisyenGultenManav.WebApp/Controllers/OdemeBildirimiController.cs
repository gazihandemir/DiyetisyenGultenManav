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
    public class OdemeBildirimiController : Controller
    {
        OdemeBildirimiManager odemeBildirimiManager = new OdemeBildirimiManager();
        // GET: OdemeBildirimi
        public ActionResult Index()
        {
            return View(odemeBildirimiManager.List());
        }

        // GET: OdemeBildirimi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
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
        public ActionResult Create(OdemeBildirimi odemeBildirimi)
        {
            if (ModelState.IsValid)
            {

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
            OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
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
            OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
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
            OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
            return RedirectToAction("Index");
        }
    }
}
