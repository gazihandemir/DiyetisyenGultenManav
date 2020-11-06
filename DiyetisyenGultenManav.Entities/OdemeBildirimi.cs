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
    [Table("OdemeBildirimi")]
    public class OdemeBildirimi : EntityBase
    {
        [DisplayName("İsim Soyisim"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string IsimSoyisim { get; set; }
        [DisplayName("Banka İsmi"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string BankaIsmi { get; set; }
        [DisplayName("Yatırılan Miktar"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string YatirilanMiktar { get; set; }
        [DisplayName("Cep Telefonu"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string TelefonNo { get; set; }
        [DisplayName("Ek Açıklamalar"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
               StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string EkAciklamalar { get; set; }
        [DisplayName("Bildirildi")]
        public bool IsNotification { get; set; }
        [DisplayName("Ödendi")]
        public bool IsPay { get; set; }
        [DisplayName("Onaylandı")]

        public bool IsOkey { get; set; }
        [DisplayName("Kullanıcı")]

        public int KullanıcıId { get; set; }


        public virtual Kullanıcı Owner { get; set; }
    }
}
