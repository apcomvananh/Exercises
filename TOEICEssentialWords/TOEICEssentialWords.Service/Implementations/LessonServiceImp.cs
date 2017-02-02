using System.Linq;
using TOEICEssentialWords.Data.Infrastructure;
using TOEICEssentialWords.Data.Repositories;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Service.Implementations
{
    public class LessonServiceImp : BaseServiceImp<Lesson>, LessonService
    {
        public LessonServiceImp(UnitOfWork unitOfWork, BaseRepository<Lesson> repository)
            : base(unitOfWork, repository)
        {
        }

        public Lesson GetBySlug(string slug)
        {
            return FindBy(w => w.Slug.Equals(slug)).FirstOrDefault();
        }
    }
}