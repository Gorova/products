using System.Data.Entity;
using System.Linq;
using ManagingProducts.DAL.IRepositories;

namespace ManagingProducts.DAL.Repositories
{
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public T Get<T>(int id) where T : class 
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Add<T>(T data) where T : class
        {
            dbContext.Set<T>().Add(data);
        }

        public void Delete<T>(int id) where T : class
        {
            var data = dbContext.Set<T>().Find(id);
            dbContext.Set<T>().Remove(data);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
