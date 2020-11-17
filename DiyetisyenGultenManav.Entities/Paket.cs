using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Paket")]
    public class Paket : EntityBase
    {
        [DisplayName("Paket İsmi"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
                StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Isim { get; set; }
        [DisplayName("Paket Fiyatı"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(20, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Fiyat { get; set; }
        [DisplayName("Paket Süresi"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(20, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Süresi { get; set; }
        [DisplayName("Birinci Renkli Alan"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string OzellikBirRed { get; set; }
        [DisplayName("Birinci Alan"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string OzellikBir { get; set; }
        [DisplayName("İkinci Renkli Alan"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string OzellikIkiRed { get; set; }
        [DisplayName("İkinci Alan"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string OzellikIki { get; set; }
        [DisplayName("Üçüncü Renkli Alan"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string OzellikUcRed { get; set; }
        [DisplayName("Üçüncü Alan"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string OzellikUc { get; set; }
        [DisplayName("Paket Rengi"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Renk { get; set; }
        [DisplayName("Button Rengi ve stili"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string RenkButton { get; set; }
        [DisplayName("Paket Açıklaması"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(500, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Aciklama { get; set; }

    }
}
