using System.Collections.Generic;
using ManagingProducts.Common.IDTO;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.Common.DTO
{
    public class ProductDto :IBaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
