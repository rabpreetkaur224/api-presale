using FluentValidation;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;

namespace PresaleApi
{
    public class ProductInquiryValidator : AbstractValidator<ProductInquiryRequest>
    {
        public ProductInquiryValidator()
        {

            RuleFor(x => x.FirstName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("FirstName is required.");
        }
    }
}
