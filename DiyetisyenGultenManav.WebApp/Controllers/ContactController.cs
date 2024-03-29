﻿using System;
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
    [Exc]

    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager();
        [Auth]
        [AuthAdmin]
        public ActionResult Index(string Ara)
        {
            if (Ara != null)
            {
                return View(contactManager.ListQueryable().Where(x => x.IsimSoyisim.Contains(Ara) || Ara == null).OrderByDescending(x => x.Zaman));
            }
            else
            {
                return View(contactManager.ListQueryable().OrderByDescending(x => x.Zaman));
            }
        }
        [Auth]
        [AuthAdmin]
        public ActionResult Details(int? id)
        {
            /*    if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Contact contact = contactManager.Find(x => x.ID == id);
                if (contact == null)
                {
                    return HttpNotFound();
                }
            */
            BusinessLayerResult<Contact> res = contactManager.GetContactById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Paket Detayı Bulunamadı",
                    RedirectingUrl = "/Contact/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                //contact.Zaman = DateTime.Now;
                //contactManager.Insert(contact);
                BusinessLayerResult<Contact> res = contactManager.CreateContact(contact);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "İletişim Oluşturulamadı.",
                        RedirectingUrl = "/Home/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                //blogYazısıManager.Insert(blogYazısı);
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index", "Home");
        }
        [Auth]
        [AuthAdmin]
        public ActionResult Edit(int? id)
        {
            /*     if (id == null)
                 {
                     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 }
                 Contact contact = contactManager.Find(x => x.ID == id);
                 if (contact == null)
                 {
                     return HttpNotFound();
                 }*/
            BusinessLayerResult<Contact> res = contactManager.GetContactById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Contact Bulunamadı",
                    RedirectingUrl = "/Contact/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }
        [Auth]
        [HttpPost]
        [AuthAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                /*   Contact db_contact = contactManager.Find(x => x.ID == contact.ID);
                   db_contact.ID = contact.ID;
                   db_contact.IsimSoyisim = contact.IsimSoyisim;
                   db_contact.TelefonNumarasi = contact.TelefonNumarasi;
                   db_contact.Email = contact.Email;
                   db_contact.Konu = contact.Konu;
                   db_contact.Mesaj = contact.Mesaj;
                   db_contact.Zaman = db_contact.Zaman;
                   contactManager.Update(db_contact);
                   return RedirectToAction("Index");*/
                BusinessLayerResult<Contact> res = contactManager.UpdateContact(contact);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Contact  Güncellenemedi",
                        RedirectingUrl = "/Contact/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        [Auth]
        [AuthAdmin]
        public ActionResult Delete(int? id)
        {
            /*     if (id == null)
                 {
                     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                 }
                 Contact contact = contactManager.Find(x => x.ID == id);
                 if (contact == null)
                 {
                     return HttpNotFound();
                 }*/
            BusinessLayerResult<Contact> res = contactManager.GetContactById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Contact Bulunamadı",
                    RedirectingUrl = "/Contact/Index",
                    IsRedirecting = true,
                    RedirectingTimeout = 1000

                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }
        [Auth]
        [AuthAdmin]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Contact contact = contactManager.Find(x => x.ID == id);
            //contactManager.Delete(contact);
            BusinessLayerResult<Contact> res = contactManager.GetRemoveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Contact Silinemedi",
                    RedirectingUrl = "/Contact/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return RedirectToAction("Index");
        }
    }
}
