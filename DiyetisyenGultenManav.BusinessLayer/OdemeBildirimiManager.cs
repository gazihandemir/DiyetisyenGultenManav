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
    public class OdemeBildirimiManager : ManagerBase<OdemeBildirimi>
    {
        /*   public new BusinessLayerResult<OdemeBildirimi> Insert(OdemeBildirimi data) // metot hiding
           {
               BusinessLayerResult<OdemeBildirimi> res = new BusinessLayerResult<OdemeBildirimi>();
               res.Result = data;
               res.Result.IsNotification = true;
               res.Result.IsPay = false;
               base.Insert(res.Result);
               return res;
           }
        */
        public BusinessLayerResult<OdemeBildirimi> GetOdemeBildirimiById(int? id)
        {
            BusinessLayerResult<OdemeBildirimi> res = new BusinessLayerResult<OdemeBildirimi>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.OdemeBildirimiIsNotFound, "Ödeme Bildirimi Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<OdemeBildirimi> GetRemoveById(int? id)
        {
            BusinessLayerResult<OdemeBildirimi> res = new BusinessLayerResult<OdemeBildirimi>();
            OdemeBildirimi db_odeme = Find(x => x.Id == id);
            if (db_odeme != null)
            {
                if (Delete(db_odeme) == 0)
                {
                    res.AddError(ErrorMessageCode.OdemeBildirimiCouldNotRemove, "Ödeme Bildirimi Silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.OdemeBildirimiIsNotFound, "Ödeme Bildirimi Bulunamadı.");
            }
            return res;
        }
        public BusinessLayerResult<OdemeBildirimi> UpdateOdemeBildirimi(OdemeBildirimi data, Boolean isAdmin)
        {
            OdemeBildirimi db_odeme = Find(x => x.Id == data.Id);
            BusinessLayerResult<OdemeBildirimi> res = new BusinessLayerResult<OdemeBildirimi>();
            if (db_odeme != null)
            {

            }

            res.Result = db_odeme;
            res.Result.IsimSoyisim = data.IsimSoyisim;
            res.Result.BankaIsmi = data.BankaIsmi;
            res.Result.YatirilanMiktar = data.YatirilanMiktar;
            res.Result.TelefonNo = data.TelefonNo;
            res.Result.EkAciklamalar = data.EkAciklamalar;
            if (isAdmin)
            {
                res.Result.IsNotification = data.IsNotification;
                res.Result.IsPay = data.IsPay;
                res.Result.IsOkey = data.IsOkey;
                if (base.Update(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.OdemeBildirimiAdminCouldNotUpdated, "Ödeme Bildirimi (Admin) Güncellenemedi.");
                }
            }
            else
            {
                res.Result.IsNotification = res.Result.IsNotification;
                res.Result.IsPay = res.Result.IsPay;
                res.Result.IsOkey = res.Result.IsOkey;
                if (base.Update(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.OdemeBildirimiUserCouldNotUpdated, "Ödeme Bildirimi (Kullanıcı) Güncellenemedi.");
                }
            }
            return res;
        }
        public BusinessLayerResult<OdemeBildirimi> CreateOdemeBildirimi(OdemeBildirimi data)
        {
            OdemeBildirimi db_odeme = Find(x => x.Id == data.Id);
            BusinessLayerResult<OdemeBildirimi> res = new BusinessLayerResult<OdemeBildirimi>();
            if (db_odeme != null)
            {
                if (db_odeme.Id == data.Id)
                {
                    res.AddError(ErrorMessageCode.OdemeBildirimiIdAlreadyExists, "Ödeme Bildirimi ID kayıtlı");
                }
            }
            else
            {
                if (base.Insert(res.Result) == 0)
                {
                    res.AddError(ErrorMessageCode.OdemeBildirimiIsNotInserted, "Kullanıcı eklenemedi");
                }
            }

            return res;
        }
    }
}
