namespace Northwind.Core.Criteria
{
    using Fanex.Data.Repository;

    public class CategoryByIdCriteria : CriteriaBase
    {
        public int CategoryId { get; set; }

        public override string GetSettingKey() => "GetCategoryById";

        public override bool IsValid() => CategoryId > 0;
    }
}