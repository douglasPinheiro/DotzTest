using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Category CreateCategory(Category category);

        SubCategory CreateSubCategory(SubCategory subCategory, Category category);

        Category GetCategoryById(int id);

        SubCategory GetSubCategoryById(int id);

        int CountCategories();
    }
}
