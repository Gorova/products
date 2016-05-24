using AutoMapper;
using ManagingProducts.Common.DTO;
using ManagingProducts.DAL.Entities;

namespace ManagingProduct.Bootstrap
{
    public class AutomapperDtoConfiguration
    {
        public static void RegisterDtoMapping()
        {
            RegisterDtoToEntity();
            RegisterEntityToDto();
        }

        private static void RegisterEntityToDto()
        {
            Mapper.CreateMap<Operation, OperationDto>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<TypeOfOperation, TypeOfOperationDto>();
            Mapper.CreateMap<User, UserDto>();
        }

        private static void RegisterDtoToEntity()
        {
            Mapper.CreateMap<OperationDto, Operation>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<TypeOfOperationDto, TypeOfOperation>();
            Mapper.CreateMap<UserDto, User>();
        }
    }
}
