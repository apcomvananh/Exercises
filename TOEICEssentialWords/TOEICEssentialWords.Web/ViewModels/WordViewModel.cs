using System.Collections.Generic;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class WordViewModel
    {
        public string Name { get; set; }

        public string WordType { get; set; }

        public string BrEPronoun { get; set; }

        public string NAmEPronoun { get; set; }

        public IList<Definition> Definitons { get; set; }
    }
}