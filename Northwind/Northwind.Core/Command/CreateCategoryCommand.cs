namespace Northwind.Core.Command
{
    using System;
    using Fanex.Data.Repository;

    public class CreateCategoryCommand : NonQueryCommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public override string GetSettingKey() => "AddCategory";

        public override bool IsValid() => !string.IsNullOrEmpty(Name);
    }
}