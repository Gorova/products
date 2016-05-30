using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.DAL.Entities;
using ManagingProducts.DAL.IRepositories;

namespace ManagingProducts.BLL.Handler
{
    public class OperationHandler : BaseHandler, IHandler<OperationDto>
    {
        public OperationHandler(IRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<OperationDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Operation>, IEnumerable<OperationDto>>(repository.GetAll<Operation>());
        }

        public OperationDto Get(int id)
        {
            return Mapper.Map<Operation, OperationDto>(repository.Get<Operation>(id));
        }

        public void Add(OperationDto operationDto)
        {
            var operation = Mapper.Map<OperationDto, Operation>(operationDto);
            
            repository.Add(operation);
            repository.Save();
        }

        public void Update(OperationDto operationDto)
        {
            var operation = repository.Get<Operation>(operationDto.Id);

            Mapper.Map(operationDto, operation);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete<Operation>(id);
            repository.Save();
        }
    }
}
