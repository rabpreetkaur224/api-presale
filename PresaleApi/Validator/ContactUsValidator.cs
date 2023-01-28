using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi
{
    public class ContactUsValidator : AbstractValidator<ContactUsRequest>
    {
        public ContactUsValidator()
        {

            RuleFor(x => x.Name).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("ContactUs Name is required.");
        }
    }
}
