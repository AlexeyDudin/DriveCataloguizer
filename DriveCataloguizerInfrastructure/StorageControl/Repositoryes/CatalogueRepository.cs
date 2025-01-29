using System.Threading.Tasks;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerModel.Models;

namespace DriveCataloguizerInfrastructure.StorageControl.Repositoryes
{
    public class CatalogueRepository : ICatalogueRepository
    {
        public IRepository<CatalogueInformation> Database { get; private set; }
        private readonly EfContext _efContext;

        public CatalogueRepository(EfContext context) 
        {
            Database = new Repository<CatalogueInformation>(context);
            _efContext = context;
        }

        public void Commit() => _efContext.SaveChanges();

        public Task CommitAsync() => _efContext.SaveChangesAsync();

        public void Dispose() => _efContext.Dispose();
    }
}
