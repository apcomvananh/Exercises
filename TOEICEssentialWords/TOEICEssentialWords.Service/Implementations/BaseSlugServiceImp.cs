using System.Collections.Generic;
using System.Linq;
using TOEICEssentialWords.Data.Infrastructure;
using TOEICEssentialWords.Data.Repositories;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;
using TOEICEssentialWords.Service.Utils;

namespace TOEICEssentialWords.Service.Implementations
{
    public class BaseSlugServiceImp<T> : BaseServiceImp<T>, BaseSlugService<T>
        where T : class, SlugEntity, new()
    {
        public BaseSlugServiceImp(UnitOfWork unitOfWork, BaseRepository<T> repository)
            : base(unitOfWork, repository)
        {
        }

        public IList<T> FindBySlug(string slug)
        {
            return FindBy(t => t.Slug.Contains(slug)).ToList();
        }

        public T GetBySlug(string slug)
        {
            return FindBy(t => t.Slug.Contains(slug)).FirstOrDefault();
        }

        public override void Add(T entity)
        {
            entity.Slug = StringUtils.GenerateSlug(entity.Name, FindBySlug(entity.Name), null);
            base.Add(entity);
        }

        public override void Edit(T entity)
        {
            UpdateSlugFromName(entity);
            base.Edit(entity);
        }

        private void UpdateSlugFromName(T entity)
        {
            var updateSlug = true;

            // Check if slug has changed as this could be an update
            if (!string.IsNullOrEmpty(entity.Slug))
            {
                var entityBySlug = GetBySlug(entity.Slug);
                if (entityBySlug.Id == entity.Id)
                {
                    updateSlug = false;
                }
            }

            if (updateSlug)
            {
                entity.Slug = StringUtils.GenerateSlug(entity.Name, FindBySlug(entity.Slug), entity.Slug);
            }
        }
    }
}