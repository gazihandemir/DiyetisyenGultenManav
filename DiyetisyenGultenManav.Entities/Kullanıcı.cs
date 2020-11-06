using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Kullanıcılar")]
    public class Kullanıcı : EntityBase
    {
        [DisplayName("İsim"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }
        [DisplayName("Soy İsim"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }
        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Username { get; set; }
        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }
        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }
        [DisplayName("Profil Fotoğrafı"), StringLength(30), ScaffoldColumn(false)] // images/user_12.jpg
        public string ProfileImageFileName { get; set; }

        [DisplayName("Doğum Tarihiniz"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
                StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DogumTarihi { get; set; }

        [DisplayName("Cep Telefonu"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string TelefonNumarası { get; set; }
        [DisplayName("Boyunuz"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Boy { get; set; }
        [DisplayName("Kilonuz"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Kilo { get; set; }
        [DisplayName("Mesleğiniz"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Meslek { get; set; }
        [DisplayName("Şehir"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Sehir { get; set; }
        [DisplayName("Hastalık"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Hastalik { get; set; }
        [DisplayName("Tahlil"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(255, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Tahlil { get; set; }
        [DisplayName("Hikaye"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(1000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Hikaye { get; set; }
        [DisplayName("Anammez"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(500, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Anammez { get; set; }

        [DisplayName("Aktivasyon Kodu"), Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }
        [DisplayName("Aktif")]
        public bool IsActive { get; set; }
        [DisplayName("Admin")]
        public bool IsAdmin { get; set; }
        [DisplayName("Online Hasta")]
        public bool IsOnline { get; set; }
        [DisplayName("Normal Hasta")]
        public bool IsNormal { get; set; }
        [DisplayName("Ödeme Yaptı")]
        public bool IsPayOnline { get; set; }


        public virtual List<BlogYazısı> BlogYazıları { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual List<Diet> Dietler { get; set; }
        public virtual List<OdemeBildirimi> OdemeBildirimi { get; set; }
        public Kullanıcı()
        {
            Dietler = new List<Diet>();
            OdemeBildirimi = new List<OdemeBildirimi>();
        }

    }
}
