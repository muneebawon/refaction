﻿using RefactorMe.Data.Entities;

namespace RefactorMe.Data.Mappings
{
    public class ProductMap : MappingBase<Product>
    {
        #region Ctor

        public ProductMap()
        {
            this.ToTable("Product");

            // Properties
            this.Property(p => p.Name);
            this.Property(p => p.Price);
            this.Property(p => p.Description);
            this.Property(p => p.DeliveryPrice);

            // Delete list options related on delete products
            this.HasMany(p => p.Options)
                .WithRequired(b => b.Product)
                .HasForeignKey(j => j.ProductId)
                .WillCascadeOnDelete(true);
        }

        #endregion
    }
}
