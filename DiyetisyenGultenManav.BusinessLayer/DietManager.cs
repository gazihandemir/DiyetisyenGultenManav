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
    public class DietManager : ManagerBase<Diet>
    {
        KullanıcıManager kullanıcıManager = new KullanıcıManager();
        public BusinessLayerResult<Diet> GetDietById(int? id)
        {
            BusinessLayerResult<Diet> res = new BusinessLayerResult<Diet>();
            res.Result = Find(x => x.Id == id);
            if (res.Result == null)
            {
                res.AddError(ErrorMessageCode.DietIsNotFound, "Diet Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<Diet> GetRemoveById(int? id)
        {
            BusinessLayerResult<Diet> res = new BusinessLayerResult<Diet>();
            Diet db_diet = Find(x => x.Id == id);
            if (db_diet != null)
            {
                if (Delete(db_diet) == 0)
                {
                    res.AddError(ErrorMessageCode.DietCouldNotRemove, "Diet Silinemedi");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.DietIsNotFound, "Diet Bulunamadı");
            }
            return res;
        }
        public BusinessLayerResult<Diet> UpdateDiet(Diet data)
        {
            BusinessLayerResult<Diet> res = new BusinessLayerResult<Diet>();
            Diet db_diet = Find(x => x.Id != data.Id && x.Owner == data.Owner);
            /*    if (db_diet != null && db_diet.Id != data.Id)
                {
                    if (db_diet.Owner == data.Owner && db_diet.)
                    {
                        res.AddError(ErrorMessageCode.WriteAnewDiet, "Yeni Diyet Yaz");
                    }
                }*/

            res.Result = Find(x => x.Id == data.Id);
            res.Result.Title = data.Title;
            res.Result.DiyetSabah = data.DiyetSabah;
            res.Result.DiyetAraBir = data.DiyetAraBir;
            res.Result.DiyetOglen = data.DiyetOglen;
            res.Result.DiyetAraIki = data.DiyetAraIki;
            res.Result.DiyetAksam = data.DiyetAksam;
            res.Result.DiyetGece = data.DiyetGece;
            res.Result.Description = data.Description;
            res.Result.DiyetKilo = data.DiyetKilo;
            res.Result.DiyetBmi = data.DiyetBmi;
            res.Result.DiyetFat = data.DiyetFat;
            res.Result.DiyetMusc = data.DiyetMusc;
            res.Result.DiyetBmh = data.DiyetBmh;
            res.Result.DiyetVf = data.DiyetVf;
            res.Result.DiyetOlcum = data.DiyetOlcum;
            res.Result.DiyetBaslangic = data.DiyetBaslangic;
            res.Result.DiyetBitis = data.DiyetBitis;
            res.Result.DiyetEkAciklamalar = data.DiyetEkAciklamalar;
            res.Result.IsNew = data.IsNew;
            if (base.Update(res.Result) == 0) // Güncelleniyor.
            {
                res.AddError(ErrorMessageCode.DietCouldNotUpdated, "Diyet Güncellenemedi.");
            }
            return res;

        }
        public BusinessLayerResult<Diet> CreateDiet(Diet data)
        {
            BusinessLayerResult<Diet> res = new BusinessLayerResult<Diet>();
            //Diet db_diet = Find(x => x.Id == data.Id);
            //int idgelen = data.Owner.Id;
            //Kullanıcı db_kullanıcı = kullanıcıManager.Find(x => x.Id == idgelen);
            res.Result = data;
            //if (db_diet != null)
            //    {
            //        if (true)
            //        {

            //        }
            //    }
            if (base.Insert(res.Result) == 0)
            {
                res.AddError(ErrorMessageCode.DietIsNotInserted, "Diyet Eklenemedi");
            }
            string diyetler = res.Result.Owner.Dietler[0].Title.ToString();
            for (int i = 0; i < res.Result.Owner.Dietler.Count - 1; i++)
            {
                if (res.Result.Owner.Dietler[i] != null)
                {
                    res.Result.Owner.Dietler[i].IsNew = false;
                    bool gazi = res.Result.Owner.Dietler[i].IsNew;
                    base.Update(res.Result);

                }
         
            }

            return res;

        }
    }
}
