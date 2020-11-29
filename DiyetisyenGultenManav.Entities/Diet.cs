using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Dietler")]
    public class Diet : EntityBase
    {
        [DisplayName("Başlık"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
                StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Title { get; set; }
        [DisplayName("Açıklama"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Description { get; set; }
        [DisplayName("Sabah"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(400, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetSabah { get; set; }
        [DisplayName("Ara"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
                StringLength(400, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetAraBir { get; set; }
        [DisplayName("Öğlen"),
         Required(ErrorMessage = "{0} alanı gereklidir."),
             StringLength(400, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetOglen { get; set; }
        [DisplayName("Ara"),
         Required(ErrorMessage = "{0} alanı gereklidir."),
             StringLength(400, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetAraIki{ get; set; }
        [DisplayName("Aksam"),
        Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(400, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetAksam { get; set; }
        [DisplayName("Gece"),
        Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(400, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetGece{ get; set; }
        [DisplayName("Kullanıcı")]
        public int KullanıcıId { get; set; }
        [DisplayName("Yeni mi")]
        public bool IsNew { get; set; }
        [DisplayName("Ölçüm"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetOlcum { get; set; }
        [DisplayName("Kilo"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetKilo { get; set; }
        [DisplayName("Vücut Kitle İndexi (BMI)"),
         Required(ErrorMessage = "{0} alanı gereklidir."),
             StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetBmi { get; set; }
        [DisplayName("Yağ Oranı (FAT)"),
         Required(ErrorMessage = "{0} alanı gereklidir."),
             StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetFat { get; set; }
        [DisplayName("Kas Oranı (MUSC)"),
         Required(ErrorMessage = "{0} alanı gereklidir."),
             StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetMusc { get; set; }
        [DisplayName("Bazal Metabolizma Hızı (BMH)"),
         Required(ErrorMessage = "{0} alanı gereklidir."),
             StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetBmh { get; set; }
        [DisplayName("Karın İçi Yağlanma (VF)"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
                StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetVf { get; set; }
        [DisplayName("Ek Açıklama"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
                StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string DiyetEkAciklamalar { get; set; }
        [DisplayName("Diyetin Başlangıç Tarihi"),
            Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime DiyetBaslangic { get; set; }
        [DisplayName("Diyetin Bitiş Tarihi"),
         Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime DiyetBitis { get; set; }

        public virtual Kullanıcı Owner { get; set; }
    }
}
