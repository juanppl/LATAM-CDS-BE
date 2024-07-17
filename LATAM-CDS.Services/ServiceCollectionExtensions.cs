using LATAM_CDS.Services.Categories;
using LATAM_CDS.Services.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection service, IConfiguration configuration)
        {
            return service
                .AddTransient<ICategoriesService, CategoriesService>()
                .AddTransient<IProductsService, ProductsService>()
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<CommonRequiredServices>();
        }
    }
}
