using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace repository
{
    public class CategoryRepository : IRepositoryCategory
    {
        private LocalReportingEntities context;

        public CategoryRepository(LocalReportingEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Category.ToList();
        }

        public void AddCategory(Category category)
        {
            context.Category.Add(category);
        }

        public Category GetCategoryById(int id)
        {
            return context.Category.Find(id);
        }

        public void DeleteCategory(int id)
        {
            context.Category.Remove(GetCategoryById(id));
        }

        public void UpdateCategory(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
 }
