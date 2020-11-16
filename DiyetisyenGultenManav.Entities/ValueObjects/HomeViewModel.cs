using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities.ValueObjects
{
    public class HomeViewModel
    {
        public List<BlogYazısı> BlogYazısı { get; set; }
        public List<Paket> Paket { get; set; }
    }
}
