using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Paket")]
    public class Paket : EntityBase
    {
        public string Isim { get; set; }
        public string Fiyat { get; set; }
        public string Süresi { get; set; }
        public string OzellikBirRed { get; set; }
        public string OzellikBir { get; set; }
        public string OzellikIkiRed { get; set; }
        public string OzellikIki { get; set; }
        public string OzellikUcRed { get; set; }
        public string OzellikUc { get; set; }
        public string Renk{ get; set; }
        public string RenkButton{ get; set; }
        public string Aciklama { get; set; }
    }
}
