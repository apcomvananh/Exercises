using System;
using System.Collections.Generic;

namespace TOEICEssentialWords.Models.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }

        public string FirtName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid Salt { get; set; }

        public bool IsLocked { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}