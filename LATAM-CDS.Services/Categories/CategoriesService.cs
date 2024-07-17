using LATAM_CDS.AppDbContext.Models;
using LATAM_CDS.AppDbContext.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.Services.Categories
{
    public class CategoriesService : QueryServiceBase, ICategoriesService
    {
        public CategoriesService(CommonRequiredServices commonRequiredServices) : base(commonRequiredServices)
        {
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await Context.Category.ToListAsync();
            return ObjectMapper.Map<List<CategoryDto>>(categories);
        }
    }
}
