using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Proj_BTL_NguyenMinhQuang_2018600016.Models
{
    public partial class Flute : DbContext
    {
        public Flute()
            : base("name=Flute")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAccount> tblAccounts { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblProduct> tblProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAccount>()
                .Property(e => e.AccountName)
                .IsUnicode(false);

            modelBuilder.Entity<tblAccount>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tblAccount>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblCategory>()
                .HasMany(e => e.tblProducts)
                .WithRequired(e => e.tblCategory)
                .WillCascadeOnDelete(false);
        }
    }
}
