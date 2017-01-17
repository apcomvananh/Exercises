using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TOEICEssentialWords.Data.Infrastructure;
using TOEICEssentialWords.Model.Entities;

namespace TOEICEssentialWords.Data.Repositories
{
    public class BaseRepositoryImp<T> : BaseRepository<T> where T : class, BaseEntity, new()
    {
        private EssentialWordsContext _dataContext;

        protected DataFactory DataFactory { get; private set; }

        protected EssentialWordsContext DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = DataFactory.Init());
            }
        }

        public IQueryable<T> GetAll()
        {
            return DataContext.Set<T>();
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DataContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DataContext.Set<T>().Where(predicate);
        }

        public T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }

        public void Edit(T entity)
        {
            var entry = DataContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = DataContext.Entry(entity);
            entry.State = EntityState.Deleted;
        }
    }
}