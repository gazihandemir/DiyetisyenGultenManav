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
    public class BlogYazısıController : Controller
    {
        BlogYazısıManager blogYazısıManager = new BlogYazısıManager();
        KategoriManager kategoriManager = new KategoriManager();
        public ActionResult Index(string Ara)
        {
            var blogYazısı = blogYazısıManager.ListQueryable().Include("Kategori").Include("Owner")
                  .Where(x => x.Owner.Id == CurrentSession.User.Id).OrderByDescending(x => x.ModifiedOn);
            var blogYazısıAra = blogYazısıManager.ListQueryable().Include("Kategori").Include("Owner")
                .Where(x => x.Owner.Id == CurrentSession.User.Id && x.Title.Contains(Ara) || Ara == null).OrderByDescending(x => x.ModifiedOn);
            if (Ara != null)
            {
                return View(blogYazısıAra.ToList());
            }
            else
            {
                //return View(blogYazısı.ToList());
                return View(blogYazısıManager.ListQueryable().OrderByDescending(x => x.ModifiedOn));
            }

        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogYazısı blogYazısı = blogYazısıManager.Find(x => x.Id == id);
            if (blogYazısı == null)
            {
                return HttpNotFound();
            }
            return View(blogYazısı);
        }
        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(kategoriManager.List(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogYazısı blogYazısı, HttpPostedFileBase blogImage)
        {

            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                if (blogImage != null && (
               blogImage.ContentType == "image/jpeg" ||
               blogImage.ContentType == "image/jpg" ||
               blogImage.ContentType == "image/png"))
                {
                    Guid guid = Guid.NewGuid();
                    string filename = $"blog_{guid}.{blogImage.ContentType.Split('/')[1]}";
                    blogImage.SaveAs(Server.MapPath($"~/ImageBlog/{filename}"));
                    blogYazısı.Picture = filename;
                }
                blogYazısı.Owner = CurrentSession.User;
                blogYazısıManager.Insert(blogYazısı);
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.List(), "Id", "Title", blogYazısı.KategoriId);
            return View(blogYazısı);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogYazısı blogYazısı = blogYazısıManager.Find(x => x.Id == id);
            if (blogYazısı == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.List(), "Id", "Title", blogYazısı.KategoriId);
            return View(blogYazısı);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogYazısı blogYazısı, HttpPostedFileBase blogImage)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                BlogYazısı db_blog = blogYazısıManager.Find(x => x.Id == blogYazısı.Id);
                db_blog.IsDraft = blogYazısı.IsDraft;
                db_blog.KategoriId = blogYazısı.KategoriId;
                db_blog.ParagrafBir = blogYazısı.ParagrafBir;
                db_blog.ParagrafIki = blogYazısı.ParagrafIki;
                db_blog.ParagrafUc = blogYazısı.ParagrafUc;
                db_blog.ParagrafDort = blogYazısı.ParagrafDort;
                db_blog.ParagrafBes = blogYazısı.ParagrafBes;
                db_blog.ParagrafAlti = blogYazısı.ParagrafAlti;
                db_blog.ParagrafYedi = blogYazısı.ParagrafYedi;
                db_blog.ParagrafSekiz = blogYazısı.ParagrafSekiz;
                db_blog.Title = blogYazısı.Title;
                db_blog.DanisanPaylasimi = blogYazısı.DanisanPaylasimi;
                if (blogImage != null && (
              blogImage.ContentType == "image/jpeg" ||
              blogImage.ContentType == "image/jpg" ||
              blogImage.ContentType == "image/png"))
                {
                    Guid guid = Guid.NewGuid();
                    string filename = $"blog_gazi{guid}.{blogImage.ContentType.Split('/')[1]}";
                    blogImage.SaveAs(Server.MapPath($"~/ImageBlog/{filename}"));
                    blogYazısı.Picture = filename;
                    db_blog.Picture = filename;
                }
                blogYazısıManager.Update(db_blog);
                return RedirectToAction("Index");
            }
            ViewBag.KategoriId = new SelectList(kategoriManager.List(), "Id", "Title", blogYazısı.KategoriId);
            return View(blogYazısı);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogYazısı blogYazısı = blogYazısıManager.Find(x => x.Id == id);
            if (blogYazısı == null)
            {
                return HttpNotFound();
            }
            return View(blogYazısı);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogYazısı blogYazısı = blogYazısıManager.Find(x => x.Id == id);
            if (blogYazısı.Picture != null)
            {
                System.IO.File.Delete(Server.MapPath($"~/ImageBlog/{blogYazısı.Picture}")); // klasörden fotoğraf silme
            }
            blogYazısıManager.Delete(blogYazısı);
            return RedirectToAction("Index");
        }
    }
}
