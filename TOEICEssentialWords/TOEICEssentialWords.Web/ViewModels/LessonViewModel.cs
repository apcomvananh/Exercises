using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class LessonViewModel
    {
        public string Name { get; set; }
        public string TopicName { get; set; }

        public IEnumerable<Word> WordsToLearn { get; set; }

        public IEnumerable<Lesson> RelatedLessons { get; set; }
    }
}