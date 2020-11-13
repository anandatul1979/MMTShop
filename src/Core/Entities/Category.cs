using System;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Category : IEquatable<Category>
    {
        [JsonPropertyName("Id")]
        public int CategoryId { get; set; }

        [JsonPropertyName("Name")]
        public string CategoryName { get; set; }

        public bool Equals(Category other)
        {
            return other.CategoryId == CategoryId
                && other.CategoryName == CategoryName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CategoryId, CategoryName);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Category);
        }
    }
}
