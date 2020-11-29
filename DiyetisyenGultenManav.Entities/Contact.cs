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
    [Table("İletisim")]

    public class Contact : EntityBase
    {
        [DisplayName("İsim Soyisim"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string IsimSoyisim { get; set; }
        [DisplayName("Telefon Numaranız"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string TelefonNumarasi { get; set; }
        [DisplayName("E-posta"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Email { get; set; }
        [DisplayName("Konu"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Konu { get; set; }
        [DisplayName("Mesajınız"), Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(400, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Mesaj { get; set; }
        [DisplayName("Oluşturulma Tarihi"), Required, ScaffoldColumn(false)]
        public DateTime Zaman { get; set; }

    }
}
