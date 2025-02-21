using System.Collections.Generic;
using ProductManagement.Models;

namespace ProductManagement.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
    }
}
