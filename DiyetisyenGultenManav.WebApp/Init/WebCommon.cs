using DiyetisyenGultenManav.Common;
using DiyetisyenGultenManav.Entities;
using DiyetisyenGultenManav.WebApp.Models;
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
            /*  if (HttpContext.Current.Session["login"] != null)
              {
                  Kullanıcı user = HttpContext.Current.Session["login"] as Kullanıcı;
                  return user.Username;
              }
            */
            Kullanıcı kullanıcı = CurrentSession.User;
            if (kullanıcı != null)
            {
                return kullanıcı.Username;
            }
            else
            {
                return "system";
            }
        }
    }
}