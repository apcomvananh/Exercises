namespace Northwind.Core.Services.Implementations
{
    using Command;
    using Criteria;
    using Fanex.Data.Repository;
    using Model;
    using System.Collections.Generic;
    using System;

    public class CategoryServiceImp : CategoryService
    {
        private DynamicRepository _repository;

        public CategoryServiceImp()
        {
            _repository = new DynamicRepository();
        }

        public void AddCategory(Category category)
        {
            var command = new CreateCategoryCommand
            {
                Name = category.Name,
                Description = category.Description
            };

            _repository.Execute(command);
        }

        public void Delete(int id)
        {
            var command = new DeleteCategoryCommand
            {
                CategoryId = id
            };

            _repository.Execute(command);
        }

        public void Edit(Category category)
        {
            var command = new UpdateCategoryCommand
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                Description = category.Description
            };

            _repository.Execute(command);
        }

        public Category Get(int id)
        {
            var criteria = new CategoryByIdCriteria
            {
                CategoryId = id
            };

            return _repository.Get<Category>(criteria);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _repository.Fetch<Category>(new CategoriesCriteria());
        }
    }
}