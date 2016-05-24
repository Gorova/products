using ManagingProducts.DAL.IRepositories;

namespace ManagingProducts.BLL.Handler
{
    public abstract class BaseHandler
    {
        protected IRepository repository;

        protected BaseHandler(IRepository repository)
        {
            this.repository = repository;
        }
    }
}

