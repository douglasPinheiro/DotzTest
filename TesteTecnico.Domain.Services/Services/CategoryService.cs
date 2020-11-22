using System;
using TesteTecnico.Domain.Core.Interfaces;
using TesteTecnico.Domain.Core.Interfaces.Services;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Domain.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int CountCategories()
        {
            return _unitOfWork.Categories.Count();
        }

        public Category CreateCategory(Category category)
        {
            category.CreatedAt = DateTime.Now;
            _unitOfWork.Categories.Add(category);
            _unitOfWork.SaveChanges();
            return category;
        }

        public SubCategory CreateSubCategory(SubCategory subCategory, Category category)
        {
            subCategory.CreatedAt = DateTime.Now;
            subCategory.Category = category;
            _unitOfWork.SubCategories.Add(subCategory);
            _unitOfWork.SaveChanges();
            return subCategory;
        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.Categories.GetById(id);
        }

        public SubCategory GetSubCategoryById(int id)
        {
            return _unitOfWork.SubCategories.GetById(id);
        }
    }
}
