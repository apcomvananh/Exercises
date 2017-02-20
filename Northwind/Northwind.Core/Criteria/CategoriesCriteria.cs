namespace Northwind.Core.Criteria
{
    using Fanex.Data.Repository;

    public class CategoriesCriteria : CriteriaBase
    {
        public int Total { get; set; }

        public override string GetSettingKey() => "QueryCategories";

        public override bool IsValid() => true;
    }
}