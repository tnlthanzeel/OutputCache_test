﻿using FluentValidation;
using OutputCache_test.Core.Common.Dtos;
using OutputCache_test.SharedKernal;

namespace OutputCache_test.Core.Common.Validators;

public sealed class AddressValidator : AbstractValidator<AddressDto>
{
    public AddressValidator()
    {
        RuleFor(r => r.Address)
            .MaximumLength(AppConstants.StringLengths.Address).WithMessage($"Address must be less than {AppConstants.StringLengths.Address} characters");

        RuleFor(r => r.City)
            .MaximumLength(AppConstants.StringLengths.City).WithMessage($"City must be less than {AppConstants.StringLengths.City} characters");

        RuleFor(r => r.Province)
            .MaximumLength(AppConstants.StringLengths.Province).WithMessage($"Province must be less than {AppConstants.StringLengths.Province} characters");

        RuleFor(r => r.State)
            .MaximumLength(AppConstants.StringLengths.State).WithMessage($"State must be less than {AppConstants.StringLengths.State} characters");
    }
}
