using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ManagingProducts.Common.DTO;
using ManagingProducts.Web.ViewModel;

namespace ManagingProducts.Web.Controllers
{
    public class TypeOfOperationController : BaseController<TypeOfOperationDto>
    {
        // GET: TypeOfOperation
        public JsonResult Get()
        {
            var typeOfOperationDto = handler.GetAll();
            var typeOfOperationViewModel =
                Mapper.Map<IEnumerable<TypeOfOperationDto>, IEnumerable<TypeOfOperationViewModel>>(typeOfOperationDto);

            return Json(typeOfOperationViewModel, JsonRequestBehavior.AllowGet);
        }
    }
}