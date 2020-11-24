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
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager();
        // GET: Contact
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

        // GET: Contact/Details/5
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
                    RedirectingUrl = "/Paket/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Zaman = DateTime.Now;
                contactManager.Insert(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactManager.Find(x => x.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contact db_contact = contactManager.Find(x => x.ID == contact.ID);
                db_contact.ID = contact.ID;
                db_contact.IsimSoyisim = contact.IsimSoyisim;
                db_contact.TelefonNumarasi = contact.TelefonNumarasi;
                db_contact.Email = contact.Email;
                db_contact.Konu = contact.Konu;
                db_contact.Mesaj = contact.Mesaj;
                db_contact.Zaman = db_contact.Zaman;
                contactManager.Update(db_contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = contactManager.Find(x => x.ID == id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = contactManager.Find(x => x.ID == id);
            contactManager.Delete(contact);
            return RedirectToAction("Index");
        }
    }
}
