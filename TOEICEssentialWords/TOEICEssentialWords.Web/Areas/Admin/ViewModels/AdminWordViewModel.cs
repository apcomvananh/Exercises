using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Enums;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class AdminWordViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Word")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Word Class")]
        public WordType WordType { get; set; }

        [DisplayName("BrE")]
        public string BrEPronoun { get; set; }

        [DisplayName("BrE Sound")]
        public string BrESoundUrl { get; set; }

        [DisplayName("NAmE")]
        public string NAmEPronoun { get; set; }

        [DisplayName("NAmE Sound")]
        public string NAmESoundUrl { get; set; }

        [Required]
        [DisplayName("Parent Lesson")]
        public int LessonId { get; set; }

        public string LessonName { get; set; }

        public IList<SelectListItem> AllLessons { get; set; }
    }

    public class AdminWordListViewModel
    {
        public IList<AdminWordViewModel> Words { get; set; }
    }
}