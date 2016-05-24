using ManagingProducts.Web.ViewModel.Interfaces;

namespace ManagingProducts.Web.ViewModel
{
    public class UserViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}