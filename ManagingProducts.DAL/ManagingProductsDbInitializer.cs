using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.DAL
{
    public class ManagingProductsDbInitializer : DropCreateDatabaseAlways<ManagingProductContext>
    {
        protected override void Seed(ManagingProductContext context)
        {
            IList<TypeOfOperation> defaultTypesOfOperation = new List<TypeOfOperation>();
            defaultTypesOfOperation.Add(new TypeOfOperation {Name = "Aarrival of goods" });
            defaultTypesOfOperation.Add(new TypeOfOperation { Name = "Shipment of goods" });

            foreach (var item in  defaultTypesOfOperation)
            {
                context.TypeOfOperations.Add(item);
            }
            base.Seed(context);
        }
    }
}
