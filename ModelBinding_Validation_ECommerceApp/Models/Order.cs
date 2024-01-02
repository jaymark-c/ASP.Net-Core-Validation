using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelBinding_Validation_ECommerceApp.CustomValidations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ModelBinding_Validation_ECommerceApp.Models
{
    public class Order //: IValidatableObject
    {
        [BindNever]
        [Display(Name = "Order Number")]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [Display(Name = "Order Date")]
        [MinimumDateValidation("2000-01-01", ErrorMessage = "Order date should be greater than 2000")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        [DisplayName("Invoice Price")]
        [InvoicePriceValidation]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between a valid number")]
        public double InvoicePrice { get; set; }

        [Required(ErrorMessage = "{0} cannot be blank")]
        //[MinLength(1, ErrorMessage = "Products needs at least 1")]
        [ProductsListValidation]
        public List<Product> Products { get; set; } = new List<Product>();


        /*
         * #only need if we do not have a custom validation class, you only want it to be used in the same class :)
         * 
         * public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var totalPrice = Products.Sum(prod => prod!.Price * prod.Quantity);

            if(totalPrice != InvoicePrice)
            {
                //yield return new ValidationResult("Product is not equal to total price\n", new[] { nameof(Products) });
                yield return new ValidationResult("InvoicePrice is not equal to total price\nProduct Price should be between valid number\nProduct Quantity should be between valid number\n", new[] { nameof(InvoicePrice) });
            }
        }*/

    }
}
