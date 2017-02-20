namespace Northwind.Core.Command
{
    using Fanex.Data.Repository;

    public class UpdateCategoryCommand : NonQueryCommand
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public override string GetSettingKey() => "UpdateCategory";

        public override bool IsValid() => CategoryId > 0 && !string.IsNullOrEmpty(CategoryName);
    }
}