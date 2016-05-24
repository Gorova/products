using System.Data.Entity;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.DAL
{
    public class ManagingProductContext : DbContext
    {
        public ManagingProductContext()
            : base("ManagingProducts")
        {
        }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<TypeOfOperation> TypeOfOperations { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .HasRequired<User>(i => i.User)
                .WithMany(i => i.Operations)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<Operation>()
                .HasRequired<Product>(i => i.Product)
                .WithMany(i => i.Operations)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Operation>()
                .HasRequired<TypeOfOperation>(i => i.TypeOfOperation)
                .WithMany(i => i.Operations)
                .HasForeignKey(i => i.TypeOfOperationId);
        }
    }
}

