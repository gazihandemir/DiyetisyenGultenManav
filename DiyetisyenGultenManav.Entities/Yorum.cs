using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    public class Yorum : EntityBase
    {
        public string  Text{ get; set; }
        public BlogYazısı BlogYazısı{ get; set; }
        public Kullanıcı Owner { get; set; }
    }
}
