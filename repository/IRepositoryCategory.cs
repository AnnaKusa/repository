using System;
using System.Collections.Generic;

namespace repository
{
    public interface IRepositoryCategory : IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void DeleteCategory(int id);
        void UpdateCategory(Category category);
        void Save();
    }
}
