using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using TOEICEssentialWords.Data;
using TOEICEssentialWords.Data.Infrastructure;
using TOEICEssentialWords.Data.Repositories;
using TOEICEssentialWords.Model.Entities;
using TOEICEssentialWords.Service.Implementations;
using TOEICEssentialWords.Service.Interfaces;

namespace TOEICEssentialWords.Web
{
    public static class SimpleInjector
    {
        public static void Start()
        {
            var container = BuildContainer();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static Container BuildContainer()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<DbContext, EssentialWordsContext>(Lifestyle.Scoped);

            container.Register<DataFactory, DataFactoryImp>(Lifestyle.Scoped);

            container.Register<UnitOfWork, UnitOfWorkImp>(Lifestyle.Scoped);

            container.Register<BaseRepository<Topic>, BaseRepositoryImp<Topic>>(Lifestyle.Scoped);
            container.Register<BaseRepository<Lesson>, BaseRepositoryImp<Lesson>>(Lifestyle.Scoped);
            container.Register<BaseRepository<Word>, BaseRepositoryImp<Word>>(Lifestyle.Scoped);
            container.Register<BaseRepository<Definition>, BaseRepositoryImp<Definition>>(Lifestyle.Scoped);
            container.Register<BaseRepository<User>, BaseRepositoryImp<User>>(Lifestyle.Scoped);
            container.Register<BaseRepository<Role>, BaseRepositoryImp<Role>>(Lifestyle.Scoped);

            container.Register<BaseService<Topic>, BaseServiceImp<Topic>>(Lifestyle.Scoped);
            container.Register<BaseService<Lesson>, BaseServiceImp<Lesson>>(Lifestyle.Scoped);
            container.Register<BaseService<Word>, BaseServiceImp<Word>>(Lifestyle.Scoped);
            container.Register<BaseService<Definition>, BaseServiceImp<Definition>>(Lifestyle.Scoped);
            container.Register<BaseService<User>, BaseServiceImp<User>>(Lifestyle.Scoped);
            container.Register<BaseService<Role>, BaseServiceImp<Role>>(Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            return container;
        }
    }
}