using System.Linq;

namespace ManagingProducts.DAL.IRepositories
{
    public interface IRepository
    {
        IQueryable<T> GetAll<T>() where T : class;

        T Get<T>(int id) where T : class;

        void Add<T>(T data) where T : class;

        void Delete<T>(int id) where T : class;

        void Save();
    }
}
