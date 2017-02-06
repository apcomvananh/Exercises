using System.Collections.Generic;

namespace TOEICEssentialWords.Model.Entities
{
    public class Lesson : SlugEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LessonNumber { get; set; }

        public int TopicId { get; set; }

        public string Slug { get; set; }

        public string DisplayName => string.Format("{0}. {1}", LessonNumber, Name);

        public virtual Topic Topic { get; set; }

        public virtual ICollection<Word> WordsToLearn { get; set; }
    }
}