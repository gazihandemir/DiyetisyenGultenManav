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
    }
}
