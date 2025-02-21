using System.Collections.Generic;
using LTW_Nhom8386.Models;
using ProductManagement.Models;
using ProductManagement.Repositories;

namespace LTW_Nhom8386.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public MockCategoryRepository()
        {
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Laptop" },
                new Category { Id = 2, Name = "Smartphone" }
            };
        }

        public IEnumerable<Category> GetAllCategories() => _categories;

        public IEnumerable<Category> GetAll() => _categories;

        public Category GetById(int id) => _categories.FirstOrDefault(c => c.Id == id);
    }
}
