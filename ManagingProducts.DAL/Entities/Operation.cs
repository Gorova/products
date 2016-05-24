using System;

namespace ManagingProducts.DAL.Entities
{
    public class Operation
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime DateOfOperation { get; set; }

        public  int UserId { get; set; }

        public int ProductId { get; set; }

        public int TypeOfOperationId { get; set; }

        public virtual User User { get; set; }

        public virtual Product Product { get; set; }

        public virtual TypeOfOperation TypeOfOperation { get; set; }
    }
}
