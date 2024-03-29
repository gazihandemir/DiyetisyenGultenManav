﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Başlık"),Required(ErrorMessage ="{0} alanı gereklidir."),
            StringLength(50,ErrorMessage ="{0} alanı max. {1} karakter içermeli.")]
        public string Title { get; set; }
        [DisplayName("Açıklama"),StringLength(160, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Description { get; set; }
        [DisplayName("İkon"), StringLength(40, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Icon { get; set; }

        public virtual List<BlogYazısı> BlogYazıları { get; set; }
        public Kategori()
        {
            BlogYazıları = new List<BlogYazısı>();
        }

    }
}
