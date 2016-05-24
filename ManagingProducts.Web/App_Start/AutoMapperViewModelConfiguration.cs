using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ManagingProducts.Common.DTO;
using ManagingProducts.Web.ViewModel;

namespace ManagingProducts.Web.App_Start
{
    public class AutoMapperViewModelConfiguration
    {
        public static void RegisterDtoMapping()
        {
            RegisterViewModelToDto();
            RegisterDtoToViewModel();
        }

        private static void RegisterViewModelToDto()
        {
            Mapper.CreateMap<OperationViewModel, OperationDto>();
            Mapper.CreateMap<ProductViewModel, ProductDto>();
            Mapper.CreateMap<TypeOfOperationViewModel, TypeOfOperationDto>();
            Mapper.CreateMap<UserViewModel, UserDto>();
        }

        private static void RegisterDtoToViewModel()
        {
            Mapper.CreateMap<OperationDto, OperationViewModel>();
            Mapper.CreateMap<ProductDto, ProductViewModel>();
            Mapper.CreateMap<TypeOfOperationDto, TypeOfOperationViewModel>();
            Mapper.CreateMap<UserDto, UserViewModel>();
        }
    }
}