using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Service.Interfaces
{
    public interface WorkService : BaseService<Word>
    {
        Word GetBySlug(string slug);
    }
}