using FluentValidation;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models.Request;

namespace PresaleApi.Validator
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {

            RuleFor(x => x.CategoryName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Category Name is required.");
        }
    }
}
