using System;
using System.Collections.Generic;
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
        [Required, ScaffoldColumn(false)]
        public DateTime CreatedOn { get; set; }
        [Required, ScaffoldColumn(false)]
        public DateTime ModifiedOn { get; set; }
        [Required,StringLength(30), ScaffoldColumn(false)]
        public string ModifiedUsername { get; set; }
    }
}
