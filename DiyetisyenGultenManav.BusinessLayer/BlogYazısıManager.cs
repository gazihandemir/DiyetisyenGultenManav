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
    public class BlogYazısıManager : ManagerBase<BlogYazısı>
    {
        public BusinessLayerResult<BlogYazısı> GetBlogYazısıById(int? id)
        {
            BusinessLayerResult<BlogYazısı> res = new BusinessLayerResult<BlogYazısı>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.ContactIsNotFound, "Blog Yazısı Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<BlogYazısı> GetRemoveById(int? id)
        {
            BusinessLayerResult<BlogYazısı> res = new BusinessLayerResult<BlogYazısı>();
            BlogYazısı db_blog = Find(x => x.Id == id);
            if (db_blog != null)
            {
                if (Delete(db_blog) == 0)
                {
                    res.AddError(ErrorMessageCode.BlogYazısıCouldNotRemove, "Blog Yazısı Silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.ContactIsNotFound, "Kullanıcı Bulunamadı.");
            }
       
            return res;
        }
        public BusinessLayerResult<BlogYazısı> UpdateBlogYazisi(BlogYazısı data)
        {
            BlogYazısı db_blog = Find(x => x.Id != data.Id && x.Title == data.Title);
            BusinessLayerResult<BlogYazısı> res = new BusinessLayerResult<BlogYazısı>();
            if (db_blog != null && db_blog.Id != data.Id)
            {
                if (db_blog.Title == data.Title)
                {
                    res.AddError(ErrorMessageCode.BlogYazisiTitleAlreadyExists, "Blok Yazısı zaten kullanılıyor");
                }
                return res;
            }
            res.Result = Find(x => x.Id == data.Id);
            res.Result.KategoriId = data.KategoriId;
            res.Result.ParagrafBir = data.ParagrafBir;
            res.Result.ParagrafIki = data.ParagrafIki;
            res.Result.ParagrafUc = data.ParagrafUc;
            res.Result.ParagrafDort = data.ParagrafDort;
            res.Result.ParagrafBes = data.ParagrafBes;
            res.Result.ParagrafAlti = data.ParagrafAlti;
            res.Result.ParagrafYedi = data.ParagrafYedi;
            res.Result.ParagrafSekiz = data.ParagrafSekiz;
            res.Result.Title = data.Title;
            res.Result.IsDraft = data.IsDraft;
            res.Result.DanisanPaylasimi = data.DanisanPaylasimi;
            res.Result.TabakPaylasimi = data.DanisanPaylasimi;
            if (string.IsNullOrEmpty(data.Picture) == false)
            {
                res.Result.Picture = data.Picture;
            }
            if (base.Update(res.Result) == 0) // blog Yazısı Güncelleniyor.
            {
                res.AddError(ErrorMessageCode.BlogYazisiCouldNotUpdated, "Blog Yazısı Güncellenemedi.");
            }
            return res;
        }
        public BusinessLayerResult<BlogYazısı> CreateBlogYazisi(BlogYazısı data)
        {
            BlogYazısı db_blog = Find(x => x.Title == data.Title);
            BusinessLayerResult<BlogYazısı> res = new BusinessLayerResult<BlogYazısı>();
            res.Result = data;
            if (db_blog != null)
            {
                if (db_blog.Title == data.Title)
                {
                    res.AddError(ErrorMessageCode.BlogYazısıTitleAlreadyExists, "Blog Yazısının başlığı kayıtlı");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(data.Picture) == false)
                {
                    res.Result.Picture = data.Picture;
                }
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.OdemeBildirimiIsNotInserted, "Kullanıcı eklenemedi");
                }
            }
            return res;
        }

    }
    /*  private DataAccessLayer.EntityFramework.Repository<BlogYazısı> repo_blogYazısı = new DataAccessLayer.EntityFramework.Repository<BlogYazısı>();

            public List<BlogYazısı> getAllBlogYazısı()
            {
                return repo_blogYazısı.List();
            }
            public IQueryable<BlogYazısı> getAllBlogYazısıQueryable()
            {
                return repo_blogYazısı.ListQueryable();
            }
    */
}


