using System;
using System.Linq;
using TOEICEssentialWords.Data.Infrastructure;
using TOEICEssentialWords.Data.Repositories;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Service.Implementations
{
    public class WorkServiceImp : BaseServiceImp<Word>, WorkService
    {
        public WorkServiceImp(UnitOfWork unitOfWork, BaseRepository<Word> repository)
            : base(unitOfWork, repository)
        {
        }

        public Word GetBySlug(string slug)
        {
            return FindBy(w => w.Slug.Equals(slug)).FirstOrDefault();
        }
    }
}