using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Kategoriler")]
    public class Kategori : EntityBase
    {
        [Required, StringLength(50)]
        public string Title { get; set; }
        [StringLength(160)]
        public string Description { get; set; }

        public virtual List<BlogYazısı> BlogYazıları { get; set; }
        public Kategori()
        {
            BlogYazıları = new List<BlogYazısı>();
        }

    }
}
