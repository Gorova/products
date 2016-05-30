using ManagingProducts.DAL.Entities;

namespace ManagingProducts.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ManagingProducts.DAL.ManagingProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ManagingProducts.DAL.ManagingProductContext";
        }

        protected override void Seed(ManagingProducts.DAL.ManagingProductContext context)
        {
            context.TypeOfOperations.AddOrUpdate(x => x.Id,
                new TypeOfOperation() { Id = 1, Name = "Arrival of goods" },
                new TypeOfOperation() { Id = 2, Name = "Goods consumption" });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
