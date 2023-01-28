using FluentValidation;
using PresaleApi.Models;

namespace PresaleApi
{
    public class ImageDumpValidator : AbstractValidator<ImageDumpRequest>
    {
        public ImageDumpValidator()
        {

            RuleFor(x => x.ImageFileName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("ImageFileName is required.");
        }
    }
}
