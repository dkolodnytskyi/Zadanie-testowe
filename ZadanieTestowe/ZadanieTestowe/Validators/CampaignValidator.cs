using FluentValidation;
using ZadanieTestowe.Dtos;

namespace ZadanieTestowe.Validators;

public class CampaignValidator : AbstractValidator<CampaignDto>
{
    public CampaignValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Campaign name is required.")
            .MaximumLength(100).WithMessage("Campaign name cannot exceed 100 characters.");

        RuleFor(x => x.KeywordsIds)
            .NotNull().WithMessage("Keywords are required.")
            .Must(x => x != null && x.Length > 0).WithMessage("At least one keyword must be selected.");

        RuleFor(x => x.BidAmount)
            .GreaterThan(0).WithMessage("Bid amount must be greater than zero.");

        RuleFor(x => x.CampaignFund)
            .GreaterThan(0).WithMessage("Campaign fund must be greater than zero.");

        RuleFor(x => x.TownId)
            .NotEqual(Guid.Empty).WithMessage("Town must be selected.");

        RuleFor(x => x.Radius)
            .GreaterThan(0).WithMessage("Radius must be greater than zero.");
    }
}