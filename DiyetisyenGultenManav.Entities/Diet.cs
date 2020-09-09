using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    public class Diet : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public Kullanıcı Owner { get; set; }

    }
}
