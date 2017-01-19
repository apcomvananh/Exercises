using System.Collections.Generic;

namespace TOEICEssentialWords.Model.Entities
{
    public class Lesson : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int LessonNumber { get; set; }

        public int TopicId { get; set; }

        public string DisplayName
        {
            get { return string.Format("{0}. {1}", LessonNumber, Name); }
        }

        public virtual Topic Topic { get; set; }

        public virtual ICollection<Word> WordsToLearn { get; set; }
    }
}