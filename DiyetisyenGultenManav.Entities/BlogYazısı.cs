using System;
using System.Collections.Generic;
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
        [Required,StringLength(60)]
        public string Title { get; set; }
        [Required, StringLength(2000)]
        public string Text { get; set; }
        public bool IsDraft { get; set; }
        public string LikeCount { get; set; }
        public string Picture { get; set; }
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
