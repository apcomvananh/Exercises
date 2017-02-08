using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class WordViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WordType { get; set; }

        public string BrEPronoun { get; set; }

        public string BrESoundUrl { get; set; }

        public string NAmEPronoun { get; set; }

        public string NAmESoundUrl { get; set; }

        public bool HasPronound { get; set; }

        public IList<Definition> Definitions { get; set; }
    }
}