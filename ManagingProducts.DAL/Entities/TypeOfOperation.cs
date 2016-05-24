using System.Collections.Generic;

namespace ManagingProducts.DAL.Entities
{
    public class TypeOfOperation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Operation> Operations { get; set; } 
    }
}
