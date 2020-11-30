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
    public class KahveManager : ManagerBase<Kahve>
    {
        public BusinessLayerResult<Kahve> GetKahveById(int? id)
        {
            BusinessLayerResult<Kahve> res = new BusinessLayerResult<Kahve>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.KahveIsNotFound, "Blog Yazısı Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<Kahve> GetRemoveById(int? id)
        {
            BusinessLayerResult<Kahve> res = new BusinessLayerResult<Kahve>();
            Kahve db_kahve = Find(x => x.Id == id);
            if (db_kahve != null)
            {
                if (Delete(db_kahve) == 0)
                {
                    res.AddError(ErrorMessageCode.KahveCouldNotRemove, "Blog Yazısı Silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.KahveIsNotFound, "Kullanıcı Bulunamadı.");
            }

            return res;
        }
        public BusinessLayerResult<Kahve> UpdateKahve(Kahve data)
        {
            BusinessLayerResult<Kahve> res = new BusinessLayerResult<Kahve>();
            Kahve db_kahve = Find(x => x.Id == data.Id);
            if (db_kahve != null && db_kahve.Id != db_kahve.Id)
            {
                if (db_kahve.Yazi == data.Yazi)
                {
                    res.AddError(ErrorMessageCode.KahveYaziAlreadyExists, "Kahve yazısı zaten kullanılıyor.");
                }
                return res;
            }
            res.Result = db_kahve;
            res.Result.Ikon = data.Ikon;
            res.Result.IkonRengi = data.IkonRengi;
            res.Result.IkonBoyutu = data.IkonBoyutu;
            res.Result.Sayi = data.Sayi;
            res.Result.SayiRengi = data.SayiRengi;
            res.Result.SayiBoyutu = data.SayiBoyutu;
            res.Result.Yazi = data.Yazi;
            res.Result.YaziRengi = data.YaziRengi;
            res.Result.YaziBoyutu = data.YaziBoyutu;
            if (base.Update(res.Result) == 0) // blog Yazısı Güncelleniyor.
            {
                res.AddError(ErrorMessageCode.KahveCouldNotUpdated, "Kahve Güncellenemedi.");
            }
            return res;
        }
        public BusinessLayerResult<Kahve> CreateKahve(Kahve data)
        {
            BusinessLayerResult<Kahve> res = new BusinessLayerResult<Kahve>();
            Kahve db_kahve = Find(x => x.Yazi == data.Yazi);
            res.Result = data;
            if (db_kahve != null)
            {
                if (db_kahve.Yazi == data.Yazi)
                {
                    res.AddError(ErrorMessageCode.KahveYaziAlreadyExists, "Kahve yazısı zaten kullanılıyor.");
                }
            }
            else
            {
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.KahveIsNotInserted, "Kahve eklenemedi");
                }
            }
            return res;
        }
    }

}
