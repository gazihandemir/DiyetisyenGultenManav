using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    [Table("Kahve")]

    public class Kahve : EntityBase
    {
        // Birinci
        [DisplayName("Arka Plan Rengi")]
        public string ArkaPlanRengi{ get; set; }
        [DisplayName("İkon")]
        public string Ikon { get; set; }
        [DisplayName("İkon Rengi")]
        public string IkonRengi { get; set; }
        [DisplayName("İkon Boyutu")]
        public string IkonBoyutu { get; set; }
        [DisplayName("Sayi")]
        public string Sayi { get; set; }
        [DisplayName("Sayi Rengi")]
        public string SayiRengi { get; set; }
        [DisplayName("Sayi Boyutu")]
        public string SayiBoyutu { get; set; }
        [DisplayName("Yazı")]
        public string Yazi { get; set; }
        [DisplayName("Yazı Rengi")]
        public string YaziRengi { get; set; }
        [DisplayName("Yazı Boyutu")]
        public string YaziBoyutu { get; set; }
    }
}
