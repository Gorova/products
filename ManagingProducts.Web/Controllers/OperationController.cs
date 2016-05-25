using System;
using System.Web.Mvc;
using AutoMapper;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.Web.ViewModel;
using Newtonsoft.Json;
using Ninject;

namespace ManagingProducts.Web.Controllers
{
    public class OperationController : BaseController<OperationDto>
    {
        //????
        public string GetFormOperatin()
        {
            var operationViewModel = new OperationViewModel();

            return JsonConvert.SerializeObject(operationViewModel);
        }

        [HttpPost]//IN PROGRESS
        public void CreateOperation(OperationViewModel operationViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDto = kernel.Get<IHandler<UserDto>>().Get(operationViewModel.UserId);
                var operationDto = Mapper.Map<OperationViewModel, OperationDto>(operationViewModel);
                operationDto.DateOfOperation = DateTime.Now;
                //user - in progress!!!
                
                handler.Add(operationDto);
            }
        }
    }
}