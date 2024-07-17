using LATAM_CDS.AppDbContext.Dto;
using LATAM_CDS.AppDbContext.Models;
using LATAM_CDS.Services;
using LATAM_CDS.Services.Products;
using Microsoft.EntityFrameworkCore;

namespace TestProject
{
    [TestClass]
    public class ProductServiceTest
    {
        [TestMethod]
        public async Task TryToGetAllProducts()
        {
            var context = ApplicationDbContextInMemory.Get();
            var mapper = ApplicationDbContextInMemory.GetMapper();

            context.Product.Add(new Product()
            {
                FullName = "Laptop",
                DisplayName = "ASUS ROG TEST",
                Description = "Gaming laptop with high performance",
                Price = 10.90M,
                IsActive = true,
                CreationDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                CategoryId = 2,
                AvailableQty = 1,
                LastModificationDate = DateTime.Now,
                IsDeleted = false
            });
            await context.SaveChangesAsync();

            var commonServices = new CommonRequiredServices(context, mapper);
            var productService = new ProductsService(commonServices);

            var response = await productService.GetListOfProducts();

            Assert.AreEqual(1, response.Count());
        }


        [TestMethod]
        public async Task TryToCreateProduct()
        {
            var context = ApplicationDbContextInMemory.Get();
            var mapper = ApplicationDbContextInMemory.GetMapper();
            var product = new ProductDto()
            {
                FullName = "Laptop",
                DisplayName = "ASUS ROG TEST",
                Description = "Gaming laptop with high performance",
                Price = 10.90M,
                CreationDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                CategoryId = 2,
                AvailableQty = 1,
                LastModificationDate = DateTime.Now
            };

            var commonServices = new CommonRequiredServices(context, mapper);
            var productService = new ProductsService(commonServices);

            await productService.CreateNewProduct(product);
            var response = await context.Product.CountAsync();

            Assert.AreEqual(1, response);
        }

        [TestMethod]
        public async Task TryToRemoveProduct()
        {
            var context = ApplicationDbContextInMemory.Get();
            var mapper = ApplicationDbContextInMemory.GetMapper();
            var product = new Product()
            {
                FullName = "Laptop",
                DisplayName = "ASUS ROG TEST",
                Description = "Gaming laptop with high performance",
                Price = 10.90M,
                CreationDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                CategoryId = 2,
                AvailableQty = 1,
                LastModificationDate = DateTime.Now
            };
            await context.AddAsync(product);
            await context.SaveChangesAsync();
            var productId = product.Id;

            var commonServices = new CommonRequiredServices(context, mapper);
            var productService = new ProductsService(commonServices);

            await productService.RemoveProduct(productId);

            var deletedProduct = await context.Product.FirstOrDefaultAsync(p => p.Id == productId);

            Assert.IsTrue(deletedProduct.IsDeleted);
        }

        [TestMethod]
        public async Task TryToModifyProduct()
        {
            var context = ApplicationDbContextInMemory.Get();
            var mapper = ApplicationDbContextInMemory.GetMapper();
            var product = new Product()
            {
                FullName = "Laptop",
                DisplayName = "ASUS ROG TEST",
                Description = "Gaming laptop with high performance",
                Price = 10.90M,
                CreationDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                CategoryId = 2,
                AvailableQty = 1,
                LastModificationDate = DateTime.Now
            };
            await context.AddAsync(product);
            await context.SaveChangesAsync();

            var productId = product.Id;
            var updatedProduct = new ProductDto()
            {
                Id = productId,
                FullName = "Laptop",
                DisplayName = "Alienware M16",
                Description = "Gaming laptop with high performance",
                Price = 10.90M,
                CreationDate = DateTime.Now,
                ExpireDate = DateTime.Now,
                CategoryId = 2,
                AvailableQty = 1,
                LastModificationDate = DateTime.Now
            };

            var commonServices = new CommonRequiredServices(context, mapper);
            var productService = new ProductsService(commonServices);

            await productService.EditProduct(updatedProduct);
            var finalProduct = await context.Product.FindAsync(productId);

            Assert.AreEqual(updatedProduct.DisplayName, finalProduct.DisplayName);
        }
    }

}