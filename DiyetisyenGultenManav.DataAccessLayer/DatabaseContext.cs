using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<BlogYazısı> BlogYazıları { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Diet> Dietler { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }

    }
}
