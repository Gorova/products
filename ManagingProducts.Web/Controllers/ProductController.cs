using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ManagingProduct.Bootstrap;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.Web.ViewModel;
using Newtonsoft.Json;
using Ninject;

namespace ManagingProducts.Web.Controllers
{
    public class ProductController : BaseController<ProductDto>
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Get()
        {
            var viewModel = Mapper.Map<IEnumerable<ProductDto>, IEnumerable<ProductViewModel>>(handler.GetAll());

            return JsonConvert.SerializeObject(viewModel);
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
            var product = handler.Get(viewModel.Id);


            var dto = Mapper.Map<ProductViewModel, ProductDto>(viewModel);
            handler.Delete(dto.Id);
        }
        [HttpPost]
        public string GetStatisticProduct(int id)
        {
           // var id = Int32.Parse(productId);
            
            var product = handler.Get(id);
            var productStatisticViewModel = new ProductStatisticViewModel();
            productStatisticViewModel.Product = product.Name;
            var price = product.Price;
            productStatisticViewModel.Price = price;
            var operations = kernel.Get<IHandler<OperationDto>>().GetAll().Where(i => i.ProductId == id).ToList();
            var quantity = GetTotalQuantity(operations);
            productStatisticViewModel.TotalQuantity = quantity;
            productStatisticViewModel.TotalCost = quantity * price;
            
            return JsonConvert.SerializeObject(productStatisticViewModel);
        }

        private int GetTotalQuantity(List<OperationDto> operations )
        {
            var quantity = 0;
            
            var intoQuantity = operations.Where(i => i.TypeOfOperation.Name == "into").Select(i => i.Quantity).Sum();
            var outQuantity = operations.Where(i => i.TypeOfOperation.Name == "out").Select(i => i.Quantity).Sum();
            quantity = intoQuantity - outQuantity;

            return quantity;
        }
    }
            
}

