namespace Northwind.Core.Repositories.Implementations
{
    using Fanex.Data;
    using Model;
    using System.Collections.Generic;
    using System;

    public class CategoryRepositoryImp : CategoryRepository
    {
        public void AddCategory(Category category)
        {
            using (var objectDb = new ObjectDb("AddCategory"))
            {
                var parameters = new
                {
                    Name = category.Name,
                    Description = category.Description
                };

                objectDb.ExecuteNonQuery(parameters);
            }
        }

        public IEnumerable<Category> QueryCategories()
        {
            using (var objectDb = new ObjectDb("QueyCategories"))
            {
                var parameters = new
                {
                    Total = 0
                };

                IEnumerable<Category> categories = objectDb.Query<Category>(parameters);
                int numberofCategories = parameters.Total;
                return categories;
            }
        }
    }
}