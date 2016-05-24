using System.Collections.Generic;

namespace ManagingProducts.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
