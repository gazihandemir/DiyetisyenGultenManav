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
    [Table("BlogYazıları")]
    public class BlogYazısı : EntityBase
    {
        [DisplayName("Başlık"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
                StringLength(60, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Title { get; set; }
        [DisplayName("Birinci Paragraf"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafBir { get; set; }
        [DisplayName("İkinci Paragraf"),
   Required(ErrorMessage = "{0} alanı gereklidir."),
       StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafIki { get; set; }
        [DisplayName("Üçüncü Paragraf"),
   Required(ErrorMessage = "{0} alanı gereklidir."),
       StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafUc { get; set; }
        [DisplayName("Dördüncü Paragraf"),
   Required(ErrorMessage = "{0} alanı gereklidir."),
       StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafDort { get; set; }
        [DisplayName("Beşinci İnce Yazı"),
   Required(ErrorMessage = "{0} alanı gereklidir."),
       StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafBes { get; set; }
        [DisplayName("Altıncı Paragraf"),
   Required(ErrorMessage = "{0} alanı gereklidir."),
       StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafAlti { get; set; }
        [DisplayName("Yedinci Paragraf"),
Required(ErrorMessage = "{0} alanı gereklidir."),
StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafYedi { get; set; }
        [DisplayName("Sekizinci Paragraf"),
Required(ErrorMessage = "{0} alanı gereklidir."),
StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string ParagrafSekiz { get; set; }
        [DisplayName("Görüntülenme")]
        public int GörüntülenmeSayisi { get; set; } // Begeni sayısı
        [DisplayName("Taslak")]
        public bool IsDraft { get; set; }
        [DisplayName("Danışan Paylaşımı")]
        public bool DanisanPaylasimi { get; set; }
        [DisplayName("Tabak Paylaşımı")]
        public bool TabakPaylasimi { get; set; }
        [DisplayName("Resim")]
        public string Picture { get; set; }
        [DisplayName("Kategori")]
        public int KategoriId { get; set; }
        public virtual Kullanıcı Owner { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual Kategori Kategori { get; set; }
        public BlogYazısı()
        {
            Yorumlar = new List<Yorum>();
        }
    }
}
