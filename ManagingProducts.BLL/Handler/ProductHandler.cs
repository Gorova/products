using System.Collections.Generic;
using AutoMapper;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.DAL.Entities;
using ManagingProducts.DAL.IRepositories;

namespace ManagingProducts.BLL.Handler
{
    public class ProductHandler : BaseHandler, IHandler<ProductDto>
    {
        public ProductHandler(IRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(repository.GetAll<Product>());
        }

        public ProductDto Get(int id)
        {
            return Mapper.Map<Product, ProductDto>(repository.Get<Product>(id));
        }

        public void Add(ProductDto productDto)
        {
            var product = Mapper.Map<ProductDto, Product>(productDto);
            //add product.operations
            repository.Add(product);
            repository.Save();
        }

        public void Update(ProductDto productDto)
        {
            var product = repository.Get<Product>(productDto.Id);
            //add product.operations
            Mapper.Map(productDto, product);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete<ProductDto>(id);
            ////clear product.operations
            repository.Save();
        }
    }
}
