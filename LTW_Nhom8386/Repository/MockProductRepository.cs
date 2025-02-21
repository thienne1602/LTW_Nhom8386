using ProductManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Laptop" },
            new Category { Id = 2, Name = "Smartphone" }
        };

        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Sản phẩm 1", Price = 100, CategoryId = 1, Description = "Mô tả sản phẩm 1", Category = new Category { Id = 1, Name = "Laptop" } },
            new Product { Id = 2, Name = "Sản phẩm 2", Price = 200, CategoryId = 2, Description = "Mô tả sản phẩm 2", Category = new Category { Id = 2, Name = "Smartphone" } }
        };

        public IEnumerable<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            product.Category = new Category { Id = product.CategoryId, Name = _categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name };
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Description = product.Description;
                existingProduct.Category = new Category { Id = product.CategoryId, Name = _categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name };
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
