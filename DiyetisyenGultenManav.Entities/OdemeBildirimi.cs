using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    [Table("OdemeBildirimi")]
    public class OdemeBildirimi : EntityBase
    {
        public string IsimSoyisim { get; set; }
        public string BankaIsmi { get; set; }
        public string YatirilanMiktar { get; set; }
        public string TelefonNo { get; set; }
        public string EkAciklamalar { get; set; }

        public bool IsNotification { get; set; }
        public bool IsPay { get; set; }
        public int KullanıcıId { get; set; }

        public Kullanıcı Owner { get; set; }
    }
}
