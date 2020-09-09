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
        public virtual Kullanıcı Owner { get; set; }

    }
}
