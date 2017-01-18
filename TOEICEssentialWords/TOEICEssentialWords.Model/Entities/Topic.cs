using System.Collections.Generic;

namespace TOEICEssentialWords.Model.Entities
{
    public class Topic : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}