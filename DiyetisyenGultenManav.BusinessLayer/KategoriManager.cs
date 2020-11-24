using DiyetisyenGultenManav.BusinessLayer.Abstract;
using DiyetisyenGultenManav.BusinessLayer.Results;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{
    public class KategoriManager : ManagerBase<Kategori>
    {
        public BusinessLayerResult<Kategori> GetKategoriById(int? id)
        {
            BusinessLayerResult<Kategori> res = new BusinessLayerResult<Kategori>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.KategoriIsNotFound,"Kategori Bulunamadı");
            }
            return res;
        }
        
        // Kategori silme kod çözümü
          public override int Delete(Kategori kategori) 
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
        } /* 
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
