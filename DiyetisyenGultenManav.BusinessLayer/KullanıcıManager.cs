using DiyetisyenGultenManav.DataAccessLayer.EntityFramework;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.ValueObjects;
using DiyetisyenGultenManav.Entities.Messages;
using System;
using DiyetisyenGultenManav.Common.Helpers;
using DiyetisyenGultenManav.BusinessLayer.Results;
using DiyetisyenGultenManav.BusinessLayer.Abstract;

namespace DiyetisyenGultenManav.BusinessLayer
{

    public class KullanıcıManager : ManagerBase<Kullanıcı>
    {
      //  private Repository<Kullanıcı> repo_user = new Repository<Kullanıcı>(); Managerbaseden gelen metotları kullanıyoruz.
        public BusinessLayerResult<Kullanıcı> RegisterUser(RegisterViewModel data)
        {
            // Kullanıcı username kontrolü
            // Kullanıcı e-posta kontrolü
            // Kayıt işlemi
            // Aktivasyon e-postası gönderimi

            Kullanıcı user = Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı zaten kayıtlı.");
                }
                if (user.Email == data.Email)
                {
                    //res.Errors.Add("E-posta adresi kayıtlı.");
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi zaten kayıtlı.");
                }
            }
            else
            {
                int dbResult =Insert(new Kullanıcı()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    ProfileImageFileName = "user.png",
                    IsActive = false,
                    IsAdmin = false,
                    IsOnline = false,
                    IsPayOnline = false,

                });
                if (dbResult > 0)
                {
                    res.Result = Find(x => x.Email == data.Email && x.Username == data.Username);
                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activateUri = $"{siteUri}/Home/UserActivate/{res.Result.ActivateGuid}";
                    string body = $"Merhaba {res.Result.Username} Hesabınızı aktifleştirmek için <a href='{activateUri}' target='_blank'>tıklayınız</a>.";
                    string subject = "Aktivasyon";
                    MailHelper.SendMail(body, res.Result.Email, subject, true);
                }
            }
            return res;
        }

        public BusinessLayerResult<Kullanıcı> LoginUser(LoginViewModel data)
        {
            // Giriş kontrolü
            // Hesap aktive edilmiş mi ?

            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();
            res.Result =Find(x => x.Username == data.Username && x.Password == data.Password);

            if (res.Result != null)
            {
                if (!res.Result.IsActive)
                {
                    res.AddError(ErrorMessageCode.UserIsNotActive, "Kullanıcı aktifleştirilmemiştir.");
                    res.AddError(ErrorMessageCode.CheckYourEmail, "Lütfen e - posta adresinizi kontrol ediniz.");
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı yada şifre uyuşmuyor.");
            }
            return res;
        }



        public BusinessLayerResult<Kullanıcı> ActivateUser(Guid id)
        {
            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();
            Kullanıcı user =Find(x => x.ActivateGuid == id);
            if (res.Result != null)
            {
                if (res.Result.IsActive)
                {
                    res.AddError(ErrorMessageCode.UserAlreadyActive, "Kullanıcı Zaten aktif edilmiştir.");
                    return res;
                }
                res.Result.IsActive = true;
                Update(res.Result);
            }
            else
            {
                res.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirilecek kullanıcı bulunamadı");
            }
            return res;
        }

        public BusinessLayerResult<Kullanıcı> RemoveUserById(int id)
        {
            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();
            Kullanıcı user = Find(x => x.Id == id);
            if (user != null)
            {
                if (Delete(user) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı Silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UserIsNotFound, "Kullanıcı bulunamadı.");
            }
            return res;
        }

        public BusinessLayerResult<Kullanıcı> GetUserById(int id)
        {
            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();
            res.Result =Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.UserIsNotFound, "Kullanıcı bulunamadı.");
            }
            return res;
        }
        public BusinessLayerResult<Kullanıcı> UpdateProfile(Kullanıcı data)
        {
            Kullanıcı db_user =Find(x => x.Id != data.Id && (x.Username == data.Username || x.Email == data.Email));
            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();
            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Username == data.Username)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı kayıtlı.");
                }
                if (db_user.Email == data.Email)
                {
                    res.AddError(ErrorMessageCode.EmailAlreadyExists, "E-posta adresi kayıtlı");
                }
                return res;
            }

            res.Result =Find(x => x.Id == data.Id);
            res.Result.Email = data.Email;
            res.Result.Name = data.Name;
            res.Result.Surname = data.Surname;
            res.Result.Password = data.Password;
            res.Result.Username = data.Username;
            res.Result.TelefonNumarası = data.TelefonNumarası;
            res.Result.DogumTarihi = data.DogumTarihi;
            res.Result.Boy = data.Boy;
            res.Result.Kilo = data.Kilo;
            res.Result.Yas = data.Yas;
            res.Result.Meslek = data.Meslek;
            res.Result.Sehir = data.Sehir;
            if (string.IsNullOrEmpty(data.ProfileImageFileName) == false)
            {
                res.Result.ProfileImageFileName = data.ProfileImageFileName;
            }
            if (Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdated, "Profil Güncellenemedi.");
            }
            return res;
        }
    }
}
