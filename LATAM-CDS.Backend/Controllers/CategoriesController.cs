using LATAM_CDS.AppDbContext.Dto;
using LATAM_CDS.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LATAM_CDS.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet("get-list-of-categories")]
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await _categoriesService.GetAllCategories();
        }
    }
}
