using System.Threading.Tasks;
using DriveCataloguizerInfrastructure.StorageControl.Interfaces;
using DriveCataloguizerModel.Models;

namespace DriveCataloguizerInfrastructure.StorageControl.Repositoryes
{
    public class DriveRepository : IDriveRepository
    {
        public IRepository<DriveInformation> Database { get; private set; }
        private readonly EfContext _efContext;

        public DriveRepository(EfContext efContext)
        {
            _efContext = efContext;
            Database = new Repository<DriveInformation>(efContext);
        }

        public void Commit() => _efContext.SaveChanges();

        public Task CommitAsync() => _efContext.SaveChangesAsync();

        public void Dispose() => _efContext.Dispose();
    }
}
