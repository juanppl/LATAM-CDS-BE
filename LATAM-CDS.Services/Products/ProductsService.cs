using LATAM_CDS.AppDbContext.Dto;
using LATAM_CDS.AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LATAM_CDS.Services.Products
{
    public class ProductsService : QueryServiceBase, IProductsService
    {
        public ProductsService(CommonRequiredServices commonRequiredServices) : base(commonRequiredServices)
        {
        }

        public async Task<List<ProductDto>> GetListOfProducts()
        {
            var products = await Context.Product
                .Include(p => p.Category)
                .Where(p => !p.IsDeleted)
                .ToListAsync();

            return ObjectMapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> CreateNewProduct(ProductDto product)
        {
            var newProduct = ObjectMapper.Map<Product>(product);
            newProduct.IsActive = true;
            Context.Add(newProduct);
            await Context.SaveChangesAsync();

            return ObjectMapper.Map<ProductDto>(newProduct);
        }

        public async Task<ProductDto> EditProduct(ProductDto product)
        {
            var foundProduct = await Context.Product.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (foundProduct == null) throw new Exception($"Product with id={product.Id} not found");

            ObjectMapper.Map(product, foundProduct);
            foundProduct.LastModificationDate = DateTime.Now;
            Context.Update(foundProduct);

            await Context.SaveChangesAsync();

            return ObjectMapper.Map<ProductDto>(foundProduct);
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await Context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            return ObjectMapper.Map<ProductDto>(product);
        }

        public async Task RemoveProduct(int id)
        {
            var product = await Context.Product.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) throw new Exception($"Product with id={id} not found");

            product.IsDeleted = true;
            product.DeletedDate = DateTime.Now;
            product.IsActive = false;
            await Context.SaveChangesAsync();

        }
    }
}
