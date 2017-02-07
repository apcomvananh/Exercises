using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class TopicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool HasChild { get; set; }

        public IList<Lesson> Lessons { get; set; }
    }

    public class TopicMenuViewModel
    {
        public IList<TopicViewModel> Topics { get; set; }
    }
}