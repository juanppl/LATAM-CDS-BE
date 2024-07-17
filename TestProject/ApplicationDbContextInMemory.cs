using AutoMapper;
using LATAM_CDS.AppDbContext;
using LATAM_CDS.Services.Categories;
using LATAM_CDS.Services.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class ApplicationDbContextInMemory
    {
        public static DbAppContext Get()
        {
            var options = new DbContextOptionsBuilder<DbAppContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            return new DbAppContext(options);
        }
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new ProductsProfile());
                options.AddProfile(new CategoriesProfile());
            });
            return config.CreateMapper();
        }
    }
}
