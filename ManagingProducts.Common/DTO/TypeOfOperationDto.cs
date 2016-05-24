using System.Collections.Generic;
using ManagingProducts.Common.IDTO;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.Common.DTO
{
    public class TypeOfOperationDto : IBaseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }
}
