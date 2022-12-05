using FluentValidation;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using System;

namespace PresaleApi.Validator 
{
    public class NearByValidator : AbstractValidator<NearBy>
    {
        public NearByValidator()
        {

            RuleFor(x => x.NearByName).Length(0, 10).NotEmpty().NotNull().OverridePropertyName("NearBy Name is required.");
        }

        
    }
}
