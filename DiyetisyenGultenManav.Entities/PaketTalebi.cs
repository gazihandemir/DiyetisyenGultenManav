using System.ComponentModel.DataAnnotations.Schema;

namespace DiyetisyenGultenManav.Entities
{
    [Table("PaketTalebi")]
    public class PaketTalebi : EntityBase
    {
        public string IsimSoyisim { get; set; }
        public string TelefonNo { get; set; }
        public string Program { get; set; }
        public string EkAciklamalar { get; set; }
    }
}
