using TOEICEssentialWords.Models.Enums;

namespace TOEICEssentialWords.Models.Entities
{
    public class Word
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public WordType WordType { get; set; }

        public string Mean { get; set; }

        public string Examples { get; set; }

        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}