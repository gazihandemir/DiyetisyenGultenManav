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
    }
}
