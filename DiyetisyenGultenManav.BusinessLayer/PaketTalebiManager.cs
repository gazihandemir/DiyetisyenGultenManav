﻿using DiyetisyenGultenManav.BusinessLayer.Abstract;
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
    }
}
