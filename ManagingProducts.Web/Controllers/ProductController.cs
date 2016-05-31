using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.Web.ViewModel;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Ninject;

namespace ManagingProducts.Web.Controllers
{
    [Authorize]
    public class ProductController : BaseController<ProductDto>
    {
        public ActionResult Index()
        {
            AddNewUser();

            return View();
        }

        public string Get()
        {
            var viewModel = Mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(handler.GetAll());

            return JsonConvert.SerializeObject(viewModel);
        }

        public JsonResult GetSingle(int id)
        {
            var productDto = handler.Get(id);
            var productViewModel = Mapper.Map<ProductDto, ProductViewModel>(productDto);

            return Json(productViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Edit(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Update(dto);
        }

        [HttpPost]
        public void Create(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
                handler.Add(dto);
        }

        [HttpPost]
        public void Delete(ProductViewModel viewModel)
        {
            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Delete(dto.Id);
        }

        public JsonResult GetStatisticProduct(int id)
        {
            var product = handler.Get(id);
            var productStatisticViewModel = new ProductStatisticViewModel();
            
            productStatisticViewModel.Product = product.Name;
            var price = product.Price;
            productStatisticViewModel.Price = price;
            var operations = GetOperations(id);
            var quantity = GetTotalQuantity(operations);
            productStatisticViewModel.TotalQuantity = quantity;
            productStatisticViewModel.TotalCost = quantity * price;
            
            return Json(productStatisticViewModel, JsonRequestBehavior.AllowGet);
        }

        public string GetStatisticOperations(int id)
        { 
            var list = new List<OperationStatisticViewModel>();
            var operations = GetOperations(id);

            foreach (var op in operations)
            {
                var statOperViewModel = new OperationStatisticViewModel();
                statOperViewModel.User = op.User.Login;
                statOperViewModel.CreatingDate = op.DateOfOperation;
                statOperViewModel.Quantity = op.Quantity;
                statOperViewModel.TypeOfOperation = op.TypeOfOperation.Name;
                list.Add(statOperViewModel);
             }

            return JsonConvert.SerializeObject(list);
        }

        public JsonResult CheckUniqueName(ProductViewModel productViewModel)
        {
            var productsDto = handler.GetAll();
            var productDto = productsDto.FirstOrDefault(i => i.Name == productViewModel.Name);
            if (productDto != null)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        private void AddNewUser()
        {
            var userViewModel = new UserViewModel();
            userViewModel.Login = User.Identity.GetUserName();
            var userDto = Mapper.Map<UserViewModel, UserDto>(userViewModel);
            kernel.Get<IHandler<UserDto>>().Add(userDto);
        }
    }
}

