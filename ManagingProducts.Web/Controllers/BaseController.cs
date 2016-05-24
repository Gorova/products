using System.Web.Mvc;
using ManagingProduct.Bootstrap;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.IDTO;
using Ninject;

namespace ManagingProducts.Web.Controllers
{
    public class BaseController<TDto> : Controller where TDto : class, IBaseDto
    {
        protected IKernel kernel;
        protected IHandler<TDto> handler;

        protected BaseController()
        {
            kernel = Kernel.Initialize();
            handler = kernel.Get<IHandler<TDto>>();
        }
    }
}