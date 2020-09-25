using DiyetisyenGultenManav.DataAccessLayer.EntityFramework;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{

    public class KullanıcıManager
    {
        private Repository<Kullanıcı> repo_user = new Repository<Kullanıcı>();
        public BusinessLayerResult<Kullanıcı> RegisterUser(RegisterViewModel data)
        {
            // Kullanıcı username kontrolü
            // Kullanıcı e-posta kontrolü
            // Kayıt işlemi
            // Aktivasyon e-postası gönderimi

            Kullanıcı user = repo_user.Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();

            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    res.Errors.Add("Kullanıcı adı kayıtlı.");
                }
                if (user.Email == data.Email)
                {
                    res.Errors.Add("E-posta adresi kayıtlı.");
                }
            }
            else
            {
                int dbResult = repo_user.Insert(new Kullanıcı()
                {
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = false,
                    IsAdmin = false,
                    IsOnline = false,
                    IsPayOnline = false,

                });
                if (dbResult > 0)
                {
                    res.Result = repo_user.Find(x => x.Email == data.Email && x.Username == data.Username);

                }
            }
            return res;
        }
        public BusinessLayerResult<Kullanıcı> LoginUser(LoginViewModel data)
        {
            // Giriş kontrolü
            // Hesap aktive edilmiş mi ?

            BusinessLayerResult<Kullanıcı> res = new BusinessLayerResult<Kullanıcı>();
            res.Result = repo_user.Find(x => x.Username == data.Username && x.Password == data.Password);

            if (res.Result != null)
            {
                if (!res.Result.IsActive)
                {
                    res.Errors.Add("Kullanıcı aktifleştirilmemiştir. Lütfen e-posta adresinizi kontrol ediniz.");
                }


            }
            else
            {
                res.Errors.Add("Kullanıcı adı yada şifre uyuşmuyor.");
            }
        }

    }
}
