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
using DiyetisyenGultenManav.WebApp.Models;
using DiyetisyenGultenManav.WebApp.ViewModels;
namespace DiyetisyenGultenManav.WebApp.Controllers
{
    [Auth]
    [Exc]

    public class DietController : Controller
    {
        DietManager dietManager = new DietManager();
        KullanıcıManager kullanıcıManager = new KullanıcıManager();
        [AuthAdmin]
        public ActionResult AllDiet(string Ara)
        {
            if (Ara != null)
            {
                return View(dietManager.ListQueryable().Where(x => x.Owner.Username.Contains(Ara) || Ara == null).OrderBy(x => x.DiyetBitis));
            }
            else
            {
                return View(dietManager.List().OrderBy(x => x.DiyetBitis));
            }
        }
        [AuthAdmin]
        public ActionResult NewDiet(string Ara)
        {
            var diet = dietManager.ListQueryable().Where(x => x.IsNew == true).OrderBy(x => x.DiyetBitis);
            var AraDiet = dietManager.ListQueryable().Where(x => x.IsNew == true && x.Owner.Username.Contains(Ara) || Ara == null).OrderBy(x => x.DiyetBitis);
            if (Ara != null)
            {
                return View(AraDiet.ToList());
            }
            else
            {
                return View(diet.ToList());
            }
            
        }
        public ActionResult Index()
        {
            var diet = dietManager.ListQueryable().Include("Owner").
                Where(x => x.Owner.Id == CurrentSession.User.Id && x.IsNew == true).OrderByDescending(x => x.ModifiedOn);
            //string satirText = db_diet.Text.ToString();
            //Console.WriteLine(satirText);
            if (diet != null)
            {
                return View(diet.ToList());
            }
            else
            {
                return View();
            }
        }
        [AuthAdmin]
        public ActionResult Details(int id)
        {
            //Diet diet = dietManager.Find(x => x.Id == id);
            BusinessLayerResult<Diet> res = dietManager.GetDietById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Diyet Detayı Bulunamadı",
                    RedirectingUrl = "/Diet/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
           /* if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (diet == null)
            {
                return HttpNotFound();
            }*/
        }
        [AuthAdmin]
        public ActionResult Create()
        {
            ViewBag.KullanıcıId = new SelectList(kullanıcıManager.List(), "Id", "Username");
            return View();
        }
        [HttpPost]
        [AuthAdmin]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Diet diet)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                //dietManager.Insert(diet);
                BusinessLayerResult<Diet> res = dietManager.CreateDiet(diet);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Diet Oluşturulamadı.",
                        RedirectingUrl = "/Diet/AllIndex"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("AllDiet");
            }
            ViewBag.KullanıcıId = new SelectList(kullanıcıManager.List(), "Id", "Username");
            //         diet.Owner = ViewBag.KullanıcıId;
            //string gazihan = diet.Owner.Username.ToString();
            return View(diet);
        }
        [AuthAdmin]
        public ActionResult Edit(int? id)
        {
            //Diet diet = dietManager.Find(x => x.Id == id);

            BusinessLayerResult<Diet> res = dietManager.GetDietById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Blog Yazısı Bulunamadı",
                    RedirectingUrl = "/BlogYazısı/Index"
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
            /*       if (id == null)
          {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          if (diet == null)
          {
              return HttpNotFound();
          }
   */
        }
        [AuthAdmin]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Diet diet)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                /*        Diet db_diet = dietManager.Find(x => x.Id == diet.Id);
                    db_diet.Title = diet.Title;
                      db_diet.DiyetSabah = diet.DiyetSabah;
                      db_diet.DiyetAraBir = diet.DiyetAraBir;
                      db_diet.DiyetOglen = diet.DiyetOglen;
                      db_diet.DiyetAraIki = diet.DiyetAraIki;
                      db_diet.DiyetAksam = diet.DiyetAksam;
                      db_diet.DiyetGece = diet.DiyetGece;
                      db_diet.Description = diet.Description;
                      db_diet.DiyetKilo = diet.DiyetKilo;
                      db_diet.DiyetBmi = diet.DiyetBmi;
                      db_diet.DiyetFat = diet.DiyetFat;
                      db_diet.DiyetMusc = diet.DiyetMusc;
                      db_diet.DiyetBmh = diet.DiyetBmh;
                      db_diet.DiyetVf = diet.DiyetVf;
                      db_diet.DiyetOlcum = diet.DiyetOlcum;
                      db_diet.DiyetBaslangic = diet.DiyetBaslangic;
                      db_diet.DiyetBitis = diet.DiyetBitis;
                      db_diet.DiyetEkAciklamalar = diet.DiyetEkAciklamalar;
                      db_diet.IsNew = diet.IsNew;
              
                dietManager.Update(db_diet);  */
                BusinessLayerResult<Diet> res = dietManager.UpdateDiet(diet);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Diyet Güncellenemedi",
                        RedirectingUrl = "/Diet/AllDiet"
                    };
                    return View("Error", ErrNotifyObj);
                }
                return RedirectToAction("AllDiet");
            }
            return View();
        }
        [AuthAdmin]
        public ActionResult Delete(int? id)
        {
            //Diet diet = dietManager.Find(x => x.Id == id);
            BusinessLayerResult<Diet> res = dietManager.GetDietById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Diet Bulunamadı",
                    RedirectingUrl = "/Diet/Index",
                    IsRedirecting = true,
                    RedirectingTimeout = 1000
                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
            /*       if (id == null)
       {
           return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
       }
       if (diet == null)
       {
           return HttpNotFound();
       }
*/
        }
        [AuthAdmin]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diet diet = dietManager.Find(x => x.Id == id);
            BusinessLayerResult<Diet> res = dietManager.GetRemoveById(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Diet silinemedi.",
                    RedirectingUrl = "/Diet/Index",
                    IsRedirecting = true,
                    RedirectingTimeout = 1000
                };
                return View("Error", ErrNotifyObj);
            }
            //dietManager.Delete(diet);
            return RedirectToAction("AllDiet");
        }
    }
}
