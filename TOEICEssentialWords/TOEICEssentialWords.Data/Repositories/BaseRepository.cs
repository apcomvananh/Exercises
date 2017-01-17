using System;
using System.Linq;
using System.Linq.Expressions;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Repositories
{
    public interface BaseRepository<T> where T : class, BaseEntity, new()
    {
        IQueryable<T> GetAll();

        IQueryable<T> All { get; }

        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        T GetSingle(int id);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);
    }
}