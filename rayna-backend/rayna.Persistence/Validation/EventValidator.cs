using rayna.Common.model.Rayna;
using FluentValidation;

namespace rayna.Persistence.Validation;

public class EventValidator : AbstractValidator<AddEventDto>
{
    public EventValidator()
    {
        RuleFor(x => x.EmailId).EmailAddress().WithMessage("EmailId is not valid");
        RuleFor(x => x.MobileNo).Length(10).WithMessage("Mobile number must have 10 digits");
        RuleFor(x => x.PhoneNo).Length(7).WithMessage("Phone number must have 7 digits");
    }
}
