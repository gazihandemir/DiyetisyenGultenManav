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
        [DisplayName("Soyisim"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }
        [DisplayName("Kullnıcı Adı"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Username { get; set; }
        [DisplayName("E-Posta"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }
        [StringLength(30),ScaffoldColumn(false)] // images/user_12.jpg
        public string ProfileImageFileName { get; set; }

       [DisplayName("Doğum Tarihiniz")]
        public string DogumTarihi { get; set; }

        [DisplayName("Telefon Numaranız")]
        public string TelefonNumarası { get; set; }
        [DisplayName("Boyunuz")]
        public string Boy { get; set; }
        [DisplayName("Kilonuz")]
        public string Kilo { get; set; }
        [DisplayName("Yaşınız")]
        public string Yas { get; set; }
        [DisplayName("Mesleğiniz")]
        public string Meslek { get; set; }
        [DisplayName("Yaşadığınız Şehir")]
        public string Sehir { get; set; }

        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
        public bool IsNormal { get; set; }
        public bool IsPayOnline { get; set; }


        public virtual List<BlogYazısı> BlogYazıları { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual List<Diet> Dietler { get; set; }
        public Kullanıcı()
        {
            Dietler = new List<Diet>();
        }

    }
}
