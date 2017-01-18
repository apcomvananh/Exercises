using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class RoleMapping : BaseEntityMapping<Role>
    {
        public RoleMapping()
        {
            Property(r => r.Name);

            ToTable("Role");
        }
    }
}