using System.Threading.Tasks;
using DriveCataloguizerModel.Models;

namespace DriveCataloguizerInfrastructure.StorageControl.Interfaces
{
    public interface ICatalogueRepository
    {
        IRepository<CatalogueInformation> Database { get; }
        void Dispose();
        void Commit();
        Task CommitAsync();
    }
}
