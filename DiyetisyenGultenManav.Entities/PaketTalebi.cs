using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenGultenManav.Entities
{
    [Table("PaketTalebi")]
    public class PaketTalebi : EntityBase
    {
        [DisplayName("İsim Soyisim"),
              Required(ErrorMessage = "{0} alanı gereklidir."),
                  StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string IsimSoyisim { get; set; }
        [DisplayName("Telefon Numarası"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string TelefonNo { get; set; }
        [DisplayName("Program"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Program { get; set; }
        [DisplayName("Açıklama"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string EkAciklamalar { get; set; }
    }
}
