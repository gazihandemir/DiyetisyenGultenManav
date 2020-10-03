using DiyetisyenGultenManav.BusinessLayer.Abstract;
using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{
    public class KategoriManager : ManagerBase<Kategori>
    {
        // Kategori silme kod çözümü
        /*    public override int Delete(Kategori kategori) 
          {
              // Kategori ile ilişkili blog yazılarının silinmesi gerekiyor.
              BlogYazısıManager blogYazısıManager = new BlogYazısıManager();
              // YorumManager yorumManager = new YorumManager();
              foreach (BlogYazısı blog in kategori.BlogYazıları.ToList())
              {
                  // Blog yazısı ile ilişkili verileri silme
                  foreach (Yorum yorum in blog.Yorumlar.ToList())
                  {
                      //yorumManager.Delete(yorum);
                  }
                  blogYazısıManager.Delete(blog);
              }
              return base.Delete(kategori);
          }
          //     private DataAccessLayer.EntityFramework.Repository<Kategori> repo_kategori = new DataAccessLayer.EntityFramework.Repository<Kategori>();
                public List<Kategori> GetKategoriler()
                  {
                      return repo_kategori.List();
                  }
                  public Kategori GetKategoriById(int id)
                  {
                      return repo_kategori.Find(x => x.Id == id);
                  }
          */
    }
}
