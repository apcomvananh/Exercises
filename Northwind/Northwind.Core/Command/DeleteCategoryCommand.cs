namespace Northwind.Core.Command
{
    using System;
    using Fanex.Data.Repository;

    public class DeleteCategoryCommand : NonQueryCommand
    {
        public int CategoryId { get; set; }

        public override string GetSettingKey() => "DeleteCategory";

        public override bool IsValid() => CategoryId > 0;
    }
}