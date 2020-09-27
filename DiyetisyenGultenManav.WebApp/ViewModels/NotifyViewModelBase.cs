using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiyetisyenGultenManav.WebApp.ViewModels
{
    public class NotifyViewModelBase<T>
    {
        public List<T> Items { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public bool IsRedirecting { get; set; }
        public string RedirectingUrl { get; set; }
        public int RedirectingTimeout { get; set; }
        public NotifyViewModelBase()
        {
            Header = "Yönlendiriliyorsunuz."; // 
            Title = "işlemi yazılımcı seçecek"; // Başlıkta ne yazsın.
            IsRedirecting = true; // Yönlendirme olsun mu 
            RedirectingUrl = "/Home/Index"; // Nereye yönlendirilsin
            RedirectingTimeout = 8000; // kaç saniye sonra yönlendirilsin.
        }
    }
}