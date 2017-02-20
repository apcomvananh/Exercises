namespace Northwind.Web.ViewModels
{
    using Core.Model;
    using System.Collections.Generic;

    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}