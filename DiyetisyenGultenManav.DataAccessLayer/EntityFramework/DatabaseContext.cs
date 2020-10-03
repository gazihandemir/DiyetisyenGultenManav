using DiyetisyenGultenManav.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyetisyenGultenManav.DataAccessLayer.EntityFramework
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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogYazısı>()
                .HasMany(b => b.Yorumlar)
                .WithRequired(y => y.BlogYazısı)
                .WillCascadeOnDelete(true);
        }
    }
}
