using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities.ValueObjects
{
    public class BlogDetailViewModel
    {
        public BlogYazısı BlogYazısı { get; set; }
        public List<Yorum> Yorum { get; set; }
    }
}
