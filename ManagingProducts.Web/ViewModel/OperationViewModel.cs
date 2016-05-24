using System;
using ManagingProducts.DAL.Entities;
using ManagingProducts.Web.ViewModel.Interfaces;

namespace ManagingProducts.Web.ViewModel
{
    public class OperationViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public DateTime DateOfOperation { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int TypeOfOperationId { get; set; }

        public User User { get; set; }

        public TypeOfOperation TypeOfOperation { get; set; }

        public Product Product { get; set; }
    }
}