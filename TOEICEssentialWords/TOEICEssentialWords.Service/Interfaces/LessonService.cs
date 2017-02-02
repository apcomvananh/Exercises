using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Service.Interfaces
{
    public interface LessonService : BaseService<Lesson>
    {
        Lesson GetBySlug(string slug);
    }
}