using FluentValidation;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;

namespace PresaleApi
{
    public class CmsValidator : AbstractValidator<CmsRequest>
    {
        public CmsValidator()
        {

            RuleFor(x => x.CmsTitle).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("CmsTitle is required.");
        }
    }
}
