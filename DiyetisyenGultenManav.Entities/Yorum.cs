using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Yorumlar")]
    public class Yorum : EntityBase
    {
        [Required,StringLength(300)]
        public string  Text{ get; set; }
        public BlogYazısı BlogYazısı{ get; set; }
        public Kullanıcı Owner { get; set; }
    }
}
