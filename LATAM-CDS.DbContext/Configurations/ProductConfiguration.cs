using LATAM_CDS.AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.AppDbContext.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCT");
            builder.HasKey(e => e.Id)
                .HasName("PK_PRODUCT");

            builder.Property(e => e.Id)
                .HasColumnName("ID");
            builder.Property(e => e.FullName)
                .HasColumnName("FULL_NAME")
                .HasMaxLength(50);
            builder.Property(e => e.DisplayName)
                .HasColumnName("DISPLAY_NAME")
                .HasMaxLength(50);
            builder.Property(e => e.Description)
                .HasColumnName("DESCRIPTION")
                .HasMaxLength(250);
            builder.Property(e => e.Price)
                .HasColumnName("PRICE");
            builder.Property(e => e.IsActive)
                .HasColumnName("IS_ACTIVE");
            builder.Property(e => e.CreationDate)
                .HasColumnName("CREATION_DATE");
            builder.Property(e => e.ExpireDate)
                .HasColumnName("EXPIRATION_DATE");
            builder.Property(e => e.CategoryId)
                .HasColumnName("CATEGORY_ID");
            builder.Property(e => e.AvailableQty)
                .HasColumnName("AVAILABLE_QTY");
            builder.Property(e => e.LastModificationDate)
                .HasColumnName("LAST_MODIFICATION_DATE");
            builder.Property(e => e.IsDeleted)
                .HasColumnName("IS_DELETED");
            builder.Property(e => e.DeletedDate)
                .HasColumnName("DELETED_DATE");

            builder.HasOne(d => d.Category)
                .WithMany(p => p.Product)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("FK_PRODUCT_CATEGORY")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
