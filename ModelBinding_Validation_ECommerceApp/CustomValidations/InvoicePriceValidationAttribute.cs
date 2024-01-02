using System.ComponentModel.DataAnnotations;
using ModelBinding_Validation_ECommerceApp.Models;
using System.Reflection;

namespace ModelBinding_Validation_ECommerceApp.CustomValidations
{
    public class InvoicePriceValidationAttribute : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "Invoice Price should be equal to the total cost (i.e {0}) in the order";
        
        public InvoicePriceValidationAttribute() { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //check if value of "InvoicePrice" has value
            if (value != null)
            {
                //get "Products" property reference, using reflection
                PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
                if (OtherProperty != null)
                {
                    //get value of "Products" property of the current object of "Order" class
                    List<Product> products = (List<Product>)OtherProperty.GetValue(validationContext.ObjectInstance)!; //! specifies that the returned value will not be null

                    double totalPrice = 0;
                    double actualPrice = (double)value;//Invoice Price property

                    foreach(Product product in products)
                    {
                        totalPrice += product.Price;
                    }
                    
                    if(totalPrice > 0)
                    {
                        if(totalPrice != actualPrice)
                        {
                            //return model error
                            return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, totalPrice), new string[] { nameof(validationContext.MemberName) });
                        }
                    }
                    else
                    {
                        return new ValidationResult("No Products found to Validate invoice price", new string[] { nameof(validationContext.MemberName) });
                    }
                    //No error
                    return ValidationResult.Success;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
