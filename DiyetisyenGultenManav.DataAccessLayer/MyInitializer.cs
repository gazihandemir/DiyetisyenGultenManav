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
            // Admin kullanıcı ekleme
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
            // normal kullanıcı eklemek
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
            // Kullanıcılar fakedata ile diet yazmak
            for (int i = 0; i < 8; i++)
            {
                Kullanıcı user = new Kullanıcı()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsActive = true,
                    IsAdmin = false,
                    IsNormal = false,
                    IsOnline = false,
                    IsPayOnline = false,
                    Username = $"user{i}",
                    Password = "123",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = $"user{i}"
                };
                Diet diet = new Diet()
                {
                    Title = $"diyet{i}",
                    Description = "3 günlük diyet",
                    Text = $"sabah {i} ekmek öglen {i} ekmek akşam {i} ekmek",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(10),
                    ModifiedUsername = "gazihandemir"
                };
                context.Kullanıcılar.Add(user);
                user.Dietler.Add(diet);
            }
           
            context.SaveChanges();


            // diet eklemek
            Diet gazininDieti = new Diet()
            {
                Title = "diyet1",
                Description = "3 günlük diyet",
                Text = "sabah 1 ekmek öglen 2 ekmek akşam 3 ekmek",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            Diet gulteninDieti = new Diet()
            {
                Title = "diyet2",
                Description = "3 günlük diyet",
                Text = "sabah 1 ekmek öglen 2 ekmek akşam 3 ekmek",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            gazi.Dietler.Add(gazininDieti);
            gulten.Dietler.Add(gulteninDieti);

            // FakeData ile kategori ekleme
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
                // FakeData ile blogyazısı eklemek
                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 9); k++)
                {
                    BlogYazısı blogYazısı = new BlogYazısı()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        Kategori = kat,
                        IsDraft = false,
                        Owner = (k % 2 == 0) ? gazi : gulten,
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                        ModifiedUsername = (k % 2 == 0) ? gazi.Username : gulten.Username,

                    };
                    // kategorinin blog yazızına kendi oluşturdugumuz blogyazısını eklemek...
                    kat.BlogYazıları.Add(blogYazısı);
                    // FakeData ile Yorumları eklemek
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        Yorum yorum = new Yorum()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = (k % 2 == 0) ? gazi : gulten,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                            ModifiedUsername = (j % 2 == 0) ? gazi.Username : gulten.Username,
                        };
                        // Blog yazısına fake data ile yorum eklemek
                        blogYazısı.Yorumlar.Add(yorum);
                    }
                }

            }


        }
    }
}
