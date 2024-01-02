using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Validation_ECommerceApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} cannot be blank")]
        [Display(Name ="Product Code")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [Display(Name ="Product Price")]
        [Range(1, double.MaxValue, ErrorMessage = "Invalid range for {0}")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [Display(Name ="Product Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid range for {0}")]
        public int Quantity { get; set; }
    }
}
