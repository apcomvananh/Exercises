using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Mappings
{
    public class UserMapping : BaseEntityMapping<User>
    {
        public UserMapping()
        {
            Property(u => u.FirtName);
            Property(u => u.LastName);
            Property(u => u.UserName);
            Property(u => u.Password);
            Property(u => u.Salt);
            Property(u => u.DateCreated);

            ToTable("User");

            HasMany(u => u.Roles).WithMany(r => r.Users)
                .Map(t => t.ToTable("UserRole").MapLeftKey("UserId").MapRightKey("RoleId"));
        }
    }
}