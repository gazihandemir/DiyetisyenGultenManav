using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.BusinessLayer.Results;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.Messages;
using DiyetisyenGultenManav.Entities.ValueObjects;
using DiyetisyenGultenManav.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogYazısıManager blogYazısıManager = new BlogYazısıManager();
        private KategoriManager kategoriManager = new KategoriManager();
        private KullanıcıManager kullanıcıManager = new KullanıcıManager();
        // GET: Home
        public ActionResult Index()
        {
            return View(blogYazısıManager.ListQueryable().OrderByDescending(x => x.ModifiedOn).ToList());
        }
        public ActionResult ByKategori(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Kategori kate = kategoriManager.Find(x => x.Id == id.Value);
            if (kate == null)
            {
                return HttpNotFound();
            }
            return View("Index", kate.BlogYazıları.OrderByDescending(x => x.ModifiedOn).ToList());
        }
        public ActionResult ShowProfile()
        {
            Kullanıcı currentUser = Session["login"] as Kullanıcı;
            BusinessLayerResult<Kullanıcı> res = kullanıcıManager.GetUserById(currentUser.Id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    RedirectingUrl = "/Home/Index",
                    Items = res.Errors

                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);
        }
        public ActionResult EditProfile()
        {
            Kullanıcı currentUser = Session["login"] as Kullanıcı;
            BusinessLayerResult<Kullanıcı> res = kullanıcıManager.GetUserById(currentUser.Id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Title = "Hata Oluştu",
                    Items = res.Errors

                };
                return View("Error", ErrNotifyObj);
            }
            return View(res.Result);

        }
        [HttpPost]
        public ActionResult EditProfile(Kullanıcı model, HttpPostedFileBase ProfileImage)
        {
            ModelState.Remove("ModifiedUsername");
            if (ModelState.IsValid)
            {
                if (ProfileImage != null && (
               ProfileImage.ContentType == "image/jpeg" ||
               ProfileImage.ContentType == "image/jpg" ||
               ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{model.Id}.{ProfileImage.ContentType.Split('/')[1]}";
                    ProfileImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                    model.ProfileImageFileName = filename;
                }
                BusinessLayerResult<Kullanıcı> res = kullanıcıManager.UpdateProfile(model);
                if (res.Errors.Count > 0)
                {
                    ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                    {
                        Items = res.Errors,
                        Title = "Profil Güncellenemedi.",
                        RedirectingUrl = "/Home/EditProfile"
                    };
                    return View("Error", ErrNotifyObj);
                }
                Session["login"] = res.Result;
                return RedirectToAction("ShowProfile");
            }
            return View();
        }
        public ActionResult RemoveProfile()
        {
            Kullanıcı currentUser = Session["login"] as Kullanıcı;
            BusinessLayerResult<Kullanıcı> res = kullanıcıManager.RemoveUserById(currentUser.Id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Items = res.Errors,
                    Title = "Profil Silinemedi",
                    RedirectingUrl = "/Home/ShowProfile"
                };
                return View("Error", ErrNotifyObj);
            }
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanıcı> res = kullanıcıManager.LoginUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError(" ", x.Message));
                    if (res.Errors.Find(x => x.Code == ErrorMessageCode.UserIsNotActive) != null)
                    {
                        ViewBag.SetLink = "E-posta Gönder";
                    }

                    return View(model);
                }
                Session["login"] = res.Result;   // session'a kullanıcı bilgi saklama
                return RedirectToAction("Index"); // Yönlendirme
            }

            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                BusinessLayerResult<Kullanıcı> res = kullanıcıManager.RegisterUser(model);
                if (res.Errors.Count > 0)
                {
                    res.Errors.ForEach(x => ModelState.AddModelError(" ", x.Message));
                    return View(model);
                }
                OkViewModel notifyObj = new OkViewModel()
                {
                    Header = "Yönlendirliyorsunuz..",
                    Title = "Kayıt Başarılı",
                    RedirectingUrl = "/Home/Login",
                };
                notifyObj.Items.Add("Lütfen e-posta adresinize gönderdiğimiz aktivasyon link'ine tıklayarak hesabınızı aktive ediniz." +
                    "Hesabınızı aktive etmeden sitemizden yararlanamazsınız !");
                return View("Ok", notifyObj);
            }
            return View(model);


            /*   if (ModelState.IsValid)
            {
                  if (model.Username == "aaa")
                  {
                      ModelState.AddModelError("", "Kullanıcı Adı kullanılıyor");
                  }
                  if (model.Email == "aaa@aa.com")
                  {
                      ModelState.AddModelError("", "e-posta adresi  kullanılıyor");
                  }
              }
             foreach (var item in ModelState)
              {
                  if (item.Value.Errors.Count > 0)
                  {
                      return View(model);
                  }
              }
          */

        }

        public ActionResult UserActivate(Guid id)
        {
            BusinessLayerResult<Kullanıcı> res = kullanıcıManager.ActivateUser(id);
            if (res.Errors.Count > 0)
            {
                ErrorViewModel ErrNotifyObj = new ErrorViewModel()
                {
                    Title = "Geçersiz İşlem",
                    RedirectingUrl = "/Home/Index",
                    Items = res.Errors

                };
                return View("Error", ErrNotifyObj);
                //TempData["errors"] = res.Errors;
            }
            OkViewModel OkNotifyObj = new OkViewModel()
            {
                Title = "Hesap Aktifleştirildi ! ",
                RedirectingUrl = "/Home/Login"
            };
            OkNotifyObj.Items.Add("Hesabınız aktifleştirildi. Artık Sitemizden Faydalanabilirsiniz.");
            return View("Ok", OkNotifyObj);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        #region TestNotify
        /*  public ActionResult TestNotify()
        {
            /*   OkViewModel model = new OkViewModel()
            //InfoViewModel model = new InfoViewModel()
            //WarningViewModel model = new WarningViewModel()
               {
                   Header = "Yönlendirme",
                   Title="ok test",
                   RedirectingTimeout=3000,
                   Items=new List<string>() { "test basarılı 1","test basarılı 2"}
               }; (*)/
        ErrorViewModel model = new ErrorViewModel()
            {
                Header = "Yönlendirme",
                Title = "error test",
                RedirectingTimeout = 3000,
                Items = new List<ErrorMessageObj>() { 
                  new ErrorMessageObj() { Message="test 1 başarılı"},
                  new ErrorMessageObj() { Message="test 2 başarılı"}
               }
            };
            return View("Error",model);
        }
    */
        #endregion
    }
}