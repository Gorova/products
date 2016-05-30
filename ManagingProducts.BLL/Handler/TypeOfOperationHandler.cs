using System.Collections.Generic;
using AutoMapper;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.DAL.Entities;
using ManagingProducts.DAL.IRepositories;

namespace ManagingProducts.BLL.Handler
{
    public class TypeOfOperationHandler : BaseHandler, IHandler<TypeOfOperationDto>
    {
        public TypeOfOperationHandler(IRepository repository)
            : base(repository)
        {
        }
          
        public IEnumerable<TypeOfOperationDto> GetAll()
        {
            return Mapper.Map<IEnumerable<TypeOfOperation>, IEnumerable<TypeOfOperationDto>>(repository.GetAll<TypeOfOperation>());
        }

        public TypeOfOperationDto Get(int id)
        {
            return Mapper.Map<TypeOfOperation, TypeOfOperationDto>(repository.Get<TypeOfOperation>(id));
        }

        public void Add(TypeOfOperationDto typeOfOperationDto)
        {
            var typeOfOperation = Mapper.Map<TypeOfOperationDto, Operation>(typeOfOperationDto);

            repository.Add(typeOfOperation);
            repository.Save();
        }

        public void Update(TypeOfOperationDto typeOfOperationDto)
        {
            var typeOfOperation = repository.Get<Operation>(typeOfOperationDto.Id);
            
            Mapper.Map(typeOfOperationDto, typeOfOperation);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete<TypeOfOperation>(id);
            
            repository.Save();
        }
    }
}
