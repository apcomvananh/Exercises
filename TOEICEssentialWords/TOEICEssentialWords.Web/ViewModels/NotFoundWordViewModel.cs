using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class NotFoundWordViewModel
    {
        public string KeyWord { get; set; }

        public IList<Word> NearestResults { get; set; }
    }
}