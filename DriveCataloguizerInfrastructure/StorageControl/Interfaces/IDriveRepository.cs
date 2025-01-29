using DriveCataloguizerModel.Models;
using System.Threading.Tasks;

namespace DriveCataloguizerInfrastructure.StorageControl.Interfaces
{
    public interface IDriveRepository
    {
        IRepository<DriveInformation> Database { get; }
        void Dispose();
        void Commit();
        Task CommitAsync();
    }
}
