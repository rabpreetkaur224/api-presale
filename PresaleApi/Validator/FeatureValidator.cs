using FluentValidation;
using PresaleApi.Models;
using System;

namespace PresaleApi.Validation
{
    public class FeatureValidator : AbstractValidator<FeatureRequest>
    {
        public FeatureValidator()
        {
           
            RuleFor(x => x.FeatureName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("Feature Name is required.");
        }
    }
}
