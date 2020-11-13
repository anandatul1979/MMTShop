using Core.Entities;
using System.Collections.Generic;

namespace TestUtil.Mothers
{
    public static class ProductSamples
    {
        public static IEnumerable<Product> Featured => new[]
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Featured 1",
                ProductSku = "10001",
                ProductDescription = "Featured 1",
                ProductPrice = 999.99m
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Featured 2",
                ProductSku = "20002",
                ProductDescription = "Featured 2",
                ProductPrice = 999.99m
            }
        };

        public static IEnumerable<Product> OfCategory => new[]
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Featured 1.1",
                ProductSku = "10001",
                ProductDescription = "Featured 1",
                ProductPrice = 999.99m
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Featured 1.2",
                ProductSku = "10002",
                ProductDescription = "Featured 1.2",
                ProductPrice = 999.99m
            }
        };
    }
}
