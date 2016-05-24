using System;
using ManagingProducts.Common.IDTO;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.Common.DTO
{
    public class OperationDto : IBaseDto
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime DateOfOperation { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int TypeOfOperationId { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public TypeOfOperation TypeOfOperation { get; set; }
    }
}
