using FluentValidation;
using PresaleApi.DataBaseEntity;

namespace PresaleApi.Validator
{
    public class ProductValidator : AbstractValidator<Product>

    {
        public ProductValidator()
        {

            RuleFor(x => x.ProductName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Product Name is required.");
        }
    }
}
