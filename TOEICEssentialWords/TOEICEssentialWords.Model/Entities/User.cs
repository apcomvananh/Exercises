using System;
using System.Collections.Generic;

namespace TOEICEssentialWords.Model.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }

        public string FirtName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Word> WordList { get; set; }
    }
}