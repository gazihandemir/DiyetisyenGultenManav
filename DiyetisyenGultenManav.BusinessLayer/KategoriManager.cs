﻿using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.BusinessLayer
{
    public class KategoriManager
    {

        private DataAccessLayer.EntityFramework.Repository<Kategori> repo_kategori = new DataAccessLayer.EntityFramework.Repository<Kategori>();
        public List<Kategori> GetKategoriler()
        {
            return repo_kategori.List();
        }
    }
}