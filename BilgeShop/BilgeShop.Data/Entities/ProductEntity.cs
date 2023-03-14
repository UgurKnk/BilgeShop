using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeShop.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; } // ? -> nullable
        public int UnitInStock { get; set; }
        public string ImagePath { get; set; }

        public int CategoryId { get; set; }

        //Relational Property

        public CategoryEntity Category { get; set; }
    }

    public class ProductEntityConfiguration : BaseConfiguration<ProductEntity> 
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired(false);

            builder.Property(x => x.UnitPrice)
                .IsRequired(false);

            builder.Property(x => x.ImagePath)
                .IsRequired(false);

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.UnitInStock)
                .IsRequired();


            // Zorunlu olma kısımları default olarak atanır, yazılmak zorunda değil fakat ben tüm bilgiler bir arada gözüksün, inceleme/hata ayıklama daha kolay olsun diye, önemli olayları yazıyorum.


            base.Configure(builder);
        }
    }
}



// ürün adı zorunlu ve max 50 karakter.

// ürün açıklaması zorunlu olmayabilir.

// ürün fiyatı zorunlu olmayabilir.

// ürün görseli zorunlu olmayabilir.

// kategori id zorunlu.

// unitstock zorunlu.

