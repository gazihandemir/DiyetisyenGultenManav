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
        [DisplayName("İçerik"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(2000, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Text { get; set; }
        [DisplayName("Taslak")]
        public bool IsDraft { get; set; }
        [DisplayName("Resim")]
        public string Picture { get; set; }
        [DisplayName("Kategori")]
        public int KategoriId{ get; set; }
        public virtual Kullanıcı Owner { get; set; }
        public virtual List<Yorum> Yorumlar{ get; set; }
        public virtual Kategori Kategori{ get; set; }
        public BlogYazısı()
        {
            Yorumlar = new List<Yorum>();
        }
    }
}
