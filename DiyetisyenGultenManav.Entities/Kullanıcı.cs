﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.Entities
{
    public class Kullanıcı : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivateGuid { get; set; }
        public bool isAdmin { get; set; }

        public virtual List<BlogYazısı> BlogYazıları { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }

    }
}
