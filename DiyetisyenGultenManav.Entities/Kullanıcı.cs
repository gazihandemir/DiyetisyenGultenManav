using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Kullanıcılar")]
    public class Kullanıcı : EntityBase
    {
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
        [Required,StringLength(50)]
        public string Username { get; set; }
        [Required,StringLength(70)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public Guid ActivateGuid { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsOnline { get; set; }
        public bool IsNormal { get; set; }
        public bool IsPayOnline { get; set; }


        public virtual List<BlogYazısı> BlogYazıları { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual List<Diet> Dietler { get; set; }
        public Kullanıcı()
        {
            Dietler = new List<Diet>();
        }

    }
}
