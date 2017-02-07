using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class LessonViewModel
    {
        public string Name { get; set; }
        public string TopicName { get; set; }

        public IEnumerable<WordsToLearnViewModel> WordsToLearn { get; set; }

        public IEnumerable<Lesson> RelatedLessons { get; set; }
    }

    public class WordsToLearnViewModel
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string WordClass { get; set; }

        public string Definition { get; set; }

        public IList<string> Examples { get; set; }
    }
}