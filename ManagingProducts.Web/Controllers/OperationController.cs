using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.DAL.Entities;
using ManagingProducts.Web.ViewModel;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Ninject;

namespace ManagingProducts.Web.Controllers
{
    
    public class OperationController : BaseController<OperationDto>
    {
       
        public string GetFormOperatin()
        {
            var operationViewModel = new OperationViewModel();


            return JsonConvert.SerializeObject(operationViewModel);
        }

        [HttpPost]
        public void CreateOperation(string productId, string quantity, string typeOfOperation)
        {
            if (ModelState.IsValid)
            {
                var operationViewModel = InitializeOperationViewModel(productId, quantity, typeOfOperation);
                var operationDto = Mapper.Map<OperationViewModel, OperationDto>(operationViewModel);
                handler.Add(operationDto);
                }
            else
            {
                RedirectToAction("Index","Home");
            }
        }

        private OperationViewModel InitializeOperationViewModel(string productId, string quantity, string typeOfOperation)
        {
            var productQuantity = Int32.Parse(quantity);
            var prodId = Int32.Parse(productId);
            var operationViewModel = new OperationViewModel();
            var currentUser = User.Identity.GetUserName();
            
            operationViewModel.ProductId = prodId;
            operationViewModel.DateOfOperation = DateTime.Now;
            
            var type = GetTypeOfOperation(typeOfOperation);
            operationViewModel.TypeOfOperationId = type.Id;
            operationViewModel.Quantity = productQuantity;
            var userDto = kernel.Get<IHandler<UserDto>>().GetAll().FirstOrDefault(i => i.Login == currentUser);
            operationViewModel.UserId = userDto.Id;

            return operationViewModel;
        }

        private TypeOfOperationDto GetTypeOfOperation(string typeOfOperation)
        {
            return kernel
                    .Get<IHandler<TypeOfOperationDto>>()
                    .GetAll()
                    .FirstOrDefault(i => i.Name == typeOfOperation);
        }
        
        public  JsonResult SetQuantity(string productId, string quantity, string typeOfOperation)
        {
            var id = Int32.Parse(productId);
            var count = Int32.Parse(quantity);

            var operatins = GetOperations(id);
            var quan = GetTotalQuantity(operatins);
            var type = GetTypeOfOperation(typeOfOperation);
            if (type.Name == "Goods consumption" && (quan - count) < 0)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}