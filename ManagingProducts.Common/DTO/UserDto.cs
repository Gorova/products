using System.Collections.Generic;
using ManagingProducts.Common.IDTO;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.Common.DTO
{
    public class UserDto : IBaseDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

       public ICollection<Operation> Operations { get; set; }
    }
}
