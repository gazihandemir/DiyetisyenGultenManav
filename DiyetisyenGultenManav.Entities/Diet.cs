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
        public string DiyetOlcum { get; set; }
        public string  DiyetKilo { get; set; }
        public string  DiyetBmi { get; set; }
        public string  DiyetFat { get; set; }
        public string  DiyetMusc { get; set; }
        public string  DiyetBmh { get; set; }
        public string  DiyetVf { get; set; }
        public string  DiyetEkAciklamalar { get; set; }
        public DateTime DiyetBaslangic{ get; set; }
        public DateTime DiyetBitis{ get; set; }

        public virtual Kullanıcı Owner { get; set; }

    }
}
