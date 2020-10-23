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
using DiyetisyenGultenManav.WebApp.Models;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class DietController : Controller
    {
        DietManager dietManager = new DietManager();
        KullanıcıManager kullanıcıManager = new KullanıcıManager();

        // GET : ALL diet
        public ActionResult AllDiet()
        {
            return View(dietManager.List());
        }

        public ActionResult DanisanBasariHikayesiDanisanBasariHikayesi()
        {
            return View(dietManager.List());
        }
        public ActionResult NewDiet()
        {
            var diet = dietManager.ListQueryable().Where(x => x.IsNew == true).OrderByDescending(x => x.ModifiedOn);
            return View(diet.ToList());
        }
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
            ViewBag.KullanıcıId = new SelectList(kullanıcıManager.List(), "Id", "Username");

            return View();
        }
        // POST: Diet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Diet diet)
        {

            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                dietManager.Insert(diet);
                return RedirectToAction("AllDiet");
            }
            ViewBag.KullanıcıId = new SelectList(kullanıcıManager.List(), "Id", "Username");
            diet.Owner = ViewBag.KullanıcıId;
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
        public ActionResult Edit(Diet diet)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");

            if (ModelState.IsValid)
            {
                Diet db_diet = dietManager.Find(x => x.Id == diet.Id);
                db_diet.Title = diet.Title;
                db_diet.Text = diet.Text;
                db_diet.Description = diet.Description;
                db_diet.IsNew = diet.IsNew;
                dietManager.Update(db_diet);
                return RedirectToAction("AllDiet");
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
            return RedirectToAction("AllDiet");
        }
        public ActionResult DiyetisyenBilgileri()
        {
            return View(dietManager.List());
        }
        public ActionResult DiyetisyenBilgileriEdit(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DiyetisyenBilgileriEdit(Diet diet)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("Title");
            ModelState.Remove("Description");
            ModelState.Remove("Text");
            if (ModelState.IsValid)
            {
                Diet db_diet = dietManager.Find(x => x.Id == diet.Id);
                db_diet.Hastalik = diet.Hastalik;
                db_diet.Tahlil = diet.Tahlil;
                db_diet.Olcum = diet.Olcum;
                db_diet.Hikaye = diet.Hikaye;
                db_diet.EkAciklama = diet.EkAciklama;
                dietManager.Update(db_diet);
                return RedirectToAction("DiyetisyenBilgileri");
            }
            return View(diet);
        }
    }
}
