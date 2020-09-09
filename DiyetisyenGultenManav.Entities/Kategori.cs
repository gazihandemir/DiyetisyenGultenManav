using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    public class Kategori : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual List<BlogYazısı> BlogYazıları { get; set; }


    }
}
