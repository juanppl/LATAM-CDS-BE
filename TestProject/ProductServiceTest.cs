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
            context.Add(new Product()
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
            });
            context.SaveChanges();
            var context2 = ApplicationDbContextInMemory.Get();
            var commonServices = new CommonRequiredServices(context2, mapper);
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
            context.SaveChanges();
            var context2 = ApplicationDbContextInMemory.Get();
            var commonServices = new CommonRequiredServices(context2, mapper);
            var productService = new ProductsService(commonServices);
            await productService.CreateNewProduct(product);
            var response = await context.Product.ToArrayAsync();
            Assert.AreEqual(1, response.Count());
        }

        [TestMethod]
        public async Task TryToRemoveUser()
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
            context.Add(product);
            context.SaveChanges();
            var productId = product.Id;

            var context2 = ApplicationDbContextInMemory.Get();
            var commonServices = new CommonRequiredServices(context2, mapper);
            var productService = new ProductsService(commonServices);
            await productService.RemoveProduct(productId);

            var response = await context.Product.FirstOrDefaultAsync(p => p.Id == productId);
            Assert.AreEqual(true, response.IsDeleted);
        }

        [TestMethod]
        public async Task TryToModifyUser()
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
            context.Add(product);
            context.SaveChanges();

            var productId = product.Id;
            var product2 = new ProductDto()
            {
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
            var context2 = ApplicationDbContextInMemory.Get();
            var commonServices = new CommonRequiredServices(context2, mapper);
            var productService = new ProductsService(commonServices);
            await productService.EditProduct(product2);
            var finalProduct = await context2.Product.FirstOrDefaultAsync();
            Assert.AreEqual(finalProduct.DisplayName, product2.DisplayName);
        }
    }
}