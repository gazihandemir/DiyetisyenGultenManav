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
                res.AddError(ErrorMessageCode.KategoriIsNotFound, "Kategori Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<Kategori> UpdateKategori(Kategori data)
        {
            BusinessLayerResult<Kategori> res = new BusinessLayerResult<Kategori>();
            Kategori db_kategori = Find(x => x.Id == data.Id);

            if (db_kategori != null && db_kategori.Id != data.Id)
            {
                if (db_kategori.Title == db_kategori.Title)
                {
                    res.AddError(ErrorMessageCode.KategoriTitleAlreadyExists, "Kategori zaten kullanılıyor.");
                }
                return res;
            }
            res.Result = Find(x => x.Id == data.Id);
            res.Result.Title = data.Title;
            res.Result.Description = data.Description;
            if (base.Update(res.Result)==0)
            {
                res.AddError(ErrorMessageCode.KategoriCouldNotUpdated, "Kategori Güncellenemedi.");
            }

            return res;
        }
        public BusinessLayerResult<Kategori> CreateKategori(Kategori data)
        {
            BusinessLayerResult<Kategori> res = new BusinessLayerResult<Kategori>();
            Kategori db_kategori = Find(x => x.Title == data.Title);
            res.Result = data;
            if (db_kategori != null)
            {
                if (db_kategori.Title == data.Title)
                {
                    res.AddError(ErrorMessageCode.KategoriTitleAlreadyExists, "Kategori Başlığı kayıtlı");
                }
            }
            else
            {
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.KategoriIsNotInserted, "Kategori Eklenemedi");
                }
            }
            return res;
        }
        // Kategori silme kod çözümü
        public override int Delete(Kategori kategori)
        {
            // Kategori ile ilişkili blog yazılarının silinmesi gerekiyor.
            BlogYazısıManager blogYazısıManager = new BlogYazısıManager();
            YorumManager yorumManager = new YorumManager();
            // YorumManager yorumManager = new YorumManager();
            foreach (BlogYazısı blog in kategori.BlogYazıları.ToList())
            {
                // Blog yazısı ile ilişkili verileri silme
                foreach (Yorum yorum in blog.Yorumlar.ToList())
                {
                    yorumManager.Delete(yorum);
                }
                blogYazısıManager.Delete(blog);
            }
            return base.Delete(kategori);
        } 
        /* 
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
