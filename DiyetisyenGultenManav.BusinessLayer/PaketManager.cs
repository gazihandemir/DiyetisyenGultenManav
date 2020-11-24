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
        public BusinessLayerResult<Paket> UpdatePaket(Paket data)
        {
            BusinessLayerResult<Paket> res = new BusinessLayerResult<Paket>();
            Paket db_paket = Find(x => x.Id == data.Id);
            /*   if (db_paket != null && db_paket.Id == data.Id) 
                {
                    if (true)
                    {

                    }
                }
            */
            res.Result = Find(x => x.Id == data.Id);
            res.Result.Isim = data.Isim;
            res.Result.Fiyat = data.Fiyat;
            res.Result.Süresi = data.Süresi;

            res.Result.OzellikBirRed = data.OzellikBirRed;
            res.Result.OzellikBir = data.OzellikBir;

            res.Result.OzellikIkiRed = data.OzellikIkiRed;
            res.Result.OzellikIki = data.OzellikIki;

            res.Result.OzellikUcRed = data.OzellikUcRed;
            res.Result.OzellikUc = data.OzellikUc;

            res.Result.Renk = data.Renk;
            res.Result.RenkButton = data.RenkButton;

            res.Result.Aciklama = data.Aciklama;
            if (base.Update(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.PaketCouldNotUpdated, "Paket Güncellenemedi");
            }
            return res;
        }
        public BusinessLayerResult<Paket> CreatePaket(Paket data)
        {
            BusinessLayerResult<Paket> res = new BusinessLayerResult<Paket>();
            Paket db_paket = Find(x => x.Id == data.Id);
            res.Result = data;
            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.PaketIsNotInserted, "Paket Eklenemedi");
            }
            return res;
        }
    }
}
