namespace TOEICEssentialWords.Data.Infrastructure
{
    public class DataFactoryImp : Disposable, DataFactory
    {
        private EssentialWordsContext _dataContext;

        public EssentialWordsContext Init()
        {
            return _dataContext ?? (_dataContext = new EssentialWordsContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }
    }
}