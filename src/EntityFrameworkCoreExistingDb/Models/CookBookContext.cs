using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkCoreExistingDb.Models
{
    public partial class CookBookContext : DbContext
    {

        public CookBookContext(DbContextOptions<CookBookContext> options) : base(options)
        { }
        // The following generated code was replaced by the constructor below
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Data Source=mcnltp173;Initial Catalog=CookBook;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Recipe)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Recipes_Book");
            });
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
    }
}