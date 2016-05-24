using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManagingProducts.DAL.Entities;

namespace ManagingProducts.Web.ViewModel
{
    public class OperationStatisticViewModel
    {
        public string User { get; set; }

        public string TypeOfOperation { get; set; }

        public int TotalQuantity { get; set; }

        public  DateTime CreatingDate { get; set; }
    }
}