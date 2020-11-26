using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class YorumController : Controller
    {
        private BlogYazısıManager blogYazısıManager = new BlogYazısıManager();
        private YorumManager yorumManager = new YorumManager();
        public ActionResult ShowNoteComments(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogYazısı blogYazısı = blogYazısıManager.ListQueryable().Include("Yorumlar").FirstOrDefault(x => x.Id == id);
            if (blogYazısı == null)
            {
                return HttpNotFound();
            }
            return PartialView("_PartialYorumlar", blogYazısı.Yorumlar);
        }
        [HttpPost]
        public ActionResult Edit(int? id, string text)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = yorumManager.Find(x => x.Id == id);
            if (yorum == null)
            {
                return new HttpNotFoundResult();
            }
            yorum.Text = text;
            if (yorumManager.Update(yorum) > 0)
            {
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = yorumManager.Find(x => x.Id == id);
            if (yorum == null)
            {
                return new HttpNotFoundResult();
            }
            if (yorumManager.Delete(yorum) > 0)
            {
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Create(Yorum yorum,int? noteid)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                if (noteid == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                BlogYazısı blogYazısı = blogYazısıManager.Find(x => x.Id == noteid);
                if (blogYazısı == null)
                {
                    return new HttpNotFoundResult();
                }
                yorum.BlogYazısı = blogYazısı;
                yorum.Owner = CurrentSession.User;
                if (yorumManager.Insert(yorum) > 0)
                {
                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }
    }
}