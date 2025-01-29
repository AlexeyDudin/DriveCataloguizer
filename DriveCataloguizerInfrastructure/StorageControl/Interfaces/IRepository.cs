using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Security.Principal;
using System;

namespace DriveCataloguizerInfrastructure.StorageControl.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void LoadDb();
        void Add(T entity);
        void Delete(T entity);
        long Count { get; }
        void Commit();

        ObservableCollection<T> Local { get; }
        ObservableCollection<T> Where(Expression<Func<T, bool>> predicate);
        ObservableCollection<T> Where(Expression<Func<T, bool>> predicate, Expression<Func<T, string>> order);
    }
}
