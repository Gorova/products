using ManagingProducts.Web.ViewModel.Interfaces;

namespace ManagingProducts.Web.ViewModel
{
    public class ProductViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}