using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.DataAccessLayer
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Kullanıcı gazi = new Kullanıcı()
            {
                Name = "gazi",
                Surname = "demir",
                Email = "gazihand@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                IsNormal = false,
                IsOnline = false,
                IsPayOnline = false,
                Username = "gazihandemir",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "gazihandemir"
            };
            Kullanıcı gulten = new Kullanıcı()
            {
                Name = "gulten",
                Surname = "manav",
                Email = "gultenmanav@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                IsNormal = false,
                IsOnline = false,
                IsPayOnline = false,
                Username = "gultenmanav",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "gazihandemir"
            };
            context.Kullanıcılar.Add(gazi);
            context.Kullanıcılar.Add(gulten);
            context.SaveChanges();

            // FakeDate ile kategori ekleme
            for (int i = 0; i < 10; i++)
            {
                Kategori kat = new Kategori()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "gazihandemir"
                };
                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    BlogYazısı blogYazısı = new BlogYazısı()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1,3)),
                        Kategori = kat,
                        IsDraft = false,
                        Owner = (k % 2 == 0) ? gazi : gulten,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now.AddYears(+1)),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now.AddYears(+1)),
                        ModifiedUsername = (k % 2 == 0) ? gazi.Username : gulten.Username,

                    };
                    kat.BlogYazıları.Add(blogYazısı);
                }

            }


        }
    }
}
