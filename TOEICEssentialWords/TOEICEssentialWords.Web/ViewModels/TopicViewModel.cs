using System.Collections.Generic;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class TopicViewModel
    {
        public IEnumerable<Model.Entities.Topic> Topics
        {
            get;
            set;
        }
    }
}