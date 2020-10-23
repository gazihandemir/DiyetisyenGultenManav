using System;
using System.Collections.Generic;
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
        [Required, StringLength(50)]
        public string Title { get; set; }
        [Required, StringLength(50)]
        public string Description { get; set; }
        [Required, StringLength(1000)]
        public string Text { get; set; }
        public int KullanıcıId{ get; set; }
        public bool IsNew { get; set; }
        public string Hastalik { get; set; }
        public string Tahlil { get; set; }
        public string Olcum { get; set; }
        public string Hikaye { get; set; }
        public string EkAciklama { get; set; }
        public string BasariHikayesi { get; set; }
        public string BaslangicKilosu { get; set; }
        public string HaftaBir { get; set; }
        public string HaftaIki { get; set; }
        public string HaftaUc { get; set; }
        public string HaftaDort { get; set; }
        public virtual Kullanıcı Owner { get; set; }

    }
}
