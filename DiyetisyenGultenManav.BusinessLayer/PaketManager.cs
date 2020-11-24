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
   public class PaketManager : ManagerBase<Paket>
    {
        public BusinessLayerResult<Paket> GetPaketById(int? id)
        {
            BusinessLayerResult<Paket> res = new BusinessLayerResult<Paket>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.PaketIsNotFound, "Paket Bulunamadı Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<Paket> GetRemoveById(int? id)
        {
            BusinessLayerResult<Paket> res = new BusinessLayerResult<Paket>();
            Paket db_paket = Find(x => x.Id == id);
            if (db_paket != null)
            {
                if (Delete(db_paket) == 0)
                {
                    res.AddError(ErrorMessageCode.PaketCouldNotRemove, "Paket Silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.PaketIsNotFound, "Paket Bulunamadı.");
            }

            return res;
        }
    }
}
