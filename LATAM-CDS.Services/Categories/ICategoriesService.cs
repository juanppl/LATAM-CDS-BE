using LATAM_CDS.AppDbContext.Models;
using LATAM_CDS.AppDbContext.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.Services.Categories
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> GetAllCategories();
    }
}
