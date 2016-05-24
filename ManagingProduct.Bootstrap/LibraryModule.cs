using System.Data.Entity;
using ManagingProducts.BLL.API;
using ManagingProducts.BLL.Handler;
using ManagingProducts.Common.DTO;
using ManagingProducts.DAL;
using ManagingProducts.DAL.IRepositories;
using ManagingProducts.DAL.Repositories;
using Ninject.Modules;


namespace ManagingProduct.Bootstrap
{
    public class LibraryModule : NinjectModule
    {
        public override void Load()
        {
            this.InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            Bind<DbContext>().To<ManagingProductContext>();
            Bind<IRepository>().To<Repository>();
            Bind<IHandler<OperationDto>>().To<OperationHandler>();
            Bind<IHandler<ProductDto>>().To<ProductHandler>();
            Bind<IHandler<TypeOfOperationDto>>().To<TypeOfOperationHandler>();
            Bind<IHandler<UserDto>>().To<UserHandler>();
        }
    }
}
