using System;

namespace ManagingProducts.Web.ViewModel
{
    public class OperationStatisticViewModel
    {
        public string User { get; set; }

        public string TypeOfOperation { get; set; }
       
        public int Quantity { get; set; }

        public  DateTime CreatingDate { get; set; }
    }
}