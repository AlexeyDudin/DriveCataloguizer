using System;
using DriveCataloguizerInfrastructure.StorageControl;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerInfrastructure.StorageControl.Repositoryes;
using DriveCataloguizerModels.Handlers;
using DriveCataloguizerModels.Interfaces;
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
            RegisterHandlers(services, resolver);
            RegisterViewModels(services, resolver);
        }

        private static void RegisterHandlers(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            var catalogueRepository = resolver.GetService<ICatalogueRepository>();
            var driveRepository = resolver.GetService<IDriveRepository>();
            services.Register<ICatalogueHandler>(() => new CatalogueHandler(catalogueRepository));
            services.Register<IDriveHandler>(() => new DriveHandler(driveRepository));
        }

        private static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
        {
            var catalogueHandler = resolver.GetService<ICatalogueHandler>();
            var driveHandler = resolver.GetService<IDriveHandler>();
            services.Register<ICataloguesViewModel>(() => new CataloguesViewModel(catalogueHandler, driveHandler));
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
