using System.Collections.Generic;

namespace TOEICEssentialWords.Models.Entities
{
    public class Topic : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }

        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}