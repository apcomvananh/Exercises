using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.Areas.Admin.ViewModels
{
    public class AdminLessonViewModel
    {
        public int Id { get; set; }

        [Required]
        public int LessonNumber { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Parent Topic")]
        public int TopicId { get; set; }

        public string TopicName { get; set; }

        public int WordsInLesson { get; set; }

        public IList<SelectListItem> AllTopics { get; set; }
    }

    public class AdminLessonListViewModel
    {
        public string Search { get; set; }

        public IList<AdminLessonViewModel> Lessons { get; set; }
    }
}