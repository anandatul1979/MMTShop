using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.DataAccess;
using Core.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProduct _featuredProducts;

        public ProductController(ILogger<ProductController> logger, IProduct featuredProducts)
        {
            _logger = logger;
            _featuredProducts = featuredProducts;
        }

        [HttpGet]
        [Route("featured")]
        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            try
            {
                return await _featuredProducts.GetFeaturedProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while getting featured products");
                throw ex;
            }
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                return await _featuredProducts.GetProductsByCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while getting products by category id");
                throw ex;
            }
        }
    }
}
