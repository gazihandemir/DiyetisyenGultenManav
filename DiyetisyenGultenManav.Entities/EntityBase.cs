using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
   public class EntityBase
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] // pk ve otomatik artma
        public int Id { get; set; }
        [DisplayName("Oluşturulma Tarihi"),Required, ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }
        [DisplayName("Düzenlenme Tarihi"),Required, ScaffoldColumn(false)]
        public DateTime ModifiedOn { get; set; }
        [DisplayName("Düzenleyen Kişi"),Required,StringLength(30), ScaffoldColumn(false)]
        public string ModifiedUsername { get; set; }
    }
}
