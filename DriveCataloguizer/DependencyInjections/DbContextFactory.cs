using DriveCataloguizerInfrastructure.StorageControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DriveCataloguizer.DependencyInjections
{
    public class DbContextFactory : IDesignTimeDbContextFactory<EfContext>
    {
        public EfContext CreateDbContext(string[] args)
        {
            return new EfContext("Data Source=Database.db");
        }
    }
}
