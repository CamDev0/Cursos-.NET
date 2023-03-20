using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Curso_ASP.Models;

public partial class PubContext : DbContext
{
    public PubContext()
    {
    }

    public PubContext(DbContextOptions<PubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = CAM\\CAMSQLSERVER; Database=PUB; user Id = sa; password = 3203904100; TrustServerCertificate= true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Brandld).HasName("PK__Brand__DAD651BEF3C0EE37");

            entity.ToTable("Brand");

            entity.Property(e => e.Brandld).ValueGeneratedNever();
            entity.Property(e => e.NameBrand).HasMaxLength(40);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryld).HasName("PK__Category__1906218DB7D912F8");

            entity.ToTable("Category");

            entity.Property(e => e.Categoryld).ValueGeneratedNever();
            entity.Property(e => e.Fkbrandld).HasColumnName("FKBrandld");
            entity.Property(e => e.NameCaty).HasMaxLength(40);

            entity.HasOne(d => d.FkbrandldNavigation).WithMany(p => p.Categories)
                .HasForeignKey(d => d.Fkbrandld)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Category__FKBran__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
