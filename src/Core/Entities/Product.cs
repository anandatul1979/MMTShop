using System;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Product : IEquatable<Product>
    {
        [JsonPropertyName("Id")]
        public int ProductId { get; set; }

        [JsonPropertyName("Sku")]
        public string ProductSku { get; set; }

        [JsonPropertyName("Name")]
        public string ProductName { get; set; }

        [JsonPropertyName("Description")]
        public string ProductDescription { get; set; }

        [JsonPropertyName("Price")]
        public decimal ProductPrice { get; set; }

        public bool Equals(Product other)
        {
            return other.ProductId == ProductId 
                && other.ProductSku == ProductSku 
                && other.ProductName == ProductName 
                && other.ProductDescription == ProductDescription 
                && other.ProductPrice == ProductPrice;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, ProductSku, ProductName, ProductDescription, ProductPrice);
        }
    }
}
