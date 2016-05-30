using System.Collections.Generic;

namespace ManagingProducts.DAL.Entities
{
    public class User 
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public virtual ICollection<Operation> Operations { get; set; } 
    }
}

