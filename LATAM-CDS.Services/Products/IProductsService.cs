using LATAM_CDS.AppDbContext.Dto;
using LATAM_CDS.AppDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.Services.Products
{
    public interface IProductsService
    {
        Task<List<ProductDto>> GetListOfProducts();
        Task<ProductDto> CreateNewProduct(ProductDto product);
        Task<ProductDto> EditProduct(ProductDto product);
        Task RemoveProduct(int id);
        Task<ProductDto> GetProduct(int id);
    }
}
