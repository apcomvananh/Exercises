using System;
using System.Linq;
using System.Linq.Expressions;
using TOEICEssentialWords.Data.Infrastructure;
using TOEICEssentialWords.Data.Repositories;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Service.Implementations
{
    public class BaseServiceImp<T> : BaseService<T> where T : class, BaseEntity, new()
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly BaseRepository<T> _repository;

        public BaseServiceImp(UnitOfWork unitOfWork, BaseRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            return _repository.AllIncluding(includeProperties);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _repository.FindBy(predicate);
        }

        public T GetSingle(int id)
        {
            return _repository.GetSingle(id);
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Edit(T entity)
        {
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }
    }
}