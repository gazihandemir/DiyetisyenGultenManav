using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.Entities;
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
            return PartialView("_PartialYorumlar",blogYazısı.Yorumlar);
        }
    }
}