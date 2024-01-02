using System.ComponentModel.DataAnnotations;

namespace ModelBinding_Validation_ECommerceApp.CustomValidations
{
    public class MinimumDateValidationAttribute : ValidationAttribute
    {
        public string DefaultMessage { get; set; } = "Order date should be greater than {0}";
        public DateTime MinimumDate { get; set; }
        public MinimumDateValidationAttribute(string minimumDateString)
        {
            MinimumDate = Convert.ToDateTime(minimumDateString);
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var orderDate = (DateTime?)value;

                if(orderDate > MinimumDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultMessage, MinimumDate.ToString("yyy-mm-dd")), new string[] { nameof(validationContext.MemberName)});
                }
                return ValidationResult.Success;
            }

            return null;
        }
    }
}
