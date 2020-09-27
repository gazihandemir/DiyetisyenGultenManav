using DiyetisyenGultenManav.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiyetisyenGultenManav.WebApp.ViewModels
{
    public class ErrorViewModel : NotifyViewModelBase<ErrorMessageObj>
    {
        public ErrorViewModel()
        {
            Title = "Geçersiz işlem !";
        }

    }
}