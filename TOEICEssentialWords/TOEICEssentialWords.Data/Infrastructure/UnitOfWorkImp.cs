using System;

namespace TOEICEssentialWords.Data.Infrastructure
{
    public class UnitOfWorkImp : UnitOfWork
    {
        private readonly DataFactory _dataFactory;
        private EssentialWordsContext _dataContext;

        public UnitOfWorkImp(DataFactory dataFactory)
        {
            _dataFactory = dataFactory;
        }

        public EssentialWordsContext DbContext
        {
            get
            {
                return _dataContext ?? (_dataContext = _dataFactory.Init());
            }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}