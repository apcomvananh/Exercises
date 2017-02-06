using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class AdminTopicViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }
    }

    public class AdminTopicListViewModel
    {
        public IList<Topic> Topics { get; set; }
    }
}