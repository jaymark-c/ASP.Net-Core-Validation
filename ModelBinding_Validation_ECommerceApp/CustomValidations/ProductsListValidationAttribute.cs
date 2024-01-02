using System.ComponentModel.DataAnnotations;
using ModelBinding_Validation_ECommerceApp.Models;
using System.Reflection;

namespace ModelBinding_Validation_ECommerceApp.CustomValidations
{
    public class ProductsListValidationAttribute : ValidationAttribute
    {

        public string? DefaultMessage { get; set; } = "Order should have at least one minimum product";
        public ProductsListValidationAttribute() { }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                return new ValidationResult(DefaultMessage, new string[] { nameof(validationContext.MemberName) });
            }
            return null;
        }
    }
}
