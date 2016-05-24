using System.ComponentModel.DataAnnotations;
using ManagingProducts.Web.ViewModel.Interfaces;

namespace ManagingProducts.Web.ViewModel
{
    public class ProductViewModel : IBaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required '{0}' field")]
        [StringLength(50, ErrorMessage = "Max length of field '{0}' - 50 symbols")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required '{0}' field")]
        [Range(1.0, 1000.0, ErrorMessage = "The field '{0}' must be min 1 to 1000.00 and not be a negative number")]
        public int Price { get; set; }
    }
}