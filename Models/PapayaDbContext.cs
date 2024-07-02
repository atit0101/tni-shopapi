using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public partial class PapayaDbContext : DbContext
{
    public PapayaDbContext(DbContextOptions<PapayaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<image> images { get; set; }

    public virtual DbSet<product> products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_uca1400_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.category_id).HasColumnType("int(11)");
            entity.Property(e => e.category_name).HasMaxLength(255);
        });

        modelBuilder.Entity<image>(entity =>
        {
            entity.HasKey(e => e.image_id).HasName("PRIMARY");

            entity.ToTable("image");

            entity.HasIndex(e => e.product_id, "product_id");

            entity.Property(e => e.image_id).HasColumnType("int(11)");
            entity.Property(e => e.image_url).HasColumnType("text");
            entity.Property(e => e.product_id).HasColumnType("int(11)");

            entity.HasOne(d => d.product).WithMany(p => p.images)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("image_ibfk_1");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.product_id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.category_id, "category_id");

            entity.Property(e => e.product_id).HasColumnType("int(11)");
            entity.Property(e => e.category_id).HasColumnType("int(11)");
            entity.Property(e => e.product_data).HasColumnType("json");
            entity.Property(e => e.product_name).HasMaxLength(255);

            entity.HasOne(d => d.category).WithMany(p => p.products)
                .HasForeignKey(d => d.category_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
