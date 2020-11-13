using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.DataAccess;
using Core.Entities;

namespace Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategory _category;

        public CategoryController(ILogger<CategoryController> logger, ICategory category)
        {
            _logger = logger;
            _category = category;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                return await _category.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occurred while getting all categories");
                throw ex;
            }
        }
    }
}
