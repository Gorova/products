using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.Web.ViewModel
{
    public class ProductStatisticViewModel
    {
        public string Product { get; set; }

        public int Price { get; set; }

        public int TotalQuantity { get; set; }

        public int TotalCost { get; set; }
    }
}