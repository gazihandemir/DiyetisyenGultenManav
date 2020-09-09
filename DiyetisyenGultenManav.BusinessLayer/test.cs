using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{
    public class test
    {
        public test()
        {
            DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
            db.Kategoriler.ToList();
        }
    }
}
