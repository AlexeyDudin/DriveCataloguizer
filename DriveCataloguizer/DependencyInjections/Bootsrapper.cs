using DriveCataloguizerInfrastructure.StorageControl;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerInfrastructure.StorageControl.Repositoryes;
using DriveCataloguizerViewModel;
using DriveCataloguizerViewModel.Interfaces;
using Splat;

namespace DriveCataloguizer.DependencyInjections
{
    public static class Bootsrapper
    {
        public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            RegisterDb(services, resolver);
            RegisterViewModels(services, resolver);
        }

        private static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            var catalogueRepository = resolver.GetService<ICatalogueRepository>();
            services.Register<ICataloguesViewModel>(() => new CataloguesViewModel(catalogueRepository));
        }

        private static void RegisterDb(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            services.RegisterLazySingleton(() => new EfContext("Data Source=Database.db"));
            var efContext = resolver.GetService<EfContext>();

            services.Register<ICatalogueRepository>(() => new CatalogueRepository(efContext));
            services.Register<IDriveRepository>(() => new DriveRepository(efContext));
        }
    }
}
