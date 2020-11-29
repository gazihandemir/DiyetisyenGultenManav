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
    public class PaketTalebiManager : ManagerBase<PaketTalebi>
    {
        public BusinessLayerResult<PaketTalebi> GetPaketTalebiById(int? id)
        {
            BusinessLayerResult<PaketTalebi> res = new BusinessLayerResult<PaketTalebi>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.PaketTalebiIsNotFound, "Paket Talebi Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<PaketTalebi> GetRemoveById(int id)
        {
            BusinessLayerResult<PaketTalebi> res = new BusinessLayerResult<PaketTalebi>();
            PaketTalebi db_paketTalebi = Find(x => x.Id == id);
            if (db_paketTalebi != null)
            {
                if (Delete(db_paketTalebi) == 0)
                {
                    res.AddError(ErrorMessageCode.PaketTalebiCouldNotRemove, "Paket Talebi Silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.PaketTalebiIsNotFound, "Paket Talebi Bulunamadı.");
            }

            return res;
        }
        public BusinessLayerResult<PaketTalebi> UpdatePaketTalebi(PaketTalebi data)
        {
            BusinessLayerResult<PaketTalebi> res = new BusinessLayerResult<PaketTalebi>();
            PaketTalebi db_paketTalebi = Find(x => x.Id == data.Id);
            if (db_paketTalebi != null)
            {
                if (db_paketTalebi.EkAciklamalar == data.EkAciklamalar)
                {
                    res.AddError(ErrorMessageCode.PaketTalebiEkAciklamalarAlreadyExists, "Ek Açıklama 1 kez yazılabilir.");
                }
            }
            res.Result = db_paketTalebi;
            res.Result.IsimSoyisim = data.IsimSoyisim;
            res.Result.TelefonNo = data.TelefonNo;
            //res.Result.Program = data.Program;
            res.Result.EkAciklamalar = data.EkAciklamalar;
            if (base.Update(res.Result) == 0) // blog Yazısı Güncelleniyor.
            {
                res.AddError(ErrorMessageCode.PaketTalebiCouldNotUpdated, "Paket Talebi Güncellenemedi.");
            }
            return res;

        }
        public BusinessLayerResult<PaketTalebi> CreatePaketTalebi(PaketTalebi data)
        {
            PaketTalebi db_paketTalebi = Find(x => x.EkAciklamalar == data.EkAciklamalar);
            BusinessLayerResult<PaketTalebi> res = new BusinessLayerResult<PaketTalebi>();
            res.Result = data;
            if (db_paketTalebi != null)
            {
                if (db_paketTalebi.EkAciklamalar == data.EkAciklamalar)
                {
                    res.AddError(ErrorMessageCode.PaketTalebiEkAciklamalarAlreadyExists, "Ek Açıklama 1 kez yazılabilir.");
                }
            }

            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.PaketTalebiIsNotInserted, "Paket Talebi eklenemedi");
            }
            return res;

        }
    }
}
