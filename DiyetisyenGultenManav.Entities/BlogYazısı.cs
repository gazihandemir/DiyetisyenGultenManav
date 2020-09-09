using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    public class BlogYazısı : EntityBase
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string IsDraft { get; set; }
        public string LikeCount { get; set; }
        public int KategoriId{ get; set; }
        public virtual Kullanıcı owner { get; set; }
        public virtual List<Yorum> Yorumlar{ get; set; }
        public virtual Kategori Kategori{ get; set; }
    }
}
