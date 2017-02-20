namespace Northwind.Core.Services
{
    using Model;
    using System.Collections.Generic;

    public interface CategoryService
    {
        IEnumerable<Category> GetCategories();

        void AddCategory(Category category);

        void Edit(Category category);

        Category Get(int id);

        void Delete(int id);
    }
}