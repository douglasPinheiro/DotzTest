using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TesteTecnico.Api.Configurations.Seed;
using TesteTecnico.Domain.Core.Interfaces.Services;

namespace TesteTecnico.Api.Configurations
{
    public static class SeederData
    {
        public static IApplicationBuilder SeedInitialData(IApplicationBuilder app)
        {
            SeedCompaniesData(app);
            SeedCategoriesData(app);
            SeedProductsData(app);

            return app;
        }

        private static void SeedCompaniesData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var companyService = serviceScope.ServiceProvider.GetRequiredService<ICompanyService>();

            if (companyService.Count() == 0)
                foreach (var company in new CompaniesSeed().GetCompanies())
                    companyService.Create(company);
        }

        private static void SeedCategoriesData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var categoryService = serviceScope.ServiceProvider.GetRequiredService<ICategoryService>();

            if (categoryService.CountCategories() == 0)
            {
                foreach (var category in new CategoriesSeed().GetCategories())
                {
                    categoryService.CreateCategory(category);
                    var subCategories = new CategoriesSeed()
                        .GetSubCategories()
                        .Where(d => d.Category.Id == category.Id)
                        .ToList();

                    foreach (var subCategory in subCategories)
                        categoryService.CreateSubCategory(subCategory, category);
                }
            }
        }

        private static void SeedProductsData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var companyService = serviceScope.ServiceProvider.GetRequiredService<ICompanyService>();
            var categoryService = serviceScope.ServiceProvider.GetRequiredService<ICategoryService>();
            var productService = serviceScope.ServiceProvider.GetRequiredService<IProductService>();

            if (productService.Count() == 0)
            {
                foreach (var product in new ProductsSeed().GetProducts())
                {
                    var company = companyService.GetById(product.Company.Id);
                    var subcategory = categoryService.GetSubCategoryById(product.SubCategory.Id);
                    product.Company = company;
                    product.SubCategory = subcategory;

                    productService.Create(product);
                }
            }
        }
    }
}
