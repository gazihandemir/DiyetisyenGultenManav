using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{
    public class BlogYazısıManager
    {
        private DataAccessLayer.EntityFramework.Repository<BlogYazısı> repo_blogYazısı = new DataAccessLayer.EntityFramework.Repository<BlogYazısı>();

        public List<BlogYazısı> getAllBlogYazısı()
        {
            return repo_blogYazısı.List();
        }
    }
}
