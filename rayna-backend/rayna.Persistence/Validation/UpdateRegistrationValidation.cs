using rayna.Common.model.Auth;
using FluentValidation;

namespace rayna.Persistence.Validation
{
    public class UpdateRegistrationValidation : AbstractValidator<RegisterDto>
    {
        public UpdateRegistrationValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Require firstName");
            RuleFor(x => x.MiddleName).NotEmpty().WithMessage("Require middleName");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Require lastName");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Require userName");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.PhoneNo).Length(10).WithMessage("Phone number must have 10 digits");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Require Address");
        }
    }
}
