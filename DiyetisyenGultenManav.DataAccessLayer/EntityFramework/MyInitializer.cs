﻿using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.DataAccessLayer.EntityFramework
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
                ProfileImageFileName = "user.png",
                Password = "123",
                DogumTarihi = "20.03.1997",
                TelefonNumarası = "05539238334",
                Boy = "1.81",
                Kilo = "85",
                Meslek = "bilgisayar mühendisi",
                Sehir = "adana",
                Hastalik = "hastaik",
                Tahlil = "tahlil",
                Hikaye = "hikaye",
                Anammez = "anammez",
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
                ProfileImageFileName = "user.png",
                Password = "123",
                DogumTarihi = "28.02.1997",
                TelefonNumarası = "05539238334",
                Boy = "1.65",
                Kilo = "60",
                Meslek = "diyetisyen",
                Sehir = "adana",
                Hastalik = "hastaik",
                Tahlil = "tahlil",
                Hikaye = "hikaye",
                Anammez = "anammez",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "gazihandemir"
            };
            // diet eklemek
            Diet gazininDieti = new Diet()
            {
                Title = "diyet1",
                Description = "3 günlük diyet",
                DiyetSabah = "sabah",
                DiyetAraBir = "ara bir",
                DiyetOglen = "öglen",
                DiyetAraIki = "iki",
                DiyetAksam = "aksam",
                DiyetGece = "gece",
                IsNew = true,
                DiyetOlcum = "olcum",
                DiyetKilo = "50",
                DiyetBmi = "35",
                DiyetFat = "48",
                DiyetMusc = "23",
                DiyetBmh = "1500",
                DiyetVf = "9",
                DiyetEkAciklamalar = "ek",
                DiyetBaslangic = DateTime.Now,
                DiyetBitis = DateTime.Now.AddDays(3),
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            Diet gulteninDieti = new Diet()
            {
                Title = "diyet2",
                Description = "3 günlük diyet",
                DiyetSabah = "sabah",
                DiyetAraBir = "ara bir",
                DiyetOglen = "öglen",
                DiyetAraIki = "iki",
                DiyetAksam = "aksam",
                DiyetGece = "gece",
                IsNew = true,
                DiyetOlcum = "olcum",
                DiyetKilo = "50",
                DiyetBmi = "35",
                DiyetFat = "48",
                DiyetMusc = "23",
                DiyetBmh = "1500",
                DiyetVf = "9",
                DiyetEkAciklamalar = "ek",
                DiyetBaslangic = DateTime.Now,
                DiyetBitis = DateTime.Now.AddDays(3),
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            Paket paket = new Paket()
            {
                Isim = "Minnoşlar Paketi",
                Fiyat = "150",
                Süresi = "1 Aylık",
                OzellikBirRed = "1 ay",
                OzellikBir = "detoks programı",
                OzellikIkiRed = "1 - 3 kilo",
                OzellikIki = "arası hedef",
                OzellikUcRed = "motivasyon",
                OzellikUc = "Günlük wp görüşmesi",
                Renk = "red",
                RenkButton = "btn-outline-danger",
                Aciklama = "Kendini her pazartesi diyete başlayacağım deyip akşam diyeti bırakırken mi buluyorsun? Hadi gel birlikte hedefimize doğru ilerleyelim ve seni bu döngüden kurtaralım. ",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            PaketTalebi paketTalebi = new PaketTalebi()
            {
                IsimSoyisim = "1",
                TelefonNo = "1",
                Program = paket,
                EkAciklamalar = "aciklama",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"

            };
            paket.PaketTalepleri.Add(paketTalebi);
            Contact contact = new Contact()
            {
                IsimSoyisim = "isim soyisim",
                TelefonNumarasi = "05539232123",
                Email = "eposta@gmail.com",
                Konu = "konu",
                Mesaj = "mesaj",
                Zaman = DateTime.Now,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            OdemeBildirimi odemeBildirimi = new OdemeBildirimi()
            {
                IsimSoyisim = "1",
                BankaIsmi = "1",
                YatirilanMiktar = "1",
                TelefonNo = "1",
                EkAciklamalar = "1",
                IsNotification = false,
                IsPay = false,
                IsOkey = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            OdemeBildirimi odemeBildirimi2 = new OdemeBildirimi()
            {
                IsimSoyisim = "1",
                BankaIsmi = "1",
                YatirilanMiktar = "1",
                TelefonNo = "1",
                EkAciklamalar = "1",
                IsNotification = false,
                IsPay = false,
                IsOkey = false,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            Kahve kahve = new Kahve()
            {
                // BİR
                ArkaPlanRengi = "transparent",
                Ikon = "fa-coffee",
                IkonRengi = "black",
                IkonBoyutu = "100",
                Sayi = "360",
                SayiRengi = "orange",
                SayiBoyutu = "50",
                Yazi = "içilen kahve",
                YaziRengi = "grey",
                YaziBoyutu = "30",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(10),
                ModifiedUsername = "gazihandemir"
            };
            context.Kahve.Add(kahve);
            context.Kullanıcılar.Add(gazi);
            context.Kullanıcılar.Add(gulten);
            context.Paketler.Add(paket);
            context.PaketTalepleri.Add(paketTalebi);
            context.Contactlar.Add(contact);

            gazi.Dietler.Add(gazininDieti);
            gulten.Dietler.Add(gulteninDieti);
            gazi.OdemeBildirimi.Add(odemeBildirimi);
            gulten.OdemeBildirimi.Add(odemeBildirimi2);
            context.SaveChanges();
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
                    ProfileImageFileName = "user.png",
                    Username = $"user{i}",
                    Password = "123",
                    DogumTarihi = FakeData.DateTimeData.GetDatetime().ToString(),
                    TelefonNumarası = FakeData.PhoneNumberData.GetPhoneNumber(),
                    Boy = FakeData.NumberData.GetNumber((150), (180)).ToString(),
                    Kilo = FakeData.NumberData.GetNumber(50, 130).ToString(),
                    Meslek = FakeData.TextData.GetSentence(),
                    Sehir = FakeData.PlaceData.GetCity(),
                    Hastalik = "hastaik",
                    Tahlil = "tahlil",
                    Hikaye = "hikaye",
                    Anammez = "anammez",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(5),
                    ModifiedUsername = $"user{i}"
                };
                Diet diet = new Diet()
                {
                    Title = $"diyet{i}",
                    Description = "3 günlük diyet",
                    DiyetSabah = "sabah",
                    DiyetAraBir = "ara bir",
                    DiyetOglen = "öglen",
                    DiyetAraIki = "iki",
                    DiyetAksam = "aksam",
                    DiyetGece = "gece",
                    IsNew = true,
                    DiyetOlcum = "olcum",
                    DiyetKilo = "50",
                    DiyetBmi = "35",
                    DiyetFat = "48",
                    DiyetMusc = "23",
                    DiyetBmh = "1500",
                    DiyetVf = "9",
                    DiyetEkAciklamalar = "ek",
                    DiyetBaslangic = DateTime.Now,
                    DiyetBitis = DateTime.Now.AddDays(3),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(10),
                    ModifiedUsername = "gazihandemir"
                };
                OdemeBildirimi odemeBildirimiUsers = new OdemeBildirimi()
                {
                    IsimSoyisim = $"user{i}",
                    BankaIsmi = $"user{i}",
                    YatirilanMiktar = $"user{i}",
                    TelefonNo = $"user{i}",
                    EkAciklamalar = $"user{i}",
                    IsNotification = false,
                    IsPay = false,
                    IsOkey = false,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now.AddMinutes(10),
                    ModifiedUsername = "gazihandemir"
                };
                context.Kullanıcılar.Add(user);
                user.Dietler.Add(diet);
                user.OdemeBildirimi.Add(odemeBildirimiUsers);
            }
            context.SaveChanges();
            List<Kullanıcı> kullanıcıList = context.Kullanıcılar.ToList();
            // FakeData ile kategori ekleme
            for (int i = 0; i < 10; i++)
            {
                Kategori kat = new Kategori()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    Icon = "list",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = "gazihandemir"
                };
                context.Kategoriler.Add(kat);
                // FakeData ile blogyazısı eklemek
                for (int k = 0; k < FakeData.NumberData.GetNumber(2, 3); k++)
                {
                    Kullanıcı owner = kullanıcıList[FakeData.NumberData.GetNumber(0, kullanıcıList.Count - 1)];
                    BlogYazısı blogYazısı = new BlogYazısı()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        ParagrafBir = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        ParagrafIki = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        ParagrafUc = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        ParagrafDort = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        ParagrafBes = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        ParagrafAlti = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        ParagrafYedi = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        ParagrafSekiz = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        Kategori = kat,
                        IsDraft = false,
                        DanisanPaylasimi = false,
                        TabakPaylasimi = false,
                        Owner = owner,
                        Picture = "user.jpg",
                        GörüntülenmeSayisi = FakeData.NumberData.GetNumber(1, 9),
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                        ModifiedUsername = owner.Username
                    };
                    // kategorinin blog yazızına kendi oluşturdugumuz blogyazısını eklemek...
                    kat.BlogYazıları.Add(blogYazısı);

                    // FakeData ile Yorumları eklemek
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        Yorum yorum = new Yorum()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            Owner = owner,
                            CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(+1)),
                            ModifiedUsername = owner.Username
                        };
                        // Blog yazısına fake data ile yorum eklemek
                        blogYazısı.Yorumlar.Add(yorum);
                    }
                }
            }
            context.SaveChanges();
        }
    }
}
