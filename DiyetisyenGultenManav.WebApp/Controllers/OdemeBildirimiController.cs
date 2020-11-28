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
using DiyetisyenGultenManav.WebApp.Models;
using DiyetisyenGultenManav.WebApp.ViewModels;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class OdemeBildirimiController : Controller
    {
        OdemeBildirimiManager odemeBildirimiManager = new OdemeBildirimiManager();
        KullanıcıManager kullanıcıManager = new KullanıcıManager();
        // GET : IndexOdemeBildirimiOwner
        public ActionResult IndexOdemeBildirimiOwner()
        {
            var Owner = odemeBildirimiManager.ListQueryable().Include("Owner").Where(x => x.Owner.Id == CurrentSession.User.Id).OrderByDescending(x => x.ModifiedOn);
            return View(Owner.ToList());
        }
        // GET : CreateOdemeBildirimiOwner
        public ActionResult CreateOdemeBildirimiOwner()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOdemeBildirimiOwner(OdemeBildirimi odemeBildirimi)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                /*  odemeBildirimi.Owner = CurrentSession.User;
                  odemeBildirimi.IsNotification = true;
                  odemeBildirimi.IsPay = false;
                  odemeBildirimi.IsOkey = false;
                  odemeBildirimiManager.Insert(odemeBildirimi);
                */
                BusinessLayerResult<OdemeBildirimi> res = odemeBildirimiManager.CreateOdemeBildirimiOwner(odemeBildirimi, CurrentSession.User);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Ödeme Bildirimi  Oluşturulamadı.",
                        RedirectingUrl = "/OdemeBildirimi/IndexOdemeBildirimiOwner"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("IndexOdemeBildirimiOwner");
            }
            return View(odemeBildirimi);
        }
        // GET: OdemeBildirimi
        public ActionResult Index(string Ara)
        {
            if (Ara != null)
            {
                return View(odemeBildirimiManager.ListQueryable().Where(x => x.Owner.Username.Contains(Ara) || Ara == null).OrderByDescending(x => x.ModifiedOn));
            }
            else
            {
                return View(odemeBildirimiManager.List().OrderByDescending(x => x.ModifiedOn));
            }
        }
        // GET: OdemeBildirimi/Details/5
        public ActionResult Details(int? id)
        {
            /*  if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
              if (odemeBildirimi == null)
              {
                  return HttpNotFound();
              } */

            BusinessLayerResult<OdemeBildirimi> res = odemeBildirimiManager.GetOdemeBildirimiById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Ödeme Bildirimi Detayı Bulunamadı",
                    RedirectingUrl = "/OdemeBildirimi/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }

        // GET: OdemeBildirimi/Create
        public ActionResult Create()
        {
            ViewBag.KullanıcıId = new SelectList(kullanıcıManager.List(), "Id", "Username");
            return View();
        }
        // POST: OdemeBildirimi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OdemeBildirimi odemeBildirimi)
        {
           
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                //  odemeBildirimiManager.Insert(odemeBildirimi);
                BusinessLayerResult<OdemeBildirimi> res = odemeBildirimiManager.CreateOdemeBildirimi(odemeBildirimi);

                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Ödeme Bildirimi  Oluşturulamadı.",
                        RedirectingUrl = "/OdemeBildirimi/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("Index");

            }
            else
            {
                BusinessLayerResult<OdemeBildirimi> res = new BusinessLayerResult<OdemeBildirimi>();
                ErrorViewModel ErrNotifyObj2 = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title="Ödeme Bildirimi Oluşturulamadı Lütfen Oluştururken Bütün Alanları Doldurmaya Dikkat edin ! ",
                    RedirectingUrl= "/OdemeBildirimi/Index",
                    IsRedirecting=true,
                };
                return View("Error", ErrNotifyObj2);
            }
            //ViewBag.KullanıcıId = new SelectList(kullanıcıManager.List(), "Id", "Username");
            //   ViewBag.KullanıcıId = "bos";
            // odemeBildirimi.Owner = ViewBag.KullanıcıId;

        }

        // GET: OdemeBildirimi/Edit/5
        public ActionResult Edit(int? id)
        {
            /*  if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
              if (odemeBildirimi == null)
              {
                  return HttpNotFound();
              }*/
            BusinessLayerResult<OdemeBildirimi> res = odemeBildirimiManager.GetOdemeBildirimiById(id);
            if (CurrentSession.User.IsAdmin)
            {
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Ödeme Bildirimi Bulunamadı",
                        RedirectingUrl = "/OdemeBildirimi/Index"
                    };
                    return View("Error", ErrNotifyObj);
                }
            }
            else
            {
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Ödeme Bildirimi Bulunamadı",
                        RedirectingUrl = "/OdemeBildirimi/IndexOdemeBildirimiOwner"
                    };
                    return View("Error", ErrNotifyObj);
                }
            }
            return View(res.Result);
        }
        // POST: OdemeBildirimi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OdemeBildirimi odemeBildirimi)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("IsNotification");
            ModelState.Remove("IsPay");
            ModelState.Remove("IsOkey");
            if (ModelState.IsValid)
            {
                /*      OdemeBildirimi db_odeme = odemeBildirimiManager.Find(x => x.Id == odemeBildirimi.Id);
                      db_odeme.IsimSoyisim = odemeBildirimi.IsimSoyisim;
                      db_odeme.BankaIsmi = odemeBildirimi.BankaIsmi;
                      db_odeme.YatirilanMiktar = odemeBildirimi.YatirilanMiktar;
                      db_odeme.TelefonNo = odemeBildirimi.TelefonNo;
                      db_odeme.EkAciklamalar = odemeBildirimi.EkAciklamalar;
                      if (CurrentSession.User.IsAdmin)
                      {
                          db_odeme.IsNotification = odemeBildirimi.IsNotification;
                          db_odeme.IsPay = odemeBildirimi.IsPay;
                          db_odeme.IsOkey = odemeBildirimi.IsOkey; 
                          odemeBildirimiManager.Update(db_odeme);
                          return RedirectToAction("Index");
                      }
                      else
                      {
                          db_odeme.IsNotification = db_odeme.IsNotification;
                          db_odeme.IsPay = db_odeme.IsPay;
                          db_odeme.IsOkey = db_odeme.IsOkey;
                          odemeBildirimiManager.Update(db_odeme);
                          return RedirectToAction("IndexOdemeBildirimiOwner");
                      }
                */
                BusinessLayerResult<OdemeBildirimi> res = odemeBildirimiManager.UpdateOdemeBildirimi(odemeBildirimi, CurrentSession.User.IsAdmin);
                if (CurrentSession.User.IsAdmin)
                {
                    if (res.Errors.Count > 0)
                    {
                        ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                        {
                            Items = res.Errors,
                            Title = "Ödeme Bildirimi Güncellenemedi",
                            RedirectingUrl = "/OdemeBildirimi/Index"
                        };
                        return View("Error", ErrNotifyObj);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    if (res.Errors.Count > 0)
                    {
                        ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                        {
                            Items = res.Errors,
                            Title = "Ödeme Bildirimi Güncellenemedi",
                            RedirectingUrl = "/OdemeBildirimi/IndexOdemeBildirimiOwner"
                        };
                        return View("Error", ErrNotifyObj);
                    }
                    return RedirectToAction("IndexOdemeBildirimiOwner");
                }
            }
            return View();
        }
        // GET: OdemeBildirimi/Delete/5
        public ActionResult Delete(int? id)
        {
            /*    if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
                if (odemeBildirimi == null)
                {
                    return HttpNotFound();
                }
            */
            BusinessLayerResult<OdemeBildirimi> res = odemeBildirimiManager.GetOdemeBildirimiById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Ödeme Bildirimi Bulunamadı",
                    RedirectingUrl = "/OdemeBildirimi/Index",
                    IsRedirecting = true,
                    RedirectingTimeout = 1000
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }
        // POST: OdemeBildirimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //OdemeBildirimi odemeBildirimi = odemeBildirimiManager.Find(x => x.Id == id);
            //odemeBildirimiManager.Delete(odemeBildirimi);
            BusinessLayerResult<OdemeBildirimi> res = odemeBildirimiManager.GetRemoveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Ödeme Bildirimi Silinemedi",
                    RedirectingUrl = "/OdemeBildirimi/Index",
                    IsRedirecting = true,
                    RedirectingTimeout=1000,
                };
                return View("Error", ErrNotifyObj);
            }
            return RedirectToAction("Index");
        }
    }
}
