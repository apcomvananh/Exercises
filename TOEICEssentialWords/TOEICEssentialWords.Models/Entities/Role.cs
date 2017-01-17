using System.Collections.Generic;

namespace TOEICEssentialWords.Models.Entities
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}