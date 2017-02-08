using System.Collections.Generic;
using System.ComponentModel;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class DefinitionViewModel
    {
        public int Id { get; set; }

        [DisplayName("Definition")]
        public string Name { get; set; }

        public string Example { get; set; }

        public int WordId { get; set; }
    }

    public class DefinitionListViewModel
    {
        public int WordId { get; set; }

        public IList<DefinitionViewModel> Definitions { get; set; }
    }
}