using DiyetisyenGultenManav.Common;
using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiyetisyenGultenManav.WebApp.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUsername()
        {
            if (HttpContext.Current.Session["login"] != null)
            {
                Kullanıcı user = HttpContext.Current.Session["login"] as Kullanıcı;
                return user.Username;
            }
            return null;
        }
    }
}