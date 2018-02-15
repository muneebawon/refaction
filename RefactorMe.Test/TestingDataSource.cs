using RefactorMe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactorMe.Test
{
    public class TestingDataSource
    {
        public static Product InvalidNewProductModel
        {
            get
            {
                return new Product()
                {
                    Id = Guid.Empty,
                    Name = string.Empty,
                    Description = string.Empty
                };
            }
        }

        public static Product ValidNewProductModel
        {
            get
            {
                return new Product()
                {
                    Id = Guid.Empty,
                    Name = "Huawei Mate 10",
                    Description = "New phone come from Huawei",
                    Price = 1000,
                    DeliveryPrice = 99
                };
            }
        }

        public static Product ExistingProductModel
        {
            get
            {
                return ProductModelList.First();
            }
        }

        public static List<Product> ProductModelList
        {
            get
            {
                return Products.Select(x => new Product
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    DeliveryPrice = x.DeliveryPrice
                }).ToList();
            }
        }

        public static List<Product> Products
        {
            get
            {
                return new List<Product>
                {
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 1", Price = 500, DeliveryPrice = 9.99m, Description = "New Product of Huawei" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 2", Price = 600, DeliveryPrice = 9.99m, Description = "New Product of Apple" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 3", Price = 700,  DeliveryPrice = 9.99m, Description = "New Product of LG" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 4", Price = 800, DeliveryPrice = 9.99m, Description = "New Product of Nokia" },
                    new Product() { Id = Guid.NewGuid(), Name = "Phone 5", Price = 900, DeliveryPrice = 9.99m, Description = "New Product of Samsung" },
                };
            }
        }

        public static List<ProductOption> ProductOptions
        {
            get
            {
                return new List<ProductOption>
                {
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[0].Id, Name = "Black", Description = "Option 1" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[0].Id, Name = "Golden", Description = "Option 2"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[1].Id, Name = "Silver", Description = "Option 3"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[1].Id, Name = "White", Description = "Option 4"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[2].Id, Name = "Pink", Description = "Option 5"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[2].Id, Name = "Red", Description = "Option 6"},
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[3].Id, Name = "Green", Description = "Option 7" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[3].Id, Name = "Orange", Description = "Option 8" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[4].Id, Name = "Blue", Description = "Option 9" },
                    new ProductOption() { Id = Guid.NewGuid(), ProductId = Products[4].Id, Name = "Purple", Description = "Option 10" }
                };
            }
        }

    }
}
