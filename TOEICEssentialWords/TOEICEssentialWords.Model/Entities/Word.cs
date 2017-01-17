﻿using TOEICEssentialWords.Model.Enums;

namespace TOEICEssentialWords.Model.Entities
{
    public class Word : BaseEntity
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