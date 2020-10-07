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
using DiyetisyenGultenManav.WebApp.Models;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class DietController : Controller
    {
        DietManager dietManager = new DietManager();

        // GET: Diet
        public ActionResult Index()
        {
            var diet = dietManager.ListQueryable().Include("Owner").
                Where(x => x.Owner.Id == CurrentSession.User.Id).OrderByDescending(x => x.ModifiedOn);
            return View(diet.ToList());
        }

        // GET: Diet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = dietManager.Find(x => x.Id == id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // GET: Diet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Diet diet)
        {
            if (ModelState.IsValid)
            {
           
                return RedirectToAction("Index");
            }

            return View(diet);
        }

        // GET: Diet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = dietManager.Find(x => x.Id == id);
            if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // POST: Diet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Text,CreatedOn,ModifiedOn,ModifiedUsername")] Diet diet)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index");
            }
            return View(diet);
        }

        // GET: Diet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diet diet = dietManager.Find(x => x.Id == id); if (diet == null)
            {
                return HttpNotFound();
            }
            return View(diet);
        }

        // POST: Diet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diet diet = dietManager.Find(x => x.Id == id);
            return RedirectToAction("Index");
        }
    }
}
