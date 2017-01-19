using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Web.ViewModels
{
    public class LessonViewModel
    {
        public Lesson Lesson { get; set; }
        public IEnumerable<Word> WordsToLearn { get; set; }
    }
}