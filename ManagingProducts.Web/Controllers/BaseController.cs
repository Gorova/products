using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ManagingProduct.Bootstrap;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.Common.IDTO;
using ManagingProducts.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;

namespace ManagingProducts.Web.Controllers
{
    public abstract class BaseController<TDto> : Controller where TDto : class, IBaseDto
    {
        protected IKernel kernel;
        protected IHandler<TDto> handler;
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected UserManager<ApplicationUser> UserManager { get; set; }

        protected BaseController()
        {
            kernel = Kernel.Initialize();
            handler = kernel.Get<IHandler<TDto>>();
        }

        public int GetTotalQuantity(List<OperationDto> operations)
        {
            var quantity = 0;

            var intoQuantity = operations.Where(i => i.TypeOfOperation.Name == "Arrival of goods").Select(i => i.Quantity).Sum();
            var outQuantity = operations.Where(i => i.TypeOfOperation.Name == "Goods consumption").Select(i => i.Quantity).Sum();
            quantity = intoQuantity - outQuantity;

            return quantity;
        }

        public List<OperationDto> GetOperations(int id)
        {
            return kernel.Get<IHandler<OperationDto>>().GetAll().Where(i => i.ProductId == id).ToList();
        }
    }
}