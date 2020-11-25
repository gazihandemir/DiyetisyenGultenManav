using DiyetisyenGultenManav.BusinessLayer;
using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace DiyetisyenGultenManav.WebApp.Models
{
    public class CacheHelper
    {
        public static List<Kategori> GetKategorilerFromCache()
        {
            var result = WebCache.Get("kategori-cache") as List<Kategori>;
            if (result == null)
            {
                KategoriManager kategoriManager = new KategoriManager();
                result = kategoriManager.List();
                WebCache.Set("kategori-cache", result, 20, true); // 20dk tutsun / sayfayı yenileyince 0dan başalsın
            }
            return result;
        }
        public static void RemoveKategorilerFromCache()
        {
            Remove("kategori-cache");
        }
        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}