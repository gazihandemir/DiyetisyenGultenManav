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
        [DisplayName("Birinci İkon")]
        public string Ikon { get; set; }
        [DisplayName("Birinci İkon Rengi")]
        public string IkonRengi { get; set; }
        [DisplayName("Birinci İkon Boyutu")]
        public string IkonBoyutu { get; set; }
        [DisplayName("Birinci Sayi")]
        public string Sayi { get; set; }
        [DisplayName("Birinci Sayi Rengi")]
        public string SayiRengi { get; set; }
        [DisplayName("Birinci Sayi Boyutu")]
        public string SayiBoyutu { get; set; }
        [DisplayName("Birinci Yazı")]
        public string Yazi { get; set; }
        [DisplayName("Birinci Yazı Rengi")]
        public string YaziRengi { get; set; }
        [DisplayName("Birinci Yazı Boyutu")]
        public string YaziBoyutu { get; set; }
    }
}
