using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.BusinessLayer.Results;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.Messages;
using DiyetisyenGultenManav.Entities.ValueObjects;
using DiyetisyenGultenManav.WebApp.Filters;
using DiyetisyenGultenManav.WebApp.Models;
using DiyetisyenGultenManav.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiyetisyenGultenManav.WebApp.Controllers
{
    [Exc]

    public class HomeController : Controller
    {
        private BlogYazısıManager blogYazısıManager = new BlogYazısıManager();
        private KategoriManager kategoriManager = new KategoriManager();
        private KullanıcıManager kullanıcıManager = new KullanıcıManager();
        private PaketManager paketManager = new PaketManager();
        private YorumManager yorumManager = new YorumManager();
        private KahveManager kahveManager = new KahveManager();
        private HomeViewModel HomeModel = new HomeViewModel();
        private BlogDetailViewModel BlogDetailModel = new BlogDetailViewModel();

        [HttpGet]
        public ActionResult BlogYazisiDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            BlogYazısı blogYazısı = blogYazısıManager.Find(x => x.Id == id);
            blogYazısı.GörüntülenmeSayisi++;
            blogYazısıManager.UpdateGörüntülenme(blogYazısı);
            BlogDetailModel.BlogYazısı = blogYazısı;
            BlogDetailModel.Yorum = blogYazısı.Yorumlar;

            if (blogYazısı == null)
            {
                return HttpNotFound();
            }
            return View(BlogDetailModel);
        }
        [HttpPost]
        public ActionResult BlogYazisiDetails(int id, FormCollection frm)
        {
            string yorumtxt = Convert.ToString(frm["yorumtxt"].ToString());

            BlogYazısı blogYazısı = blogYazısıManager.Find(x => x.Id == id);
            Yorum yorum = new Yorum();
            yorum.Text = yorumtxt;
            yorum.BlogYazısı = blogYazısı;
            yorum.Owner = CurrentSession.User;
            blogYazısı.Yorumlar.Add(yorum);
            BlogDetailModel.BlogYazısı = blogYazısı;
            BlogDetailModel.Yorum = blogYazısı.Yorumlar;
            return View(BlogDetailModel);
        }
        public ActionResult About()
        {
            return View();
        }
        // GET: Home
        public ActionResult Index()
        {
            List<BlogYazısı> BlogYazilari = blogYazısıManager.ListQueryable().Where(x => x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList();
            List<Paket> Paketler = paketManager.List();
            List<Kategori> Kategoriler = kategoriManager.ListQueryable().OrderByDescending(x => x.ModifiedOn).ToList();
            List<Kahve> kahveler = kahveManager.ListQueryable().OrderBy(x => x.CreatedOn).ToList();
            HomeModel.BlogYazısı = BlogYazilari;
            HomeModel.Paket = Paketler;
            HomeModel.Kategoriler = Kategoriler;
            HomeModel.Kahveler = kahveler;
            return View(HomeModel);
        }
        public ActionResult Danisanlarim()
        {
            List<BlogYazısı> BlogYazilari = blogYazısıManager.ListQueryable().Where(x => x.DanisanPaylasimi == true && x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList();
            List<Paket> Paketler = paketManager.List();
            List<Kategori> Kategoriler = kategoriManager.ListQueryable().OrderByDescending(x => x.ModifiedOn).ToList();
            List<Kahve> kahveler = kahveManager.ListQueryable().OrderBy(x => x.CreatedOn).ToList();
            HomeModel.BlogYazısı = BlogYazilari;
            HomeModel.Paket = Paketler;
            HomeModel.Kategoriler = Kategoriler;
            HomeModel.Kahveler = kahveler;
            return View("Blog", HomeModel);
        }
        public ActionResult Tabaklar()
        {
            List<BlogYazısı> BlogYazilari = blogYazısıManager.ListQueryable().Where(x => x.TabakPaylasimi == true && x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList();
            List<Paket> Paketler = paketManager.List();
            List<Kategori> Kategoriler = kategoriManager.ListQueryable().OrderByDescending(x => x.ModifiedOn).ToList();
            List<Kahve> kahveler = kahveManager.ListQueryable().OrderBy(x => x.CreatedOn).ToList();
            HomeModel.BlogYazısı = BlogYazilari;
            HomeModel.Paket = Paketler;
            HomeModel.Kategoriler = Kategoriler;
            HomeModel.Kahveler = kahveler;
            return View("Blog", HomeModel);
        }
        public ActionResult Blog()
        {
            List<BlogYazısı> BlogYazilari = blogYazısıManager.ListQueryable().Where(x => x.DanisanPaylasimi == false && x.TabakPaylasimi == false && x.IsDraft == false).OrderByDescending(x => x.ModifiedOn).ToList();
            List<Paket> Paketler = paketManager.List();
            List<Kategori> Kategoriler = kategoriManager.ListQueryable().OrderByDescending(x => x.ModifiedOn).ToList();
            List<Kahve> kahveler = kahveManager.ListQueryable().OrderBy(x => x.CreatedOn).ToList();
            HomeModel.BlogYazısı = BlogYazilari;
            HomeModel.Paket = Paketler;
            HomeModel.Kategoriler = Kategoriler;
            HomeModel.Kahveler = kahveler;
            return View("Blog", HomeModel);
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
            List<Paket> Paketler = paketManager.List();
            List<Kategori> Kategoriler = kategoriManager.ListQueryable().OrderByDescending(x => x.ModifiedOn).ToList();
            List<Kahve> kahveler = kahveManager.ListQueryable().OrderBy(x => x.CreatedOn).ToList();
            HomeModel.BlogYazısı = kate.BlogYazıları;
            HomeModel.Paket = Paketler;
            HomeModel.Kategoriler = Kategoriler;
            HomeModel.Kahveler = kahveler;
            return View("Index", HomeModel);

            //return View("Index", kate.HomeViewModel.BlogYazısı.OrderByDescending(x => x.ModifiedOn).ToList());

        }
        [Auth]
        public ActionResult ShowProfile()
        {
            //Kullanıcı currentUser = Session["login"] as Kullanıcı;
            BusinessLayerResult<Kullanıcı> res = kullanıcıManager.GetUserById(/*currentUser*/CurrentSession.User.Id);
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
        [Auth]
        public ActionResult EditProfile()
        {
            //Kullanıcı currentUser = Session["login"] as Kullanıcı;
            BusinessLayerResult<Kullanıcı> res = kullanıcıManager.GetUserById(/*currentUser*/CurrentSession.User.Id);
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
        [Auth]
        [HttpPost]
        public ActionResult EditProfile(Kullanıcı model, HttpPostedFileBase ProfileImage)
        {
            ModelState.Remove("CreatedOn");
            ModelState.Remove("ModifiedOn");
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("ProfileImageFileName");

            ModelState.Remove("Hastalik");
            ModelState.Remove("Tahlil");
            ModelState.Remove("Hikaye");
            ModelState.Remove("Anammez");
            if (ModelState.IsValid)
            {
                if (ProfileImage != null && (
               ProfileImage.ContentType == "image/jpeg" ||
               ProfileImage.ContentType == "image/jpg" ||
               ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{model.Id}.{ProfileImage.ContentType.Split('/')[1]}";
                    ProfileImage.SaveAs(Server.MapPath($"~/ImageProfil/{filename}"));
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
                //Session["login"] = res.Result;
                CurrentSession.Set<Kullanıcı>("login", res.Result);
                return RedirectToAction("ShowProfile");
            }
            return View();
        }
        //public ActionResult RemoveProfile()
        //{
        //    //Kullanıcı currentUser = Session["login"] as Kullanıcı;
        //    BusinessLayerResult<Kullanıcı> res = kullanıcıManager.RemoveUserById(/*currentUser*/CurrentSession.User.Id);
        //    if (res.Errors.Count > 0)
        //    {
        //        ErrorViewModel ErrNotifyObj = new ErrorViewModel()
        //        {
        //            Items = res.Errors,
        //            Title = "Profil Silinemedi",
        //            RedirectingUrl = "/Home/ShowProfile"
        //        };
        //        return View("Error", ErrNotifyObj);
        //    }
        //    Session.Clear();
        //    return RedirectToAction("Index");
        //}
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
                //Session["login"] = res.Result;   // session'a kullanıcı bilgi saklama
                CurrentSession.Set<Kullanıcı>("login", res.Result);
                return RedirectToAction("Index"); // Yönlendirme
            }
            return View(model);
        }
        public ActionResult AccessDenied()
        {
            return View();
        }
        public ActionResult HasError()
        {
            return View();
        }
        //public ActionResult Register()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        BusinessLayerResult<Kullanıcı> res = kullanıcıManager.RegisterUser(model);
        //        if (res.Errors.Count > 0)
        //        {
        //            res.Errors.ForEach(x => ModelState.AddModelError(" ", x.Message));
        //            return View(model);
        //        }
        //        OkViewModel notifyObj = new OkViewModel()
        //        {
        //            Header = "Yönlendirliyorsunuz..",
        //            Title = "Kayıt Başarılı",
        //            RedirectingUrl = "/Home/Login",
        //        };
        //        notifyObj.Items.Add("Lütfen e-posta adresinize gönderdiğimiz aktivasyon link'ine tıklayarak hesabınızı aktive ediniz." +
        //            "Hesabınızı aktive etmeden sitemizden yararlanamazsınız !");
        //        return View("Ok", notifyObj);
        //    }
        //    return View(model);
        //    /*   if (ModelState.IsValid)
        //    {
        //          if (model.Username == "aaa")
        //          {
        //              ModelState.AddModelError("", "Kullanıcı Adı kullanılıyor");
        //          }
        //          if (model.Email == "aaa@aa.com")
        //          {
        //              ModelState.AddModelError("", "e-posta adresi  kullanılıyor");
        //          }
        //      }
        //     foreach (var item in ModelState)
        //      {
        //          if (item.Value.Errors.Count > 0)
        //          {
        //              return View(model);
        //          }
        //      }
        //  */
        //}
        //public ActionResult UserActivate(Guid id)
        //{
        //    BusinessLayerResult<Kullanıcı> res = kullanıcıManager.ActivateUser(id);
        //    if (res.Errors.Count > 0)
        //    {
        //        ErrorViewModel ErrNotifyObj = new ErrorViewModel()
        //        {
        //            Title = "Geçersiz İşlem",
        //            RedirectingUrl = "/Home/Index",
        //            Items = res.Errors

        //        };
        //        return View("Error", ErrNotifyObj);
        //        //TempData["errors"] = res.Errors;
        //    }
        //    OkViewModel OkNotifyObj = new OkViewModel()
        //    {
        //        Title = "Hesap Aktifleştirildi ! ",
        //        RedirectingUrl = "/Home/Login"
        //    };
        //    OkNotifyObj.Items.Add("Hesabınız aktifleştirildi. Artık Sitemizden Faydalanabilirsiniz.");
        //    return View("Ok", OkNotifyObj);
        //}
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