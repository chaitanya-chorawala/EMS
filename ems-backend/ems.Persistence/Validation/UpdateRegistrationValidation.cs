using ems.Common.model.Auth;
using FluentValidation;

namespace ems.Persistence.Validation
{
    public class UpdateRegistrationValidation : AbstractValidator<RegisterDto>
    {
        public UpdateRegistrationValidation()
        {
            RuleFor(x => x.DisplayName).NotEmpty().WithMessage("Require DisplayName");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Require userName");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.PhoneNo).Length(10).WithMessage("Phone number must have 10 digits");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Require Address");
        }
    }
}
