﻿using DiyetisyenGultenManav.BusinessLayer.Abstract;
using DiyetisyenGultenManav.BusinessLayer.Results;
using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{
    public class OdemeBildirimiManager : ManagerBase<OdemeBildirimi>
    {
        //public new BusinessLayerResult<OdemeBildirimi> Insert(OdemeBildirimi data) // metot hiding
        //{
        //    BusinessLayerResult<OdemeBildirimi> res = new BusinessLayerResult<OdemeBildirimi>();
        //    res.Result = data;
        //    res.Result.IsNotification = true;
        //    res.Result.IsPay = false;
        //    base.Insert(res.Result);
        //    return res;
        //}
    }
}
