using DiyetisyenGultenManav.DataAccessLayer.EntityFramework;
using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
/* 
namespace DiyetisyenGultenManav.BusinessLayer
{
    public class test
    {
        Repository<Kullanıcı> repo_user = new Repository<Kullanıcı>();
        Repository<Kategori> repo_kategori= new Repository<Kategori>();
        Repository<Yorum> repo_yorum= new Repository<Yorum>();
        Repository<BlogYazısı> repo_blog = new Repository<BlogYazısı>();
        Repository<Diet> repo_diet= new Repository<Diet>();

        public test()
        {
         //   DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
           //  db.Kategoriler.ToList(); 
// repo.List(x => x.Id > 5 );
List<Kategori> kategoriler =  repo_kategori.List();
            List<Kategori> kategorilerFiltre =  repo_kategori.List(x => x.Id > 5);
        }
        public void InsertTest()
        {
            int result = repo_user.Insert(new Kullanıcı()
            {
                Name = "aaa",
                Surname = "bbb",
                Email = "aaabbb@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                IsNormal = false,
                IsOnline = false,
                IsPayOnline = false,
                Username = "aaabbb",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "gazihandemir"
            });
        }
        public void UpdateTest()
        {
            Kullanıcı user = repo_user.Find(x => x.Username == "aaabbb");
            if(user != null)
            {
                user.Username = "xxx";
              int result =   repo_user.Update(user);
            }
        }
        public void DeleteTest()
        {
            Kullanıcı user = repo_user.Find(x => x.Username == "xxx");
            if(user != null)
            {
               int result =  repo_user.Delete(user);
            }
        }

        public void YorumTest()
        {
            Kullanıcı user =  repo_user.Find(x => x.Id == 1);
            BlogYazısı blogYazısı = repo_blog.Find(x => x.Id == 3);

            Yorum yorum = new Yorum()
            {
                Text= "bu bir testtir",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "gazihandemir",
                BlogYazısı = null,
                Owner = null
            };
            repo_yorum.Insert(yorum);
        } 
    }
}
*/
