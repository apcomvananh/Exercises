namespace Northwind.Core.Repositories
{
    using Model;
    using System.Collections.Generic;

    public interface CategoryRepository
    {
        IEnumerable<Category> QueryCategories();

        void AddCategory(Category category);
    }
}