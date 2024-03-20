using ems.Common.model.Auth;
using FluentValidation;

namespace ems.Persistence.Validation;

public class RegistrationValidator : AbstractValidator<Register>
{
    public RegistrationValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Require firstName");
        RuleFor(x => x.MiddleName).NotEmpty().WithMessage("Require middleName");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Require lastName");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Require userName");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
        RuleFor(x => x.PhoneNo).Length(10).WithMessage("Phone number must have 10 digits");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Require Address");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Required")
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&amp;])[A-Za-z\\d@$!%*?&amp;]{8,50}$")
            .WithMessage("Password should be minimum 8 character, one upper letter and special character");
    }
}
