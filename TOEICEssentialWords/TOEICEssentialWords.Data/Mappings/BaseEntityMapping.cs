using System.Data.Entity.ModelConfiguration;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class BaseEntityMapping<T> : EntityTypeConfiguration<T> where T : class, BaseEntity
    {
        public BaseEntityMapping()
        {
            HasKey(e => e.Id);
        }
    }
}