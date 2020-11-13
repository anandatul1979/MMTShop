using Core.Entities;
using System.Collections.Generic;

namespace TestUtil.Mothers
{
    public static class CategorySamples
    {
        public static IEnumerable<Category> All => new[]
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "First Category"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Second Category"
            }
        };
    }
}
