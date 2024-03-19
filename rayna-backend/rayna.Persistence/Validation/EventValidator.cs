using rayna.Common.model.Rayna;
using FluentValidation;

namespace rayna.Persistence.Validation;

public class EventValidator : AbstractValidator<AddEventDto>
{
    public EventValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Provide Name");
        RuleFor(x => x.SupplierId).NotEmpty().WithMessage("Provide SupplierId");
        RuleFor(x => x.CountryId).NotEmpty().WithMessage("Provide CountryId");
        RuleFor(x => x.StateId).NotEmpty().WithMessage("Provide StateId");
        RuleFor(x => x.CityId).NotEmpty().WithMessage("Provide CityId");
        RuleFor(x => x.InventoryId).NotEmpty().WithMessage("Provide InventoryId");
        RuleFor(x => x.TypeId).NotEmpty().WithMessage("Provide TypeId");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Provide CategoryId");
        RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Provide CurrencyId");
        RuleFor(x => x.FromDateTime).NotEmpty().WithMessage("Provide FromDateTime");
        RuleFor(x => x.ToDateTime).NotEmpty().WithMessage("Provide FromDateTime");
    }
}
