using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InterfaceToCollection.Model
{
    public partial class CustomcollectionContext : DbContext
    {
        public CustomcollectionContext()
        {
        }

        public CustomcollectionContext(DbContextOptions<CustomcollectionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AptRenovationItem> AptRenovationItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=den1.mssql7.gear.host;Database=customcollection;User Id=customcollection;PWD=Ob9J__6p9ta9;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AptRenovationItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.DateChanged)
                    .HasColumnName("dateChanged")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedCost)
                    .HasColumnName("estimatedCost")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");
            });
        }
    }
}
